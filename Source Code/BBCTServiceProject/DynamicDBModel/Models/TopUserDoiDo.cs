using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class TopUserDoiDo
    {
        [ProtoMember(1)]
        public string userid { get; set; }
        [ProtoMember(2)]
        public string nickname { get; set; }
        [ProtoMember(3)]
        public int avatar { get; set; }
        [ProtoMember(4)]
        public double total_point { get; set; }
    }
}
