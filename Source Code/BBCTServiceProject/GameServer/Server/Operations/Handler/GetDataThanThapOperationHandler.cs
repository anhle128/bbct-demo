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
using System.Collections.Generic;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataThanThapOperationHandler : IOperationHandler
    {
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            ThanThapConfig thanThapConfig = StaticDatabase.entities.configs.thanThapConfig;
            if (player.cacheData.info.level < thanThapConfig.levelRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            MUserThanThap userThanThap =
                MongoController.UserDb.ThanThap.GetData(player.cacheData.info._id, ThanThapInfo.GetHashTimeEnd());
            if (userThanThap == null)
            {
                // calculate bonus attribute
                MUserThanThap lastTimeAttackThanThap =
                    MongoController.UserDb.ThanThap.GetData(player.cacheData.info._id,
                        ThanThapInfo.GetPrevHashTimeEnd());
                int allBonusAttribute = 0;
                if (lastTimeAttackThanThap != null)
                {
                    allBonusAttribute = lastTimeAttackThanThap.floor / 4;
                }
                player.cacheData.info.all_bonus_than_thap_attributes = allBonusAttribute;
                MongoController.UserDb.Info.UpdateBonusThanThap(player.cacheData.info._id, allBonusAttribute);

                // create data than thap
                userThanThap = new MUserThanThap()
                {
                    user_id = player.cacheData.info._id,
                    hash_code_time = ThanThapInfo.GetHashTimeEnd(),
                    nickname = player.cacheData.info.nickname,
                    floor = 1,
                    bonus_attributes = new int[4] { 0, 0, 0, 0 },
                    monsters = CommonFunc.GetRandomMoster(),
                    dead = false,
                    avatar = player.cacheData.info.avatar
                };
                MongoController.UserDb.ThanThap.Create(userThanThap);
            }
            player.cacheData.thanThapAttacked = userThanThap;

            List<TopReward> listTopRewardConfigs =
                MongoController.ConfigDb.ThanThap.GetListTopRewards();

            DataThanThapResponseData responseData = new DataThanThapResponseData()
            {
                all_bonus_tran_phap_attribute = player.cacheData.info.all_bonus_than_thap_attributes,
                floor = userThanThap.floor,
                reset_attack_times = userThanThap.reset_times,
                top_10_rewards = listTopRewardConfigs,
                priv_top_users = ThanThapInfo.PrevTopUsers,
                bonus_attributes = userThanThap.bonus_attributes,
                bonus_attributes_selection = userThanThap.bonus_attributes_selection,
                monster = userThanThap.monsters,
                dead = userThanThap.dead,
                star = userThanThap.star
            };

            // response
            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "OperationResponse done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
