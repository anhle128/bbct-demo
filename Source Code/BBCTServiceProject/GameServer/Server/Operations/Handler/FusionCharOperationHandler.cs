using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class FusionCharOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            FusionCharRequestData request = new FusionCharRequestData();
            request.Deserialize(operationRequest.Parameters);

            if (request.chars.Count < 2)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            MUserCharacter userChar1 = player.cacheData.listUserChar.FirstOrDefault(a => a._id.Equals(request.chars[0]));
            if (userChar1 == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            MUserCharacter userChar2 = player.cacheData.listUserChar.FirstOrDefault(a => a._id.Equals(request.chars[1]));
            if (userChar2 == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (userChar1.level != userChar2.level ||
                userChar1.star_level != userChar2.star_level ||
                userChar1.powerup_level != userChar2.powerup_level)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            CharacterConfig charConfig = StaticDatabase.entities.configs.characterConfig;

            if (userChar1.star_level >= charConfig.maxStar)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.MaxStar);

            if (userChar1.powerup_level < charConfig.maxPowerup)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.PowerupNotEnough);

            if (userChar1.powerup_level < charConfig.maxLevel)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            int silverRequire = charConfig.GetSilverNeedToFusion(userChar1.star_level);
            if (player.cacheData.info.silver < silverRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.NotEnoughSliver);


            FusionCharConfig fusionCharConfig = StaticDatabase.entities.configs.fusionCharConfig;
            List<Reward> listReward = null;
            int star = userChar1.star_level + 1;
            if (player.cacheData.info.count_times_fusion >= fusionCharConfig.timesToGetSpecialReward)
            {
                listReward = fusionCharConfig.GetSpecialReward(star);
                player.cacheData.info.count_times_fusion = 0;
            }
            else
            {
                listReward = fusionCharConfig.GetNormalRewards(star);
                player.cacheData.info.count_times_fusion++;
            }

            SubRewardItem rewardItem = CommonFunc.RandomOneSubRewardItem(listReward);

            rewardItem.star = star;
            player.cacheData.info.silver -= silverRequire;
            player.cacheData.DeleteAllUserChar(new List<MUserCharacter>()
            {
                userChar1, userChar2
            });

            MongoController.UserDb.Info.UpdateSilver_CountTimesFusion(player.cacheData, TypeUseSilver.FusionChar, silverRequire);

            List<RewardItem> rewards = MongoController.UserDb.UpdateReward
            (
                player.cacheData,
                new List<SubRewardItem>()
                {
                    rewardItem
                },
                ReasonActionGold.None
            );

            RewardResponseData response = new RewardResponseData()
            {
                user_silver = player.cacheData.info.silver,
                rewards = rewards
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = response.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}
