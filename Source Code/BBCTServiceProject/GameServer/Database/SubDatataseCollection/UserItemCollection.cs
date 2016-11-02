using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserItemCollection : AbsCollectionController<MUserItem>
    {
        public UserItemCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexStaticData(Collection);
        }

        public MUserItem GetData(string userid, int staticId)
        {
            return GetSingleData
            (
                a =>
                    a.user_id == userid &&
                    a.static_id == staticId
            );
        }

        public List<MUserItem> GetDatas(string userid)
        {
            return GetListData(a => a.user_id.Equals(userid));
        }
    }
}
