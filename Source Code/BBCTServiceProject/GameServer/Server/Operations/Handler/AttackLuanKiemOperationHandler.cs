using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using GameServer.Battle;
using GameServer.Common;
using GameServer.Common.Core;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.RequestData;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Enum;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class AttackLuanKiemOperationHandler : IOperationHandler
    {

        private static readonly object lockObject = new object();

        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {
            ActionPlayerRequestData requestData = new ActionPlayerRequestData();
            requestData.Deserialize(operationRequest.Parameters);


            int countTimesAttack = MongoController.LogSubDB.LuanKiem.CountAttackTimes(player.cacheData.info._id);
            VipConfig vip = StaticDatabase.entities.configs.vipConfigs[player.cacheData.vip];
            if (countTimesAttack >= vip.arenaTimes)
            {
                Item luanKiemLenh = StaticDatabase.entities.items.Single(a => a.type == (int)TypeItem.LuanKiemLenh);
                MUserItem userItem =
                    player.cacheData.listUserItem.FirstOrDefault
                    (
                        a =>
                            a.quantity >= 1 &&
                            a.static_id == luanKiemLenh.id
                    );
                if (userItem == null)
                    return CommonFunc.SimpleResponse(operationRequest, ReturnCode.DoesNotEnoughItem);

                userItem.quantity--;
                MongoController.UserDb.Item.UpdateQuantity(userItem);
            }

            // process
            MUserInfo userOpponent = MongoController.UserDb.Info.GetData((requestData.userid));
            player.cacheData.lastTimeAttackLuanKiem = DateTime.Now;
            MongoController.UserDb.Info.UpdateLastTimeAttackLuanKiem(player.cacheData);

            if (player.cacheData.rankLuanKiem <= userOpponent.rank_luan_kiem)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.InvalidData);

            MLuanKiemLog log = new MLuanKiemLog()
            {
                user = new UserLuanKiem()
                {
                    userid = player.cacheData.info._id.ToString(),
                    nickname = player.cacheData.nickname,
                    old_rank = player.cacheData.rankLuanKiem,
                    new_rank = player.cacheData.rankLuanKiem
                },
                hash_code_time = CommonFunc.GetHashCodeTime(),
                outcome = OutcomeResult.Lose,
                user_opponent = new UserLuanKiem()
                {
                    userid = userOpponent._id.ToString(),
                    nickname = userOpponent.nickname,
                    new_rank = userOpponent.rank_luan_kiem,
                    old_rank = userOpponent.rank_luan_kiem
                }
            };

            MongoController.LogSubDB.NhiemVuHangNgay.SaveLogNhiemVu(player.cacheData.info._id, TypeNhiemVuHangNgay.AttackLuanKiem);

            BattleProcessor processor = new BattleProcessor();
            BattleSimulator.Battle battleSim = processor.BattlePvp
            (
               player.cacheData,
               userOpponent._id
            );

            log.battle_replay = ProtoBufSerializerHelper.Handler().Serialize(battleSim.replay);

            List<RewardItem> listRewardResult = null;
            List<SubRewardItem> listReward = null;

            if (battleSim.result == 2) // Player win
            {
                lock (lockObject)
                {
                    MUserInfo userInfo = MongoController.UserDb.Info.GetData(player.cacheData.info._id);
                    if (userInfo.rank_luan_kiem != player.cacheData.rankLuanKiem)
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.RankChanged);

                    userOpponent = MongoController.UserDb.Info.GetData((log.user_opponent.userid));
                    if (userOpponent.rank_luan_kiem != log.user_opponent.old_rank)
                        return CommonFunc.SimpleResponse(operationRequest, ReturnCode.RankChanged);

                    log.outcome = OutcomeResult.Win;
                    player.cacheData.rankLuanKiem = log.user_opponent.old_rank;
                    log.user.new_rank = log.user_opponent.old_rank;
                    log.user_opponent.new_rank = log.user.old_rank;

                    userInfo.rank_luan_kiem = log.user.new_rank;
                    userOpponent.rank_luan_kiem = log.user_opponent.new_rank;

                    if (!userOpponent.isBot)
                        MongoController.UserDb.Mail.SendMailAttackedLuanKiem(player.cacheData.nickname, userOpponent._id, userOpponent.rank_luan_kiem);

                    MongoController.UserDb.Info.UpdateRank(userInfo);
                    MongoController.UserDb.Info.UpdateRank(userOpponent);

                    GamePlayer opponentPlayer = GameController.Instance.GetUserOnline((log.user_opponent.userid));

                    if (opponentPlayer != null)
                    {
                        opponentPlayer.cacheData.rankLuanKiem = log.user_opponent.new_rank;
                    }

                    MongoController.LogSubDB.LuanKiem.Create(log);

                    listReward =
                      CommonFunc.RandomSubRewardItem(StaticDatabase.entities.configs.luanKiemConfig.winRewards);
                }
            }
            else
            {
                MongoController.LogSubDB.LuanKiem.Create(log);

                listReward =
                    CommonFunc.RandomSubRewardItem(StaticDatabase.entities.configs.luanKiemConfig.loseRewards);
            }

            listRewardResult = MongoController.UserDb.UpdateReward
            (
                player.cacheData,
                listReward,
                ReasonActionGold.RewardAttackLuanKiem
            );

            RewardResponseData responseData = new RewardResponseData()
            {
                rewards = listRewardResult,
                replay = battleSim.replay
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };

        }
    }
}
