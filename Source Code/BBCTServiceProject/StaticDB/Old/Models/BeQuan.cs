using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class BeQuan
    {
        [ProtoMember(1)]
        public int time { get; set; }
        [ProtoMember(2)]
        public int pieceReceive { get; set; }
        [ProtoMember(3)]
        public int goldRequire { get; set; }
    }
}
