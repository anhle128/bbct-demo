using System;
using GameServer.Common;
using GameServer.GlobalInfo;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class EndGlobalBossJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("Execute EndGlobalBossJob");
            GlobalBossInfo.RestartAndSendGifts();
            GlobalBossInfo.IsSendGift = false;
        }
    }
}
