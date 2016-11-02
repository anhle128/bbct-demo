using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDBModel.Enum;
using MongoDBModel.Implement;

namespace MongoDBModel.MainDatabaseModels
{
    public class MGiftCodeLog : IUserDataModel
    {
        public string gift_code { get; set; }
        public string category { get; set; }
        public GiftCodeType type { get; set; }
        public SubRewardItem[] rewards { get; set; }
    }
}
