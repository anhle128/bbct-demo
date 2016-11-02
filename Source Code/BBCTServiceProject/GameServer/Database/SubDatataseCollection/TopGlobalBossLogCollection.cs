using DynamicDBModel.Models;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class TopGlobalBossLogCollection : AbsCollectionController<MTopGlobalBossLog>
    {
        public TopGlobalBossLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerTimeData(Collection);
        }

        public TopUsersGlobalBoss GetTopUsersGlobalBoss(int hashTimeCode)
        {
            MTopGlobalBossLog log =
                GetSingleData(a => a.server_id == Settings.Instance.server_id && a.hash_code_time == hashTimeCode);
            if (log == null)
                return null;
            TopUsersGlobalBoss dataResult = new TopUsersGlobalBoss()
            {
                topUsers = log.top_users,
                userKillBoss = log.user_kill_boss
            };
            return dataResult;
        }
    }
}
