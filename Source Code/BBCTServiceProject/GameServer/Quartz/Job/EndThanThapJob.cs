using GameServer.Common;
using GameServer.GlobalInfo;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class EndThanThapJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("Execute EndThanThapJob");

            // reset thần tháp
            ThanThapInfo.SendGiftAndRestart();
        }
    }
}
