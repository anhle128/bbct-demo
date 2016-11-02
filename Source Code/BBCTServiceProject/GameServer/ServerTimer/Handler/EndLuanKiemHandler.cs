using GameServer.Common;
using GameServer.GlobalInfo;
using GameServer.ServerTimer.Core;
using System;
using System.Timers;

namespace GameServer.ServerTimer.Handler
{
    public class EndLuanKiemHandler : AbsTimeCounterHandler
    {
        public EndLuanKiemHandler(DateTime endTime)
            : base(endTime)
        {
            CommonLog.Instance.PrintLog("time end luan kiem: " + endTime);

        }

        public override void Handler(object sender, ElapsedEventArgs e)
        {
            CommonLog.Instance.PrintLog("EndLuanKiemHandler running..........................");
            LuanKienInfo.RestartAndSendGift();
            Restart(CommonFunc.GetNextDay());
        }
    }
}
