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
    
    public partial class dbLuanKiemPoint
    {
        public int id { get; set; }
        public Nullable<int> idLuanKiem { get; set; }
        public Nullable<int> rangeStart { get; set; }
        public Nullable<int> rangeEnd { get; set; }
        public Nullable<int> pointReward { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> silverReward { get; set; }
        public Nullable<int> goldReward { get; set; }
    
        public virtual dbLuanKiemConfig dbLuanKiemConfig { get; set; }
    }
}
