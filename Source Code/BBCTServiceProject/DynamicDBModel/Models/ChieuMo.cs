
using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class ChieuMo
    {
        [ProtoMember(1)]
        public ChieuMoPrice quay_tuong_normal;
        [ProtoMember(2)]
        public ChieuMoPrice quay_tuong_special;
        [ProtoMember(3)]
        public ChieuMoPrice quay_vat_pham;
        [ProtoMember(4)]
        public int count_time_free_quay_tuong_normal;
        [ProtoMember(5)]
        public int max_free_quay_tuong_normal_in_day;
    }
}
