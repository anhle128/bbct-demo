using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Enum;
using MongoDBModel.Implement;
using System;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSKDoiDoConfig : IServerDataModel
    {
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime start { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime end { get; set; }
        public Status status { get; set; }

        public MRefeshDoiDoi refesh { get; set; }
        public List<ItemDoiDo> exchange_items { get; set; }
        public List<PointDoiDoReward> point_rewards { get; set; }
        public List<TopRewardDoiDo> top_rewards { get; set; }
    }
}
