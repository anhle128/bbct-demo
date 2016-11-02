using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class GuildMember
    {
        [ProtoMember(1)]
        public string username { get; set; }
        [ProtoMember(2)]
        public string nickname { get; set; }
        [ProtoMember(3)]
        public int avatar { get; set; }
        [ProtoMember(4)]
        public int vip { get; set; }
        [ProtoMember(5)]
        public int level { get; set; }
        [ProtoMember(6)]
        public bool isMaster { get; set; }
        [ProtoMember(7)]
        public int contribution { get; set; }
        [ProtoMember(8)]
        public DateTime lastUpdate { get; set; }
    }
}
