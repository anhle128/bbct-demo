using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using Photon.SocketServer;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class FindItemOnMarketOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            FindMarketRequestData requestData = new FindMarketRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            if (string.IsNullOrEmpty(requestData.keyword))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            if (requestData.minPrice < 0)
            {
                requestData.minPrice = int.MinValue;
            }

            if (requestData.maxPrice < 0)
            {
                requestData.maxPrice = int.MaxValue;
            }

            requestData.keyword = requestData.keyword.ToLower();

            var items = MongoController.MarketDb.ItemSelling.FindDatas
            (
                requestData.keyword,
                requestData.minPrice,
                requestData.maxPrice,
                player.cacheData.id
            );

            GetItemOnMarketResponseData responseData = new GetItemOnMarketResponseData()
            {
                items = new List<ItemOnMarket>(),
            };

            int count = 0;

            foreach (var item in items)
            {
                var equipment = MongoController.UserDb.Equip.GetData(item.id_equipment);

                var info = StaticDatabase.entities.equipments.FirstOrDefault(x => x.id == equipment.static_id);

                if (info != null)
                {
                    if (requestData.category == 0 || info.category == requestData.category)
                    {
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
                                bonusAttributeMod = equipment.bonus_attribute_mod,
                                bonusAttributeGrowMod = equipment.bonus_attribute_grow_mod
                            },
                            price = item.price,
                            id = item._id.ToString(),
                        };

                        responseData.items.Add(dAuc);

                        count++;
                    }
                }

                if (count >= 30)
                {
                    break;
                }
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
