using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class ShopItemCollection : AbsCollectionController<MShopItem>
    {
        public ShopItemCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public List<MShopItem> GetDatas()
        {
            return GetListData(a => a.server_id == Settings.Instance.server_id);
        }

        public MShopItem GetData(string id)
        {
            return GetSingleData(a => a._id.Equals((id)) && a.server_id == Settings.Instance.server_id);
        }
    }
}
