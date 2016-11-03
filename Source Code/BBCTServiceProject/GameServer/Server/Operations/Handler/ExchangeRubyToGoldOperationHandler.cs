
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using Photon.SocketServer;
using StaticDB.Enum;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class ExchangeRubyToGoldOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            ExchangeRubyRequestData requestData = new ExchangeRubyRequestData();
            requestData.Deserialize(operationRequest.Parameters);

            if (player.cacheData.info.ruby < requestData.ruby)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            player.cacheData.info.ruby -= requestData.ruby;

            int goldReward = requestData.ruby * StaticDatabase.entities.configs.exchangeRubyToGoldConfig;

            int oldGold = player.cacheData.info.gold;

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
                user_gold = player.cacheData.info.gold,
                user_silver = player.cacheData.info.silver,
                user_ruby = player.cacheData.info.ruby
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
