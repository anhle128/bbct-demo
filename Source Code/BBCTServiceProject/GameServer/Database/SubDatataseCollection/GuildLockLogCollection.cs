using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class GuildLockLogCollection : AbsCollectionController<MGuildLockLog>
    {
        public GuildLockLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public MGuildLockLog GetData(string userid)
        {
            return GetSingleData(x => x.user_id.Equals(userid));
        }
    }
}
