using GameServer.Database.SubDatataseCollection;
using MongoDB.Driver;

namespace GameServer.Database.Controller
{
    public class GuildDbController
    {
        #region Property
        private readonly GuildCollection _guild;
        private readonly GuildMemberCollection _guildMember;
        private readonly GuildLockLogCollection _lockLog;
        private readonly GuildRequestJoinCollection _requestJoin;
        private readonly BangChienCollection _bangChien;
        private readonly BattleBangChienCollection _battleBangChien;

        public GuildCollection Guild
        {
            get { return _guild; }
        }

        public GuildMemberCollection GuildMember
        {
            get { return _guildMember; }
        }

        public GuildLockLogCollection LockLog
        {
            get { return _lockLog; }
        }

        public GuildRequestJoinCollection RequestJoin
        {
            get { return _requestJoin; }
        }

        public BangChienCollection BangChien
        {
            get { return _bangChien; }
        }

        public BattleBangChienCollection BattleBangChien
        {
            get { return _battleBangChien; }
        }
        #endregion

        public GuildDbController(IMongoDatabase database)
        {
            _guild = new GuildCollection("guild", database);
            _guildMember = new GuildMemberCollection("guild_members", database);
            _lockLog = new GuildLockLogCollection("guild_lock_log", database);
            _requestJoin = new GuildRequestJoinCollection("guild_request_join", database);
            _bangChien = new BangChienCollection("bang_chien", database);
            _battleBangChien = new BattleBangChienCollection("battle_bang_chien", database);
        }

    }
}
