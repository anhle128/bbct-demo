using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.MMO.Concepts;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class EnterWorldOperationHandler : IOperationHandler
    {

        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            // kiểm tra state
            if (player.state != GamePlayer.State.SignIn)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.StateInvalid);

            // kiểm tra sự tồn tại của world
            World world;
            if (WorldCache.Instance.TryGet(Settings.Instance.WorldName, out world) == false)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.WorldNotFound);

            //CommonLog.Instance.PrintLog(Player.cacheData.nickname + " - enter world");

            // process
            Vector2D position = new Vector2D(player.cacheData.x, player.cacheData.y);

            Item item = new Item(player.cacheData.username, position, world, player.peer);

            player.EnterWorld(item);
            item.Spawn();

            // response
            EnterWorldResponseData rData = new EnterWorldResponseData()
            {
                x = (int)position.x,
                y = (int)position.y,
                chatData = GameController.Instance.chatData.Items
            };

            var response = new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = rData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
            return response;
        }
    }
}
