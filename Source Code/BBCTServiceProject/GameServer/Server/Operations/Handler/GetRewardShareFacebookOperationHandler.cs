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
    public class GetRewardShareFacebookOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MUserInfo userInfo = MongoController.UserDb.Info.GetData(player.cacheData.info._id);

            if (userInfo.hash_code_time_send_facebook == CommonFunc.GetHashCodeTime())
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDone);

            userInfo.hash_code_time_send_facebook = CommonFunc.GetHashCodeTime();

            List<RewardItem> listReward =
                MongoController.UserDb.UpdateReward(player.cacheData, CommonFunc.ConvertToSubReward(StaticDatabase.entities.configs.shareFacebookRewards), ReasonActionGold.RewardSharedFacebook);

            MongoController.UserDb.Info.Update(userInfo);


            RewardResponseData responseData = new RewardResponseData();
            responseData.rewards = listReward;
            responseData.user_gold = player.cacheData.info.gold;
            responseData.user_silver = player.cacheData.info.silver;
            responseData.user_exp = player.cacheData.info.exp;
            responseData.user_level = player.cacheData.info.level;
            responseData.user_ruby = player.cacheData.info.ruby;


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
