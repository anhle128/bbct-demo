using System.Collections.Generic;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class InviteFriendConfig
    {
        [ProtoMember(1)]
        public int require { get; set; }
        [ProtoMember(2)]
        public List<Reward> rewards  { get; set; }
    }
}