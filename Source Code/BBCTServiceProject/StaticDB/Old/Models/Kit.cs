using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Kit
    {
        [ProtoMember(1)]
        public int id { get; set; }
        //[ProtoMember(2)]
        //public List<EquipmentComponent> equipments { get; set; }
     
        public Kit()
        {

        }
    }
}
