
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardPointVongQuayMayManOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            IndexRequestData requestData = new IndexRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MSKVongQuayMayManConfig config = MongoController.ConfigDb.SkVongQuayMayMan.GetData();
            if (config == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            MSKVongQuayMayManLog log = MongoController.LogSubDB.SkVongQuayMayMan.GetData(player.cacheData.id, config._id);

            if (log == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (log.index_point_received == null)
                log.index_point_received = new List<int>();

            if (log.index_point_received.Any(a => a == requestData.index))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDone);

            if (requestData.index > config.point_rewards.Count - 1)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (log.total_point < config.point_rewards[requestData.index].point_require)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

            log.index_point_received.Add(requestData.index);
            MongoController.LogSubDB.SkVongQuayMayMan.Update(log);

            List<RewardItem> listReward = MongoController.UserDb.UpdateReward(player.cacheData,
                config.point_rewards[requestData.index].rewards, ReasonActionGold.RewardPointSkVongQuayMayMan);


            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listReward,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                user_level = player.cacheData.level,
                user_exp = player.cacheData.exp,
                user_ruby = player.cacheData.ruby
            };

            // response
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
