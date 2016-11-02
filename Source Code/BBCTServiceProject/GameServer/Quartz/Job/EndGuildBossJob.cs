using System.Collections.Generic;
using GameServer.Common;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using Quartz;

namespace GameServer.Quartz.Job
{
    public class EndGuildBossJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("Execute EndGuildBossJob");
            List<MGuild> guilds = MongoController.GuildDb.Guild.GetDatas();
            List<MBossGuildLog> listBosstGuildLog = MongoController.LogSubDB.BossGuildLog.GetDatas();
            List<MGuildMember> listGuildMembers = MongoController.GuildDb.GuildMember.GetDatas();

            MongoController.UserDb.Mail.SendGiftGuildBoss(guilds, listBosstGuildLog, listGuildMembers);
        }
    }
}
