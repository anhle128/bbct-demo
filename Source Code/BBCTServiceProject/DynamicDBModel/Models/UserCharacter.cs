using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserCharacter
    {
        [ProtoMember(1)]
        public string _id { get; set; }
        [ProtoMember(2)]
        public int char_id { get; set; }
        [ProtoMember(3)]
        public int level { get; set; }
        [ProtoMember(4)]
        public int exp { get; set; }
        [ProtoMember(5)]
        public int powerup_level { get; set; } // cuong hoa
        [ProtoMember(6)]
        public int star_level { get; set; } // thăng sao
        [ProtoMember(7)]
        public List<LevelSkill> active_skills { get; set; }
        [ProtoMember(8)]
        public List<LevelSkill> passive_skills { get; set; }
        [ProtoMember(9)]
        public List<string> equipments { get; set; }
    }
}
