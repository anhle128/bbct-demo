using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Implement;
using System;

namespace MongoDBModel.MainDatabaseModels
{
    public class MLoginLog : IUserDataModel
    {
        public int hash_code_time { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime login_time { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime logout_time { get; set; }

        public string server_id { get; set; }
    }
}
