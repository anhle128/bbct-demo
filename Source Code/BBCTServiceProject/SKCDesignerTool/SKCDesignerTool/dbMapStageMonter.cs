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
    
    public partial class dbMapStageMonter
    {
        public int id { get; set; }
        public Nullable<int> idStage { get; set; }
        public Nullable<int> idMonter { get; set; }
        public Nullable<int> levels { get; set; }
        public Nullable<int> levelPower { get; set; }
        public Nullable<int> star { get; set; }
        public Nullable<int> col { get; set; }
        public Nullable<int> row { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual dbMapStage dbMapStage { get; set; }
    }
}
