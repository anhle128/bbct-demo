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
    
    public partial class dbCharPowerUpReceipt
    {
        public dbCharPowerUpReceipt()
        {
            this.dbCharDetailPowerUpReceipts = new HashSet<dbCharDetailPowerUpReceipt>();
        }
    
        public int id { get; set; }
        public Nullable<int> idCharacter { get; set; }
        public Nullable<int> gen { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual dbCharacter dbCharacter { get; set; }
        public virtual ICollection<dbCharDetailPowerUpReceipt> dbCharDetailPowerUpReceipts { get; set; }
    }
}
