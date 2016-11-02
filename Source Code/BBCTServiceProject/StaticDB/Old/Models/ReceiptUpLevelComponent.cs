using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class ReceiptUpLevelComponent
    {
        [ProtoMember(1)]
        public int category { get; set; }
        [ProtoMember(2)]
        public int id { get; set; }
        [ProtoMember(3)]
        public int amount{ get; set; }

        public ReceiptUpLevelComponent()
        {

        }
    }
}
