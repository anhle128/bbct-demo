using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class DoXucXacDoPhuongOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            DoXucXacDoPhuongRequestData requestData = new DoXucXacDoPhuongRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            Configs mConfig = StaticDatabase.entities.configs;
            if (mConfig.goldDoPhuongConfig > requestData.goldBet || mConfig.maxGoldDoPhuongConfig < requestData.goldBet)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

            if (requestData.goldBet > player.cacheData.info.gold)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

            int count = MongoController.LogSubDB.DoPhuong.Count(player.cacheData.info._id);

            int maxTimes = StaticDatabase.entities.configs.GetVipConfig(player.cacheData.info.vip).doPhuongTimes;
            //CommonLog.Instance.PrintLog("Max Do Phuong " + maxTimes);
            if (count >= maxTimes)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxDoPhuongTimes);
            }

            int rnd1 = CommonFunc.RandomNumber(1, 6);
            int rnd2 = CommonFunc.RandomNumber(1, 6);
            int rnd3 = CommonFunc.RandomNumber(1, 6);
            int totalXucXac = rnd1 + rnd2 + rnd3;

            bool isWin = false;
            if (totalXucXac % 2 == 0)
            {
                if (requestData.isChan)
                {
                    isWin = true;
                }
            }
            else
            {
                if (!requestData.isChan)
                {
                    isWin = true;
                }
            }

            if (isWin)
            {
                List<SubRewardItem> listReward = new List<SubRewardItem>(1)
                {
                    new SubRewardItem()
                    {
                        type_reward = (int)TypeReward.Gold,
                        quantity = requestData.goldBet
                    }
                };

                MongoController.UserDb.UpdateReward(player.cacheData, listReward, ReasonActionGold.ThangDoPhuong);
            }
            else
            {
                player.cacheData.info.gold -= requestData.goldBet;
                MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.ThuaDoPhuong, requestData.goldBet);
            }

            MDoPhuongLog log = new MDoPhuongLog()
            {
                user_id = player.cacheData.info._id,
                hash_code_time = CommonFunc.GetHashCodeTime(),
                betGold = requestData.goldBet,
                isWin = isWin
            };
            MongoController.LogSubDB.DoPhuong.Create(log);

            DoXucXacDoPhuongResponseData responseData = new DoXucXacDoPhuongResponseData()
            {
                goldReward = requestData.goldBet,
                isWin = isWin,
                xucXac1 = rnd1,
                xucXac2 = rnd2,
                xucXac3 = rnd3,
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}
