using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Upgrade
    {
        [ProtoMember(1)]
        public int category { get; set; }
        [ProtoMember(2)]
        public int int1 { get; set; }
        [ProtoMember(3)]
        public int int2 { get; set; }

        public Upgrade()
        {

        }
    }
}
