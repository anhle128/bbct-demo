using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Implement;

namespace MongoDBModel.MainDatabaseModels
{
    public class MGiftCode : IMongoModel
    {
        public string category { get; set; }
        public string code { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string user_id { get; set; }
    }
}
