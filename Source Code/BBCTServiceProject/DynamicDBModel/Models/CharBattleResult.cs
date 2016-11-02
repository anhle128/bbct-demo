using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class CharBattleResult
    {
        [ProtoMember(1)]
        public string _id { get; set; }
        [ProtoMember(2)]
        public int char_id { get; set; }
        [ProtoMember(3)]
        public int level { get; set; }
        [ProtoMember(4)]
        public int exp { get; set; }
        [ProtoMember(5)]
        public bool is_up_level { get; set; }
    }
}
