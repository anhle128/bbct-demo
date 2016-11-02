using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class SuKienRotDoLogCollection : AbsCollectionController<MSKRotDoLog>
    {
        public SuKienRotDoLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public MSKRotDoLog GetData(string userid, string suKienId)
        {
            return
                GetSingleData(
                    a => a.user_id.Equals(userid) && a.su_kien_id.Equals(suKienId));
        }
    }
}
