using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models.GiangHo
{
     [ProtoContract]
    public class StageGiangHo
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public int stamina { get; set; }
        [ProtoMember(3)]
        public List<Wave> finalBattle { get; set; }
        [ProtoMember(4)]
        public List<Reward> rewards { get; set; }
        [ProtoMember(5)]
        public int silverMin { get; set; }
        [ProtoMember(6)]
        public int silverMax { get; set; }
        [ProtoMember(7)]
        public int expMin { get; set; }
        [ProtoMember(8)]
        public int expMax { get; set; }
        [ProtoMember(9)]
        public int honorMin { get; set; }
        [ProtoMember(10)]
        public int honorMax { get; set; }
        [ProtoMember(11)]
        public float posX { get; set; }
        [ProtoMember(12)]
        public float posY { get; set; }
        [ProtoMember(13)]
        public int maxAttack { get; set; }
        [ProtoMember(14)]
        public int idIcon { get; set; }
        [ProtoMember(15)]
        public NormalBattle normalBattle { get; set; }
        [ProtoMember(16)]
        public int idBackGround { get; set; }
        [ProtoMember(17)]
        public List<Reward> missionRewards { get; set; }
        public StageGiangHo()
        { 
        }
    }
}
