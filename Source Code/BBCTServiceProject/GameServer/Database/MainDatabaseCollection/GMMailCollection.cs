using DynamicDBModel.Models;
using GameServer.Common;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.MainDatabaseModels;

namespace GameServer.Database.MainDatabaseCollection
{
    public class GMMailCollection : AbsCollectionController<MGMMail>
    {
        public GMMailCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
        }

        protected override void SetDefaultValue(MGMMail data)
        {
            data.status = Status.Deactivate;
        }

        public int CountMailSent(string userid)
        {
            return CountData(
                 a =>
                     a.user_id.Equals(userid) && a.hash_code_time == CommonFunc.GetHashCodeTime());
        }

        public void Create(string userid, SystemMail mail)
        {
            MGMMail gmMail = new MGMMail()
            {
                user_id = userid,
                content = mail.content,
                title = mail.title,
                hash_code_time = CommonFunc.GetHashCodeTime()
            };
            Create(gmMail);
        }
    }
}
