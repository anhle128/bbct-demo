using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardCuuCuuTriTonOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            MUserCuuCuuTriTon userCuuCuuTriTon = MongoController.UserDb.CuuCuuTriTon.GetData(player.cacheData.id);
            if (userCuuCuuTriTon == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (userCuuCuuTriTon.hash_code_time == CommonFunc.GetHashCodeTime())
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDone);

            userCuuCuuTriTon.hash_code_time = CommonFunc.GetHashCodeTime();
            MongoController.UserDb.CuuCuuTriTon.Update(userCuuCuuTriTon);

            List<RewardItem> rewards =
                MongoController.UserDb.UpdateReward
                (
                    player.cacheData,
                    CommonFunc.ConvertToSubReward(StaticDatabase.entities.configs.cuuCuuTriTonConfig.rewards),
                    ReasonActionGold.RewardCuuCuuTriTon
                );

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
