using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class SuKienThanTaiLogCollection : AbsCollectionController<MSKThanTaiLog>
    {
        public SuKienThanTaiLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }


        public MSKThanTaiLog GetData(string userid, string suKienId)
        {
            return
                GetSingleData
                (
                    a =>
                        a.user_id.Equals(userid) &&
                        a.sk_kien_id == suKienId
                );
        }
    }
}
