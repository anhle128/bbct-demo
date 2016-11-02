//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KDQHDesignerTool
{
    using System;
    using System.Collections.Generic;
    
    public partial class dbGuildConfig
    {
        public dbGuildConfig()
        {
            this.dbGuildBosses = new HashSet<dbGuildBoss>();
            this.dbGuildLevelContributions = new HashSet<dbGuildLevelContribution>();
            this.dbGuildMissions = new HashSet<dbGuildMission>();
            this.dbGuildRewardBangChiens = new HashSet<dbGuildRewardBangChien>();
            this.dbGuildRewardsLuaTrais = new HashSet<dbGuildRewardsLuaTrai>();
        }
    
        public int id { get; set; }
        public Nullable<int> idConfig { get; set; }
        public Nullable<int> levelRequireCreateGuild { get; set; }
        public Nullable<int> priceCreateGuild { get; set; }
        public string defaultNotice { get; set; }
        public Nullable<int> defaultContribution { get; set; }
        public Nullable<int> defaultContributionMember { get; set; }
        public Nullable<int> hourLockMember { get; set; }
        public Nullable<int> defaultAmountMember { get; set; }
        public Nullable<int> maxLevel { get; set; }
        public Nullable<int> priceContribute1 { get; set; }
        public Nullable<int> recieveContribute1 { get; set; }
        public Nullable<int> priceContribute2 { get; set; }
        public Nullable<int> recieveContribute2 { get; set; }
        public Nullable<int> priceContribute3 { get; set; }
        public Nullable<int> recieveContribute3 { get; set; }
        public Nullable<int> recieveContributeMember1 { get; set; }
        public Nullable<int> recieveContributeMember2 { get; set; }
        public Nullable<int> recieveContributeMember3 { get; set; }
        public Nullable<int> durationLuaTraiMinutes { get; set; }
        public Nullable<int> goldToFinishNowMission { get; set; }
        public Nullable<int> maxTimeAttackBossGuild { get; set; }
        public Nullable<int> idBoss { get; set; }
        public Nullable<System.DateTime> timeRewardBoss { get; set; }
        public Nullable<int> hourRewardBoss { get; set; }
        public Nullable<int> minuteRewardBoss { get; set; }
        public Nullable<int> hourStartBangChien { get; set; }
        public Nullable<int> minuteStartBangChien { get; set; }
        public Nullable<int> dayOfWeekBangChien { get; set; }
        public Nullable<int> minuteDurationBattleBangChien { get; set; }
        public Nullable<int> waitTimeBangChien { get; set; }
        public Nullable<int> bangChienMinMember { get; set; }
    
        public virtual dbConfig dbConfig { get; set; }
        public virtual ICollection<dbGuildBoss> dbGuildBosses { get; set; }
        public virtual ICollection<dbGuildLevelContribution> dbGuildLevelContributions { get; set; }
        public virtual ICollection<dbGuildMission> dbGuildMissions { get; set; }
        public virtual ICollection<dbGuildRewardBangChien> dbGuildRewardBangChiens { get; set; }
        public virtual ICollection<dbGuildRewardsLuaTrai> dbGuildRewardsLuaTrais { get; set; }
    }
}
