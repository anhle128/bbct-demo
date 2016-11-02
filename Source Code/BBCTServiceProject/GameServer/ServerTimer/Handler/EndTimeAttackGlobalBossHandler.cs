using GameServer.GlobalInfo;
using GameServer.ServerTimer.Core;
using System;
using System.Timers;

namespace GameServer.ServerTimer.Handler
{
    class EndTimeAttackGlobalBossHandler : AbsTimeCounterHandler
    {
        public EndTimeAttackGlobalBossHandler(DateTime endTime)
            : base(endTime)
        {
        }

        public override void Handler(object sender, ElapsedEventArgs e)
        {
            GlobalBossInfo.RestartAndSendGifts();
            Restart(GlobalBossInfo.EndTime);
        }
    }
}
