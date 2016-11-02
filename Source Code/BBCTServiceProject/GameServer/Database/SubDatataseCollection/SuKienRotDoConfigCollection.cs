
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Threading.Tasks;

namespace GameServer.Database.SubDatataseCollection
{
    public class SuKienRotDoConfigCollection : AbsCollectionController<MSKRotDoConfig>
    {
        public SuKienRotDoConfigCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public MSKRotDoConfig GetData()
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

        public async Task<bool> CheckActivate()
        {
            int count = await CountDataAsync(a =>
                DateTime.Now >= a.start &&
                DateTime.Now <= a.end &&
                a.server_id.Equals(Settings.Instance.server_id) &&
                a.status == Status.Activate);
            return count > 0;
        }
    }
}
