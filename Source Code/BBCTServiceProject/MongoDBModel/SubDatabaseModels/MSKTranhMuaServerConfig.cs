
using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Enum;
using MongoDBModel.Implement;
using System;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSKTranhMuaServerConfig : IMongoModel
    {
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime start { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime end { get; set; }
        public Status status { get; set; }
        public List<DayTranhMua> days { get; set; }
    }
}
