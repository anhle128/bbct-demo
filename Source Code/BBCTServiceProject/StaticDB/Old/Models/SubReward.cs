using ProtoBuf;
using System;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class SubReward
    {
        [ProtoMember(1)]
        public int category { get; set; }
        [ProtoMember(2)]
        public int id { get; set; }
        [ProtoMember(3)]
        public int amount { get; set; }
        [ProtoMember(4)]
        public int charId { get; set; }
        public SubReward()
        {

        }
    }
}
