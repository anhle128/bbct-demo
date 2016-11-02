using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System;

namespace GameServer.Database.SubDatataseCollection
{
    public class LuaTraiLogCollection : AbsCollectionController<MLuaTraiLog>
    {
        public LuaTraiLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerTimeData(Collection);
        }

        public MLuaTraiLog GetData(string guildId, TimeSpan timeSpan)
        {
            return GetSingleData(x => x.guild_id.Equals(guildId) &&
                x.created_at < DateTime.Now &&
                x.created_at > DateTime.Now - timeSpan);
        }

        public int CoundLogInDay(string guildId)
        {
            return MongoController.LogSubDB.LuaTraiLog.CountData(x => x.guild_id.Equals(guildId) &&
                x.hash_code_time == CommonFunc.GetHashCodeTime());
        }

        public int CoundLogInTimeSpan(string guildId, TimeSpan timeSpan)
        {
            return CountData(x => x.guild_id.Equals(guildId) &&
                x.created_at < DateTime.Now &&
                x.created_at > DateTime.Now - timeSpan);
        }
    }
}
