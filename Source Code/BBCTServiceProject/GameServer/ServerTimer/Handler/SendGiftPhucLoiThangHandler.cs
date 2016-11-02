using GameServer.Common;
using GameServer.Database;
using GameServer.Database.Controller;
using GameServer.ServerTimer.Core;
using MongoDB.Bson;
using System;
using System.Timers;

namespace GameServer.ServerTimer.Handler
{
    public class SendGiftPhucLoiThangHandler : AbsTimeCounterHandler
    {
        private DateTime _targetSendTime;

        public SendGiftPhucLoiThangHandler(DateTime endTime)
            : base(endTime)
        {
            _targetSendTime = endTime;
            CommonLog.Instance.PrintLog("SendGiftPhucLoiThangHandler: " + _targetSendTime);

        }

        public override void Handler(object sender, ElapsedEventArgs e)
        {
            CommonLog.Instance.PrintLog("SendGiftPhucLoiThangHandler-------------------");

            string[] arrUserId = MongoController.UserDb.PhucLoiThang.GetUserActivate();
            MongoController.UserDb.Mail.SendGiftPhucLoiThang(arrUserId, StaticDatabase.entities.configs.phucLoiThangConfig.rewards);

            Restart(CommonFunc.GetNextDay());
        }
    }
}
