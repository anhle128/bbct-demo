using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class LeBaoCollection : AbsCollectionController<MLebao>
    {
        public LeBaoCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public List<MLebao> GetDatas()
        {
            return GetListData(a => a.server_id == Settings.Instance.server_id);
        }

        public List<MLebao> GetActivateLeBaos()
        {
            return GetListData(a => a.server_id == Settings.Instance.server_id && a.status == Status.Activate);
        }

        public MLebao GetData(string id)
        {
            return
                GetSingleData(
                    a => a._id.Equals((id)) && a.server_id.Equals(Settings.Instance.server_id));
        }
    }
}
