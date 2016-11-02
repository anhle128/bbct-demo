using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class CuuCuuTriTonConfig
    {

        [ProtoMember(1)]
        public int ruby_require { get; set; }
        [ProtoMember(2)]
        public Reward[] rewards { get; set; }
        [ProtoMember(3)]
        public int duration { get; set; }

    }
}
