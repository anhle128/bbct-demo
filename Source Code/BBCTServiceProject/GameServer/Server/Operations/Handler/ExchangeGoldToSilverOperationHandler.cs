
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
using StaticDB.Enum;
using StaticDB.Models;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class ExchangeGoldToSilverOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ExchangeGoldToSilverRequestData requestData = new ExchangeGoldToSilverRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            MExchangeGoldToSilverLog log =
                MongoController.LogSubDB.ExchangeGoldToSilver.GetData(player.cacheData.id,
                    CommonFunc.GetHashCodeTime());

            bool isCreate = false;
            if (log == null)
            {
                log = new MExchangeGoldToSilverLog()
                {
                    user_id = player.cacheData.id,
                    hash_code_time = CommonFunc.GetHashCodeTime(),
                    times = 0
                };
                isCreate = true;
            }

            if (requestData.times > 0)
                return ExchangeOneTimes(player, operationRequest, log, isCreate);
            else
                return ExchangeMaxTimes(player, operationRequest, log, isCreate);
        }

        private OperationResponse ExchangeMaxTimes(GamePlayer player, OperationRequest operationRequest,
           MExchangeGoldToSilverLog log, bool isCreate)
        {
            ExchangeGoldToSilverConfig config = StaticDatabase.entities.configs.exchangeGoldToSilverConfig;
            if (config.levelRequire > player.cacheData.level)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            VipConfig vipConfig = StaticDatabase.entities.configs.vipConfigs[player.cacheData.vip];

            if (log.times >= vipConfig.exchangeGoldToSilverTimes)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxExchangeTimes);

            int totalTimesExchange = vipConfig.exchangeGoldToSilverTimes - log.times;

            int totalSilverReward = 0;
            int totalGoldNeed = 0;

            for (int i = 0; i < totalTimesExchange; i++)
            {
                if (log.times > vipConfig.exchangeGoldToSilverTimes)
                    break;

                log.times++;

                int goldNeed = config.GetGoldNeed(log.times);


                if (log.times > config.freeTimes)
                {
                    if (goldNeed > player.cacheData.gold)
                        break;

                    player.cacheData.gold -= goldNeed;
                    totalGoldNeed += goldNeed;
                }

                double randomBonus = CommonFunc.RandomNumberDouble();
                int silverReward = config.baseSilver;
                if (randomBonus > config.procBonusSilver)
                {
                    silverReward = config.GetBonusSilver();
                }
                totalSilverReward += silverReward;
            }

            if (isCreate)
                MongoController.LogSubDB.ExchangeGoldToSilver.Create(log);
            else
                MongoController.LogSubDB.ExchangeGoldToSilver.Update(log);

            player.cacheData.silver += totalSilverReward;

            MongoController.UserDb.Info.UpdateGold_Silver(player.cacheData, totalGoldNeed);

            ExchangeGoldToSilverResponseData responseData = new ExchangeGoldToSilverResponseData()
            {
                rewards = new List<RewardItem>(1)
                {
                    new RewardItem()
                    {
                        quantity = totalSilverReward,
                        static_id = 0,
                        type_reward = (int) TypeReward.Silver,
                    }
                },
                user_silver = player.cacheData.silver,
                user_glod = player.cacheData.gold,
                total_time_exchange = log.times,
            };

            // response
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "ExchangeGoldToSilverOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }

        private OperationResponse ExchangeOneTimes(GamePlayer player, OperationRequest operationRequest,
            MExchangeGoldToSilverLog log, bool isCreate)
        {
            ExchangeGoldToSilverConfig config = StaticDatabase.entities.configs.exchangeGoldToSilverConfig;
            if (config.levelRequire > player.cacheData.level)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            VipConfig vipConfig = StaticDatabase.entities.configs.vipConfigs[player.cacheData.vip];

            if (log.times >= vipConfig.exchangeGoldToSilverTimes)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxExchangeTimes);

            log.times++;

            int goldNeed = config.GetGoldNeed(log.times);

            double randomBonus = CommonFunc.RandomNumberDouble();
            int silverReward = config.baseSilver;
            if (randomBonus > config.procBonusSilver)
            {
                silverReward = config.GetBonusSilver();
            }

            if (log.times > config.freeTimes)
            {
                if (player.cacheData.gold < goldNeed)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

                player.cacheData.gold -= goldNeed;
            }
            player.cacheData.silver += silverReward;


            MongoController.UserDb.Info.UpdateGold_Silver(player.cacheData, goldNeed);

            if (isCreate)
                MongoController.LogSubDB.ExchangeGoldToSilver.Create(log);
            else
                MongoController.LogSubDB.ExchangeGoldToSilver.Update(log);

            ExchangeGoldToSilverResponseData responseData = new ExchangeGoldToSilverResponseData()
            {
                rewards = new List<RewardItem>(1)
                {
                    new RewardItem()
                    {
                        quantity = silverReward,
                        static_id = 0,
                        type_reward = (int) TypeReward.Silver,
                    }
                },
                user_silver = player.cacheData.silver,
                user_glod = player.cacheData.gold,
                total_time_exchange = log.times
            };

            // response
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "ExchangeGoldToSilverOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}
