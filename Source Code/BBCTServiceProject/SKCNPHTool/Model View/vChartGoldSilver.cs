using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    [ProtoContract]
    class vChartGoldSilver
    {
        [ProtoMember(1)]
        public string type { get; set; }
        [ProtoMember(2)]
        public double hienCo { get; set; }
        [ProtoMember(3)]
        public double daTieu { get; set; }
        public vChartGoldSilver()
        {

        }
    }
}
