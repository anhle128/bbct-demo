using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class DuBi
    {
        [ProtoMember(1)]
        public int index { get; set; }
        [ProtoMember(2)]
        public string id_char { get; set; }
    }
}
