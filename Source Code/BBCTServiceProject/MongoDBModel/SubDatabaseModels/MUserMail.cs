
using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDBModel.Enum;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserMail : IUserDataModel
    {
        public string title { get; set; }
        public string content { get; set; }
        public string trans_id { get; set; }
        public List<SubRewardItem> rewards { get; set; }
        public bool readed { get; set; }
        public UserMailType type { get; set; }
        public string server_id { get; set; }
    }
}
