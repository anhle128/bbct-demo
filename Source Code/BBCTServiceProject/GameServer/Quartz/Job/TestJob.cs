using Quartz;

namespace GameServer.Quartz.Job
{
    public class TestJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            //CommonLog.Instance.PrintLog("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        }
    }
}
