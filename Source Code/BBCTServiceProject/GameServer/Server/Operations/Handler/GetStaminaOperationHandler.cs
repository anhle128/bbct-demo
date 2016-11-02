using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using Photon.SocketServer;
using System;

namespace GameServer.Server.Operations.Handler
{
    public class GetStaminaOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var responseData = CommonFunc.CheckStaminaAndCooldownTime(player);

            return new OperationResponse()
                {
                    OperationCode = operationRequest.OperationCode,
                    DebugMessage = "GetStaminaOperationHandler done!",
                    Parameters = responseData.Serialize(),
                    ReturnCode = (short)ReturnCode.OK
                };
        }
    }
}
