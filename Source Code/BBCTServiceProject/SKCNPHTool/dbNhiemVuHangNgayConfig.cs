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
    
    public partial class dbNhiemVuHangNgayConfig
    {
        public dbNhiemVuHangNgayConfig()
        {
            this.dbNhiemVuHangNgays = new HashSet<dbNhiemVuHangNgay>();
        }
    
        public int id { get; set; }
        public Nullable<int> idConfig { get; set; }
        public Nullable<int> goldRequireCompolete { get; set; }
    
        public virtual dbConfig dbConfig { get; set; }
        public virtual ICollection<dbNhiemVuHangNgay> dbNhiemVuHangNgays { get; set; }
    }
}
