using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Receipt
    {
        [ProtoMember(1)]
        public int idItem { get; set; }

        [ProtoMember(2)]
        public int amount { get; set; }

        public Receipt()
        {

        }
    }
}
