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
    
    public partial class dbGuildBoss
    {
        public dbGuildBoss()
        {
            this.dbGuildBossRewards = new HashSet<dbGuildBossReward>();
        }
    
        public int id { get; set; }
        public Nullable<int> idGuild { get; set; }
        public Nullable<int> minRange { get; set; }
        public Nullable<int> maxRange { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual ICollection<dbGuildBossReward> dbGuildBossRewards { get; set; }
        public virtual dbGuildConfig dbGuildConfig { get; set; }
    }
}