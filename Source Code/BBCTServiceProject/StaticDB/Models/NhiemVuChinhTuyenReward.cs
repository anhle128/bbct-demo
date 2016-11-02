using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class NhiemVuChinhTuyenReward
    {
        [ProtoMember(1)]
        public int typeReward { get; set; }
        [ProtoMember(2)]
        public int staticID { get; set; }
        [ProtoMember(3)]
        public int quantity { get; set; }
        [ProtoMember(4)]
        public int stepUpQuantity { get; set; }
    }
}
