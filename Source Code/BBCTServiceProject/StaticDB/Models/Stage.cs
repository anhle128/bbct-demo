
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Stage
    {
        [ProtoMember(1)]
        public string name { get; set; }
        [ProtoMember(2)]
        public string description { get; set; }
        [ProtoMember(3)]
        public int typeStage { get; set; }
        [ProtoMember(4)]
        public Point2[] path { get; set; }
        [ProtoMember(5)]
        public int maxAttack { get; set; }
        [ProtoMember(6)]
        public int silverRewardMin { get; set; }
        [ProtoMember(7)]
        public int silverRewardMax { get; set; }
        [ProtoMember(8)]
        public int expRewardMin { get; set; }
        [ProtoMember(9)]
        public int expRewardMax { get; set; }
        [ProtoMember(10)]
        public Reward[] rewards { get; set; }
        [ProtoMember(11)]
        public int stamina { get; set; }
        [ProtoMember(13)]
        public float totalPower { get; set; }
        [ProtoMember(14)]
        public MonsterStage[] monsters { get; set; }
        [ProtoMember(15)]
        public Point2 position { get; set; }
        [ProtoMember(16)]
        public int background { get; set; }
        [ProtoMember(17)]
        public Reward[] rewardsSupper { get; set; }
        [ProtoMember(18)]
        public MonsterStage[] monstersSupper { get; set; }

        public Stage()
        {

        }
    }
}
