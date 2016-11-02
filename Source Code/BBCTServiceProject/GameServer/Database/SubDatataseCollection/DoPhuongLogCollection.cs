using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class DoPhuongLogCollection : AbsCollectionController<MDoPhuongLog>
    {
        public DoPhuongLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public int Count(string userid)
        {
            return
                CountData
                (
                    a =>
                        a.hash_code_time == CommonFunc.GetHashCodeTime() &&
                        a.user_id.Equals(userid)
                );
        }
    }
}
