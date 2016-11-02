using MongoDB.Bson;
using MongoDBModel.Implement;

namespace MongoDBModel.MainDatabaseModels
{
    public class MUserProblemGoldLog : IUserDataModel
    {
        public int user_gold { get; set; }
        public int new_gold_in_db { get; set; }
        public string action_gold_log_id { get; set; }
    }
}
