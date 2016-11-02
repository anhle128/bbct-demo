using DynamicDBModel.Models;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MVipRewardConfig : IServerDataModel
    {
        public int vip { get; set; }
        public List<SubRewardItem> rewards { get; set; }
    }
}
