using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model
{
    [ProtoContract]
    public class RuongBauModel
    {
        [ProtoMember(1)]
        public string id_ruong { get; set; }
        [ProtoMember(2)]
        public string value { get; set; }

        public RuongBauModel()
        {

        }
    }
}
