using GameServer.ServerTimer.Core;
using GameServer.Database;
using GameServer.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Timers;

namespace GameServer.ServerTimer.Handler
{
    public class EndTimeBossGuildHandler : AbsTimeCounterHandler
    {
        public EndTimeBossGuildHandler(DateTime endTime)
            : base(endTime)
        {
        }

        public override void Handler(object sender, ElapsedEventArgs e)
        {
            List<MGuild> guilds = MongoController.GuildDb.Guild.GetDatas();
            List<MBossGuildLog> listBosstGuildLog = MongoController.LogSubDB.BossGuildLog.GetDatas();
            List<MGuildMember> listGuildMembers = MongoController.GuildDb.GuildMember.GetDatas();

            MongoController.UserDb.Mail.SendGiftGuildBoss(guilds, listBosstGuildLog, listGuildMembers);
            Restart(StaticDatabase.entities.configs.guildConfig.GetDateTimeEndBoss());
        }
    }
}
