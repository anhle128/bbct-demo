using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataGlobalBossOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            MUserGlobalBoss userGlobalBoss =
                MongoController.UserDb.GlobalBoss.GetData(player.cacheData.info._id, GlobalBossInfo.HashCodeEndTime);
            if (userGlobalBoss == null)
            {
                userGlobalBoss = new MUserGlobalBoss()
                {
                    user_id = player.cacheData.info._id,
                    total_damages = 0,
                    hash_code_time = GlobalBossInfo.HashCodeEndTime,
                    last_time_attack = new DateTime(),
                    nickname = player.cacheData.nickname
                };
                MongoController.UserDb.GlobalBoss.Create(userGlobalBoss);
            }
            player.cacheData.userGlobalBoss = userGlobalBoss;

            GlobalBossConfig config = StaticDatabase.entities.configs.globalBossConfig;


            List<TopReward> listTopRewardConfigs =
               MongoController.ConfigDb.GlobalBoss.GetData().top_rewards.OrderBy(a => a.index).ToList();

            DataGlobalBossResponseData responseData = new DataGlobalBossResponseData();
            responseData.total_damage = userGlobalBoss.total_damages;
            responseData.current_top_users = GlobalBossInfo.CurrentTopUsers;
            responseData.prev_top_users = GlobalBossInfo.PrevTopUsers;
            responseData.top_10_rewards = listTopRewardConfigs.OrderBy(a => a.index).ToList();
            responseData.time_attack = CommonFunc.GetCoolTimeSecond
            (
                userGlobalBoss.last_time_attack,
                config.attackConfigs[0].waitTime
            );

            // trong gio danh boss
            //CommonLog.Instance.PrintLog("GlobalBossInfo.StartTime: " + GlobalBossInfo.StartTime);
            //CommonLog.Instance.PrintLog("GlobalBossInfo.EndTime: " + GlobalBossInfo.EndTime);
            //CommonLog.Instance.PrintLog("DateTime.Now: " + DateTime.Now);
            if (GlobalBossInfo.StartTime <= DateTime.Now && GlobalBossInfo.EndTime >= DateTime.Now)
            {
                CommonLog.Instance.PrintLog("");
                responseData.time_boss = GlobalBossInfo.GetCoolDownTimeEndAttackBoss();
                responseData.in_time_attack_boss = true;
            }
            else // ngoai gio danh boss
            {
                responseData.in_time_attack_boss = false;
                double coolDownTimeAttackBoss = GlobalBossInfo.GetCoolDownTimeAttackBoss();
                responseData.time_boss = coolDownTimeAttackBoss;
            }

            responseData.maxBossHp = GlobalBossInfo.MaxBossHp;
            responseData.currentBossHp = GlobalBossInfo.BossHp;
            responseData.indexTimeAttackBoss = GlobalBossInfo.IndexTimeBoss;

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataGlobalBossOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
