using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Condition
    {
        [ProtoMember(1)]
        public int id { get; set; }

        [ProtoMember(2)]
        public int target { get; set; }

        [ProtoMember(3)]
        public int valueCondition { get; set; }

        [ProtoMember(4)]
        public int attribute { get; set; }
        public Condition()
        {

        }
    }
}
