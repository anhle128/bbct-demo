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
    
    public partial class dbVanTieuProtectReward
    {
        public int id { get; set; }
        public Nullable<int> idVanTieu { get; set; }
        public Nullable<int> typeReward { get; set; }
        public Nullable<int> staticID { get; set; }
        public Nullable<int> amountMin { get; set; }
        public Nullable<int> amountMax { get; set; }
        public Nullable<double> procs { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual dbVanTieu dbVanTieu { get; set; }
    }
}
