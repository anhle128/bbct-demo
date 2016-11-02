using ProtoBuf;
using System;

namespace StaticDB.Models
{
    [ProtoContract]
    public class GuildConfig
    {
        [ProtoMember(1)]
        public int levelRequireCreateGuild { get; set; }
        [ProtoMember(2)]
        public int priceCreateGuild { get; set; }
        [ProtoMember(3)]
        public string defaultNotice { get; set; }
        [ProtoMember(4)]
        public int defaultContribution { get; set; }
        [ProtoMember(5)]
        public int defaultContributionMember { get; set; }
        [ProtoMember(6)]
        public int hourLockMember { get; set; }
        [ProtoMember(7)]
        public int defaultAmountMember { get; set; }
        [ProtoMember(8)]
        public GuildLevelContribution[] levelContribution { get; set; }
        [ProtoMember(9)]
        public int maxLevel { get; set; }
        [ProtoMember(10)]
        public int priceContribute1 { get; set; }
        [ProtoMember(11)]
        public int recieveContribute1 { get; set; }
        [ProtoMember(12)]
        public int priceContribute2 { get; set; }
        [ProtoMember(13)]
        public int recieveContribute2 { get; set; }
        [ProtoMember(14)]
        public int priceContribute3 { get; set; }
        [ProtoMember(15)]
        public int recieveContribute3 { get; set; }
        [ProtoMember(16)]
        public int recieveContributeMember1 { get; set; }
        [ProtoMember(17)]
        public int recieveContributeMember2 { get; set; }
        [ProtoMember(18)]
        public int recieveContributeMember3 { get; set; }
        [ProtoMember(19)]
        public Reward[] rewardsLuaTrai { get; set; }
        [ProtoMember(20)]
        public int durationLuaTraiMinutes { get; set; }
        [ProtoMember(21)]
        public MissionGuild[] missions { get; set; }
        [ProtoMember(22)]
        public int goldToFinishNowMission { get; set; }
        [ProtoMember(23)]
        public RewardBossGuild[] rewardBoss { get; set; }
        [ProtoMember(24)]
        public int maxTimeAttackBossGuild { get; set; }
        [ProtoMember(25)]
        public int idBoss { get; set; }
        [ProtoMember(26)]
        public Hour timeRewardBoss { get; set; }
        //[ProtoMember(27)]
        //public int maxRequestJoin { get; set; }

        #region Bang Chien

        [ProtoMember(27)]
        public DayOfWeek dayOfWeekBangChien { get; set; }
        [ProtoMember(28)]
        public Hour hourStartBangChien { get; set; }
        [ProtoMember(29)]
        public int minuteDurationBattleBangChien { get; set; }
        [ProtoMember(30)]
        public int waitTimeBangChien { get; set; }
        [ProtoMember(31)]
        public Reward[] rewardBangChien { get; set; }
        [ProtoMember(32)]
        public int bangChienMinMember { get; set; }
        #endregion


        public DateTime GetDateTimeEndBoss()
        {
            DateTime timeNow = DateTime.Now;
            DateTime targetTimeEndBoss = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, timeRewardBoss.hour, timeRewardBoss.minute, 0);
            if (targetTimeEndBoss > timeNow)
            {
                return targetTimeEndBoss;
            }
            else
            {
                return targetTimeEndBoss.AddDays(1);
            }
        }
    }
}
