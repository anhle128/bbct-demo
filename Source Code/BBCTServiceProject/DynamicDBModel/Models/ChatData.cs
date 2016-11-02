using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class ChatData
    {
        [ProtoMember(1)]
        public string message { get; set; }
        [ProtoMember(2)]
        public string username { get; set; }
        [ProtoMember(3)]
        public string nickname { get; set; }
        [ProtoMember(4)]
        public int avatar { get; set; }
        [ProtoMember(5)]
        public int vip { get; set; }
    }
}
