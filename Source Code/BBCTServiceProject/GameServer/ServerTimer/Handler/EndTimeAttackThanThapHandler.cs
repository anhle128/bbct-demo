using GameServer.Common;
using GameServer.GlobalInfo;
using GameServer.ServerTimer.Core;
using System;
using System.Timers;

namespace GameServer.ServerTimer.Handler
{
    public class EndTimeAttackThanThapHandler : AbsTimeCounterHandler
    {
        public EndTimeAttackThanThapHandler(DateTime endTime)
            : base(endTime)
        {
            CommonLog.Instance.PrintLog("EndTimeAttackThanThapHandler: " + endTime.ToString());
        }

        public override void Handler(object sender, ElapsedEventArgs e)
        {
            CommonLog.Instance.PrintLog("EndTimeAttackThanThapHandler running..........................");
            // reset thần tháp
            ThanThapInfo.SendGiftAndRestart();
            Restart(ThanThapInfo.EndTime);
        }
    }
}
