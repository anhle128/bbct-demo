using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Server.Operations.Core;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class InviteFriendOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            UpdateQuantityRequestData requestData = new UpdateQuantityRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MUserInfo userInfo = MongoController.UserDb.Info.GetData(player.cacheData.id);

            if (userInfo == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AccountDoNotExist);

            //Change Data and response
            MongoController.UserDb.Info.UpdateInviteFriend(userInfo._id, requestData.quantity);

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "InviteFriendOperationHandler done!",
                Parameters = null,
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
