using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Common;
using GameServer.Database;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class CheckAttackBangChienJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("Execute CheckAttackBangChienJob");
            DayOfWeek day = DateTime.Now.DayOfWeek;
            if (day == StaticDatabase.entities.configs.guildConfig.dayOfWeekBangChien)
            {
                int hourStartBangChien = StaticDatabase.entities.configs.guildConfig.hourStartBangChien.hour;
                int minuteStartBangChien = StaticDatabase.entities.configs.guildConfig.hourStartBangChien.minute;

                DateTime timeStartBangChien = new DateTime
                (
                    DateTime.Now.Year, 
                    DateTime.Now.Hour, 
                    DateTime.Now.Minute,
                    hourStartBangChien, 
                    minuteStartBangChien,
                    0
                );

                if(DateTime.Now > timeStartBangChien)
                    return;

                CommonLog.Instance.PrintLog("Time start bang chien: " + timeStartBangChien);
                QuartzManager.Instance.ScheduleAttackBangChien(timeStartBangChien);
            }
        }
    }
}
