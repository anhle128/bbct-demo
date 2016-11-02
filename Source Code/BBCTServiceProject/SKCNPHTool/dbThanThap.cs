//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KDQHNPHTool
{
    using System;
    using System.Collections.Generic;
    
    public partial class dbThanThap
    {
        public dbThanThap()
        {
            this.dbThanThapAttributes = new HashSet<dbThanThapAttribute>();
            this.dbThanThapFloorRewards = new HashSet<dbThanThapFloorReward>();
            this.dbThanThapMoneyResets = new HashSet<dbThanThapMoneyReset>();
            this.dbThanThapMonsters = new HashSet<dbThanThapMonster>();
            this.dbThanThapPlusAttributeRequires = new HashSet<dbThanThapPlusAttributeRequire>();
            this.dbThanThapStarRewards = new HashSet<dbThanThapStarReward>();
        }
    
        public int id { get; set; }
        public Nullable<int> idConfig { get; set; }
        public Nullable<int> hourEnd { get; set; }
        public Nullable<int> prefixRestPlusGold { get; set; }
        public Nullable<int> levelRequire { get; set; }
        public Nullable<int> stepFloorGetBonusAttribute { get; set; }
        public Nullable<int> stepFloorGetBonusReward { get; set; }
        public Nullable<int> modLevel { get; set; }
        public Nullable<int> modPower { get; set; }
        public Nullable<int> modPromotion { get; set; }
        public Nullable<int> modStar { get; set; }
        public Nullable<int> modDifficult { get; set; }
        public Nullable<int> maxLevel { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<double> modLevelF { get; set; }
        public Nullable<double> modPowerF { get; set; }
        public Nullable<double> modStarF { get; set; }
        public Nullable<double> modDifficultF { get; set; }
    
        public virtual dbConfig dbConfig { get; set; }
        public virtual ICollection<dbThanThapAttribute> dbThanThapAttributes { get; set; }
        public virtual ICollection<dbThanThapFloorReward> dbThanThapFloorRewards { get; set; }
        public virtual ICollection<dbThanThapMoneyReset> dbThanThapMoneyResets { get; set; }
        public virtual ICollection<dbThanThapMonster> dbThanThapMonsters { get; set; }
        public virtual ICollection<dbThanThapPlusAttributeRequire> dbThanThapPlusAttributeRequires { get; set; }
        public virtual ICollection<dbThanThapStarReward> dbThanThapStarRewards { get; set; }
    }
}
