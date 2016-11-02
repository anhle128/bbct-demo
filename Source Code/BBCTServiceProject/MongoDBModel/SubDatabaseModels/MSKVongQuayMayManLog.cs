using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSKVongQuayMayManLog : IUserDataModel
    {
        public string server_id { get; set; }
        public string su_kien_id { get; set; }
        public int count_times_quay_free { get; set; }
        public int total_point { get; set; }
        public List<SubRewardItem> rewards { get; set; }
        public List<int> index_point_received { get; set; }
        public string nickname { get; set; }
        public int level { get; set; }
        public int avatar { get; set; }
        public int vip { get; set; }
    }
}
