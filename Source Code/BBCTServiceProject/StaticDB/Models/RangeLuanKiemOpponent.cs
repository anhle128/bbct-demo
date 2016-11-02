using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]

    public class RangeLuanKiemOpponent
    {
        [ProtoMember(1)]
        public Range range { get; set; }
        [ProtoMember(2)]
        public Range[] rangeOpponent { get; set; }
    }
}
