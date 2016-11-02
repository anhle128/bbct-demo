
using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Enum;
using MongoDBModel.Implement;
using StaticDB.Models;
using System;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSKRotDoConfig : IServerDataModel
    {
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime start { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime end { get; set; }
        public Status status { get; set; }

        public List<Reward> drop_items { get; set; }
        public List<RotDoReward> rewards { get; set; }
    }
}
