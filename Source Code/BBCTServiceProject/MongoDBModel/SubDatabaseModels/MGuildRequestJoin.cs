using MongoDB.Bson;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MGuildRequestJoin : IUserDataModel
    {
        public string guild_id;
        public string server_id;
    }
}
