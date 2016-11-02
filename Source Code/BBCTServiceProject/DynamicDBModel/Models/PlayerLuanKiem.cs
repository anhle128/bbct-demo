using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class PlayerLuanKiem
    {
        [ProtoMember(1)]
        public string username { get; set; }
        [ProtoMember(2)]
        public string nickname { get; set; }
        [ProtoMember(3)]
        public int rank { get; set; }
        [ProtoMember(4)]
        public int level { get; set; }
        [ProtoMember(5)]
        public int vip { get; set; }
        [ProtoMember(6)]
        public int avatar { get; set; }
        [ProtoMember(7)]
        public int levelAvatar { get; set; }
        [ProtoMember(8)]
        public SubDataPlayer data { get; set; }

    }
}
