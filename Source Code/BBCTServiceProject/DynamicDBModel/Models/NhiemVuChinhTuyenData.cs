
using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class NhiemVuChinhTuyenData
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public int level { get; set; }
        [ProtoMember(3)]
        public int process { get; set; }
    }
}
