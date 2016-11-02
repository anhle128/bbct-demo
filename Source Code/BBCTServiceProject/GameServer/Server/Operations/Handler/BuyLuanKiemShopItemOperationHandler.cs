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
    public class BuyLuanKiemShopItemOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            BuyItemInShopRequestData requestData = new BuyItemInShopRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            // kiểm tra shop item
            MLuanKiemShopItem shopItem =
                MongoController.ShopDb.LuanKiem.GetData(requestData.id);

            if (shopItem == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // kiểm tra point yêu cầu
            int pointRequire = shopItem.point_luan_kiem * requestData.quantity;
            if (player.cacheData.pointLuanKiem < pointRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughPoint);

            // kiểm tra tổng số lượt đã mua trong ngày
            int countTotalNumberBought =
                int.Parse(MongoController.LogSubDB.BuyLuanKiemShopItem.GetSumData
                (
                    filter =>
                        filter.user_id == player.cacheData.id &&
                        filter.item_id == requestData.id &&
                        filter.hash_code_time == CommonFunc.GetHashCodeTime() &&
                        filter.server_id == Settings.Instance.server_id,
                    summer =>
                        summer.quantity
                ).ToString());
            int maxNumberCanBuyInDay = shopItem.maxBuyTimes;
            if ((countTotalNumberBought + requestData.quantity) > maxNumberCanBuyInDay)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxTimesCanBuy);

            List<SubRewardItem> listReward = new List<SubRewardItem>(1)
                {
                    shopItem.reward
                };

            // process
            player.cacheData.pointLuanKiem -= shopItem.point_luan_kiem * requestData.quantity;
            MongoController.UserDb.Info.UpdatePointLuanKiem(player.cacheData);

            MBuyShopLuanKiemItemLog log = new MBuyShopLuanKiemItemLog()
            {
                user_id = player.cacheData.id,
                hash_code_time = CommonFunc.GetHashCodeTime(),
                item_id = requestData.id,
                quantity = requestData.quantity,
                rewards = listReward
            };
            MongoController.LogSubDB.BuyLuanKiemShopItem.Create(log);

            shopItem.reward.quantity = shopItem.reward.quantity * requestData.quantity;

            List<RewardItem> listRewardItems = MongoController.UserDb.UpdateReward
            (
                userInfo: player.cacheData,
                listReward: listReward,
                resource: ReasonActionGold.None
            );

            // response
            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listRewardItems,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                user_level = player.cacheData.level,
                user_exp = player.cacheData.exp,
                user_ruby = player.cacheData.ruby

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
