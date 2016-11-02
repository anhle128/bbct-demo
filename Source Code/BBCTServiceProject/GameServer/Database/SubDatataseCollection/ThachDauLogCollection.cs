using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class ThachDauLogCollection : AbsCollectionController<MThachDauLog>
    {
        public ThachDauLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public int Count(string userid)
        {
            return CountData
            (
                a => a.hash_code_time == CommonFunc.GetHashCodeTime()
                    && a.user_id.Equals(userid)
            );
        }

        public bool CheckAttacedkUser(string userid, string opponentUserid)
        {
            int count = CountData
            (
                a => a.hash_code_time == CommonFunc.GetHashCodeTime()
                    && a.user_id.Equals(userid)
                    && a.other_user_id.Equals(opponentUserid)
            );
            return count != 0;
        }
    }
}
