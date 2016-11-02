
using MongoDBModel.Implement;

namespace MongoDBModel.MainDatabaseModels
{
    public class MServer : IMongoModel
    {
        public string group_id;
        public bool is_main;
        public string name;
        public int status;
        public MPhotonConnection photon_connection;
        public MMongoConnection mongo_connection;
    }
}
