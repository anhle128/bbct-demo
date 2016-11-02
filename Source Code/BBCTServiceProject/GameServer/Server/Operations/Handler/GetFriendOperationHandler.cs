using DynamicDBModel.Models;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetFriendOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {

            // process
            List<MUserFriend> listDataFriends = MongoController.UserDb.Friend.GetDatas(player.cacheData.id);

            List<MUserInfo> listFriendInfos = listDataFriends.Select
            (
                dataFriend => MongoController.UserDb.Info.GetData(dataFriend.user_id_friend)
            ).ToList();

            List<UserFriend> listResultFriends = listFriendInfos.Select
            (
                MongoController.GetUserFriendFromUserInfo
            ).ToList();

            if (listResultFriends == null)
                listResultFriends = new List<UserFriend>();
            else
                listResultFriends = listResultFriends.Where(a => a != null).ToList();
            // response
            FriendResponseData responseData = new FriendResponseData();
            responseData.friends = listResultFriends;

            var operationResponse = new OperationResponse();
            operationResponse.OperationCode = operationRequest.OperationCode;
            operationResponse.DebugMessage = "GetFriendOperationHandler done!";
            operationResponse.Parameters = responseData.Serialize();
            operationResponse.ReturnCode = (short)ReturnCode.OK;

            return operationResponse;
        }
    }
}
