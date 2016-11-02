using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class TimeAttackBoss
    {
        [ProtoMember(1)]
        public Hour start { get; set; }
        [ProtoMember(2)]
        public Hour end { get; set; }
    }
}
