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
    
    public partial class dbNhiemVuHangNgay
    {
        public dbNhiemVuHangNgay()
        {
            this.dbNhiemVuHangNgayRewards = new HashSet<dbNhiemVuHangNgayReward>();
        }
    
        public int id { get; set; }
        public Nullable<int> idChinhTuyen { get; set; }
        public Nullable<int> types { get; set; }
        public string name { get; set; }
        public string des { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual dbNhiemVuHangNgayConfig dbNhiemVuHangNgayConfig { get; set; }
        public virtual ICollection<dbNhiemVuHangNgayReward> dbNhiemVuHangNgayRewards { get; set; }
    }
}
