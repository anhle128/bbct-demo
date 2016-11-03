
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
    public class GetRewardStarMapOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            GetRewardStarMapRequestData requestData = new GetRewardStarMapRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            //CommonLog.Instance.PrintLog(JsonMapper.ToJson(requestData));

            StarReward[] starReward = StaticDatabase.entities.starRewards;

            if (requestData.index_reward > starReward.Length - 1)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            double totalStar = MongoController.UserDb.Stage.SumStar(player.cacheData.info._id, requestData.index_map, requestData.level);
            if (starReward[requestData.index_reward].starRequire > totalStar)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

            MUserStarReward userStarReward = MongoController.UserDb.StarReward.GetData
            (
                player.cacheData.info._id,
                requestData.index_map,
                requestData.level
            );

            if (userStarReward == null)
            {
                userStarReward = new MUserStarReward()
                {
                    user_id = player.cacheData.info._id,
                    map_index = requestData.index_map,
                    level = requestData.level,
                    index_reveived = new List<int>()
                    {
                        requestData.index_reward
                    }
                };
                MongoController.UserDb.StarReward.Create(userStarReward);
            }
            else
            {
                if (userStarReward.index_reveived.Any(a => a == requestData.index_reward))
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDone);

                userStarReward.index_reveived.Add(requestData.index_reward);
                MongoController.UserDb.StarReward.UpdateReveived(userStarReward);
            }

            List<RewardItem> rewards =
                MongoController.UserDb.UpdateReward
                (
                    player.cacheData,
                    CommonFunc.ConvertToSubReward(starReward[requestData.index_reward].rewards),
                    ReasonActionGold.RewardStarMap
                );

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = rewards,
                user_gold = player.cacheData.info.gold,
                user_silver = player.cacheData.info.silver,
                user_ruby = player.cacheData.info.ruby,
                user_level = player.cacheData.info.level,
                user_exp = player.cacheData.info.exp
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetRewardStarMapOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}
