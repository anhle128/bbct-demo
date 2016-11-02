using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserCauCaCollection : AbsCollectionController<MCauCa>
    {
        public UserCauCaCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public MCauCa GetCurrentCauCa(string userid)
        {
            return
                GetSingleData
               (
                   x =>
                       x.is_open &&
                       x.user_id.Equals(userid)
               );
        }

        public void CloseThis(string objectId)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"is_open",false}
            };
            UpdateFields(objectId, dictData);
        }

        public int Count(string userid)
        {
            return
                CountData
                (
                    x =>
                        x.user_id.Equals(userid) &&
                        x.hash_code_time == CommonFunc.GetHashCodeTime()
                );
        }
    }
}
