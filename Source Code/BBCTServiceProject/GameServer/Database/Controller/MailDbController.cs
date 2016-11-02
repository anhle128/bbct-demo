
using DynamicDBModel.Models;
using GameServer.Database.MainDatabaseCollection;
using MongoDB.Driver;
using MongoDBModel.MainDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.Controller
{
    public class MailDbController
    {
        private readonly SystemMailCollection _system;

        public SystemMailCollection System
        {
            get { return _system; }
        }

        public GMMailCollection Gm
        {
            get { return _gm; }
        }

        private readonly GMMailCollection _gm;

        public MailDbController(IMongoDatabase database)
        {
            _system = new SystemMailCollection("system_mails", database);
            _gm = new GMMailCollection("gm_mails", database);
        }

        public List<SystemMail> GetSystemMails()
        {
            List<MSystemMail> listSystemMails =
                MongoController.MailDb.System.GetDatas();
               
            return (from a in listSystemMails
                    select new SystemMail()
                        {
                            content = a.content,
                            title = a.title,
                            time = a.created_at
                        }).ToList();
        }
    }
}
