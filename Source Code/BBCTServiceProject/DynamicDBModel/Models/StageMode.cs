
using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class StageMode
    {
        [ProtoMember(1)]
        public int stage_index { get; set; }
        [ProtoMember(2)]
        public int map_index { get; set; }
        [ProtoMember(3)]
        public int level { get; set; }
    }
}
