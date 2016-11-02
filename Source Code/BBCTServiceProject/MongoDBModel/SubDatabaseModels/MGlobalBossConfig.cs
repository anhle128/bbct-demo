using DynamicDBModel.Models;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MGlobalBossConfig : IServerDataModel
    {
        public int hash_code_time_end_boss { get; set; }
        public int current_index_boss { get; set; }
        public int level { get; set; }
        public List<TopReward> top_rewards { get; set; }
        public List<SubRewardItem> kill_boss_rewards { get; set; }
    }
}
