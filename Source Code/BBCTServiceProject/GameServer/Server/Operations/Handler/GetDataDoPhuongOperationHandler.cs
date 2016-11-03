using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataDoPhuongOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player,
            OperationRequest operationRequest,
            SendParameters sendParameters,
            OperationController controller)
        {
            if (player.cacheData.level < StaticDatabase.entities.configs.levelRequireDoPhuong)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            int count = MongoController.LogSubDB.DoPhuong.Count(player.cacheData.info._id);
          

            GetDataDoPhuongResponseData rData = new GetDataDoPhuongResponseData()
            {
                countTimesPlay = count
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = rData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
