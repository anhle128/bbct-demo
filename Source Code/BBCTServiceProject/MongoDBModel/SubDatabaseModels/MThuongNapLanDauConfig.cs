
using DynamicDBModel.Models;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MThuongNapLanDauConfig : IServerDataModel
    {
        public List<SubRewardItem> rewards;
    }
}
