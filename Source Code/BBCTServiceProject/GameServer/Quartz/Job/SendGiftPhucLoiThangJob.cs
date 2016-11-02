using GameServer.Common;
using GameServer.Database;
using GameServer.Database.Controller;
using MongoDB.Bson;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class SendGiftPhucLoiThangJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("Execute SendGiftPhucLoiThangJob");

            string[] arrUserId= MongoController.UserDb.PhucLoiThang.GetUserActivate();
            MongoController.UserDb.Mail.SendGiftPhucLoiThang(arrUserId, StaticDatabase.entities.configs.phucLoiThangConfig.rewards);
        }
    }
}
