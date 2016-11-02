using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using GameServer.ServerTimer.Core;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace GameServer.ServerTimer.Handler
{
    class EndTimeVongQuayMayManHandler : AbsTimeCounterHandler
    {
        public MSKVongQuayMayManConfig config { get; set; }

        public EndTimeVongQuayMayManHandler(DateTime endTime)
            : base(endTime)
        {
            CommonLog.Instance.PrintLog("EndTimeVongQuayMayManHandler: " + endTime);
        }

        public override void Handler(object sender, ElapsedEventArgs e)
        {
            CommonLog.Instance.PrintLog("EndTimeVongQuayMayManHandler running..........................");
            SuKienInfo.SetDeactiveSuKien(TypeSuKien.VongQuayMayMan);
            TimerController.IsStartCountEndTimeVongQuayMayMan = false;

            List<TopUserVongQuayMayMan> listTop =
                MongoController.LogSubDB.SkVongQuayMayMan.GetTopUsers(config._id);

            if (listTop.Any() && config.top_rewards.Any())
            {
                MongoController.UserDb.Mail.SendGiftTopVongQuayMayMan(listTop, config.top_rewards);
            }
        }
    }
}
