using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class LevelSubReward
    {
        [ProtoMember(1)]
        public List<SubReward> rewards { get; set; }
    }
}
