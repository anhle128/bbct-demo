using ProtoBuf;
using System;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class SystemMail
    {
        [ProtoMember(1)]
        public string title { get; set; }
        [ProtoMember(2)]
        public string content { get; set; }
        [ProtoMember(3)]
        public DateTime time { get; set; }
    }
}
