using DynamicDBModel.Models;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserItem : IStaticObjCountable
    {
        public string ruong_bau_id { get; set; }
        public List<SubRewardItem> rewards { get; set; }

    }
}
