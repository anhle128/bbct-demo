using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models.GiangHo
{
    [ProtoContract]
    public class NormalBattle
    {
        [ProtoMember(1)]
        public List<Monster> monsters { get; set; }
        [ProtoMember(2)]
        public int numberMonsterInBattle { get; set; }
        [ProtoMember(3)]
        public int numberWaveInBattle { get; set; }
    }
}
