using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Item
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public int border { get; set; }
        //[ProtoMember(3)]
        //public int category { get; set; }

        public Item()
        {

        }
    }
}
