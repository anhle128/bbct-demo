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
    
    public partial class dbThanThapPlusAttributeRequire
    {
        public int id { get; set; }
        public Nullable<int> idThanThap { get; set; }
        public Nullable<int> startRequire { get; set; }
        public Nullable<int> procReceive { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual dbThanThap dbThanThap { get; set; }
    }
}
