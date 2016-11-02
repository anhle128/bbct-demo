using GameServer.Common.Enum;
using GameServer.Common.SerializeData.EventData;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class ChatServerOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            ChatServerRequestData requestData = new ChatServerRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            Dictionary<byte, object> subParam = new Dictionary<byte, object>();
            subParam.Add(1, requestData.message);

            GameController.Instance.FireEvent(player.peer, new SendParameters(),
                (byte)EventCode.ChatServer, new Dictionary<byte, object>(), subParam);

            GameController.Instance.AddChat(player.cacheData, requestData.message);

            return null;
        }
    }
}
