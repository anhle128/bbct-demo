﻿using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataShopOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            ShopResponseData responseData = new ShopResponseData()
            {
                items = MongoController.GetShopItems(player.cacheData.id, player.cacheData.vip),
                lebaos = MongoController.GetLeBaos(player.cacheData.id, player.cacheData.vip)
            };
            var response = new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetShopDataOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
            return response;

        }
    }
}