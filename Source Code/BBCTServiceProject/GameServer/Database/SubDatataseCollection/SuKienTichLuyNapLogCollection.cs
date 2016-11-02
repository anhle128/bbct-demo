using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class SuKienTichLuyNapLogCollection : AbsCollectionController<MSKTichLuyNapLog>
    {
        public SuKienTichLuyNapLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public MSKTichLuyNapLog GetData(string userid, string suKienId)
        {
            return
                GetSingleData
                (
                    a =>
                        a.user_id.Equals(userid) &&
                        a.su_kien_id == suKienId
                );
        }

        public MSKTichLuyNapLog GetData(string userid, string suKienId, int hashCodeTime)
        {
            return
                GetSingleData
                (
                    a =>
                        a.user_id == userid &&
                        a.su_kien_id == suKienId &&
                        a.hash_code_time == hashCodeTime
                );
        }
    }
}
