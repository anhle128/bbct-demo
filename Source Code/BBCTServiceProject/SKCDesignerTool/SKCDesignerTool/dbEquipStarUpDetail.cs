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
    
    public partial class dbEquipStarUpDetail
    {
        public int id { get; set; }
        public Nullable<int> idStarUp { get; set; }
        public Nullable<double> value { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual dbEquipStarUpConfig dbEquipStarUpConfig { get; set; }
    }
}
