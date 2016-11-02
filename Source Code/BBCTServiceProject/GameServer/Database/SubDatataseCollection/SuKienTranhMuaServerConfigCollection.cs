
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Threading.Tasks;

namespace GameServer.Database.SubDatataseCollection
{
    public class SuKienTranhMuaServerConfigCollection : AbsCollectionController<MSKTranhMuaServerConfig>
    {
        public SuKienTranhMuaServerConfigCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
        }

        public async Task<bool> CheckActivate()
        {
            int count = await CountDataAsync(a =>
                DateTime.Now >= a.start &&
                DateTime.Now <= a.end &&
                a.status == Status.Activate);
            return count == 1 ? true : false;
        }

        public MSKTranhMuaServerConfig GetData()
        {
            return GetSingleData
            (
                a =>
                    a.status == Status.Activate &&
                    DateTime.Now >= a.start &&
                    DateTime.Now <= a.end
            );
        }
    }
}
