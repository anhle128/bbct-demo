using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class NhiemVuHangNgay
    {
        [ProtoMember(1)]
        public int count { get; set; }
        [ProtoMember(2)]
        public int silver { get; set; }
        [ProtoMember(3)]
        public int gold { get; set; }
        [ProtoMember(4)]
        public int exp { get; set; }
        [ProtoMember(5)]
        public int id { get; set; }

        public NhiemVuHangNgay()
        { }
    }
}
