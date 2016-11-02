using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model
{
    [ProtoContract]
    public class Server
    {
        [ProtoMember(1)]
        public string id { get; set; }
        [ProtoMember(2)]
        public string value { get; set; }

        public Server()
        {

        }
    }
}
