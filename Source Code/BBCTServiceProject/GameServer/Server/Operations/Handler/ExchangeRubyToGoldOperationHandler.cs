
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Server.Operations.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using Photon.SocketServer;
using StaticDB.Enum;
using System.Collections.Generic;
using MongoDBModel.Enum;

namespace GameServer.Server.Operations.Handler
{
    public class ExchangeRubyToGoldOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            ExchangeRubyRequestData requestData = new ExchangeRubyRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (player.cacheData.ruby < requestData.ruby)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            player.cacheData.ruby -= requestData.ruby;

            int goldReward = requestData.ruby * StaticDatabase.entities.configs.exchangeRubyToGoldConfig;

            int oldGold = player.cacheData.gold;

            //Player.cacheData.gold += goldReward;

            List<SubRewardItem> listReward = new List<SubRewardItem>(1)
            {
                new SubRewardItem() {quantity = goldReward, type_reward = (int)TypeReward.Gold}
            };

            MongoController.UserDb.UpdateReward(player.cacheData, listReward, ReasonActionGold.ExchangeRubyToGold);

            MongoController.UserDb.Info.UpdateRuby(player.cacheData);

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = new List<RewardItem>()
                    {
                        new RewardItem()
                        {
                            quantity = goldReward,
                            static_id = 0,
                            type_reward = (int)TypeReward.Gold
                        }
                    },
                user_gold = player.cacheData.gold,
                user_silver = player.cacheData.silver,
                user_level = player.cacheData.level,
                user_exp = player.cacheData.level,
                user_ruby = player.cacheData.ruby
            };

            // response
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "ExchangeRubyToGoldOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
