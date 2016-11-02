using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class BuyShopItemOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            BuyItemInShopRequestData requestData = new BuyItemInShopRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            // kiểm tra shop item
            MShopItem shopItem =
                MongoController.ShopDb.Item.GetData(requestData.id);

            if (shopItem == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // kiểm tra quay_tuong_normal yêu cầu
            int goldRequire = shopItem.gold * requestData.quantity;
            if (player.cacheData.gold < goldRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

            // kiểm tra tổng số lượt đã mua trong ngày
            int countTotalNumberBought =
                int.Parse(MongoController.LogSubDB.BuyShopItem.GetSumData
                (
                    filter =>
                        filter.user_id == player.cacheData.info._id &&
                        filter.server_id == Settings.Instance.server_id &&
                        filter.item_id == requestData.id &&
                        filter.hash_code_time == CommonFunc.GetHashCodeTime(),
                    summer =>
                        summer.quantity
                ).ToString());
            int maxNumberCanBuyInDay = shopItem.vip_buy_times[player.cacheData.vip];
            if ((countTotalNumberBought + requestData.quantity) > maxNumberCanBuyInDay)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxTimesCanBuy);

            List<SubRewardItem> listReward = new List<SubRewardItem>(1)
                {
                    shopItem.reward
                };

            // process
            player.cacheData.gold -= goldRequire;
            MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.BuyShopItem, goldRequire);

            MBuyShopItemLog log = new MBuyShopItemLog()
            {
                user_id = player.cacheData.info._id,
                hash_code_time = CommonFunc.GetHashCodeTime(),
                item_id = requestData.id,
                quantity = requestData.quantity,
                total_gold = requestData.quantity * shopItem.gold,
                rewards = listReward
            };
            MongoController.LogSubDB.BuyShopItem.Create(log);

            shopItem.reward.quantity = shopItem.reward.quantity * requestData.quantity;

            List<RewardItem> listRewardItems = MongoController.UserDb.UpdateReward
            (
                userInfo: player.cacheData,
                listReward: listReward,
                resource: ReasonActionGold.None
            );


            // response
            BuyItemInShopResponseData responseData = new BuyItemInShopResponseData()
            {
                rewards = listRewardItems,
                user_gold = player.cacheData.gold
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "BuyShopItemOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}
