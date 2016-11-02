using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class MoiRuouLogCollection : AbsCollectionController<MMoiRuouLog>
    {
        public MoiRuouLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public void UpdateHashCodeTime(MMoiRuouLog data)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"hash_code_time",data.hash_code_time}
            };
            UpdateFields(data._id, dictData);
        }

        public MMoiRuouLog GetData(string userid, string otherUserid)
        {
            return GetSingleData
                (
                    a =>
                        a.user_id == userid &&
                        a.other_user_id == otherUserid &&
                        a.hash_code_time == CommonFunc.GetHashCodeTime()
                );
        }

        public int Count(string userid)
        {
            return
                CountData
                (
                    a =>
                        a.user_id == userid &&
                        a.hash_code_time == CommonFunc.GetHashCodeTime()
                );
        }
    }
}
