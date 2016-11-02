using DynamicDBModel.Models;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class BangChienCollection : AbsCollectionController<MBangChien>
    {
        public BangChienCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public List<MBangChien> GetDatas(BangChien.State stage)
        {
            return GetListData
            (
                x =>
                    x.server_id.Equals(Settings.Instance.server_id) &&
                    x.state == stage
            );
        }

        public MBangChien GetData(BangChien.State stage)
        {
            return GetSingleData
            (
                x =>
                    x.server_id.Equals(Settings.Instance.server_id) &&
                    x.state == stage
            );
        }
    }
}
