using GameServer.Common;
using GameServer.GlobalInfo;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class EndLuanKiemJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("Execute EndLuanKiemJob");
            LuanKienInfo.RestartAndSendGift();
        }
    }
}
