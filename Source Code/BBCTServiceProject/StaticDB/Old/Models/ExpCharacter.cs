using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class ExpCharacter
    {
        [ProtoMember(1)]
        public int id { get; set; }

        [ProtoMember(2)]
        public int level { get; set; }

        [ProtoMember(3)]
        public int exp { get; set; }
    }
}
