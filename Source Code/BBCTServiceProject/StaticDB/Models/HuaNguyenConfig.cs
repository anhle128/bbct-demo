using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class HuaNguyenConfig
    {
        [ProtoMember(1)]
        public int levelRequire { get; set; }
        [ProtoMember(2)]
        public int freeTimes { get; set; }
        [ProtoMember(3)]
        public double procGetCharHuaNguyen { get; set; } // tỉ lê ra char hứa nguyện (0 -> 100)
        [ProtoMember(4)]
        public int numberSoulReward { get; set; }
    }
}
