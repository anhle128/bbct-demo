using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDBModel.Enum;
using MongoDBModel.Implement;

namespace MongoDBModel.MainDatabaseModels
{
    public class MGiftCodeCategory : IMongoModel
    {
        public string name { get; set; }
        public GiftCodeType type { get; set; }
        public string server_id { get; set; }
        public SubRewardItem[] rewards { get; set; }
    }
}
