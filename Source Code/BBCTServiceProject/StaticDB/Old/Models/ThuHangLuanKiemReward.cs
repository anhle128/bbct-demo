using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class ThuHangLuanKiemReward
    {
        [ProtoMember(1)]
        public int index { get; set; }

        [ProtoMember(2)]
        public List<SubReward> rewards { get; set; }
    }
}
