using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Enum;
using MongoDBModel.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSKDuaTopServerConfig : IServerDataModel
    {
        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime start { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime end { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime hide { get; set; }

        public List<TopReward> top_level_rewards { get; set; }
        public List<TopReward> top_power_rewards { get; set; }

        public List<TopUser> top_level_player { get; set; }
        public List<TopUser> top_power_player { get; set; }

        public bool is_send_reward { get; set; }
        public Status status { get; set; }
    }
}
