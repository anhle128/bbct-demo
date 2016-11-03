using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class RefeshMailOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            MailResponseData responseData = new MailResponseData()
            {
                system_mails = MongoController.MailDb.GetSystemMails(),
                user_mails = MongoController.UserDb.GetListUserEmail(player.cacheData.info._id)
            };

            // responseData
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "RefeshMailOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
