using ProtoBuf;
using System;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class THReward
    {
        [ProtoMember(1)]
        public int category { get; set; }
        [ProtoMember(2)]
        public int id { get; set; }
        [ProtoMember(3)]
        public int amount { get; set; }
        [ProtoMember(4)]
        public int charId { get; set; }
        [ProtoMember(5)]
        public int typeReward { get; set; }

        [ProtoMember(6)]
        public int price { get; set; }

        [ProtoMember(7)]
        public int maxBuyed { get; set; }

        public THReward()
        {
        }

    }
}
