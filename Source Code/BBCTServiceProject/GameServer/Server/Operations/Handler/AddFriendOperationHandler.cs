using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class AddFriendOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ActionPlayerRequestData requestData = new ActionPlayerRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            string otherUserId = (requestData.userid);

            if (player.cacheData.info._id.Equals(otherUserId))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // kiểm tra tổng số lượng friend
            int countTotalFriend =
                MongoController.UserDb.Friend.Count(player.cacheData.info._id);

            if (countTotalFriend >= StaticDatabase.entities.configs.friendConfig.numberFriendCanAdd)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxFriends);



            // kiểm tra đã add friend hay chưa
            bool checkExistFriend =
                MongoController.UserDb.Friend.CheckExistFriend(player.cacheData.info._id, otherUserId);

            if (checkExistFriend)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.FriendExist);

            // process
            MUserFriend userFriend = new MUserFriend();
            userFriend.user_id_friend = (requestData.userid);
            userFriend.user_id = player.cacheData.info._id;
            MongoController.UserDb.Friend.Create(userFriend);

            // response
            MUserInfo userInfo = MongoController.UserDb.Info.GetData(otherUserId);
            AddFriendResponseData responseData = new AddFriendResponseData()
            {
                new_friend = MongoController.GetUserFriendFromUserInfo(userInfo)
            };
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "AddFriendOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}
