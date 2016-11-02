using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class UpStarEquipOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            UpStarEquipRequestData requestData = new UpStarEquipRequestData();
            requestData.Deserialize(operationRequest.Parameters);



            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "UpStarEquipOperationHandler done!",
                Parameters = null,
                ReturnCode = (short)ReturnCode.OK
            };


        }
    }
}
