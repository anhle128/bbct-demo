using DynamicDBModel.Models;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class ThanThapConfigColletion : AbsCollectionController<MThanThapConfig>
    {
        public ThanThapConfigColletion(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public List<TopReward> GetListTopRewards()
        {
            return GetSingleData(a => a.server_id.Equals(Settings.Instance.server_id)).top_rewards.OrderBy(a => a.index).ToList();
        }

        public MThanThapConfig GetData()
        {
            return GetSingleData(a => a.server_id.Equals(Settings.Instance.server_id));
        }
    }
}
