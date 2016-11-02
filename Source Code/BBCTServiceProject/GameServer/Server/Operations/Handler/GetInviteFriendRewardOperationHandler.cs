using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;
using System.Collections.Generic;
using MongoDBModel.Enum;

namespace GameServer.Server.Operations.Handler
{
    public class GetInviteFriendRewardOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            IndexRequestData requestData = new IndexRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MUserInfo userInfo = MongoController.UserDb.Info.GetData(player.cacheData.id);

            if (userInfo == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AccountDoNotExist);

            if (userInfo.index_invite_rewarded == null)
                userInfo.index_invite_rewarded = new List<int>();

            if (userInfo.index_invite_rewarded.Contains(requestData.index))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDone);

            InviteFriendConfig[] mConfigs = StaticDatabase.entities.configs.inviteFriendConfigs;
            if (mConfigs == null || requestData.index >= mConfigs.Length)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            InviteFriendConfig mConfig = mConfigs[requestData.index];

            if (userInfo.invite_friend < mConfig.require)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            //Change Data and response
            userInfo.index_invite_rewarded.Add(requestData.index);
            MongoController.UserDb.Info.Update(userInfo);

            List<RewardItem> listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, CommonFunc.ConvertToSubReward(mConfig.rewards),ReasonActionGold.RewardInvitedFriend);

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
                DebugMessage = "GetInviteFriendRewardOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
