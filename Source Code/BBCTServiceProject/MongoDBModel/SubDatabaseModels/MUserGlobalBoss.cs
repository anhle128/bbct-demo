using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Implement;
using System;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserGlobalBoss : IUserTimeDataModel
    {
        public string nickname { get; set; }
        public double total_damages { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime last_time_attack { get; set; }
    }
}
