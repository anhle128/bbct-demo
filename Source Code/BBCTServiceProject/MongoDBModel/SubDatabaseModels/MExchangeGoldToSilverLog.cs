using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    [BsonIgnoreExtraElements]
    public class MExchangeGoldToSilverLog : IUserTimeDataModel
    {
        public int times { get; set; }
    }
}
