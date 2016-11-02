using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    [ProtoContract]
    public class vChartOnlineTime510152030
    {
        [ProtoMember(1)]
        public string time { get; set; }
        [ProtoMember(2)]
        public int value { get; set; }
        public vChartOnlineTime510152030()
        {

        }
    }
}
