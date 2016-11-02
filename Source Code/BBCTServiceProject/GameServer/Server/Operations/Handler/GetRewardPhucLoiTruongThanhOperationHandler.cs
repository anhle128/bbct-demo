
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
    public class GetRewardPhucLoiTruongThanhOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            IndexRequestData requestData = new IndexRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MPhucLoiTruongThanhLog log = MongoController.LogSubDB.SkPhucLoiTruongThanh.GetData(player.cacheData.id);
            if (log == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            if (requestData.index > StaticDatabase.entities.configs.phucLoiTruongThanhConfig.rewards.Count - 1)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            LevelReward levelReward =
                StaticDatabase.entities.configs.phucLoiTruongThanhConfig.rewards[requestData.index];

            if (player.cacheData.level < levelReward.level)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

            if (log.index_received == null)
                log.index_received = new List<int>();

            if (log.index_received.Any(a => a == requestData.index))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDone);

            log.index_received.Add(requestData.index);
            List<RewardItem> rewards = MongoController.UserDb.UpdateReward(player.cacheData,
                CommonFunc.ConvertToSubReward(levelReward.rewards), ReasonActionGold.RewardPhucLoiTruongThanh);

            if (log.index_received.Count == StaticDatabase.entities.configs.phucLoiTruongThanhConfig.rewards.Count)
            {
                log.status = Status.Deactivate;
                MongoController.LogSubDB.SkPhucLoiTruongThanh.Update(log);
            }
            else
            {
                MongoController.LogSubDB.SkPhucLoiTruongThanh.UpdateIndexsReceived(log);

            }

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = rewards,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                user_ruby = player.cacheData.ruby,
                user_level = player.cacheData.level,
                user_exp = player.cacheData.exp
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
