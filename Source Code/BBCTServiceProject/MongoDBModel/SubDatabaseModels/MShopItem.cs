using DynamicDBModel.Models;
using MongoDBModel.Enum;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MShopItem : IServerDataModel
    {
        public SubRewardItem reward { get; set; }
        public int gold { get; set; }
        public int[] vip_buy_times { get; set; }
        public Status status { get; set; }
    }
}
