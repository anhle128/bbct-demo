using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class ContributeGuildLogCollection : AbsCollectionController<MContributeGuildLog>
    {
        public ContributeGuildLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public void UpdateTime(string id)
        {
            var data = new Dictionary<string, object>(1)
            {
                { "created_at", DateTime.Now }
            };
            UpdateFields(id, data);
        }

        public MContributeGuildLog GetData(string userid)
        {
            return GetSingleData(x => x.user_id.Equals(userid));
        }
    }
}
