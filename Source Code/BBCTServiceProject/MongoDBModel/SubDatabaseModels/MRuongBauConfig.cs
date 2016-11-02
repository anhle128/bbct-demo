using DynamicDBModel.Models;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MRuongBauConfig : IServerDataModel
    {
        public string name { get; set; }
        public string desc { get; set; }
        public List<SubRewardItem> rewards { get; set; }
    }
}
