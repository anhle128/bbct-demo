using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Option
    {
        [ProtoMember(1)]
        public int attribute { get; set; }
        [ProtoMember(2)]
        public float mod { get; set; }
        [ProtoMember(3)]
        public float growthMod { get; set; }

        public Option()
        {

        }
    }
}
