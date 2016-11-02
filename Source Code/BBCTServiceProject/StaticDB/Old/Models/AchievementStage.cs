using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
     [ProtoContract]
    public class AchievementStage
    {
        [ProtoMember(1)]
        public int level { get; set; }
        [ProtoMember(2)]
        public int indexStage { get; set; }
        [ProtoMember(3)]
        public int idMap { get; set; }
    }
}
