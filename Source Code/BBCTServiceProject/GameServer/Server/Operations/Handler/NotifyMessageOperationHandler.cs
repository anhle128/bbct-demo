using GameServer.Common.Enum;
using GameServer.Common.SerializeData.EventData;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class NotifyMessageOperationHandler : IOperationHandler
    {
        //Guck
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            NotifyMessageRequestData requestData = new NotifyMessageRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            NotifyMessageEventData mData = new NotifyMessageEventData()
            {
                message = requestData.message
            };

            Dictionary<byte, object> subParam = new Dictionary<byte, object>();
            subParam.Add(1, requestData.message);
            GameController.Instance.FireEvent(player.peer, new SendParameters(),
                (byte)EventCode.NotifyMessage, new Dictionary<byte, object>(), subParam);
            return null;
        }
    }
}
