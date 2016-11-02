using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDBModel.Implement;
using System;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSKDoiDoLog : IUserTimeDataModel
    {
        public string nickname { get; set; }
        public string su_kien_id { get; set; }
        public List<ItemDoiDo> exchange_items { get; set; }
        public List<int> index_exchanged { get; set; }
        public List<IndexReceived> index_receiveds { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime last_time_get_item { get; set; }
        public int total_point { get; set; }
        public int current_point { get; set; }
        public int avatar { get; set; }

    }
}
