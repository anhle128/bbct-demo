using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class TopUsersGlobalBoss
    {
        [ProtoMember(1)]
        public List<TopUserPrivateBoss> topUsers { get; set; }
        [ProtoMember(2)]
        public TopUserPrivateBoss userKillBoss { get; set; }

    }
}
