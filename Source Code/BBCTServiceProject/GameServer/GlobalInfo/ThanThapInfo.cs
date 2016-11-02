using DynamicDBModel.Models;
using ExitGames.Concurrency.Fibers;
using GameServer.Common;
using GameServer.Database;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.GlobalInfo
{
    public class ThanThapInfo
    {
        private static DateTime _endTime;
        private static List<TopUserThanThap> _prevTopUsers;
        private static List<TopUserThanThap> _currentTopUsers;

        private static int _endTimeHashCode;
        private static int _prevTimeHashCode;

        private static PoolFiber _poolFiber;

        public static DateTime EndTime
        {
            get { return _endTime; }
        }

        public static List<TopUserThanThap> PrevTopUsers
        {
            get { return _prevTopUsers; }
        }

        public static List<TopUserThanThap> CurrentTopUsers
        {
            get { return _currentTopUsers; }
        }

        public static void Start()
        {
            _poolFiber = new PoolFiber();
            _poolFiber.Start();

            CaculateEndTime();
            _prevTopUsers = MongoController.LogSubDB.TopThanThap.GetTopUsersInServer(_prevTimeHashCode, 10);
            _currentTopUsers = MongoController.UserDb.ThanThap.GetTopUsers(10, _endTimeHashCode).Select(a => a.user).ToList();
        }

        public static void SendGiftAndRestart()
        {
            SendGift();
            CaculateEndTime();
            _prevTopUsers = _currentTopUsers;
            _currentTopUsers = new List<TopUserThanThap>();
        }

        private static void CaculateEndTime()
        {
            int hourEnd = StaticDatabase.entities.configs.thanThapConfig.hourEnd;

            _endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hourEnd, 0, 0);

            if (DateTime.Now > _endTime)
            {
                _prevTimeHashCode = _endTime.GetHashCode();
                _endTime = _endTime.AddDays(1);
            }
            else
            {
                _prevTimeHashCode = _endTime.AddDays(-1).GetHashCode();
            }
            _endTimeHashCode = _endTime.GetHashCode();


            //_endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hourEnd, 0, 0).AddDays(-1);
            //_prevTimeHashCode = _endTime.AddDays(-1).GetHashCode();
            //_endTimeHashCode = _endTime.GetHashCode();
            CommonLog.Instance.PrintLog("ThanThapInfo _endTimeHashCode: " + _endTimeHashCode);

        }

        public static void AddUserToTop(MUserThanThap userThanThap)
        {
            _poolFiber.Enqueue(() =>
            {
                TopUserThanThap topUser = _currentTopUsers.FirstOrDefault(a => a.userid.Equals(userThanThap.user_id.ToString()));
                if (topUser != null)
                {
                    topUser.floor = userThanThap.floor;
                    _currentTopUsers = _currentTopUsers.OrderByDescending(a => a.floor).Skip(0).Take(10).ToList();
                }
                else
                {
                    if (_currentTopUsers.Count < 10)
                    {
                        _currentTopUsers.Add(new TopUserThanThap()
                        {
                            userid = userThanThap.user_id.ToString(),
                            star = userThanThap.star,
                            floor = userThanThap.floor,
                            avatar = userThanThap.avatar,
                            group_id = Settings.Instance.group_id,
                            nickname = userThanThap.nickname,
                            total_day_in_top = ProcessTotalDayInTop(userThanThap)
                        });
                        _currentTopUsers = _currentTopUsers.OrderByDescending(a => a.floor).Skip(0).Take(10).ToList();
                    }
                    else if (_currentTopUsers.Any(a => a.floor <= userThanThap.floor))
                    {
                        _currentTopUsers.Add(new TopUserThanThap()
                        {
                            userid = userThanThap.user_id.ToString(),
                            star = userThanThap.star,
                            floor = userThanThap.floor,
                            avatar = userThanThap.avatar,
                            group_id = Settings.Instance.group_id,
                            nickname = userThanThap.nickname,
                            total_day_in_top = ProcessTotalDayInTop(userThanThap)
                        });
                        _currentTopUsers = _currentTopUsers.OrderByDescending(a => a.floor).Skip(0).Take(10).ToList();
                    }
                }
            });
        }


        private static void SendGift()
        {
            foreach (var currentTop in _currentTopUsers)
            {
                currentTop.total_day_in_top++;
            }

            List<TopReward> listTopReward =
                MongoController.ConfigDb.ThanThap.GetListTopRewards();

            MongoController.UserDb.Mail.SendGiftThanThap(_currentTopUsers, listTopReward);

            List<MTopThanPhapLog> listThanPhapLogs = _currentTopUsers.Select(currentTop => new MTopThanPhapLog()
            {
                server_id = Settings.Instance.server_id,
                hash_code_time = _endTimeHashCode,
                user = currentTop

            }).ToList();

            // create log
            MongoController.LogSubDB.TopThanThap.CreateAll(listThanPhapLogs);
        }



        private static int ProcessTotalDayInTop(MUserThanThap userThanThap)
        {
            TopUserThanThap topUserThanThap = _prevTopUsers.FirstOrDefault(a => a.userid.Equals(userThanThap.user_id.ToString()));

            if (topUserThanThap == null)
                return 0;
            else
                return topUserThanThap.total_day_in_top;
        }

        public static int GetHashTimeEnd()
        {
            return _endTimeHashCode;
        }

        public static int GetPrevHashTimeEnd()
        {
            return _prevTimeHashCode;
        }
    }
}
