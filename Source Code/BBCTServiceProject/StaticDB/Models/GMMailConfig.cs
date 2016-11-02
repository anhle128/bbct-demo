using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class GMMailConfig
    {
        [ProtoMember(1)]
        public int maxMailCanSentPerDay { get; set; }
        [ProtoMember(2)]
        public int titleLength { get; set; }
        [ProtoMember(3)]
        public int contentLength { get; set; }

    }
}
