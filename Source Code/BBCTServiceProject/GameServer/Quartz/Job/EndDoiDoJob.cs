using GameServer.Common;
using GameServer.GlobalInfo;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class EndDoiDoJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("Execute EndDoiDoJob");
            SuKienDoiDoInfo.EndSuKien();
        }
    }
}
