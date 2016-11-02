using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataLuanKiemShopOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            LuanKiemShopResponseData responseData = new LuanKiemShopResponseData()
            {
                items = MongoController.GetLuanKiemShopItems(player.cacheData.id),
                rank = player.cacheData.rankLuanKiem,
                point = player.cacheData.pointLuanKiem
            };
            var response = new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataLuanKiemShopOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
            return response;

        }
    }
}
