using DynamicDBModel.Models;
using MongoDBModel.Implement;
using System.Collections.Generic;
using MongoDB.Bson;

namespace MongoDBModel.SubDatabaseModels
{
    public class MBuyShopItemLog : IUserTimeDataModel
    {
        public string item_id;
        public int total_gold;
        public int quantity;
        public List<SubRewardItem> rewards;
        public string server_id;
    }
}
