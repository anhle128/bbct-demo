using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Reward
    {
        [ProtoMember(1)]
        public int typeReward { get; set; }
        [ProtoMember(2)]
        public int staticID { get; set; }
        [ProtoMember(3)]
        public int amountMin { get; set; }
        [ProtoMember(4)]
        public int amountMax { get; set; }
        [ProtoMember(5)]
        public double proc { get; set; }
        [ProtoMember(6)]
        public int star { get; set; }// chỉ dùng cho character


        public Reward()
        {

        }
    }
}
