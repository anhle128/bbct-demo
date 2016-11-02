using MongoDB.Bson;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MGuild : IUserDataModel
    {
        public string name;
        public int level;
        public int contribution;
        public string notice;
        public int tmp_contribution;
        public string server_id;
    }
}
