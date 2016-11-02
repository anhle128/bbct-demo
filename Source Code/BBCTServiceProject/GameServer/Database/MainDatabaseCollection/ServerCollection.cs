using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.MainDatabaseModels;

namespace GameServer.MainServer.Database.MainDatabaseCollection
{
    public class ServerCollection : AbsCollectionController<MServer>
    {

        public ServerCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
        }

        public MServer GetServer(string server_id)
        {
            MServer server = GetSingleData(a => a._id.Equals(server_id));
            return server;
        }
    }
}
