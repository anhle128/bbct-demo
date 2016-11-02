using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class ExchangeGoldToSilverLogCollection : AbsCollectionController<MExchangeGoldToSilverLog>
    {
        public ExchangeGoldToSilverLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public MExchangeGoldToSilverLog GetData(string userid, int hashCodeTime)
        {
            return
                GetSingleData
                (
                    a =>
                        a.user_id.Equals(userid) &&
                        a.hash_code_time == hashCodeTime
                );
        }
    }
}
