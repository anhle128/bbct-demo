
using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class ChieuMoPrice
    {
        [ProtoMember(1)]
        public int price;
        [ProtoMember(2)]
        public int x10_price;
        [ProtoMember(3)]
        public double rest_free_time;
    }
}
