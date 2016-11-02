using ProtoBuf;
using System.Collections.Generic;

namespace StaticDB.Models.GiangHo
{
    [ProtoContract]
    public class Wave
    {
        [ProtoMember(1)]
        public List<Monster> monsters { get; set; }

        [ProtoMember(2)]
        public List<BattleDialog> startDialogs { get; set; }

        [ProtoMember(3)]
        public List<BattleDialog> endDialogs { get; set; }

        [ProtoMember(4)]
        public int backgroundMap { get; set; }        

        public Wave()
        { }
    }
}
