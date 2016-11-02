using GameServer.GlobalInfo;
using GameServer.ServerTimer.Core;
using System;
using System.Timers;

namespace GameServer.ServerTimer.Handler
{
    class WaitTimeStartCheckSuKien : AbsTimeCounterHandler
    {
        public WaitTimeStartCheckSuKien(DateTime endTime)
            : base(endTime)
        {
        }

        public override void Handler(object sender, ElapsedEventArgs e)
        {
            SuKienInfo.CheckSuKien();
            Restart(DateTime.Now.AddMinutes(15));
        }
    }
}
