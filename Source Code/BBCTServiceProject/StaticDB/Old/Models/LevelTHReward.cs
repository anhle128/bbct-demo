using ProtoBuf;
using System;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class LevelTHReward
    {
        [ProtoMember(1)]
        public List<THReward> rewards;
    }
}
