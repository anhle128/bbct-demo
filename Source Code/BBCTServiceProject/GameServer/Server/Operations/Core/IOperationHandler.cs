using Photon.SocketServer;

namespace GameServer.Server.Operations.Core
{
    public interface IOperationHandler
    {
        OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller);
    }
}
