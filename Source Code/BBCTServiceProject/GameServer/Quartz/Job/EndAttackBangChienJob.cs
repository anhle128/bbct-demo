using System;
using GameServer.Common;
using GameServer.GlobalInfo;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class EndAttackBangChienJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("Execute EndAttackBangChienJob");
            BangChienInfo.Instance.EndAttackBangChien();
        }
    }
}
