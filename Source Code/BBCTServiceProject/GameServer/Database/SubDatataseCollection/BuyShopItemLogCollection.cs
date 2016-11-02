using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class BuyShopItemLogCollection : AbsCollectionController<MBuyShopItemLog>
    {
        public BuyShopItemLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        protected override void SetDefaultValue(MBuyShopItemLog data)
        {
            data.server_id = Settings.Instance.server_id;
        }

        public List<MBuyShopItemLog> GetDatas(string userid)
        {
            return
                GetListData
                (
                    a =>
                        a.user_id.Equals(userid) &&
                        a.hash_code_time == CommonFunc.GetHashCodeTime()
                );
        }
    }
}
