using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;

namespace GameServer.Server.Operations.Handler
{
    public class BuyItemOnMarketOperationHandler : IOperationHandler
    {
        private static object lockBuy = new object();

        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ItemOnMarketRequestData requestData = new ItemOnMarketRequestData();
            requestData.Deserialize(operationRequest.Parameters);
            if (string.IsNullOrEmpty(requestData.id))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }
            lock (lockBuy)
            {
                var itemOnMarket = MongoController.MarketDb.ItemSelling.GetData((requestData.id));

                if (itemOnMarket == null)
                {
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.ItemsBought);
                }

                if (player.cacheData.ruby < itemOnMarket.price)
                {
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughRuby);
                }

                player.cacheData.ruby -= itemOnMarket.price;
                MongoController.UserDb.Info.UpdateRuby(player.cacheData);



                int pricePercent = (int)(itemOnMarket.price * StaticDatabase.entities.configs.percentBuySuccessMarket);
                int priceReceive = itemOnMarket.price - pricePercent;

                MongoController.UserDb.Mail.SendRubyBuyItemMarket(itemOnMarket.user_id, priceReceive, pricePercent);

                MUserEquip userEquip =
                    MongoController.UserDb.Equip.GetData(itemOnMarket.id_equipment);
                userEquip.user_id = player.cacheData.info._id;
                player.cacheData.AddOwnOwnEquipment(userEquip);

                MongoController.MarketDb.ItemSelling.Delete(itemOnMarket._id);
                var eq = MongoController.UserDb.Equip.GetData(itemOnMarket.id_equipment);

                BuyItemOnMarketResponseData responseData = new BuyItemOnMarketResponseData()
                {
                    equip = new UserEquip()
                    {
                        _id = eq._id.ToString(),
                        char_equip = "-1",
                        equip_id = eq.static_id,
                        powerup_level = eq.powerup_level,
                        star_level = eq.star_level,
                        element = eq.element,
                        bonusAttribute = eq.bonus_attribute,
                        bonusAttributeGrowMod = eq.bonus_attribute_grow_mod,
                        bonusAttributeMod = eq.bonus_attribute_mod
                    },
                    userRuby = player.cacheData.ruby,
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
}
