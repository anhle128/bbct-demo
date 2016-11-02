using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicDBModel.Models.Battle
{
    [ProtoContract]
    public class TargetReplay
    {
        [ProtoMember(1)]
        public string idTarget { get; set; }

        [ProtoMember(2)]
        public List<ActionReplay> actions { get; set; }

        public TargetReplay()
        {

        }
    }
}
