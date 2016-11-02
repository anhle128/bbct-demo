using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MBuyLeBaoLog : IUserTimeDataModel
    {
        public string le_bao_id;
        public List<SubRewardItem> rewards;
        public int gold;
    }
}
