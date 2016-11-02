using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;

namespace MongoDBModel.Implement
{
    public class IMongoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime updated_at { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime created_at { get; set; }
    }
}
