using GameServer.ServerTimer.Core;
using GameServer.Database.Controller;
using System;
using System.Timers;

namespace GameServer.ServerTimer.Handler
{
    public class TimeSaveLoghandler : AbsTimeCounterHandler
    {
        public TimeSaveLoghandler(DateTime endTime)
            : base(endTime)
        {
        }

        public override void Handler(object sender, ElapsedEventArgs e)
        {
            MongoController.LogDb.ActionGold.SaveLogs();
            //MongoController.LogDb.ChieuMo.SaveLogs();
            //MongoController.LogDb.Request.SaveLogs();
            Restart(DateTime.Now.AddMinutes(2));
        }
    }
}
