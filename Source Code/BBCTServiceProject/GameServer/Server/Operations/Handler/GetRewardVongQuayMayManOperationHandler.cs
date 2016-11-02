
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
    public class GetRewardVongQuayMayManOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            GetRewardVongQuayMayManRequestData resquestData = new GetRewardVongQuayMayManRequestData();
            resquestData.Deserialize(operationRequest.Parameters);

            MSKVongQuayMayManConfig config = MongoController.ConfigDb.SkVongQuayMayMan.GetData();
            if (config == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            bool isCreate = false;


            MSKVongQuayMayManLog log = MongoController.LogSubDB.SkVongQuayMayMan.GetData(player.cacheData.info._id, config._id);
            if (log == null)
            {
                isCreate = true;
                log = new MSKVongQuayMayManLog()
                {
                    user_id = player.cacheData.info._id,
                    count_times_quay_free = 0,
                    server_id = Settings.Instance.server_id,
                    su_kien_id = config._id,
                    rewards = new List<SubRewardItem>(),
                    total_point = 0,
                    level = player.cacheData.level,
                    nickname = player.cacheData.nickname,
                    avatar = player.cacheData.avatar,
                    vip = player.cacheData.vip,
                };
            }
            else
            {
                log.nickname = player.cacheData.nickname;
                log.level = player.cacheData.level;
                log.avatar = player.cacheData.avatar;
                log.vip = player.cacheData.vip;
            }


            List<RewardItem> rewardResult = null;
            GetRewardVongQuayMayManResponseData responseData = null;
            List<SubRewardItem> rewards = new List<SubRewardItem>();

            int goldRequired = 0;

            if (resquestData.times == 1) // quay x1
            {
                if (log.count_times_quay_free < config.max_free_times) // free
                {
                    rewards.Add(CommonFunc.RandomOneSubRewardItem(config.vatPhams));
                    log.count_times_quay_free++;
                }
                else
                {
                    if (player.cacheData.gold < config.price)
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);
                    goldRequired = config.price;
                    log.total_point += 1;
                    rewards.Add(CommonFunc.RandomOneSubRewardItem(config.vatPhams));
                }
            }
            else // quay x10
            {
                if (player.cacheData.gold < config.x10_price)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

                // process
                goldRequired = config.x10_price;
                for (int i = 0; i < 10; i++)
                {
                    rewards.Add(CommonFunc.RandomOneSubRewardItem(config.vatPhams));
                }
                log.total_point += 10;
            }

            player.cacheData.gold -= goldRequired;

            // update
            MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.GetRewardSkVongQuayMayMan, goldRequired);
            rewardResult = MongoController.UserDb.UpdateReward(player.cacheData, rewards, ReasonActionGold.RewardSkVongQuayMayMan);

            foreach (var reward in rewards)
            {
                SubRewardItem subReward = new SubRewardItem()
                {
                    static_id = reward.static_id,
                    quantity = reward.quantity,
                    type_reward = reward.type_reward
                };
                log.rewards.Add(subReward);
            }

            if (isCreate)
            {
                MongoController.LogSubDB.SkVongQuayMayMan.Create(log);
            }
            else
            {
                MongoController.LogSubDB.SkVongQuayMayMan.Update(log);
            }

            responseData = new GetRewardVongQuayMayManResponseData()
            {
                rewards = rewardResult,
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                show_rewards = rewards
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "ChonTuongBanDauOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
