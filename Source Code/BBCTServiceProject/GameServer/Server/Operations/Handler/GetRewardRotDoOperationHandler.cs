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
using StaticDB.Enum;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetRewardRotDoOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            IndexRequestData requestData = new IndexRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MSKRotDoConfig config = MongoController.ConfigDb.SkRotDo.GetData();
            if (config == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            MSKRotDoLog log = MongoController.LogSubDB.SkRotDo.GetData(player.cacheData.id, config._id);

            if (log == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (log.hash_code_time != CommonFunc.GetHashCodeTime())
            {
                log.hash_code_time = CommonFunc.GetHashCodeTime();
                log.index_receiveds = new List<IndexReceived>();
            }

            if (requestData.index > config.rewards.Count - 1)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            IndexReceived indexReceive = log.index_receiveds.FirstOrDefault(a => a.index == requestData.index);
            if (indexReceive == null)
            {
                indexReceive = new IndexReceived()
                {
                    index = requestData.index,
                    received_times = 0
                };
                log.index_receiveds.Add(indexReceive);
            }

            RotDoReward rotDoReward = config.rewards[requestData.index];
            if (indexReceive.received_times >= rotDoReward.max_exchange_in_day)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxReceived);

            List<SubRewardItem> requireItems = rotDoReward.requires;
            List<MUserItem> listUserRequireItem = new List<MUserItem>();

            int totalGoldNeed = 0;
            int totalSilverNeed = 0;

            foreach (var requireIten in requireItems)
            {
                if (requireIten.type_reward == (int)TypeReward.Item)
                {
                    MUserItem item =
                        player.cacheData.listUserItem.FirstOrDefault(a => a.static_id == requireIten.static_id);

                    if (item.quantity < requireIten.quantity)
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);

                    item.quantity -= requireIten.quantity;
                    listUserRequireItem.Add(item);
                }
                else if (requireIten.type_reward == (int)TypeReward.Gold)
                {
                    totalGoldNeed += requireIten.quantity;

                    if (totalGoldNeed > player.cacheData.gold)
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);
                }
                else if (requireIten.type_reward == (int)TypeReward.Silver)
                {
                    totalSilverNeed += requireIten.quantity;

                    if (totalSilverNeed > player.cacheData.silver)
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughSliver);
                }
            }
            indexReceive.received_times++;

            List<RewardItem> listReceive = MongoController.UserDb.UpdateReward(player.cacheData, rotDoReward.rewards, ReasonActionGold.RewardSkRotDo);
            MongoController.LogSubDB.SkRotDo.Update(log);
            foreach (var requireItem in listUserRequireItem)
            {
                MongoController.UserDb.Item.UpdateQuantity(requireItem);
            }

            if (totalGoldNeed > 0)
            {
                player.cacheData.gold -= totalGoldNeed;
                MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.ExchangeGoldInSkRotDo, totalGoldNeed);
            }

            if (totalSilverNeed > 0)
            {
                player.cacheData.silver -= totalSilverNeed;
                MongoController.UserDb.Info.UpdateSilver(player.cacheData, TypeUseSilver.ExchangeSilverInSkRotDo, totalGoldNeed);
            }

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listReceive,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                user_ruby = player.cacheData.ruby
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetRewardRotDoOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}
