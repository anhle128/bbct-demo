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
    
    public partial class dbVanTieu
    {
        public dbVanTieu()
        {
            this.dbVanTieuProtectRewards = new HashSet<dbVanTieuProtectReward>();
            this.dbVanTieuRobRewards = new HashSet<dbVanTieuRobReward>();
        }
    
        public int id { get; set; }
        public Nullable<int> idConfig { get; set; }
        public Nullable<int> silverReward { get; set; }
        public Nullable<int> procs { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual dbConfig dbConfig { get; set; }
        public virtual ICollection<dbVanTieuProtectReward> dbVanTieuProtectRewards { get; set; }
        public virtual ICollection<dbVanTieuRobReward> dbVanTieuRobRewards { get; set; }
    }
}