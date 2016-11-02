using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class GuildLevelContribution
    {
        [ProtoMember(1)]
        public int contribution { get; set; }

    }
}
