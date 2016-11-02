using ProtoBuf;
using StaticDB.Enum;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class NhiemVuHangNgayData
    {
        [ProtoMember(1)]
        public TypeNhiemVuHangNgay type { get; set; }
        [ProtoMember(2)]
        public int count { get; set; }
        [ProtoMember(3)]
        public bool received { get; set; }
    }
}
