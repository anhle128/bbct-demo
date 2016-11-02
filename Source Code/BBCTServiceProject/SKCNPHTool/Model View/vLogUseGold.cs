using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    [ProtoContract]
    public class vLogUseGold
    {
        [ProtoMember(1)]
        public int old_glod { get; set; }
        [ProtoMember(2)]
        public int reward_glod { get; set; }
        [ProtoMember(3)]
        public int new_gold { get; set; }
        [ProtoMember(4)]
        public int reason { get; set; }
        [ProtoMember(5)]
        public int type { get; set; }
        [ProtoMember(6)]
        public DateTime timeUse { get; set; }
        public vLogUseGold()
        {

        }
    }
}
