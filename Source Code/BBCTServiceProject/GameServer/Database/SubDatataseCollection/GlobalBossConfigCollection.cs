using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class GlobalBossConfigCollection : AbsCollectionController<MGlobalBossConfig>
    {
        public GlobalBossConfigCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public MGlobalBossConfig GetData()
        {
            return GetSingleData(a => a.server_id.Equals(Settings.Instance.server_id));
        }

        public void UpdateLevel(string id, int level, int hashCodeTimeEndBoss, int currentIndexBoss)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"level",level},
                {"hash_code_time_end_boss",hashCodeTimeEndBoss},
                 {"current_index_boss",currentIndexBoss},
            };
            UpdateFields(id, dictData);
        }
    }
}
