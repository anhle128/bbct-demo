using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database.Controller;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardRuongBauOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ActionRuongBauRequestData requestData = new ActionRuongBauRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MUserItem userRuongBau = player.cacheData.listUserItem.FirstOrDefault(a => a._id.ToString() == requestData.id);

            if (userRuongBau == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (requestData.index_reward > userRuongBau.rewards.Count - 1)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (userRuongBau.rewards == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            List<SubRewardItem> listReward = new List<SubRewardItem>(1)
            {
                userRuongBau.rewards[requestData.index_reward]
            };

            player.cacheData.DeleteUserItem(userRuongBau);

            List<RewardItem> rewardResult = MongoController.UserDb.UpdateReward(player.cacheData, listReward, ReasonActionGold.RewardRuongBau);

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = rewardResult,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                user_level = player.cacheData.level,
                user_exp = player.cacheData.exp,
                user_ruby = player.cacheData.ruby
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetRewardRotDoOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}
