
using GameServer.GlobalInfo;
using GameServer.ServerTimer.Core;
using System;
using System.Timers;

namespace GameServer.ServerTimer.Handler
{
    public class TimeCalculateBXHHandler : AbsTimeCounterHandler
    {
        public TimeCalculateBXHHandler(DateTime endTime)
            : base(endTime)
        {
            BangXepHangInfo.Start();
        }

        public override void Handler(object sender, ElapsedEventArgs e)
        {
            BangXepHangInfo.Start();
            Restart(DateTime.Now.AddMinutes(15));
        }
    }
}
