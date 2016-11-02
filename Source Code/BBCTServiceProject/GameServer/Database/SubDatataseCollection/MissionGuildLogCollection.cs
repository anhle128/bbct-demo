using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class MissionGuildLogCollection : AbsCollectionController<MMissionGuildLog>
    {
        public MissionGuildLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserTimeData(Collection);
        }

        public MMissionGuildLog GetAvailableMission(string guildId, string userId, int indexMission)
        {
            return
                GetSingleData(x => x.guild_id.Equals(guildId) &&
                x.user_id.Equals(userId) &&
                x.index_mission == indexMission &&
                x.hash_code_time == CommonFunc.GetHashCodeTime() &&
                !x.is_finish);
        }

        public List<MMissionGuildLog> GetDatas(string guildId, string userId)
        {
            return GetListData(x => x.guild_id.Equals(guildId) &&
                x.hash_code_time == CommonFunc.GetHashCodeTime() && x.user_id.Equals(userId));
        }

        public void UpdateState(string _id, bool isFinish)
        {
            var data = new Dictionary<string, object>(1)
            {
                { "is_finish", isFinish }
            };
            UpdateFields(_id, data);
        }


        public int Count(string guildId, string userId, int indexMission)
        {
            return CountData
            (
                x => x.guild_id.Equals(guildId) &&
                    x.user_id.Equals(userId) &&
                    x.index_mission == indexMission &&
                    x.hash_code_time == CommonFunc.GetHashCodeTime()
            );
        }
    }
}
