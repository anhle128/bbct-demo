using DynamicDBModel.Models;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class GetMyItemOnMarketOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var items = MongoController.MarketDb.ItemSelling.GetDatas(player.cacheData.info._id);


            GetItemOnMarketResponseData responseData = new GetItemOnMarketResponseData()
            {
                items = new List<ItemOnMarket>(),
            };

            foreach (var item in items)
            {
                var equipment = MongoController.UserDb.Equip.GetData(item.id_equipment);

                ItemOnMarket dAuc = new ItemOnMarket()
                {
                    equipment = new UserEquip()
                    {
                        _id = equipment._id.ToString(),
                        char_equip = "-1",
                        element = equipment.element,
                        equip_id = equipment.static_id,
                        powerup_level = equipment.powerup_level,
                        star_level = equipment.star_level,
                        bonusAttribute = equipment.bonus_attribute,
                        bonusAttributeGrowMod = equipment.bonus_attribute_grow_mod,
                        bonusAttributeMod = equipment.bonus_attribute_mod
                    },
                    price = item.price,
                    id = item._id.ToString(),
                };

                responseData.items.Add(dAuc);
            }

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
