using GameServer.Common;
using GameServer.GlobalInfo;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class AttackBangChien : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("AttackBangChien Execute");
            BangChienInfo.Instance.StartBangChien();
        }
    }
}
