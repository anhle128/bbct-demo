
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class SuKienTranhMuaServerLogCollection : AbsCollectionController<MSkTranhMuaServerLog>
    {
        public SuKienTranhMuaServerLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public MSkTranhMuaServerLog GetData(string userId, string suKienId, int day)
        {
            return GetSingleData
            (
                a =>
                    a.user_id == userId &&
                    a.su_kien_id == suKienId &&
                    a.day == day
            );
        }

        public MSkTranhMuaServerLog GetDataAllServer(string userId, string suKienId, int day)
        {
            return GetSingleData
            (
                a =>
                    a.user_id == userId &&
                    a.su_kien_id == suKienId &&
                    a.day == day
            );
        }
    }
}
