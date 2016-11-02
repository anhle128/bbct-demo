using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class MissionGuild
    {
        [ProtoMember(1)]
        public string name { get; set; }
        [ProtoMember(2)]
        public int durationMinutes { get; set; }
        [ProtoMember(3)]
        public int contribute { get; set; }
        [ProtoMember(4)]
        public int contributeMember { get; set; }
    }
}
