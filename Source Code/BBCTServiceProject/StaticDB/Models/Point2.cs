using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Point2
    {
        [ProtoMember(1)]
        public float x { get; set; }
        [ProtoMember(2)]
        public float y { get; set; }
    }
}
