
using GameServer.Common;
using GameServer.GlobalInfo;
using GameServer.ServerTimer.Core;
using GameServer.Database;
using System;
using System.Timers;

namespace GameServer.ServerTimer.Handler
{
    public class StartNewDayHandler : AbsTimeCounterHandler
    {
        public StartNewDayHandler(DateTime endTime)
            : base(endTime)
        {
        }

        public override void Handler(object sender, ElapsedEventArgs e)
        {
            DayOfWeek day = DateTime.Now.DayOfWeek;
            if (day == StaticDatabase.entities.configs.guildConfig.dayOfWeekBangChien)
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
                    CommonLog.Instance.PrintLog("Time start bang chien: " + timeStartBangChien);
                    StartBangChienHandler handler = new StartBangChienHandler(timeStartBangChien);
                    handler.Start(EndTimeEventListener);
                }
            }
            DateTime targetTime = DateTime.Today.AddDays(1);
            Restart(targetTime);
        }

        private void EndTimeEventListener(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            BangChienInfo.Instance.StartBangChien();
        }
    }
}
