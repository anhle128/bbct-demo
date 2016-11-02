using ProtoBuf;
using System;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserMail
    {
        [ProtoMember(1)]
        public string _id { get; set; }
        [ProtoMember(2)]
        public string title { get; set; }
        [ProtoMember(3)]
        public string content { get; set; }
        [ProtoMember(4)]
        public List<RewardItem> rewards { get; set; }
        [ProtoMember(5)]
        public bool readed { get; set; }
        [ProtoMember(6)]
        public DateTime time { get; set; }
    }
}
