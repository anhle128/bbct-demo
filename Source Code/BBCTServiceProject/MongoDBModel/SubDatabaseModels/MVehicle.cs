using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using StaticDB.Enum;
using System;

namespace MongoDBModel.SubDatabaseModels
{
    public class MVehicle
    {
        public TypeVehicle type;
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime start;
        public bool going_on;
    }
}
