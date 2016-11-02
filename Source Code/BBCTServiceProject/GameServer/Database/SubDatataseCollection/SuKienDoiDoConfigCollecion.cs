using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Threading.Tasks;

namespace GameServer.Database.SubDatataseCollection
{
    public class SuKienDoiDoConfigCollecion : AbsCollectionController<MSKDoiDoConfig>
    {
        public SuKienDoiDoConfigCollecion(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public MSKDoiDoConfig GetData()
        {
            return GetSingleData
            (
                a =>
                    a.status == Status.Activate &&
                    DateTime.Now >= a.start &&
                    DateTime.Now <= a.end &&
                    a.server_id == Settings.Instance.server_id
            );
        }

        public MSKDoiDoConfig GetData(string suKienId)
        {
            return GetSingleData
            (
                a => a._id.Equals(suKienId)

            );
        }

        public async Task<bool> CheckActivate()
        {
            int count = await CountDataAsync(a =>
                DateTime.Now >= a.start &&
                DateTime.Now <= a.end &&
                a.server_id == Settings.Instance.server_id &&
                a.status == Status.Activate);
            return count > 1 ? true : false;
        }
    }
}
