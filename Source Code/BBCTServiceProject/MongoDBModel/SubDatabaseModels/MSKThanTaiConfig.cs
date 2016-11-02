using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Enum;
using MongoDBModel.Implement;
using System;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSKThanTaiConfig : IServerDataModel
    {
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime start { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime end { get; set; }

        public Status status { get; set; }

        public MThanTaiReward[] rewards { get; set; }
    }
}
