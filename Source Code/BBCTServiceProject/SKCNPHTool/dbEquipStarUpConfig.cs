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
    
    public partial class dbEquipStarUpConfig
    {
        public dbEquipStarUpConfig()
        {
            this.dbEquipStarUpDetails = new HashSet<dbEquipStarUpDetail>();
        }
    
        public int id { get; set; }
        public Nullable<int> idEquipmentConfig { get; set; }
        public Nullable<int> value { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> amountItemNeed { get; set; }
        public Nullable<double> modifierAttribute { get; set; }
        public Nullable<int> amountExtendAttributeBeOpened { get; set; }
        public Nullable<int> equipStockStar { get; set; }
        public Nullable<int> promotion { get; set; }
    
        public virtual dbEquipmentConfig dbEquipmentConfig { get; set; }
        public virtual ICollection<dbEquipStarUpDetail> dbEquipStarUpDetails { get; set; }
    }
}
