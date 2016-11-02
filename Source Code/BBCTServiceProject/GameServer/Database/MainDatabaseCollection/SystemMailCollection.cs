using System;
using System.Collections.Generic;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.MainDatabaseModels;

namespace GameServer.Database.MainDatabaseCollection
{
    public class SystemMailCollection : AbsCollectionController<MSystemMail>
    {
        public SystemMailCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
        }

        public List<MSystemMail> GetDatas()
        {
            return
                GetListDataDescending
                (
                    filter: a => a.created_at >= DateTime.Now.AddDays(-3),
                    skip: 0,
                    take: 100,
                    orderBy: a => a.created_at
                );
        }
    }
}
