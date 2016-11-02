using GameServer.Common;
using GameServer.GlobalInfo;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class WaitBangChienJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("Execute WaitBangChienJob");
           BangChienInfo.Instance.EndWaitTimeBangChien();
        }
    }
}
