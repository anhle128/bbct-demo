using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class ThanThapFormation
    {
        [ProtoMember(1)]
        public List<MonsterStage> monsters { get; set; }
    }
}
