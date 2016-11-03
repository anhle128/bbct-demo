using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class RemoveFriendRewardOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            ActionPlayerRequestData requestData = new ActionPlayerRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            string otherUserid = (requestData.userid);

            if (player.cacheData.info._id.Equals(otherUserid))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // kiểm tra đã add friend hay chưa
            var mUFriend = MongoController.UserDb.Friend.GetData(player.cacheData.info._id, otherUserid);
            if (mUFriend == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AccountDoNotExist);

            // response
            MongoController.UserDb.Friend.Delete(mUFriend._id);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}
