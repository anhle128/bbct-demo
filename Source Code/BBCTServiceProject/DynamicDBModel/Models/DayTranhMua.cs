
using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class DayTranhMua
    {
        [ProtoMember(1)]
        public int day { get; set; }
        [ProtoMember(2)]
        public List<ItemTranhMua> items { get; set; }
    }
}
