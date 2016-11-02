using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class TopUserPrivateBoss
    {
        [ProtoMember(1)]
        public string userid;
        [ProtoMember(2)]
        public string nickname;
        [ProtoMember(3)]
        public double totalDamage;
    }
}
