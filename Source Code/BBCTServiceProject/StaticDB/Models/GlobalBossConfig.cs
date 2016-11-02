using ProtoBuf;
using System.Collections.Generic;

namespace StaticDB.Models
{

    [ProtoContract]
    public class GlobalBossConfig
    {
        [ProtoMember(1)]
        public TimeAttackBoss[] timeAttackBoss { get; set; }
        [ProtoMember(2)]
        public int levelRequire { get; set; }
        [ProtoMember(3)]
        public int hpBossAtLevel1 { get; set; }
        [ProtoMember(4)]
        public int growthHp { get; set; }
        [ProtoMember(5)]
        public AttackGlobalBossConfig[] attackConfigs { get; set; }
        [ProtoMember(6)]
        public List<Reward> bonusRewards { get; set; }

        public int GetSilverReward(double damage)
        {
            return (int)damage / 10;
        }
    }
}
