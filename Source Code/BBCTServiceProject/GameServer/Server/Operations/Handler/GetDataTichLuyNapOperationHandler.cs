using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataTichLuyNapOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MSKTichLuyNapConfig sk = MongoController.ConfigDb.SkTichluyNap.GetData();

            if (sk == null)
            {
                SuKienInfo.SetDeactiveSuKien(TypeSuKien.TichLuyNap);
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }


            SkTichLuyNapResponseData responseData = new SkTichLuyNapResponseData();
            responseData.type = sk.type;
            responseData.end_time = sk.end;
            responseData.gold_rewards = new List<GoldReward>();

            if (sk.type == TypeSuKienTichLuyNap.RangeTime)
            {
                double totalTransGold = MongoController.LogDb.Trans.GetTotalRuby
                (
                    player.cacheData.id,
                    sk.start, DateTime.Now
                );

                responseData.total_trans_gold = totalTransGold;

                MSKTichLuyNapLog log = MongoController.LogSubDB.SkTichLuyNap.GetData
               (
                   player.cacheData.id,
                   sk._id.ToString()
               );

                if (log == null)
                {
                    foreach (MGoldReward t in sk.gold_rewards)
                    {
                        GoldReward gold = new GoldReward();
                        gold.goldRequire = t.gold_require;
                        gold.rewards = t.rewards;
                        gold.received = false;
                        responseData.gold_rewards.Add(gold);
                    }
                }
                else
                {
                    for (int i = 0; i < sk.gold_rewards.Count; i++)
                    {
                        GoldReward gold = new GoldReward();
                        gold.goldRequire = sk.gold_rewards[i].gold_require;
                        gold.rewards = sk.gold_rewards[i].rewards;
                        gold.received = log.index_received.Any(a => a == i);
                        responseData.gold_rewards.Add(gold);
                    }
                }

                return new OperationResponse()
                {
                    OperationCode = operationRequest.OperationCode,
                    DebugMessage = "OperationResponse done!",
                    Parameters = responseData.Serialize(),
                    ReturnCode = (short)ReturnCode.OK
                };
            }
            else
            {
                MSKTichLuyNapLog log = MongoController.LogSubDB.SkTichLuyNap.GetData
                (
                   player.cacheData.id,
                   sk._id.ToString(),
                   CommonFunc.GetHashCodeTime()
                );
                double totalTransGold = MongoController.LogDb.Trans.GetTotalRuby
                (
                    player.cacheData.id,
                    CommonFunc.GetStartTimeInDay(),
                    CommonFunc.GetEndTimeInDay()
                );
                responseData.total_trans_gold = totalTransGold;
                responseData.type = sk.type;

                if (log == null)
                {
                    foreach (MGoldReward t in sk.gold_rewards)
                    {
                        GoldReward gold = new GoldReward();
                        gold.goldRequire = t.gold_require;
                        gold.rewards = t.rewards;
                        gold.received = false;
                        responseData.gold_rewards.Add(gold);
                    }
                }
                else
                {
                    for (int i = 0; i < sk.gold_rewards.Count; i++)
                    {
                        GoldReward gold = new GoldReward();
                        gold.goldRequire = sk.gold_rewards[i].gold_require;
                        gold.rewards = sk.gold_rewards[i].rewards;
                        gold.received = log.index_received.Any(a => a == i);
                        responseData.gold_rewards.Add(gold);
                    }
                }

                return new OperationResponse()
                {
                    OperationCode = operationRequest.OperationCode,
                    DebugMessage = "OperationResponse done!",
                    Parameters = responseData.Serialize(),
                    ReturnCode = (short)ReturnCode.OK
                };
            }
        }
    }
}
