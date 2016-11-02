using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserLuanKiem
    {
        [ProtoMember(1)]
        public string userid;
        [ProtoMember(2)]
        public string nickname;
        [ProtoMember(3)]
        public int old_rank;
        [ProtoMember(4)]
        public int new_rank;
    }
}
