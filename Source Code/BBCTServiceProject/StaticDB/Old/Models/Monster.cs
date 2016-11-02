using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Monster
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public int promotionLevel { get; set; }
        [ProtoMember(3)]
        public int evolutionLevel { get; set; }
        [ProtoMember(4)]
        public int level { get; set; }
        [ProtoMember(5)]
        public int[] skills { get; set; }
        //[ProtoMember(6)]
        //public List<ItemEquipment> listEquipment { get; set; }

        public Monster()
        {

        }
    }
}
