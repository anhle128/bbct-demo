using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class BadWord
    {
        [ProtoMember(1)]
        public List<string> listBadWord { get; set; }
        [ProtoMember(2)]
        public Dictionary<string, string> dicBadWord { get; set; }

        public BadWord()
        {

        }
    }
}
