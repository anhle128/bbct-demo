using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class ReceiptUpLevel
    {
        [ProtoMember(1)]
        public int level { get; set; }

        [ProtoMember(2)]
        public float probability { get; set; }

        [ProtoMember(3)]
        public List<ReceiptUpLevelComponent> listItem { get; set; }
    }
}
