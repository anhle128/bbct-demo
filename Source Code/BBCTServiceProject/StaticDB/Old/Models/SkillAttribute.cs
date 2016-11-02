using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class SkillAttribute
    {
         [ProtoMember(1)]
        public int title { get; set; }
         [ProtoMember(2)]
        public float mod { get; set; }
         [ProtoMember(3)]
        public float growthMod { get; set; }

        public SkillAttribute()
         { }
    }

}
