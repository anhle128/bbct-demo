using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class TopUserThanThap
    {
        [ProtoMember(1)]
        public string userid;
        [ProtoMember(2)]
        public int avatar;
        [ProtoMember(3)]
        public string nickname;
        [ProtoMember(4)]
        public int floor;
        [ProtoMember(5)]
        public int star;
        [ProtoMember(6)]
        public int total_day_in_top;
        [ProtoMember(7)]
        public string group_id;

    }
}
