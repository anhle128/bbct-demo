using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.GlobalInfo;
using MongoDBModel.SubDatabaseModels;
using Quartz;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Quartz.Job
{
    public class EndVongQuayMayManJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            CommonLog.Instance.PrintLog("Execute EndVongQuayMayManJob");

            SuKienInfo.SetDeactiveSuKien(TypeSuKien.VongQuayMayMan);

            MSKVongQuayMayManConfig config = SuKienInfo.vongQuayMayManEnd;

            List<TopUserVongQuayMayMan> listTop =
                MongoController.LogSubDB.SkVongQuayMayMan.GetTopUsers(config._id);

            if (listTop.Any() && config.top_rewards.Any())
            {
                MongoController.UserDb.Mail.SendGiftTopVongQuayMayMan(listTop, config.top_rewards);
            }
        }
    }
}
