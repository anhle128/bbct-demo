using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.MMO.Concepts;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class ExitWorldOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters, OperationController controller)
        {
            // kiểm tra state
            if (player.state != GamePlayer.State.InWorld)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.StateInvalid);

            // kiểm tra sự tồn tại của world
            World world;
            if (WorldCache.Instance.TryGet(Settings.Instance.WorldName, out world) == false)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.WorldNotFound);

            // process
            player.ExitWorld();

            // response
            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);
        }
    }
}
