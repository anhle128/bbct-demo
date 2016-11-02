using GameServer.Common;
using GameServer.GlobalInfo;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class CalculateBXHJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            BangXepHangInfo.Start();
        }
    }
}
