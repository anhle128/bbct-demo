using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserCharSoul
    {
        [ProtoMember(1)]
        public string _id { get; set; }
        [ProtoMember(2)]
        public int char_id { get; set; }
        [ProtoMember(3)]
        public int quantity { get; set; }
    }
}
