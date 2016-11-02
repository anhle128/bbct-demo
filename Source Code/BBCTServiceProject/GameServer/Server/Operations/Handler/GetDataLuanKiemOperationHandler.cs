using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Common.SerializeData.ResponseData;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.Server.Operations.Core;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Server.Operations.Handler
{
    public class GetDataLuanKiemOperationHandler : IOperationHandler
    {
        private string currentUserId;
        public OperationResponse Handler(GamePlayer player, OperationRequest operationRequest, SendParameters sendParameters,
            OperationController controller)
        {

            LuanKiemConfig config = StaticDatabase.entities.configs.luanKiemConfig;
            if (player.cacheData.level < config.levelRequire)
                return CommonFunc.SimpleResponse(operationRequest, ReturnCode.LevelNotEnough);

            currentUserId = player.cacheData.id.ToString();

            int countAttackTimes = MongoController.LogSubDB.LuanKiem.CountAttackTimes(player.cacheData.id);

            List<PlayerLuanKiem> listPlayers = GetLuanKiemPlayers(player);
            List<LuanKiemLog> listLogs = GetDataChienBao(player);
            List<LuanKiemLog> listLogTop10 = GetDataChienBapTop10();

            double coolTime = CommonFunc.GetCoolTimeSecond(player.cacheData.lastTimeAttackLuanKiem,
                StaticDatabase.entities.configs.luanKiemConfig.GetSecondCoolDownAttack());

            DataLuanKiemResponse responseData = new DataLuanKiemResponse()
            {
                currentRank = player.cacheData.rankLuanKiem,
                pointLuanKiem = player.cacheData.pointLuanKiem,
                attackTimes = countAttackTimes,
                players = listPlayers,
                logs = listLogs,
                top10Logs = listLogTop10,
                cooldownAttack = coolTime
            };

            return new OperationResponse()
            {
                OperationCode = operationRequest.OperationCode,
                DebugMessage = "GetDataLuanKiemOperationHandler done!",
                Parameters = responseData.Serialize(),
                ReturnCode = (short)ReturnCode.OK
            };
        }

        private List<LuanKiemLog> GetDataChienBapTop10()
        {
            List<MLuanKiemLog> listLog = MongoController.LogSubDB.LuanKiem.GetChienBaoTop10();
            if (listLog.Count > 0)
                return listLog.Select(a => new LuanKiemLog()
                {
                    _id = a._id.ToString(),
                    ountcome = a.outcome,
                    time = a.created_at,
                    typeAttack = TypeLuanKiemAttack.Attack,
                    user = a.user,
                    userOpponent = a.user_opponent
                }).ToList();
            return null;
        }

        private List<PlayerLuanKiem> GetLuanKiemPlayers(GamePlayer player)
        {
            List<PlayerLuanKiem> listPlayers = new List<PlayerLuanKiem>();

            if (player.cacheData.rankLuanKiem <= 4)
            {
                listPlayers = GetTopPlayerLuanKiem(4);
            }
            else if (player.cacheData.rankLuanKiem <= 11)
            {
                listPlayers.Add(new PlayerLuanKiem()
                {
                    username = player.cacheData.username,
                    nickname = player.cacheData.nickname,
                    rank = player.cacheData.rankLuanKiem,
                    avatar = player.cacheData.avatar,
                    level = player.cacheData.level,
                    vip = player.cacheData.vip
                });

                listPlayers.AddRange(GetRandomLuanKiemPlayer(player.cacheData.rankLuanKiem - 1));
                listPlayers = listPlayers.OrderByDescending(a => a.rank).ToList();
            }
            else
            {
                listPlayers.Add(new PlayerLuanKiem()
                {
                    username = player.cacheData.username,
                    nickname = player.cacheData.nickname,
                    rank = player.cacheData.rankLuanKiem,
                    avatar = player.cacheData.avatar,
                    level = player.cacheData.level,
                    vip = player.cacheData.vip
                });

                Add3LuanKiemOpponentPlayer(player, listPlayers);
            }
            return listPlayers.OrderBy(a => a.rank).ToList();
        }


        private List<LuanKiemLog> GetDataChienBao(GamePlayer player)
        {
            List<MLuanKiemLog> dataAllLuanKiemLogs = MongoController.LogSubDB.LuanKiem.GetChienBaoLogs(player.cacheData.id);
            // delete log
            //if (dataAllLuanKiemLogs.CoundLogInDay > 10)
            //{
            //    DateTime lastTimeLog = dataAllLuanKiemLogs.Last().created_at;
            //    MongoController.LogSubDB.LuanKiem.DeleteAll
            //    (
            //        a =>
            //            a.user.userid == Player.cacheData.userid &&
            //            a.created_at <= lastTimeLog &&
            //            a.server_id == Settings.Instance.server_id
            //            ||
            //            a.user_opponent.userid == Player.cacheData.userid &&
            //            a.created_at <= lastTimeLog &&
            //            a.server_id == Settings.Instance.server_id
            //    );
            //}
            //MLuanKiemLog lastChangeLuanKiem = dataAllLuanKiemLogs.FirstOrDefault();
            //if (lastChangeLuanKiem != null)
            //    if (lastChangeLuanKiem.user.userid == Player.cacheData.userid)
            //    {
            //        Player.cacheData.rankLuanKiem = lastChangeLuanKiem.user.new_rank;
            //    }
            //    else
            //    {
            //        Player.cacheData.rankLuanKiem = lastChangeLuanKiem.user_opponent.new_rank;
            //    }

            return ConvertToListLuanKiemLog(dataAllLuanKiemLogs);
        }

        private void Add3LuanKiemOpponentPlayer(GamePlayer player, List<PlayerLuanKiem> listPlayers)
        {
            RangeLuanKiemOpponent rangeConfig =
                StaticDatabase.entities.configs.luanKiemConfig.rangeOpponent.First(
                    a => a.range.start <= player.cacheData.rankLuanKiem &&
                         a.range.end >= player.cacheData.rankLuanKiem);
            for (int i = 0; i < rangeConfig.rangeOpponent.Length; i++)
            {
                Range range = rangeConfig.rangeOpponent[i];
                bool validUser = true;
                int count = 0;
                do
                {
                    count++;
                    int rankRandom = range.start != range.end
                        ? CommonFunc.RandomNumber(range.start, range.end, player.cacheData.rankLuanKiem)
                        : player.cacheData.rankLuanKiem - range.start;
                    if (listPlayers.All(a => a.rank != rankRandom))
                    {
                        MUserInfo userInfo =
                            MongoController.UserDb.Info.GetData(rankRandom);
                        if (userInfo == null)
                        {
                            validUser = false;
                            CommonLog.Instance.PrintLog("invalid rank: " + rankRandom);
                        }
                        else
                        {
                            listPlayers.Add(GetPlayerLuanKiem(userInfo));
                        }
                    }
                } while (!validUser || count >= 10);
            }
        }

        private PlayerLuanKiem GetPlayerLuanKiem(MUserInfo userInfo)
        {
            PlayerLuanKiem playerLuanKiem = new PlayerLuanKiem();
            playerLuanKiem.username = userInfo.username;
            playerLuanKiem.nickname = userInfo.nickname;
            playerLuanKiem.rank = userInfo.rank_luan_kiem;
            playerLuanKiem.avatar = userInfo.avatar;
            playerLuanKiem.levelAvatar =
                MongoController.UserDb.Char.GetData(userInfo._id, userInfo.avatar).star_level;
            playerLuanKiem.level = userInfo.level;
            playerLuanKiem.vip = userInfo.vip;
            playerLuanKiem.data = MongoController.UserDb.GetSubDataPlayer(userInfo);
            return playerLuanKiem;
        }

        private List<PlayerLuanKiem> GetTopPlayerLuanKiem(int top)
        {
            List<PlayerLuanKiem> listPlayers = new List<PlayerLuanKiem>();
            List<MUserInfo> listUserInfo =
                MongoController.UserDb.Info.GetTopPlayersLuanKiem(top);


            listPlayers = ConvertToListPlayerLuanKiem(listUserInfo);
            return listPlayers.OrderBy(a => a.rank).ToList();
        }

        private List<PlayerLuanKiem> GetRandomLuanKiemPlayer(int highestRank)
        {
            List<PlayerLuanKiem> listPlayers = new List<PlayerLuanKiem>();
            List<MUserInfo> listUserInfo =
                MongoController.UserDb.Info.GetRandomWithRank(highestRank);
            listPlayers = ConvertToListPlayerLuanKiem(listUserInfo);
            return listPlayers.OrderBy(a => a.rank).ToList();
        }

        private List<PlayerLuanKiem> ConvertToListPlayerLuanKiem(List<MUserInfo> listUserInfo)
        {
            List<PlayerLuanKiem> listResult = new List<PlayerLuanKiem>();
            foreach (var userInfo in listUserInfo)
            {
                PlayerLuanKiem playerLuanKiem = new PlayerLuanKiem()
                {
                    username = userInfo.username,
                    nickname = userInfo.nickname,
                    rank = userInfo.rank_luan_kiem,
                    avatar = userInfo.avatar,
                    level = userInfo.level,
                    vip = userInfo.vip

                };
                if (userInfo.username != currentUserId)
                {
                    playerLuanKiem.data = MongoController.UserDb.GetSubDataPlayer(userInfo);
                    playerLuanKiem.levelAvatar =
                        MongoController.UserDb.Char.GetData(userInfo._id, userInfo.avatar).star_level;
                }
                listResult.Add(playerLuanKiem);
            }
            return listResult;
        }

        private List<LuanKiemLog> ConvertToListLuanKiemLog(List<MLuanKiemLog> listLogData)
        {
            List<LuanKiemLog> listResult = new List<LuanKiemLog>();
            foreach (var data in listLogData)
            {
                LuanKiemLog log = new LuanKiemLog();
                log._id = data._id.ToString();
                if (data.user.userid == currentUserId)
                {
                    log.user = data.user;
                    log.userOpponent = data.user_opponent;
                    log.typeAttack = TypeLuanKiemAttack.Attack;
                }
                else
                {
                    log.user = data.user_opponent;
                    log.userOpponent = data.user;
                    log.typeAttack = TypeLuanKiemAttack.Defend;
                }
                log.ountcome = data.outcome;
                log.time = data.created_at;
                listResult.Add(log);
            }
            return listResult;
        }

    }
}
