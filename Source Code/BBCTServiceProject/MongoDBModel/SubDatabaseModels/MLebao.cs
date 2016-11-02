using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using MongoDBModel.Enum;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MLebao : IServerDataModel
    {
        public string name { get; set; }
        public int gold { get; set; }
        public int real_gold { get; set; }
        public List<SubRewardItem> rewards { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public int vip_required { get; set; }
        public int max_buy_times { get; set; }
        public TypeLeBaoBuyTimes buy_times { get; set; }
        public int[] vip_buy_times { get; set; }
        public TypeLeBaoActivationTime activation { get; set; }
        public Status status { get; set; }
    }
}
