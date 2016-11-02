using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
      [ProtoContract]
    public class DotLuaReward
    {
        [ProtoMember(1)]
        public int bac { get; set; }
        [ProtoMember(2)]
        public int knb { get; set; }
        [ProtoMember(3)]
        public int danhVong { get; set; }
    }
}
