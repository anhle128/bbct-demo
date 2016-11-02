using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBModel.Implement
{
    public class IUserDataModel : IMongoModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string user_id { get; set; }
    }
}
