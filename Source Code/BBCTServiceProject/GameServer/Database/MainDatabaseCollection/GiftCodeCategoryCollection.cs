using GameServer.Common;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.MainDatabaseModels;

namespace GameServer.Database.MainDatabaseCollection
{
    public class GiftCodeCategoryCollection : AbsCollectionController<MGiftCodeCategory>
    {
        public GiftCodeCategoryCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
        }

        public MGiftCodeCategory GetData(string category)
        {
            return
                GetSingleData(
                    a => a._id == category);
        }
    }
}
