using GameServer.Common;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Database.SubDatataseCollection
{
    public class BossGuildLogCollection : AbsCollectionController<MBossGuildLog>
    {
        public BossGuildLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
        }

        protected override void SetDefaultValue(MBossGuildLog data)
        {
            data.server_id = Settings.Instance.server_id;
        }
        public MBossGuildLog GetData(string guildId, string userId)
        {
            return GetSingleData(x => x.guild_id.Equals(guildId) &&
            x.user_id.Equals(userId) &&
            x.hash_code_time == CommonFunc.GetHashCodeTime());
        }

        public List<MBossGuildLog> GetDatas(string guildId)
        {
            return GetListData(x => x.guild_id.Equals(guildId) &&
                x.hash_code_time == CommonFunc.GetHashCodeTime()).OrderByDescending(x => x.dmg).ToList();
        }

        public List<MBossGuildLog> GetDatas()
        {
            return GetListData(a => a.server_id.Equals(Settings.Instance.server_id));
        }

        public void UpdateDamageAndAttackTime(string id, double damage, int attackTimes)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>(1)
            {
                {"dmg", damage},
                {"attack_times", attackTimes},
            };
            UpdateFields(id, dictData);
        }


    }
}
