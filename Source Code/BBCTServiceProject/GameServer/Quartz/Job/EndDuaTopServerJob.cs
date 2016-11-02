using System;
using System.Collections.Generic;
using System.Linq;
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.GlobalInfo;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class EndDuaTopServerJob : IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("Execute EndDuaTopServerJob");
            List<TopUser>[] arrTopUsers = BangXepHangInfo.GetTopUsers(true);

            MSKDuaTopServerConfig config = SuKienInfo.duaTopEndd;

            MongoController.ConfigDb.SkDuaTopServer.UpdateTopPlayer(config._id, arrTopUsers);

            if (arrTopUsers[0].Any() && config.top_level_rewards.Any())
            {
                MongoController.UserDb.Mail.SendGiftTopLevelDuaTopServer(arrTopUsers[0], config.top_level_rewards);
            }

            if (arrTopUsers[1].Any() && config.top_power_rewards.Any())
            {
                MongoController.UserDb.Mail.SendGiftTopPowerDuaTopServer(arrTopUsers[1], config.top_power_rewards);
            }
        }
    }
}
