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
    public class GetVipRewardOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            VipRewardRequestData requestData = new VipRewardRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MUserInfo userInfo = MongoController.UserDb.Info.GetData(player.cacheData.id);

            if (userInfo == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.Error);

            if (userInfo.vip_rewarded == null)
                userInfo.vip_rewarded = new List<int>();


            if (userInfo.vip < requestData.vip || userInfo.vip_rewarded.Any(a => a == requestData.vip))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // process
            userInfo.vip_rewarded.Add(requestData.vip);
            MongoController.UserDb.Info.UpdateVipRewarded(userInfo);

            MVipRewardConfig vipReward = MongoController.ConfigDb.VipReward.GetData(requestData.vip);

            List<RewardItem> listRewardResult = MongoController.UserDb.UpdateReward
            (
                userInfo: player.cacheData,
                listReward: vipReward.rewards,
                resource: ReasonActionGold.RewardVip
            );

            // responseData

            RewardResponseData response = new RewardResponseData()
            {
                rewards = listRewardResult,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                user_ruby = player.cacheData.ruby
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetVipRewardOperationHandler done!",
                Parameters = response.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
