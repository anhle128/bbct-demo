using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Server.Operations.Core;
using GameServer.Database.Controller;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class SetTutorialOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            TutorialRequestData requestData = new TutorialRequestData();
            requestData.Deserialize(operationRequest.Parameters);

                MongoController.UserDb.Info.UpdateTutorial(player.cacheData.info._id, requestData.tutorial);

                return new OperationResponse()
                {
                    OperationCode = operationRequest.OperationCode,
                    DebugMessage = "SetTutorialOperationHandler done!",
                    Parameters = null,
                    ReturnCode = (short)ReturnCode.OK
                };

        }
    }
}
