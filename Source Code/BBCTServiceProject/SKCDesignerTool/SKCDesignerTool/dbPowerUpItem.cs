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
    
    public partial class dbPowerUpItem
    {
        public dbPowerUpItem()
        {
            this.dbPowerUpItemsAttributes = new HashSet<dbPowerUpItemsAttribute>();
            this.dbPowerUpItemsReceipts = new HashSet<dbPowerUpItemsReceipt>();
        }
    
        public int id { get; set; }
        public Nullable<int> idPowerUpItems { get; set; }
        public Nullable<int> levelRequire { get; set; }
        public Nullable<int> promotion { get; set; }
        public Nullable<int> status { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<dbPowerUpItemsAttribute> dbPowerUpItemsAttributes { get; set; }
        public virtual ICollection<dbPowerUpItemsReceipt> dbPowerUpItemsReceipts { get; set; }
    }
}
