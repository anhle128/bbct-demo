using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    [ProtoContract]
    public class vThanTai
    {
        [ProtoMember(1)]
        public int goldRequire { get; set; }
        [ProtoMember(2)]
        public int goldMin { get; set; }
        [ProtoMember(3)]
        public int goldMax { get; set; }
        public vThanTai()
        {

        }
    }
}
