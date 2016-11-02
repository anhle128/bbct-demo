using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class DoiHinhDuBiConfig
    {
        [ProtoMember(1)]
        public DoiHinhDuBiRequire[] datas { get; set; }
    }
}
