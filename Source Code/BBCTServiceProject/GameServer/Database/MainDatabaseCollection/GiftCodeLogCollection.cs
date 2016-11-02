using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.MainDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.MainDatabaseCollection
{
    public class GiftCodeLogCollection : AbsCollectionController<MGiftCodeLog>
    {
        public GiftCodeLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndex(Collection, new Dictionary<string, object>()
            {
                {"gift_code",1}
            });
        }

        public int Count(string userid, string giftCodeCategoryId)
        {
            return
                CountData
                (
                    a =>
                        a.user_id.Equals(userid) &&
                        a.category.Equals(giftCodeCategoryId)
                );
        }
    }
}
