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
    
    public partial class dbBattlePoint2Config
    {
        public int id { get; set; }
        public Nullable<int> idPoint2Array { get; set; }
        public Nullable<double> x { get; set; }
        public Nullable<double> y { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual dbBattlePoint2ArrayConfig dbBattlePoint2ArrayConfig { get; set; }
    }
}