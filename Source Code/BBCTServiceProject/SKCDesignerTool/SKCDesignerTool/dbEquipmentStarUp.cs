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
    
    public partial class dbEquipmentStarUp
    {
        public dbEquipmentStarUp()
        {
            this.dbEquipmentReceipts = new HashSet<dbEquipmentReceipt>();
        }
    
        public int id { get; set; }
        public Nullable<int> idEquipment { get; set; }
        public Nullable<int> value { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual dbEquipment dbEquipment { get; set; }
        public virtual ICollection<dbEquipmentReceipt> dbEquipmentReceipts { get; set; }
    }
}