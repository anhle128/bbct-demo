using DynamicDBModel.Models;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class VipRewardConfigCollection : AbsCollectionController<MVipRewardConfig>
    {
        public VipRewardConfigCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public MVipRewardConfig GetData(int vip)
        {
            return GetSingleData(a => a.server_id == Settings.Instance.server_id && a.vip == vip);
        }

        public List<VipReward> GetVipRewards()
        {
            List<MVipRewardConfig> listVipRewadConfigs = GetListData(a => a.server_id == Settings.Instance.server_id);
            return (from a in listVipRewadConfigs
                    select new VipReward()
                    {
                        vip = a.vip,
                        rewards = (from b in a.rewards
                                   select new RewardItem()
                                   {
                                       quantity = b.quantity,
                                       type_reward = b.type_reward,
                                       static_id = b.static_id,
                                   }).ToList()
                    }).ToList()
            ;
        }


        public List<MVipRewardConfig> GetDatas()
        {
            return GetListData(a => a.server_id == Settings.Instance.server_id);
        }
    }
}
