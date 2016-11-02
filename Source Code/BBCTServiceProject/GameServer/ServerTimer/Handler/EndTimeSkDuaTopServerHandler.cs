using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.GlobalInfo;
using GameServer.ServerTimer.Core;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GameServer.ServerTimer.Handler
{
    class EndTimeSkDuaTopServerHandler : AbsTimeCounterHandler
    {
        public MSKDuaTopServerConfig config { get; set; }

        public EndTimeSkDuaTopServerHandler(DateTime endTime)
            : base(endTime)
        {
            CommonLog.Instance.PrintLog("EndTimeSkDuaTopServerHandler: " + endTime);
        }

        public override void Handler(object sender, ElapsedEventArgs e)
        {
            List<TopUser>[] arrTopUsers = BangXepHangInfo.GetTopUsers(true);
            MongoController.ConfigDb.SkDuaTopServer.UpdateTopPlayer(config._id, arrTopUsers);

            if (arrTopUsers[0].Any() && config.top_level_rewards.Any())
            {
                MongoController.UserDb.Mail.SendGiftTopLevelDuaTopServer(arrTopUsers[0], config.top_level_rewards);
            }

            if (arrTopUsers[1].Any() && config.top_power_rewards.Any())
            {
                MongoController.UserDb.Mail.SendGiftTopPowerDuaTopServer(arrTopUsers[1], config.top_power_rewards);
            }

            TimerController.IsStartCountEndTimeSkDuaTopServer = false;
        }
    }
}