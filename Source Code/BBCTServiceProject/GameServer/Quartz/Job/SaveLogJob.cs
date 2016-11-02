using GameServer.Common;
using GameServer.Database.Controller;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class SaveLogJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            MongoController.LogDb.ActionGold.SaveLogs();
        }
    }
}
