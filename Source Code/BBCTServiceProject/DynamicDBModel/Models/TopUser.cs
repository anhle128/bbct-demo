using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class TopUser
    {
        [ProtoMember(1)]
        public string userid { get; set; }
        [ProtoMember(2)]
        public string nickname { get; set; }
        [ProtoMember(3)]
        public int level { get; set; }
        [ProtoMember(4)]
        public int avatar { get; set; }
        [ProtoMember(5)]
        public int vip { get; set; }
        [ProtoMember(6)]
        public double power { get; set; }
    }
}
