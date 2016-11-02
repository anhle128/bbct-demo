using DynamicDBModel.Models;
using MongoDB.Bson;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MBuyShopLuanKiemItemLog : IUserTimeDataModel
    {
        public string item_id;
        public int quantity;
        public List<SubRewardItem> rewards;
        public string server_id;
    }
}
