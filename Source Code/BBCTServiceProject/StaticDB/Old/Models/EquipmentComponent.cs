using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class EquipmentComponent
    {
        [ProtoMember(1)]
        public int category { get; set; }
        [ProtoMember(2)]
        public int equipmentId { get; set; }
    }
}
