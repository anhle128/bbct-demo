using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
namespace GameServer.Database.SubDatataseCollection
{
    public class ChieuMoConfigCollection : AbsCollectionController<MChieuMoConfig>
    {
        public ChieuMoConfigCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public MChieuMoConfig GetData()
        {
            return GetSingleData(a => a.server_id.Equals(Settings.Instance.server_id));
        }
    }
}
