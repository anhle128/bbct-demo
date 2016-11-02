using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.MainDatabaseModels;

namespace GameServer.Database.MainDatabaseCollection
{
    public class RewardedGoldLogCollection : AbsCollectionController<MRewardedGoldLog>
    {
        public RewardedGoldLogCollection(string nameCollection, IMongoDatabase database) : base(nameCollection, database)
        {
        }

        public void Create(string userId, int oldGlod, int rewardGlod, int newGold, ReasonActionGold resource)
        {
            MRewardedGoldLog log = new MRewardedGoldLog()
            {
                user_id = userId,
                old_glod = oldGlod,
                reward_glod = rewardGlod,
                new_gold = newGold,
                resource = resource
            };
            Create(log);
        }
    }
}
