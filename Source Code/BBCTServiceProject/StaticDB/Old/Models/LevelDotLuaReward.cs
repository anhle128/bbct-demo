using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{

    [ProtoContract]
    public class LevelDotLuaReward
    {
         [ProtoMember(1)]
        public List<DotLuaReward> rewards { get; set; }
    }
}
