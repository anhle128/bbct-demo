using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class ItemOnMarketCollection : AbsCollectionController<MItemSellingOnMarket>
    {
        public ItemOnMarketCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        protected override void SetDefaultValue(MItemSellingOnMarket data)
        {
            data.server_id = Settings.Instance.server_id;
        }

        public List<MItemSellingOnMarket> FindDatas(string keyword, double minPrice, double maxPrice, string ignoreUserId)
        {
            return GetListData(x => x.server_id.Equals(Settings.Instance.server_id) &&
                x.keyword_search.Contains(keyword) &&
                x.price >= minPrice &&
                x.price <= maxPrice &&
                !x.user_id.Equals(ignoreUserId)).OrderBy(x => x.price).ToList();
        }

        public List<MItemSellingOnMarket> GetDatas(string userid)
        {
            return GetListData(x => x.server_id.Equals(Settings.Instance.server_id) &&
            x.user_id.Equals(userid));
        }

        public MItemSellingOnMarket GetData(string id)
        {
            return GetSingleData(x => x._id.Equals(id)); ;
        }

        public int Count(string userid)
        {
            return
                CountData(x =>
                    x.user_id.Equals(userid));
        }
    }
}
