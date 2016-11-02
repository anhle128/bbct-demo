
using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserStarReward
    {
        [ProtoMember(1)]
        public int map_index { get; set; }
        [ProtoMember(2)]
        public int level { get; set; }

        [ProtoMember(3)]
        public List<int> index_reveived { get; set; }
    }
}
