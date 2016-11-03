using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class StopItemOnMarketOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ItemOnMarketRequestData requestData = new ItemOnMarketRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (string.IsNullOrEmpty(requestData.id))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var itemOnMarket = MongoController.MarketDb.ItemSelling.GetData((requestData.id));


            if (itemOnMarket == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            if (!itemOnMarket.user_id.Equals(player.cacheData.info._id))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotHavePermission);
            }

            MongoController.MarketDb.ItemSelling.Delete(itemOnMarket._id);
            //MongoController.UserDb.Equip.UpdateOwner(itemOnMarket.id_equipment, player.cacheData.userid);
            MUserEquip userEquip =
                MongoController.UserDb.Equip.GetData(itemOnMarket.id_equipment);

            userEquip.user_id = player.cacheData.info._id;

            player.cacheData.AddOwnOwnEquipment(userEquip);

            //var eq = MongoController.UserDb.Equip.GetSingleData(x => x._id.Equals(itemOnMarket.id_equipment));
            StopItemOnMarketResponseData responseData = new StopItemOnMarketResponseData()
            {
                equip = new UserEquip()
                {
                    _id = userEquip._id.ToString(),
                    char_equip = "-1",
                    element = userEquip.element,
                    equip_id = userEquip.static_id,
                    powerup_level = userEquip.powerup_level,
                    star_level = userEquip.star_level,
                    bonusAttribute = userEquip.bonus_attribute,
                    bonusAttributeGrowMod = userEquip.bonus_attribute_grow_mod,
                    bonusAttributeMod = userEquip.bonus_attribute_mod
                }
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
