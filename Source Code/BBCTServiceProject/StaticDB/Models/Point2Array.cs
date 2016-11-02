using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Point2Array
    {
        [ProtoMember(1)]
        public Point2[] values { get; set; }
    }
}
