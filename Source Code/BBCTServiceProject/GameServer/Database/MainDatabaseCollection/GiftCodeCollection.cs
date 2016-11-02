
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.MainDatabaseModels;
using System.Collections.Generic;
using GameServer.Server.Operations.Handler;

namespace GameServer.Database.MainDatabaseCollection
{
    public class GiftCodeCollection : AbsCollectionController<MGiftCode>
    {

        public GiftCodeCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndex(Collection, new Dictionary<string, object>()
            {
                {"code",1}
            });
        }

        public MGiftCode GetData(string code)
        {
            return GetSingleData(a => a.code.Equals(code));
        }
    }
}
