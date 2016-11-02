using System;
using System.Collections.Generic;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Reward
    {
        [ProtoMember(1)]
        public int category { get; set; }
        [ProtoMember(2)]
        public int id { get; set; }
        [ProtoMember(3)]
        public int amountMin { get; set; }
        [ProtoMember(4)]
        public int amountMax { get; set; }
        [ProtoMember(5)]
        public float probability { get; set; }
        [ProtoMember(6)]
        public int charId { get; set; }

        public Reward()
        {

        }
    }
}
