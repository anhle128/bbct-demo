using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class ItemEquipment
    {
        [ProtoMember(1)]
        public int idEquipment { get; set; }
        [ProtoMember(2)]
        public int evolution { get; set; }
        [ProtoMember(3)]
        public int level { get; set; }
    }
}
