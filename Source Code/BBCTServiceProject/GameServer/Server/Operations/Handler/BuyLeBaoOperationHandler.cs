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
    public class BuyLeBaoOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            BuyItemInShopRequestData requestData = new BuyItemInShopRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MLebao leBao =
                MongoController.ShopDb.LeBao.GetData(requestData.id);
            //.GetSingleData(a => a._id == (requestData.id) && a.server_id == Settings.Instance.server_id);
            if (leBao == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            // kiểm tra vip
            if (player.cacheData.vip < leBao.vip_required)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);


            // kiểm tra thời gian có thể mua lễ bao
            if (!CommonFunc.CheckValidTimeToBuyLeBao(leBao.activation, leBao.start, leBao.end))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            // kiểm tra quay_tuong_normal
            if (player.cacheData.gold < leBao.gold)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

            // kiểm tra số lần mua lễ bao
            int totalTimesCanBuy = CommonFunc.GetTimesCanBuyLeBao(leBao, player.cacheData.vip);
            int totalTimesBought =
                MongoController.LogSubDB.BuyLeBao.Count(player.cacheData.info._id, (requestData.id));

            if (totalTimesCanBuy <= totalTimesBought)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxTimesCanBuy);

            // process
            player.cacheData.gold -= leBao.gold;
            MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.BuyLeBao, leBao.gold);

            MBuyLeBaoLog log = new MBuyLeBaoLog()
            {
                user_id = player.cacheData.info._id,
                rewards = leBao.rewards,
                gold = leBao.gold,
                le_bao_id = leBao._id,
                hash_code_time = CommonFunc.GetHashCodeTime()
            };
            MongoController.LogSubDB.BuyLeBao.Create(log);

            List<RewardItem> listReward = MongoController.UserDb.UpdateReward(player.cacheData, log.rewards, ReasonActionGold.None);

            // response
            BuyItemInShopResponseData responseData = new BuyItemInShopResponseData()
            {
                rewards = listReward,
                user_gold = player.cacheData.gold
            };
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "BuyLeBaoOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}
