using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Common;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class ReloadStaticDatabaseJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("Execute ReloadStaticDatabaseJob");
            CommonFunc.LoadStaticDBAndStartTimeCounter();
        }
    }
}
