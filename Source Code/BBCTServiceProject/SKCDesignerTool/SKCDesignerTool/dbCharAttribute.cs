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
    
    public partial class dbCharAttribute
    {
        public int id { get; set; }
        public Nullable<int> idCharacter { get; set; }
        public Nullable<int> attribute { get; set; }
        public Nullable<double> mods { get; set; }
        public Nullable<double> growthMod { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual dbCharacter dbCharacter { get; set; }
    }
}
