using GameServer.Common;
using GameServer.GlobalInfo;
using GameServer.ServerTimer.Core;
using System;
using System.Timers;

namespace GameServer.ServerTimer.Handler
{
    class EndSuKienDoiDoHandler : AbsTimeCounterHandler
    {
        public EndSuKienDoiDoHandler(DateTime endTime)
            : base(endTime)
        {
            CommonLog.Instance.PrintLog("EndSuKienDoiDoHandler: " + endTime);
        }

        public override void Handler(object sender, ElapsedEventArgs e)
        {
            CommonLog.Instance.PrintLog("EndSuKienDoiDoHandler running...........................");
            SuKienDoiDoInfo.EndSuKien();
        }
    }
}
