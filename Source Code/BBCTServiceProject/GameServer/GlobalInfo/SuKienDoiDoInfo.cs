
using DynamicDBModel.Models;
using ExitGames.Concurrency.Fibers;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace GameServer.GlobalInfo
{
    public class SuKienDoiDoInfo
    {
        private static bool _duration;
        private static DateTime _startTime;
        private static DateTime _endTime;
        private static TopUserDoiDo[] _topUser;
        private static int _sizeTopUser;
        private static string _suKienId;
        private static PoolFiber _poolFiber;
        private static List<TopRewardDoiDo> topRewards;

        private static readonly object ObjectLock = new object();

        public static bool IsStartCountEndTime = false;

        public static bool Duration
        {
            get
            {
                return _duration;
            }
        }

        public static DateTime StartTime
        {
            get { return _startTime; }
        }

        public static DateTime EndTime
        {
            get { return _endTime; }
        }

        public static TopUserDoiDo[] TopUser
        {
            get { return _topUser; }
        }

        public static string SuKienId
        {
            get { return _suKienId; }
        }

        public static void EndSuKien()
        {
            MSKDoiDoConfig config = MongoController.ConfigDb.SkDoiDo.GetData(_suKienId);
            MongoController.UserDb.Mail.SendMailTopSuKienDoiDo(_topUser, config.top_rewards);

            _topUser = new TopUserDoiDo[config.top_rewards.Count];
            IsStartCountEndTime = false;
            _duration = false;

        }

        public static void CheckStartSuKienDoiDo(MSKDoiDoConfig config)
        {

            if (_poolFiber == null)
            {
                _poolFiber = new PoolFiber();
                _poolFiber.Start();
            }

            if (_duration)
                return;

            _suKienId = config._id;
            _duration = true;

            topRewards = config.top_rewards;
            _sizeTopUser = config.top_rewards.Count;

            _startTime = config.start;
            _endTime = config.end;

            _topUser = MongoController.LogSubDB.SkDoiDo.GetTopUser(config._id, config.top_rewards);
            if (_topUser == null)
            {
                _topUser = new TopUserDoiDo[config.top_rewards.Count];
            }
            else
            {
                ChangeTopUser();
            }

            _duration = true;

        }

        //private static void StartCountDownEndSuKien()
        //{
        //    CommonLog.Instance.PrintLog("Start count down end su kien doi do");
        //    endSuKienHandler = new EndSuKienDoiDoHandler(_endTime);
        //    endSuKienHandler.Start();
        //}

        public static void RefeshCurrentTopUsers(MSKDoiDoLog log)
        {
            if (!_duration)
                return;

            _poolFiber.Enqueue
            (
                () =>
                {
                    try
                    {
                        if (topRewards.Last().point_require > log.total_point)
                            return;

                        if (_topUser.Any(a => a != null && a.userid == log.user_id.ToString()))
                        {
                            _topUser.Single(a => a != null && a.userid == log.user_id.ToString()).total_point = log.total_point;
                            _topUser = ChangeTopUser();
                        }
                        else
                        {
                            TopUserDoiDo topLog = new TopUserDoiDo()
                            {
                                userid = log.user_id.ToString(),
                                total_point = log.total_point,
                                nickname = log.nickname,
                                avatar = log.avatar
                            };
                            _topUser = ChangeTopUser(topLog);
                            //CommonLog.Instance.PrintLog("Done here");
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            );
        }

        private static TopUserDoiDo[] ChangeTopUser(TopUserDoiDo log)
        {
            TopUserDoiDo topLog = new TopUserDoiDo()
            {
                userid = log.userid,
                total_point = log.total_point,
                nickname = log.nickname,
                avatar = log.avatar
            };
            List<TopUserDoiDo> listLog = _topUser.ToList();
            listLog.Add(topLog);
            listLog = listLog.OrderByDescending(a => a.total_point).ToList();

            return ChangeTopUserFromList(listLog);
        }

        private static TopUserDoiDo[] ChangeTopUser()
        {
            List<TopUserDoiDo> listResult = _topUser.Where(a => a != null).OrderByDescending(a => a.total_point).ToList();
            return ChangeTopUserFromList(listResult);
        }

        private static TopUserDoiDo[] ChangeTopUserFromList(List<TopUserDoiDo> litData)
        {
            TopUserDoiDo[] arrData = new TopUserDoiDo[topRewards.Count];
            foreach (var log in litData)
            {
                for (int i = 0; i < topRewards.Count; i++)
                {
                    TopRewardDoiDo topReward = topRewards[i];

                    if (log.total_point >= topReward.point_require)
                    {
                        if (arrData[i] == null)
                        {
                            arrData[i] = log;
                            break;
                        }
                        else
                        {
                            if (arrData[i].total_point < log.total_point)
                            {
                                arrData[i] = log;
                                break;
                            }
                        }
                    }
                }
            }

            TopUserDoiDo[] arrResult = new TopUserDoiDo[topRewards.Count];
            for (int i = 0; i < topRewards.Count; i++)
            {
                if (arrData[i] == null)
                    continue;
                TopUserDoiDo top = new TopUserDoiDo()
                {
                    userid = arrData[i].userid,
                    total_point = arrData[i].total_point,
                    nickname = arrData[i].nickname,
                    avatar = arrData[i].avatar
                };
                arrResult[i] = top;
            }
            return arrResult;
        }
    }
}
