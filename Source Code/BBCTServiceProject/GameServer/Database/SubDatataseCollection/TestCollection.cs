using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class TestCollection : AbsCollectionController<MTest>
    {
        public TestCollection(string nameCollection, IMongoDatabase database) : base(nameCollection, database)
        {
        }

        public List<MTest> GetDatas()
        {
            return GetListData(a => true);
        }


    }
}
