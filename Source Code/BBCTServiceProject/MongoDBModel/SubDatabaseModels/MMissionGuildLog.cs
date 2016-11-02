using MongoDB.Bson;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MMissionGuildLog : IUserTimeDataModel
    {
        public string guild_id;
        public int index_mission;
        public bool is_finish;
    }
}
