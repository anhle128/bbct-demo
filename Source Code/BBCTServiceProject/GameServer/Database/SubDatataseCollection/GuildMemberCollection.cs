using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;
using System.Collections.Generic;

namespace GameServer.Database.SubDatataseCollection
{
    public class GuildMemberCollection : AbsCollectionController<MGuildMember>
    {
        public GuildMemberCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection, new Dictionary<string, object>()
            {
                {"guild_id",1}
            });
        }

        public MGuildMember GetMemberInGuild(string userid, string guildid)
        {
            return GetSingleData(x => x.user_id.Equals(userid) &&
                   x.guild_id.Equals(guildid));
        }

        public MGuildMember GetData(string userid)
        {
            return GetSingleData(x => x.user_id.Equals(userid));
        }

        public List<MGuildMember> GetDatas()
        {
            return GetListData(a => a.server_id.Equals(Settings.Instance.server_id));
        }

        public List<MGuildMember> GetDatas(string guidId)
        {
            return GetListData(a => a.guild_id.Equals(guidId));
        }

        public bool CheckMemberInGuild(string userid)
        {
            int count = CountData(x => x.user_id.Equals(userid));
            return count > 0;
        }

        public int CountMemberInGuild(string guildId)
        {
            return CountData(x => x.guild_id.Equals(guildId));
        }



    }
}
