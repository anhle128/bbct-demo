using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Enum;
using MongoDBModel.Implement;
using System;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSKVongQuayMayManConfig : IServerDataModel
    {
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime start { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime end { get; set; }
        public int max_free_times { get; set; }
        public int price { get; set; }
        public int x10_price { get; set; }
        public MVatPham[] vatPhams { get; set; }
        public Status status { get; set; }
        public List<PointVongQuayMayManReward> point_rewards { get; set; }
        public List<TopReward> top_rewards { get; set; }
    }
}
