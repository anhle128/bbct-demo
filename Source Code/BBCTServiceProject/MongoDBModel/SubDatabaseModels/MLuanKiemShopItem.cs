using DynamicDBModel.Models;
using MongoDBModel.Enum;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MLuanKiemShopItem : IServerDataModel
    {
        public int rank_require;
        public int maxBuyTimes;
        public int point_luan_kiem;
        public SubRewardItem reward;
        public Status status;

    }
}
