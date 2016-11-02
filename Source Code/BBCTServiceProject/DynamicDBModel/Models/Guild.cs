using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class Guild
    {
        [ProtoMember(1)]
        public string _id { get; set; }
        [ProtoMember(2)]
        public string name { get; set; }
        [ProtoMember(3)]
        public int level { get; set; }
        [ProtoMember(4)]
        public int contribution { get; set; }
        [ProtoMember(5)]
        public string nicknameMaster { get; set; }
        [ProtoMember(6)]
        public int amountMember { get; set; }
        [ProtoMember(7)]
        public int tmpContribute { get; set; }
    }
}
