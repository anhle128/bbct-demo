using GameServer.Common.SerializeData.RequestData;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class PowerupCharOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            PowerupCharRequestData request = new PowerupCharRequestData();
            request.Deserialize(operationRequest.Parameters);



            throw new System.NotImplementedException();
        }
    }
}
