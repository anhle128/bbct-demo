using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class GuildRequestJoinCollection : AbsCollectionController<MGuildRequestJoin>
    {
        public GuildRequestJoinCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection, new Dictionary<string, object>()
            {
                {"guild_id",1}
            });
        }

        protected override void SetDefaultValue(MGuildRequestJoin data)
        {
            data.server_id = Settings.Instance.server_id;
        }

        public List<MGuildRequestJoin> GetDatas(string guildId)
        {
            return GetListData(x => x.guild_id.Equals(guildId), 0, 50);
        }

        public MGuildRequestJoin GetData(string guildId, string userid)
        {
            return GetSingleData(x => x.user_id.Equals(userid) && x.guild_id.Equals(guildId));
        }

        public int CountRequestInGuild(string guildId)
        {
            return CountData(a => a.guild_id.Equals(guildId));
        }

        public bool CheckExistRequest(string guildId, string userId)
        {
            return CountData(x => x.user_id.Equals(userId) &&
                x.guild_id.Equals(guildId)) > 0;
        }
    }
}
