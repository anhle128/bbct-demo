using ProtoBuf;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Exp
    {
        [ProtoMember(1)]
        public List<Upgrade> upgrades { get; set; }

        public Exp()
        {

        }
    }
}
