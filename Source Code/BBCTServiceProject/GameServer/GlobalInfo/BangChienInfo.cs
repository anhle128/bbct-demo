

using GameServer.Database;
using GameServer.Database.Controller;
using System;
using System.Timers;
using GameServer.Common;
using GameServer.Quartz;
using GameServer.Quartz.Job;
using Quartz;

namespace GameServer.GlobalInfo
{

    public class BangChienInfo
    {
        #region Singletion
        private static BangChienInfo _instance;

        public static BangChienInfo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BangChienInfo();
                }
                return _instance;
            }
        }
        #endregion

        private int _countTimeStart = 0;
        private int _countTimeEnd = 0;

        public void StartBangChien()
        {
            CommonLog.Instance.PrintLog("StartBangChien");
            if (_countTimeStart < 3)
            {
                DateTime timeEndBangChien =
                    DateTime.Now.AddMinutes(StaticDatabase.entities.configs.guildConfig.minuteDurationBattleBangChien);

                QuartzManager.Instance.ScheduleEndAttackBangChien(timeEndBangChien);

                _countTimeStart++;

                StartHandler(_countTimeStart);
            }
        }

        public void EndAttackBangChien()
        {
            DateTime waitTimeNextBangChien =
                DateTime.Now.AddMinutes(StaticDatabase.entities.configs.guildConfig.waitTimeBangChien);

            QuartzManager.Instance.ScheduleWaitBangChien(waitTimeNextBangChien);

            _countTimeEnd++;

            EndHandler(_countTimeEnd);
        }

        public void EndWaitTimeBangChien()
        {
            StartBangChien();
        }

        public void StartHandler(int time)
        {
            MongoController.GuildDb.BattleBangChien.ProcessStartBangChien(time);
        }

        public void EndHandler(int time)
        {
            MongoController.GuildDb.BattleBangChien.ProcessEndBangChien(time);
        }
    }
}
