
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class ExchangeItemOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            IndexRequestData requestData = new IndexRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (!SuKienDoiDoInfo.Duration)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            MSKDoiDoLog log = MongoController.LogSubDB.SkDoiDo.GetData(player.cacheData.info._id, SuKienDoiDoInfo.SuKienId);

            if (log.index_exchanged == null)
                log.index_exchanged = new List<int>();

            if (log.index_exchanged.Any(a => a == requestData.index))
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.AlreadyDone);


            ItemDoiDo itemDoiDo = log.exchange_items[requestData.index];

            SubRewardItem requireItem = itemDoiDo.require_item;

            if (requireItem.type_reward == (int)TypeReward.Gold)
            {
                if (player.cacheData.info.gold < requireItem.quantity)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);
                player.cacheData.info.gold -= requireItem.quantity;
                MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.SkDoiDo, requireItem.quantity);
            }
            else if (requireItem.type_reward == (int)TypeReward.Silver)
            {
                if (player.cacheData.info.silver < requireItem.quantity)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);
                player.cacheData.info.silver -= requireItem.quantity;
                MongoController.UserDb.Info.UpdateSilver(player.cacheData, TypeUseSilver.SkDoiDo, requireItem.quantity);
            }
            else if (requireItem.type_reward == (int)TypeReward.Item)
            {
                MUserItem staticItem =
                    player.cacheData.listUserItem.FirstOrDefault(a => a.static_id == requireItem.static_id);
                if (staticItem == null || staticItem.quantity < requireItem.quantity)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);
                staticItem.quantity -= requireItem.quantity;
                MongoController.UserDb.Item.UpdateQuantity(staticItem);
            }

            List<RewardItem> listResult = MongoController.UserDb.UpdateReward
            (
                player.cacheData,
                new List<SubRewardItem>()
                    {
                        itemDoiDo.reward_item
                    },
                ReasonActionGold.RewardExchangeItem
            );

            log.index_exchanged.Add(requestData.index);
            log.current_point += itemDoiDo.reward_point;
            log.total_point += itemDoiDo.reward_point;
            SuKienDoiDoInfo.RefeshCurrentTopUsers(log);
            MongoController.LogSubDB.SkDoiDo.Update(log);

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listResult,
                user_gold = player.cacheData.info.gold,
                user_silver = player.cacheData.info.silver,
                user_ruby = player.cacheData.info.ruby
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "ExchangeItemOperationHandler Done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }


}
