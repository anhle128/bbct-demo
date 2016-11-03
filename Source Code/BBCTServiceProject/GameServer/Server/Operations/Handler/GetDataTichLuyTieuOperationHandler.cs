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
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataTichLuyTieuOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MSKTichLuyTieuConfig sk = MongoController.ConfigDb.SkTichluyTieu.GetData();

            if (sk == null)
            {
                SuKienInfo.SetDeactiveSuKien(TypeSuKien.TichLuyTieu);
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);
            }

            double totalUsedGold = MongoController.LogDb.ActionGold.GetTotalUsedGold(player.cacheData.info._id,
               sk.start, sk.end);

            SkTichLuyTieuResponseData responseData = new SkTichLuyTieuResponseData();
            responseData.total_used_gold = totalUsedGold;
            responseData.end_time = sk.end;
            responseData.gold_rewards = new List<GoldReward>();

            MSKTichLuyTieuLog log = MongoController.LogSubDB.SkTichLuyTieu.GetData
            (
                player.cacheData.info._id,
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
    }
}
