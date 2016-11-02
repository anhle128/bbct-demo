using DynamicDBModel.Models;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MGoldReward
    {
        public int gold_require { get; set; }
        public List<SubRewardItem> rewards { get; set; }

    }
}
