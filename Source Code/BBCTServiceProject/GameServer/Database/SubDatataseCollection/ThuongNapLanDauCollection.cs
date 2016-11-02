﻿
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class ThuongNapLanDauCollection : AbsCollectionController<MThuongNapLanDauConfig>
    {
        public ThuongNapLanDauCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public MThuongNapLanDauConfig GetData()
        {
            return GetSingleData(a => a.server_id == Settings.Instance.server_id);
        }
    }
}
