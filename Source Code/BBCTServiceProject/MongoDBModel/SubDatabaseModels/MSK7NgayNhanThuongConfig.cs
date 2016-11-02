using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Enum;
using MongoDBModel.Implement;
using System;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSK7NgayNhanThuongConfig : IServerDataModel
    {
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime start { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime end { get; set; }

        public DayReward[] day_rewards;

        public Status status { get; set; }
    }
}
