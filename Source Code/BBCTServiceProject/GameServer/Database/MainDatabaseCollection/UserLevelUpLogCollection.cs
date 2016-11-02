using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.MainDatabaseModels;

namespace GameServer.Database.MainDatabaseCollection
{
    public class UserLevelUpLogCollection : AbsCollectionController<MUserLevelUpLog>
    {
        public UserLevelUpLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public void Create(string userid, int level)
        {
            MUserLevelUpLog levelUp = new MUserLevelUpLog()
            {
                user_id = userid,
                level = level,
            };
            Create(levelUp);
        }
    }
}
