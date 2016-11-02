using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class HuaNguyenLogCollection : AbsCollectionController<MHuaNguyenLog>
    {
        public HuaNguyenLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public MHuaNguyenLog GetData(string userid, int hashCodeTime)
        {
            return
                GetSingleData(
                    a =>
                        a.user_id.Equals(userid) &&
                        a.hash_code_time == hashCodeTime);
        }

        public void UpdateCountTimes(MHuaNguyenLog huaNguyenLog)
        {
            UpdateFields(huaNguyenLog._id, new Dictionary<string, double>(1)
            {
                {"count_times",huaNguyenLog.count_times }
            });
        }
    }
}
