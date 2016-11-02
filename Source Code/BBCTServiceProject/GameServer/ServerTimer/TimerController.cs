using GameServer.Common;
using GameServer.GlobalInfo;
using GameServer.ServerTimer.Handler;
using GameServer.Database;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Timers;

namespace GameServer.ServerTimer
{
    public class TimerController
    {
        #region Singleton
        private static TimerController instance;

        public static TimerController Instance
        {
            get
            {
                if (instance == null) instance = new TimerController();
                return instance;
            }
        }
        #endregion

        private static readonly object ObjectLokc = new object();
        public static bool IsStartCountEndTimeVongQuayMayMan = false;

        public static bool IsStartCountEndTimeSkDuaTopServer = false;

        public void Start()
        {
            try
            {
                //ThanThapInfo.Start();
                //EndTimeAttackThanThapHandler endTimeAttackThanThap =
                //    new EndTimeAttackThanThapHandler(ThanThapInfo.EndTime);
                //endTimeAttackThanThap.Start();

                //GlobalBossInfo.Start();
                //EndTimeAttackGlobalBossHandler endTimeAttackGlobalBossHandler =
                //    new EndTimeAttackGlobalBossHandler(GlobalBossInfo.EndTime);
                //endTimeAttackGlobalBossHandler.Start();

                //EndTimeBossGuildHandler endTimeBossGuildHandler =
                //    new EndTimeBossGuildHandler(StaticDatabase.entities.configs.guildConfig.GetDateTimeEndBoss());
                //endTimeBossGuildHandler.Start();

                //LuanKienInfo.Start();
                //EndLuanKiemHandler endLuanKiemHandler = new EndLuanKiemHandler(LuanKienInfo.EndTime);
                //endLuanKiemHandler.Start();


                CheckStartBangChien();


                //DateTime targetTimeSendQuaVipThang = new DateTime
                //(
                //        year: DateTime.Now.Year,
                //        month: DateTime.Now.Month,
                //        day: DateTime.Now.Day,
                //        hour: 0,
                //        minute: 0,
                //        second: 0
                //);
                //targetTimeSendQuaVipThang = targetTimeSendQuaVipThang.AddDays(1);

                ////DateTime targetTimeSendQuaVipThang = DateTime.Now.AddMinutes(2);

                //SendGiftPhucLoiThangHandler sendGiftPhucLoiThangHandler = new SendGiftPhucLoiThangHandler(targetTimeSendQuaVipThang);
                //sendGiftPhucLoiThangHandler.Start();

                // tính bảng xếp hạng
                //TimeCalculateBXHHandler timeCalculateBXH = new TimeCalculateBXHHandler(DateTime.Now.AddMinutes(15));
                //timeCalculateBXH.Start();

                //TimeSaveLoghandler timeSaveActionGoldLogHandler = new TimeSaveLoghandler(DateTime.Now.AddMinutes(2));
                //timeSaveActionGoldLogHandler.Start();

            }
            catch (Exception ex)
            {
                CommonLog.Instance.PrintLog(ex.ToString());
            }
        }

        private void CheckStartBangChien()
        {
            if (DateTime.Now.DayOfWeek == StaticDatabase.entities.configs.guildConfig.dayOfWeekBangChien)
            {
                DateTime timeStartBangChien = new DateTime
                (
                    DateTime.Now.Year,
                    DateTime.Now.Month,
                    DateTime.Now.Day,
                    StaticDatabase.entities.configs.guildConfig.hourStartBangChien.hour,
                    StaticDatabase.entities.configs.guildConfig.hourStartBangChien.minute,
                    0
                );
                if (DateTime.Now < timeStartBangChien)
                {
                    CommonLog.Instance.PrintLog("time start bang chien: " + timeStartBangChien);
                    StartBangChienHandler handler = new StartBangChienHandler(timeStartBangChien);
                    handler.Start(EndTimeEventListener);
                }
            }
            DateTime targetTime = DateTime.Today.AddDays(1);
            StartNewDayHandler startNewDayHandler = new StartNewDayHandler(targetTime);
            startNewDayHandler.Start();
        }

        private void EndTimeEventListener(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            BangChienInfo.Instance.StartBangChien();
        }

        //public void ScheduleEndTimeVongQuayMayMan(MSKVongQuayMayManConfig config)
        //{
        //    if (!IsStartCountEndTimeVongQuayMayMan)
        //    {
        //        IsStartCountEndTimeVongQuayMayMan = true;

        //        EndTimeVongQuayMayManHandler endTimeHandler = new EndTimeVongQuayMayManHandler(config.end)
        //        {
        //            config = config
        //        };
        //        endTimeHandler.Start();
        //    }
        //}

        //public void StartCountEndTimeSkDuaTopServer(MSKDuaTopServerConfig config)
        //{
        //    if (!IsStartCountEndTimeSkDuaTopServer)
        //    {
        //        IsStartCountEndTimeSkDuaTopServer = true;

        //        EndTimeSkDuaTopServerHandler endTimeHandler = new EndTimeSkDuaTopServerHandler(config.end)
        //        {
        //            config = config
        //        };
        //        endTimeHandler.Start();
        //    }
        //}
    }

}
