//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BBCTDesignerTool
{
    using System;
    using System.Collections.Generic;
    
    public partial class dbLevelRewardConfig
    {
        public dbLevelRewardConfig()
        {
            this.dbLevelReward_Reward = new HashSet<dbLevelReward_Reward>();
        }
    
        public int id { get; set; }
        public Nullable<int> levels { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual ICollection<dbLevelReward_Reward> dbLevelReward_Reward { get; set; }
    }
}
