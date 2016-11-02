using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class LuanKiemConfig
    {
        [ProtoMember(1)]
        public int levelRequire { get; set; }
        //[ProtoMember(2)]
        //public int freeTimesAttack { get; set; }
        [ProtoMember(3)]
        public int timeMinutesCoolDownAttack { get; set; }
        [ProtoMember(4)]
        public RankLuanKiemReward[] rankRewards { get; set; }
        [ProtoMember(5)]
        public RangeLuanKiemOpponent[] rangeOpponent { get; set; }
        [ProtoMember(6)]
        public RankLuanKiemPoint[] rankPoint { get; set; }
        [ProtoMember(7)]
        public Hour hourSendGift { get; set; }
        [ProtoMember(8)]
        public int goldRequireQuickAttack { get; set; }
        [ProtoMember(9)]
        public Reward[] winRewards { get; set; }
        [ProtoMember(10)]
        public Reward[] loseRewards { get; set; }

        public RankLuanKiemPoint GetPointReward(int rank)
        {
            foreach (var range in rankPoint)
            {
                if (rank >= range.rank.start && rank <= range.rank.end)
                    return range;
            }
            return null;
        }

        public int GetSecondCoolDownAttack()
        {
            return timeMinutesCoolDownAttack * 60;
        }

    }
}
