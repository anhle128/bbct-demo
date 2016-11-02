using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class NhiemVuHangNgay
    {
        [ProtoMember(1)]
        public int type { get; set; }
        [ProtoMember(2)]
        public string name { get; set; }
        [ProtoMember(3)]
        public string desc { get; set; }
        [ProtoMember(4)]
        public int quantity { get; set; }
        [ProtoMember(5)]
        public Reward[] rewards { get; set; }
    }
}
