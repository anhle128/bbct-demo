using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class SuKien7NgayNhanThuongLogCollection : AbsCollectionController<MSK7NgayNhanThuongLog>
    {
        public SuKien7NgayNhanThuongLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public MSK7NgayNhanThuongLog GetData(string userId, string suKienid)
        {
            return GetSingleData
            (
                a =>
                    a.user_id.Equals(userId)  &&
                    a.su_kien_id.Equals(suKienid)
            );
        }
    }
}
