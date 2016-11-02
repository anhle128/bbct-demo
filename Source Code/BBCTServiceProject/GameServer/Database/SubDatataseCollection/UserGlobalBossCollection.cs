using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserGlobalBossCollection : AbsCollectionController<MUserGlobalBoss>
    {
        public UserGlobalBossCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public MUserGlobalBoss GetData(string userid, int hashCodeEndTime)
        {
            return
                GetSingleData(
                    a =>
                        a.user_id == userid && a.hash_code_time == hashCodeEndTime);
        }
    }
}
