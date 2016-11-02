using ProtoBuf;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class PhucLoiThangConfig
    {
        [ProtoMember(1)]
        public int rubyRequire { get; set; }

        [ProtoMember(2)]
        public int ngay { get; set; }
        [ProtoMember(3)]
        public List<Reward> rewards { get; set; }
    }
}
