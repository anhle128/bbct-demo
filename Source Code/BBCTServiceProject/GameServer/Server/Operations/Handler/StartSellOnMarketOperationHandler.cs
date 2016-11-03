using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GameServer.Server.Operations.Handler
{
    public class StartSellOnMarketOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            StartSellOnMarketRequestData requestData = new StartSellOnMarketRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (string.IsNullOrEmpty(requestData.equip_id))
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            requestData.keywordSearch = requestData.keywordSearch.ToLower();
            requestData.keywordSearch = ConvertToUnsign3(requestData.keywordSearch);

            if (player.cacheData.info.ruby < StaticDatabase.entities.configs.priceStartBuyMarket)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughRuby);
            }

            int countItemSelling = MongoController.MarketDb.ItemSelling.Count(player.cacheData.info._id);


            if (countItemSelling >= StaticDatabase.entities.configs.GetVipConfig(player.cacheData.info.vip).maxSellMarket)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxAmountItemCanSell);
            }

            var equipment = player.cacheData.listUserEquip.FirstOrDefault
                (
                    x =>
                        x._id.ToString() == requestData.equip_id &&
                        x.char_equip.Equals("-1")
                );

            if (equipment == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            var info = StaticDatabase.entities.equipments.FirstOrDefault(x => x.id == equipment.static_id);

            if (info == null)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }

            if (!info.canSellMarket)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.CannotSellOnMarket);
            }

            if (requestData.price < info.baseMarketPrice)
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.CannotLessBasePrice);
            }

            player.cacheData.info.ruby -= StaticDatabase.entities.configs.priceStartBuyMarket;
            MongoController.UserDb.Info.UpdateRuby(player.cacheData);

            player.cacheData.RemoveOwnEquipment(equipment);

            MItemSellingOnMarket itemSell = new MItemSellingOnMarket()
            {
                id_equipment = equipment._id,
                user_id = player.cacheData.info._id,
                price = requestData.price,
                keyword_search = requestData.keywordSearch,
            };
            MongoController.MarketDb.ItemSelling.Create(itemSell);

            return CommonFunc.SimpleResponse(operationRequest, ReturnCode.OK);

        }

        public string ConvertToUnsign3(string str)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = str.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty)
                        .Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
