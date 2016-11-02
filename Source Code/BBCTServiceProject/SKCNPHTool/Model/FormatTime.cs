using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model
{
    [ProtoContract]
    public class FormatTime
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public int value { get; set; }
        [ProtoMember(3)]
        public int aven { get; set; }
        public FormatTime()
        {

        }
    }
}
