using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class LuaTraiRewardLogCollection : AbsCollectionController<MLuaTraiRewardLog>
    {
        public LuaTraiRewardLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public int Count(string guildId, string userid)
        {
            return CountData
            (
                x =>
                    x.user_id.Equals(userid) &&
                    x.guild_id.Equals(guildId) &&
                    x.hash_code_time == CommonFunc.GetHashCodeTime()
            );
        }
    }
}
