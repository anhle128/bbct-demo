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
    
    public partial class dbPucLoiThangConfig
    {
        public dbPucLoiThangConfig()
        {
            this.dbPucLoiThangRewards = new HashSet<dbPucLoiThangReward>();
        }
    
        public int id { get; set; }
        public Nullable<int> goldRequire { get; set; }
        public Nullable<int> ngay { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual ICollection<dbPucLoiThangReward> dbPucLoiThangRewards { get; set; }
    }
}