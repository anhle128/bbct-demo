using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class SignOutOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            player.SignOut();
            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}
