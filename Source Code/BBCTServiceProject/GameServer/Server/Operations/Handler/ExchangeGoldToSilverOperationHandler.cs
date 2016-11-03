
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
                MongoController.LogSubDB.ExchangeGoldToSilver.GetData(player.cacheData.info._id,
                    CommonFunc.GetHashCodeTime());

            bool isCreate = false;
            if (log == null)
            {
                log = new MExchangeGoldToSilverLog()
                {
                    user_id = player.cacheData.info._id,
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
            if (config.levelRequire > player.cacheData.info.level)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            VipConfig vipConfig = StaticDatabase.entities.configs.vipConfigs[player.cacheData.info.vip];

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
                    if (goldNeed > player.cacheData.info.gold)
                        break;

                    player.cacheData.info.gold -= goldNeed;
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

            player.cacheData.info.silver += totalSilverReward;

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
                user_silver = player.cacheData.info.silver,
                user_glod = player.cacheData.info.gold,
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
            if (config.levelRequire > player.cacheData.info.level)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            VipConfig vipConfig = StaticDatabase.entities.configs.vipConfigs[player.cacheData.info.vip];

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
                if (player.cacheData.info.gold < goldNeed)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

                player.cacheData.info.gold -= goldNeed;
            }
            player.cacheData.info.silver += silverReward;


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
                user_silver = player.cacheData.info.silver,
                user_glod = player.cacheData.info.gold,
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
