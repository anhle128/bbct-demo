
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class MoRuongLogCollection : AbsCollectionController<MMoRuongLog>
    {
        public MoRuongLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexStaticData(Collection);
        }

        public MMoRuongLog GetData(string userid, int staticId)
        {
            return
                GetSingleData(
                    a => a.user_id.Equals(userid) && a.static_id == staticId);
        }
    }
}
