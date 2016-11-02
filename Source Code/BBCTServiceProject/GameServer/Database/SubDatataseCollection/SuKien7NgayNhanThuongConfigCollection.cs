using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Threading.Tasks;

namespace GameServer.Database.SubDatataseCollection
{
    public class SuKien7NgayNhanThuongConfigCollection : AbsCollectionController<MSK7NgayNhanThuongConfig>
    {
        public SuKien7NgayNhanThuongConfigCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public async Task<bool> CheckActivate()
        {
            int count = await CountDataAsync(a =>
                DateTime.Now >= a.start &&
                DateTime.Now <= a.end &&
                a.server_id.Equals(Settings.Instance.server_id) &&
                a.status == Status.Activate);
            return count > 0;
        }

        public MSK7NgayNhanThuongConfig GetData()
        {
            return GetSingleData
            (
                a =>
                    a.status == Status.Activate &&
                    DateTime.Now >= a.start &&
                    DateTime.Now <= a.end &&
                    a.server_id.Equals(Settings.Instance.server_id)
            );
        }
    }
}
