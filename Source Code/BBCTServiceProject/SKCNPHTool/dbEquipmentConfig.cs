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
    
    public partial class dbEquipmentConfig
    {
        public dbEquipmentConfig()
        {
            this.dbEquipStarUpConfigs = new HashSet<dbEquipStarUpConfig>();
            this.dbpieceExportReceives = new HashSet<dbpieceExportReceive>();
            this.dbPieceNeedToImports = new HashSet<dbPieceNeedToImport>();
        }
    
        public int id { get; set; }
        public Nullable<int> goldSilverToLevelUp { get; set; }
        public Nullable<int> maxStarCanReach { get; set; }
        public Nullable<int> levelDefault { get; set; }
        public Nullable<int> starLevelDefault { get; set; }
        public Nullable<int> maxEquipToUpStar { get; set; }
        public Nullable<double> procReceivedUpStar { get; set; }
        public Nullable<int> baseGold { get; set; }
    
        public virtual ICollection<dbEquipStarUpConfig> dbEquipStarUpConfigs { get; set; }
        public virtual ICollection<dbpieceExportReceive> dbpieceExportReceives { get; set; }
        public virtual ICollection<dbPieceNeedToImport> dbPieceNeedToImports { get; set; }
    }
}
