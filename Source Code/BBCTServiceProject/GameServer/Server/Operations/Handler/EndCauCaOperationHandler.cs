using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using Photon.SocketServer;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class EndCauCaOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            var userCauCa = MongoController.UserDb.CauCa.GetCurrentCauCa(player.cacheData.info._id);

            if (userCauCa != null)
            {
                double timeMinus = (DateTime.Now - userCauCa.created_at).TotalSeconds;

                CauCaConfig config = StaticDatabase.entities.configs.cauCaConfig;

                if (timeMinus < config.canCauConfigs[userCauCa.indexCanCau].duration)
                {
                    // quick end
                    if (player.cacheData.vip < config.vipRequireToEnd)
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LackOfRequirement);
                    if (player.cacheData.gold < config.goldRequireToEnd)
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughGold);

                    player.cacheData.gold -= config.goldRequireToEnd;
                    MongoController.UserDb.Info.UpdateGold(player.cacheData, ReasonActionGold.QuickEndCauCa, config.goldRequireToEnd);
                }


                Reward[] arrReward = config.canCauConfigs[userCauCa.indexCanCau].rewards;

                List<SubRewardItem> listReward = CommonFunc.RandomSubRewardItem
                (
                    arrReward
                );

                if (listReward.Count == 0)
                {
                    Reward bonusReward = arrReward.Last();
                    listReward.Add(new SubRewardItem()
                    {
                        quantity = bonusReward.amountMax == bonusReward.amountMin
                        ? bonusReward.amountMax : CommonFunc.RandomNumber(bonusReward.amountMin, bonusReward.amountMax),
                        static_id = bonusReward.staticID,
                        type_reward = bonusReward.typeReward
                    });
                }

                var listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, listReward, ReasonActionGold.RewardCauCa);
                MongoController.UserDb.CauCa.CloseThis(userCauCa._id);

                EndCauCaResponseData responseData = new EndCauCaResponseData()
                {
                    rewards = listRewardResult
                };

                return new OperationResponse()
                {
                    OperationCode = operationRequest.OperationCode,
                    DebugMessage = "",
                    Parameters = responseData.Serialize(),
                    ReturnCode = (short)ReturnCode.OK
                };

            }
            else
            {
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);
            }
        }
    }
}
