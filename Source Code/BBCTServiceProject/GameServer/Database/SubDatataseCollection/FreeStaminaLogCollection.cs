using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class FreeStaminaLogCollection : AbsCollectionController<MFreeStaminaLog>
    {
        public FreeStaminaLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public List<MFreeStaminaLog> GetDatas(string userid)
        {
            return GetListData
            (
                a =>
                    a.user_id.Equals(userid) &&
                    a.hash_code_time == CommonFunc.GetHashCodeTime()
            );
        }
    }
}
