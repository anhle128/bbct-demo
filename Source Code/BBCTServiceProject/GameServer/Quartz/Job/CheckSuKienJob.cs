using GameServer.Common;
using GameServer.GlobalInfo;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class CheckSuKienJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            SuKienInfo.CheckSuKien();
        }
    }
}
