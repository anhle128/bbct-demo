using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using StaticDB.Models;

namespace GameServer.Server.Operations.Handler
{
    class PlushAttributeThanThapOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            PlusAttributeThanThapRequestData requestData = new PlusAttributeThanThapRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (player.cacheData.thanThapAttacked == null)
            {
                player.cacheData.thanThapAttacked =
               MongoController.UserDb.ThanThap.GetData(player.cacheData.info._id, ThanThapInfo.GetHashTimeEnd());
            }

            if (player.cacheData.thanThapAttacked == null
                || player.cacheData.thanThapAttacked.bonus_attributes_selection == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (requestData.index_bonus_attribute_selection > 2)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            PlusAttributeRequire plusAttributeRequire =
                StaticDatabase.entities.configs.thanThapConfig.plushAttributeRequires[
                    requestData.index_bonus_attribute_selection];
            if (player.cacheData.thanThapAttacked.star < plusAttributeRequire.startRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            player.cacheData.thanThapAttacked.star -= plusAttributeRequire.startRequire;

            int indexAttribue =
                player.cacheData.thanThapAttacked.bonus_attributes_selection[requestData.index_bonus_attribute_selection];

            player.cacheData.thanThapAttacked.bonus_attributes[CommonFunc.GetBonusAttributeIndex(indexAttribue)] += plusAttributeRequire.procReceive;
            player.cacheData.thanThapAttacked.bonus_attributes_selection = null;

            MongoController.UserDb.ThanThap.UpdateBonusAttribute_DonePlusAttribute(player.cacheData.thanThapAttacked);
            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }
    }
}
