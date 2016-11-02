using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class LuanKiemShopItemCollection : AbsCollectionController<MLuanKiemShopItem>
    {
        public LuanKiemShopItemCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public List<MLuanKiemShopItem> GetDatas()
        {
            return GetListData(a => a.server_id.Equals(Settings.Instance.server_id));
        }

        public List<MLuanKiemShopItem> GetActiveItems()
        {
            return GetListData(a => a.server_id.Equals(Settings.Instance.server_id) && a.status == Status.Activate);
        }

        public MLuanKiemShopItem GetData(string id)
        {
            return
                GetSingleData(
                    a => a._id.Equals((id)) && a.server_id.Equals(Settings.Instance.server_id));
        }
    }
}
