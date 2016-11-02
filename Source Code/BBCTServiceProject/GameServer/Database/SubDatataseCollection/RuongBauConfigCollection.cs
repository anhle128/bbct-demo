
using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class RuongBauConfigCollection : AbsCollectionController<MRuongBauConfig>
    {
        public RuongBauConfigCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public MRuongBauConfig GetData(string id)
        {
            return GetSingleData(a => a._id == id && a.server_id == Settings.Instance.server_id);
        }

        public List<MRuongBauConfig> GetDatas()
        {
            return GetListData(a => a.server_id == Settings.Instance.server_id);
        }
    }
}
