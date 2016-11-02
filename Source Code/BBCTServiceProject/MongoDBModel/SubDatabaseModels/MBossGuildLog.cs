using MongoDB.Bson;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MBossGuildLog : IUserDataModel
    {
        public string guild_id;
        public double dmg;
        public int attack_times;
        public int hash_code_time;
        public string server_id;
    }
}
