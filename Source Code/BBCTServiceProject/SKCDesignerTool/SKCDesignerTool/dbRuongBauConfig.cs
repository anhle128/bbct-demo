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
    
    public partial class dbRuongBauConfig
    {
        public dbRuongBauConfig()
        {
            this.dbRuongBauRewards = new HashSet<dbRuongBauReward>();
        }
    
        public int id { get; set; }
        public Nullable<int> idRuongBau { get; set; }
        public string name { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual ICollection<dbRuongBauReward> dbRuongBauRewards { get; set; }
    }
}
