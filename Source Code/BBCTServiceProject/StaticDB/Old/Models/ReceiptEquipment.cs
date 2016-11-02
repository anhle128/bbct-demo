using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class ReceiptEquipment
    {
        [ProtoMember(1)]
        public List<ReceiptComponent> components { get; set; }
        [ProtoMember(2)]
        public int level { get; set; }
    }
}
