using System;
using System.Diagnostics;
using GameServer.Common;
using GameServer.GlobalInfo;
using GameServer.Quartz.Job;
using GameServer.Database;
using MongoDBModel.SubDatabaseModels;
using Quartz;
using Quartz.Impl;
using StaticDB.Models;

namespace GameServer.Quartz
{
    public class QuartzManager
    {
        #region Singleton
        private static QuartzManager _instance;

        public static QuartzManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new QuartzManager();
                }
                return _instance;
            }
        }
        #endregion

        private ISchedulerFactory _schedFact;
        private IScheduler _sched;

        public void StartSchedule()
        {

            if (_sched == null)
            {
                // construct a scheduler factory
                _schedFact = new StdSchedulerFactory();

                // get a scheduler
                _sched = _schedFact.GetScheduler();
                _sched.Start();
            }
            else
            {
                _sched.Clear();

                // get a scheduler
                _sched = _schedFact.GetScheduler();
                _sched.Start();
            }

            CommonLog.Instance.PrintLog("QuartzManager StartSchedule");

            RunScheduleEveryDay<SendGiftPhucLoiThangJob>("send-gift-phuc-loi-thang-job", TimeOfDay.HourAndMinuteOfDay(0,0));

            DateTime timeEndGlobalBoss = StaticDatabase.entities.configs.guildConfig.GetDateTimeEndBoss();
            RunScheduleEveryDay<EndGuildBossJob>("end-guild-boss-job", TimeOfDay.HourAndMinuteOfDay(timeEndGlobalBoss.Hour, timeEndGlobalBoss.Minute));

            ThanThapInfo.Start();
            RunScheduleEveryDay<EndThanThapJob>("end-than-thap-job", TimeOfDay.HourAndMinuteOfDay(StaticDatabase.entities.configs.thanThapConfig.hourEnd,0));

            LuanKiemConfig luanKiemConfig = StaticDatabase.entities.configs.luanKiemConfig;
            RunScheduleEveryDay<EndLuanKiemJob>("end-luan-kiem", TimeOfDay.HourAndMinuteOfDay(luanKiemConfig.hourSendGift.hour, luanKiemConfig.hourSendGift.minute));

            GlobalBossInfo.Start();
            GlobalBossConfig globalBossConfig = StaticDatabase.entities.configs.globalBossConfig;
            ScheduleEndTimeGlobalBoss(globalBossConfig.timeAttackBoss);

            RunScheduleEveryMinite<CalculateBXHJob>("calculate-bxh", 15);

            RunScheduleEveryMinite<SaveLogJob>("save-log", 5);

            RunScheduleEveryMinite<CheckSuKienJob>("check-su-kien-activate", 15);


            GuildConfig guildConfig = StaticDatabase.entities.configs.guildConfig;
            RunScheduleEveryWeek<StartBangChienJob>("start-bang-chien-time",guildConfig.dayOfWeekBangChien,TimeOfDay.HourAndMinuteOfDay(guildConfig.hourStartBangChien.hour, guildConfig.hourStartBangChien.minute));


            RunScheduleEveryDay<ReloadStaticDatabaseJob>("reload-static-database-1", TimeOfDay.HourAndMinuteOfDay(15, 0));
            RunScheduleEveryDay<ReloadStaticDatabaseJob>("reload-static-database-2", TimeOfDay.HourAndMinuteOfDay(3, 0));
        }

        public void ScheduleEndTimeGlobalBoss(TimeAttackBoss[] timeAttackBosses)
        {
            for (int i = 0; i < timeAttackBosses.Length; i++)
            {
                TimeAttackBoss timeAttackBoss = timeAttackBosses[i];
                string identity = "end-global-boss-" + i;
                RunScheduleEveryDay<EndGlobalBossJob>(identity, TimeOfDay.HourAndMinuteOfDay(timeAttackBoss.end.hour, timeAttackBoss.end.minute));
            }
        }

        public void ScheduleEndTimeVongQuayMayMan(MSKVongQuayMayManConfig config)
        {
            string identity = "end-vong-quay-may-man";

            if (_sched.CheckExists(JobKey.Create(identity)))
                return;

            RunSchedule<EndVongQuayMayManJob>(identity,config.end);
        }

        public void ScheduleEndTimeDuaTopServer(MSKDuaTopServerConfig config)
        {
            string identity = "dua-top-server";

            if (_sched.CheckExists(JobKey.Create(identity)))
                return;

            RunSchedule<EndDuaTopServerJob>(identity,config.end);
        }

        public void ScheduleAttackBangChien(DateTime timeJob)
        {
            string identity = "attack-bang-chien";

            DeleteJob(identity);

            RunSchedule<AttackBangChien>(identity,timeJob);
        }

        public void ScheduleEndAttackBangChien(DateTime timeJob)
        {
            string identity = "end-attack-bang-chien";

            DeleteJob(identity);
           
            RunSchedule<EndAttackBangChienJob>(identity,timeJob);
        }

        public void ScheduleWaitBangChien(DateTime timeJob)
        {
            string identity = "wait-bang-chien";

            DeleteJob(identity);
            
            RunSchedule<WaitBangChienJob>(identity, timeJob);
        }

        public void ScheduleEndDoiDo(MSKDoiDoConfig config)
        {
            string identity = "end-doi-do";

            if(_sched.CheckExists(JobKey.Create(identity)))
                return;

            RunSchedule<EndDoiDoJob>(identity,config.end);
        }


        #region Helper

        private void RunScheduleEveryDay<T>(string identity, TimeOfDay timeOfDay) where T : IJob
        {
            DeleteJob(identity);

            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(identity)
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity(identity)
              .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(timeOfDay.Hour, timeOfDay.Minute))
              .Build();

            _sched.ScheduleJob(job, trigger);
        }


        private void RunScheduleEveryWeek<T>(string identity, DayOfWeek dayOfWeek, TimeOfDay timeOfDay) where T : IJob
        {
            DeleteJob(identity);

            CommonLog.Instance.PrintLog(string.Format("RunScheduleEveryWeek day {0} - hour {1} - minute {2}", dayOfWeek, timeOfDay.Hour, timeOfDay.Minute));

            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(identity)
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(identity)
                .StartNow()
                .WithSchedule(CronScheduleBuilder.WeeklyOnDayAndHourAndMinute(dayOfWeek,timeOfDay.Hour,timeOfDay.Minute))
                .Build();

            _sched.ScheduleJob(job, trigger);
        }

        private void RunScheduleEveryMinite<T>(string identity, int minute) where T : IJob
        {
            DeleteJob(identity);

            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(identity)
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity(identity)
              .StartNow()
               .WithSimpleSchedule(a => a.WithIntervalInMinutes(minute).RepeatForever())
              .Build();

            _sched.ScheduleJob(job, trigger);
        }

        private void RunScheduleEverySecond<T>(string identity, int second) where T : IJob
        {
            DeleteJob(identity);

            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(identity)
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity(identity)
              .StartNow()
                .WithSimpleSchedule(a => a.WithIntervalInSeconds(second).RepeatForever())
              .Build();

            _sched.ScheduleJob(job, trigger);
        }

        private void RunSchedule<T>(string identity, DateTime jobTime) where T : IJob
        {
            if (jobTime.Minute == 59)
                jobTime = jobTime.AddMinutes(1);

            identity = identity + "-" + jobTime;

            CommonLog.Instance.PrintLog("create job: " + identity);

            if(_sched.CheckExists(JobKey.Create(identity)))
                return;

            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(identity)
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity(identity)
              .WithDailyTimeIntervalSchedule
                (
                    a => 
                    a.StartingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(jobTime.Hour,jobTime.Minute,jobTime.Second)).EndingDailyAfterCount(1)
                )
              .Build();

            _sched.ScheduleJob(job, trigger);
        }

        private void DeleteJob(string identity)
        {
            JobKey key = JobKey.Create(identity);
            if (_sched.CheckExists(key))
                _sched.DeleteJob(key);
        } 
        #endregion
    }
}
