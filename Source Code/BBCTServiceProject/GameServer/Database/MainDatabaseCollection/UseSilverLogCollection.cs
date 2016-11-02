using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.MainDatabaseModels;

namespace GameServer.Database.MainDatabaseCollection
{
    public class UseSilverLogCollection : AbsCollectionController<MUsedSilverLog>
    {
        public UseSilverLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public void Create(string userid, int silver, TypeUseSilver type)
        {
            if (silver == 0)
                return;
            MUsedSilverLog log = new MUsedSilverLog()
            {
                user_id = userid,
                silver = silver,
                type = type,
            };
            Create(log);
        }


    }
}
