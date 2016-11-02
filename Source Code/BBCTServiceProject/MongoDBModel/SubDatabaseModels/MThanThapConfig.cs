using DynamicDBModel.Models;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MThanThapConfig : IServerDataModel
    {
        public List<TopReward> top_rewards { get; set; }
    }
}
