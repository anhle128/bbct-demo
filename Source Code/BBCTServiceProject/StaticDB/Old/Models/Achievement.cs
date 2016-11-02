using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Achievement
    {
        //[ProtoMember(1)]
        //public int id { get; set; }
        [ProtoMember(2)]
        public int bonus { get; set; }
        public Achievement()
        {

        }
    }
}
