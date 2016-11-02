using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class BuyPointSkillLogCollection : AbsCollectionController<MBuyPointSkillLog>
    {
        public BuyPointSkillLogCollection(string nameCollection, IMongoDatabase database) : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public MBuyPointSkillLog GetData(string userid, int hashCodeTime)
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
