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
    
    public partial class dbGlobalAttackConfig
    {
        public int id { get; set; }
        public Nullable<int> idGlobal { get; set; }
        public Nullable<int> vipRequire { get; set; }
        public Nullable<int> waitTime { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual dbGlobalBossConfig dbGlobalBossConfig { get; set; }
    }
}
