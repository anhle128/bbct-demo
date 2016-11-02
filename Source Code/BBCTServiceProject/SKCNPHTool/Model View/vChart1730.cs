using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    [ProtoContract]
    public class vChart1730
    {
        [ProtoMember(1)]
        public string date { get; set; }
        [ProtoMember(2)]
        public int value { get; set; }
        public vChart1730()
        {

        }
    }
}
