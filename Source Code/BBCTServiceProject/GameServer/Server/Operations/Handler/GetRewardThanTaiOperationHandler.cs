using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardThanTaiOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MSKThanTaiConfig config = MongoController.ConfigDb.SkThanTai.GetData();
            if (config == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            MSKThanTaiLog log = MongoController.LogSubDB.SkThanTai.GetData(player.cacheData.info._id,
                config._id.ToString());

            bool isCreate = false;
            if (log == null)
            {
                isCreate = true;
                log = new MSKThanTaiLog()
                {
                    user_id = player.cacheData.info._id,
                    sk_kien_id = config._id,
                    current_index_reward = 0
                };
            }

            if (log.current_index_reward > config.rewards.Length - 1)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            MThanTaiReward thanTaiReward = config.rewards[log.current_index_reward];
            int goldRequire = thanTaiReward.gold_require;
            if (player.cacheData.gold < goldRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

            player.cacheData.gold -= goldRequire;

            int goldReward = CommonFunc.RandomNumber(thanTaiReward.min_gold_reward, thanTaiReward.max_gold_reward);

            log.current_index_reward++;
            if (isCreate)
                MongoController.LogSubDB.SkThanTai.Create(log);
            else
                MongoController.LogSubDB.SkThanTai.Update(log);

            List<SubRewardItem> listReward = new List<SubRewardItem>(1)
            {
                new SubRewardItem()
                {
                    type_reward = (int)TypeReward.Gold,
                    quantity = goldReward
                }
            };

            MongoController.UserDb.UpdateReward(player.cacheData, listReward, ReasonActionGold.RewardThanTai);

            SkThanTaiRewardResponseData responseData = new SkThanTaiRewardResponseData()
            {
                user_gold = player.cacheData.gold,
                gold_reward = goldReward
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetRewardThanTaiOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
