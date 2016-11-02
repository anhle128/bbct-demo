using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.MMO.Concepts;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    class MoveToOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            if (player.state == GamePlayer.State.InWorld)
            {
                MoveToRequestData data = new MoveToRequestData();
                data.Deserialize(operationRequest.Parameters);
                Vector2D newPosition = new Vector2D(data.x, data.y);
                player.item.Move(newPosition);
                return null;
            }
            else
            {
                //Trả về lỗi báo client gọi khi không đúng trạng thái
                return new OperationResponse()
                {
                    OperationCode = operationRequest.OperationCode,
                    DebugMessage = "",
                    Parameters = new Dictionary<byte, object>(),
                    ReturnCode = (short)ReturnCode.StateInvalid
                };
            }
        }
    }
}
