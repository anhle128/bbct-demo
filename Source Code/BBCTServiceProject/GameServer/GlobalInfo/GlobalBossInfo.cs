using DynamicDBModel.Models;
using ExitGames.Concurrency.Fibers;
using GameServer.Common;
using GameServer.Common.Enum;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.NotifyMessage;
using GameServer.Server;
using MongoDB.Bson;
using MongoDBModel.SubDatabaseModels;
using Photon.SocketServer;
using StaticDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.GlobalInfo
{
    public class GlobalBossInfo
    {
        #region Field
        private static int _bossLevel;
        private static double _bossHp;
        private static double _maxBossHp;
        private static string id;

        private static readonly object objectLock = new object();

        private static bool isWin = false;

        private static DateTime _startTime = DateTime.Today;
        private static DateTime _endTime = DateTime.Today;

        private static int _hashCodeEndTime;

        private static TopUsersGlobalBoss _prevTopUsers;
        private static TopUsersGlobalBoss _currentTopUsers;

        private static PoolFiber _poolFiber;

        public static int IndexTimeBoss;

        public static bool IsSendGift = false;
        #endregion

        #region Property
        public static DateTime StartTime
        {
            get { return _startTime; }
        }

        public static DateTime EndTime
        {
            get { return _endTime; }
        }

        public static TopUsersGlobalBoss PrevTopUsers
        {
            get { return _prevTopUsers; }
        }

        public static TopUsersGlobalBoss CurrentTopUsers
        {
            get { return _currentTopUsers; }
        }

        public static int BossLevel
        {
            get { return _bossLevel; }
        }

        public static double BossHp
        {
            get { return _bossHp; }
        }

        public static bool IsWin
        {
            get { return isWin; }
        }

        public static double MaxBossHp
        {
            get { return _maxBossHp; }
        }

        public static int HashCodeEndTime
        {
            get { return _hashCodeEndTime; }
        }
        #endregion

        public static void Start()
        {
            _poolFiber = new PoolFiber();
            _poolFiber.Start();
            DateTime timeNow = DateTime.Now;
            GlobalBossConfig config = StaticDatabase.entities.configs.globalBossConfig;

            MGlobalBossConfig mongoConfig = MongoController.ConfigDb.GlobalBoss.GetData();
            id = mongoConfig._id;
            _bossLevel = mongoConfig.level;
            _bossHp = config.hpBossAtLevel1 + (_bossLevel - 1) * config.growthHp;
            _maxBossHp = _bossHp;

            IndexTimeBoss = mongoConfig.current_index_boss;

            for (int i = IndexTimeBoss; i < config.timeAttackBoss.Length; i++)
            {
                IndexTimeBoss = i;
                TimeAttackBoss time = config.timeAttackBoss[i];
                DateTime endTime = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, time.end.hour, time.end.minute, 0);

                //end boss at current index time
                if (DateTime.Now > endTime)
                    continue;

                // right current index time
                _endTime = endTime;
                _startTime = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, time.start.hour, time.start.minute, 0);
                break;
            }
            CommonLog.Instance.PrintLog("end time attack boss: " + _endTime);
            // end time boss at this day
            // add time attack boss at the fist index of time attackbos at the next day
            if (_endTime < DateTime.Now)
            {
                timeNow = timeNow.AddDays(1);
                IndexTimeBoss = 0;

                TimeAttackBoss time = config.timeAttackBoss[IndexTimeBoss];

                _endTime = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, time.end.hour, time.end.minute, 0);
                _startTime = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, time.start.hour, time.start.minute, 0);

            }

            _currentTopUsers = new TopUsersGlobalBoss()
            {
                topUsers = new List<TopUserPrivateBoss>(),
                userKillBoss = null
            };

            _hashCodeEndTime = _endTime.GetHashCode();

            int prevHashCodeEndTime = CalculatePrevTimeEnd(IndexTimeBoss, _endTime).GetHashCode();
            _prevTopUsers =
                   MongoController.LogSubDB.TopGlobalBoss.GetTopUsersGlobalBoss(prevHashCodeEndTime);

            //CommonLog.Instance.PrintLog("time start global boss: " + _startTime);
        }

        public static void RestartAndSendGifts()
        {
            CommonLog.Instance.PrintLog("IsSendGift: " + IsSendGift);

            if (IsSendGift)
            {
                return;
            }

            lock (objectLock)
            {
                CommonLog.Instance.PrintLog("GlobalBoss - RestartAndSendGifts");

                SendGiftTopUsers();

                GlobalBossConfig config = StaticDatabase.entities.configs.globalBossConfig;

                IndexTimeBoss++;
                DateTime timeNow = DateTime.Now;

                // end time attack boss at this day
                // change timeNow and IndexTimeBoss
                CommonLog.Instance.PrintLog("IndexTimeBoss: " + IndexTimeBoss);
                CommonLog.Instance.PrintLog("config.timeAttackBoss.Length: " + config.timeAttackBoss.Length);
                if (IndexTimeBoss >= config.timeAttackBoss.Length)
                {
                    CommonLog.Instance.PrintLog("vao day nao");
                    timeNow = timeNow.AddDays(1);
                    IndexTimeBoss = 0;
                }

                // process start and end time with IndexTimeBoss and time now
                TimeAttackBoss time = config.timeAttackBoss[IndexTimeBoss];
                _endTime = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, time.end.hour, time.end.minute, 0);
                _startTime = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, time.start.hour, time.start.minute, 0);
                _hashCodeEndTime = _endTime.GetHashCode();
                CommonLog.Instance.PrintLog("next endTimeBoss: " + _endTime);
                _prevTopUsers = _currentTopUsers;
                _currentTopUsers = new TopUsersGlobalBoss()
                {
                    topUsers = new List<TopUserPrivateBoss>(),
                    userKillBoss = null
                };

                ResartBossLevelAndHp();

                IsSendGift = true;
            }
        }

        private static void ResartBossLevelAndHp()
        {
            GlobalBossConfig config = StaticDatabase.entities.configs.globalBossConfig;
            if (_bossHp == 0)
            {
                _bossLevel++;

            }
            else
            {
                if (_bossLevel > 1)
                    _bossLevel--;

            }
            MongoController.ConfigDb.GlobalBoss.UpdateLevel(id, _bossLevel, _hashCodeEndTime, IndexTimeBoss);

            _bossHp = config.hpBossAtLevel1 + (_bossLevel - 1) * config.growthHp;
        }

        private static void SendGiftTopUsers()
        {
            MGlobalBossConfig config = MongoController.ConfigDb.GlobalBoss.GetData();

            MongoController.UserDb.Mail.SendGiftGlobalBoss(_currentTopUsers, config);

            if (_currentTopUsers.userKillBoss != null)
            {
                NotifyMessageController.Instance.SendKillGlobalBoss(_currentTopUsers.userKillBoss.nickname);
            }
            if (_currentTopUsers.topUsers.Count > 0)
            {
                NotifyMessageController.Instance.SendTop1GlobalBoss(_currentTopUsers.topUsers[0].nickname);
            }

            // create log
            MTopGlobalBossLog log = new MTopGlobalBossLog()
            {
                hash_code_time = _hashCodeEndTime,
                top_users = _currentTopUsers.topUsers,
                user_kill_boss = _currentTopUsers.userKillBoss
            };
            MongoController.LogSubDB.TopGlobalBoss.Create(log);
        }

        public static void RefeshCurrentTopUsersAndHpBoss(string userid, string nickname, double totalDamage, double damage)
        {

            string strUserid = userid.ToString();

            _poolFiber.Enqueue(
            () =>
            {
                _bossHp = _bossHp - damage;
                if (_bossHp < 0)
                {
                    IsSendGift = false;
                    _bossHp = 0;

                    _currentTopUsers.userKillBoss = new TopUserPrivateBoss()
                    {
                        userid = strUserid,
                        nickname = nickname,
                        totalDamage = totalDamage
                    };
                }

                CommonLog.Instance.PrintLog("---------------------------------------------------------------");
                CommonLog.Instance.PrintLog("current hp boss: " + _bossHp);
                CommonLog.Instance.PrintLog(string.Format("userid: {0} - total damage: {1}", strUserid, totalDamage));
                CommonLog.Instance.PrintLog("---------------------------------------------------------------");
                if (_currentTopUsers.topUsers.Count < 10)
                {
                    TopUserPrivateBoss topUser = _currentTopUsers.topUsers.FirstOrDefault(a => a.userid == strUserid);
                    if (topUser == null)
                    {
                        _currentTopUsers.topUsers.Add
                       (
                           new TopUserPrivateBoss()
                           {
                               nickname = nickname,
                               userid = strUserid,
                               totalDamage = totalDamage
                           }
                       );
                    }
                    else
                    {
                        topUser.totalDamage = totalDamage;
                    }
                    _currentTopUsers.topUsers = _currentTopUsers.topUsers.OrderByDescending(a => a.totalDamage).ToList();
                }
                else if (_currentTopUsers.topUsers.Any(a => a.totalDamage < totalDamage))
                {
                    TopUserPrivateBoss topUser = _currentTopUsers.topUsers.FirstOrDefault(a => a.userid == strUserid);
                    if (topUser != null)
                    {
                        topUser.totalDamage = totalDamage;
                        _currentTopUsers.topUsers = _currentTopUsers.topUsers.OrderByDescending(a => a.totalDamage).ToList();
                    }
                    else
                    {
                        topUser = new TopUserPrivateBoss()
                        {
                            userid = strUserid,
                            nickname = nickname,
                            totalDamage = totalDamage
                        };
                        _currentTopUsers.topUsers.Add(topUser);
                        _currentTopUsers.topUsers = _currentTopUsers.topUsers.OrderByDescending(a => a.totalDamage).Skip(0).Take(10).ToList();
                    }
                }
                if (_bossHp == 0)
                {
                    CommonLog.Instance.PrintLog("_bossHp == 0");

                    Dictionary<byte, object> subParam = new Dictionary<byte, object>();
                    subParam.Add(1, "Boss thế giới đã bị tiêu diệt");
                    GameController.Instance.FireEvent(null, new SendParameters(),
                        (byte)EventCode.BossDeath, new Dictionary<byte, object>(), subParam);

                    RestartAndSendGifts();
                }
            });
        }

        public static bool AllowAttack()
        {
            return DateTime.Now >= _startTime && DateTime.Now < _endTime && _bossHp > 0 ? true : false;
        }

        public static double GetCoolDownTimeAttackBoss()
        {
            return (_startTime - DateTime.Now).TotalSeconds > 0
                ? (_startTime - DateTime.Now).TotalSeconds
                : 0;
        }

        private static DateTime CalculatePrevTimeEnd(int indexTimeAttackBoss, DateTime timeEndBoss)
        {
            // đầu ngày đánh boss
            if (indexTimeAttackBoss == 0)
            {
                return new DateTime
                (
                    timeEndBoss.Year,
                    timeEndBoss.Month,
                    timeEndBoss.AddDays(-1).Day,
                    StaticDatabase.entities.configs.globalBossConfig.timeAttackBoss.Last().end.hour,
                    StaticDatabase.entities.configs.globalBossConfig.timeAttackBoss.Last().end.minute,
                    0
                );
            }
            else
            {
                return new DateTime
                (
                    timeEndBoss.Year,
                    timeEndBoss.Month,
                    timeEndBoss.Day,
                    StaticDatabase.entities.configs.globalBossConfig.timeAttackBoss[indexTimeAttackBoss - 1].end.hour,
                    StaticDatabase.entities.configs.globalBossConfig.timeAttackBoss[indexTimeAttackBoss - 1].end.minute,
                    0
                );
            }
        }

        public static double GetCoolDownTimeEndAttackBoss()
        {
            return _endTime > DateTime.Now ? (_endTime - DateTime.Now).TotalSeconds : 0;

        }
    }
}
