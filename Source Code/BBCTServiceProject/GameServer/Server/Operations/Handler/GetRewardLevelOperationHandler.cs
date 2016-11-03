
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
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardLevelOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            IndexRequestData requestData = new IndexRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MUserInfo userInfo = MongoController.UserDb.Info.GetData(player.cacheData.info._id);

            if (userInfo.index_level_rewarded == null)
                userInfo.index_level_rewarded = new List<int>();

            if (userInfo.index_level_rewarded.Any(a => a == requestData.index))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDone);

            if (requestData.index >= StaticDatabase.entities.configs.levelRewardConfig.Length)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            LevelReward levelReward = StaticDatabase.entities.configs.levelRewardConfig[requestData.index];

            if (userInfo.level < levelReward.level)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            userInfo.index_level_rewarded.Add(requestData.index);
            MongoController.UserDb.Info.Update(userInfo);

            List<RewardItem> listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, CommonFunc.ConvertToSubReward(levelReward.rewards), ReasonActionGold.RewardLevel);

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listRewardResult,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                user_level = player.cacheData.level,
                user_exp = player.cacheData.exp,
                user_ruby = player.cacheData.ruby
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetRewardLevelOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
