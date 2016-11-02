using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class DoiHinhDuBiRequire
    {
        [ProtoMember(1)]
        public int numberItem { get; set; }
        [ProtoMember(2)]
        public int level { get; set; }
    }
}
