using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class LuanKiem
    {
        [ProtoMember(1)]
        public List<RewardComponent> rewards { get; set; }
    }
}
