using DynamicDBModel.Models;
using GameServer.Battle;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;
using System;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class AttackGlobalBossOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            StartAttackGlobalBossRequestData requestData = new StartAttackGlobalBossRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            GlobalBossConfig globalBossConfig = StaticDatabase.entities.configs.globalBossConfig;

            if (player.cacheData.level < globalBossConfig.levelRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            if (player.cacheData.userGlobalBoss == null)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            if (!GlobalBossInfo.AllowAttack())
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            if (requestData.typeAttackGlobalBoss >
                globalBossConfig.attackConfigs.Length)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            AttackGlobalBossConfig config = globalBossConfig.attackConfigs[requestData.typeAttackGlobalBoss - 1];
            if (
                (DateTime.Now -
                 player.cacheData.userGlobalBoss.last_time_attack)
                    .TotalSeconds < config.waitTime)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidTime);

            if (requestData.typeAttackGlobalBoss == (int)TypeAttackGlobalBoss.Special && player.cacheData.vip < config.vipRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            player.cacheData.userGlobalBoss.last_time_attack = DateTime.Now;

            BattleProcessor processor = new BattleProcessor();
            BattleSimulator.Battle battleSim = processor.BattleGlobalBoss
            (
               player.cacheData,
               GlobalBossInfo.BossLevel
            );


            double damage = Math.Round(battleSim.GetTotalDamageTeamA());

            if (GlobalBossInfo.AllowAttack())
            {
                player.cacheData.userGlobalBoss.total_damages += damage;

                MongoController.UserDb.GlobalBoss.Update(player.cacheData.userGlobalBoss);

                GlobalBossInfo.RefeshCurrentTopUsersAndHpBoss
                (
                    player.cacheData.id,
                    player.cacheData.nickname,
                    player.cacheData.userGlobalBoss.total_damages,
                    damage
                );
            }

            int silverReward = StaticDatabase.entities.configs.globalBossConfig.GetSilverReward(damage);

            List<SubRewardItem> listReward = new List<SubRewardItem>()
            {
                new SubRewardItem()
                {
                    quantity = silverReward,
                    static_id = 0,
                    type_reward = (int)TypeReward.Silver
                },
            };

            if (StaticDatabase.entities.configs.globalBossConfig.bonusRewards != null &&
                StaticDatabase.entities.configs.globalBossConfig.bonusRewards.Count != 0)
            {
                SubRewardItem bonusReward =
                    CommonFunc.RandomOneSubRewardItem(StaticDatabase.entities.configs.globalBossConfig.bonusRewards);
                listReward.Add(bonusReward);
            }

            List<RewardItem> listRewardResult = MongoController.UserDb.UpdateReward(player.cacheData, listReward, ReasonActionGold.RewardAttackGlobalBoss);

            EndAttackGlobalBossResponseData responseData = new EndAttackGlobalBossResponseData()
            {
                current_top_users = GlobalBossInfo.CurrentTopUsers,
                time_boss = GlobalBossInfo.GetCoolDownTimeAttackBoss(),
                user_silver = player.cacheData.silver,
                rewards = listRewardResult,
                replay = battleSim.replay
            };

            MongoController.UserDb.GlobalBoss.Update(player.cacheData.userGlobalBoss);
            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.id, TypeNhiemVuHangNgay.AttackGlobalBoss);

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "EndAttackGlobalBossOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }
    }
}
