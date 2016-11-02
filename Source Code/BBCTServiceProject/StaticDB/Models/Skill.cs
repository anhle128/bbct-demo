using ProtoBuf;
using StaticDB.Enum;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Skill
    {
        [ProtoMember(1)]
        public string name { get; set; } //tên
        [ProtoMember(2)]
        public string description { get; set; } // mô tả
        [ProtoMember(3)]
        public int type { get; set; } // loại skill unitimate or normal passive
        [ProtoMember(4)]
        public int slot { get; set; } //slot
        [ProtoMember(5)]
        public CategoryCharacter category { get; set; } //nội ngoại
        [ProtoMember(6)]
        public int cooldown { get; set; } //lượt dãn cách
        [ProtoMember(7)]
        public int startCooldown { get; set; } //lượt chờ ban đầu
        [ProtoMember(8)]
        public TargetSkill target { get; set; } //đối tượng
        [ProtoMember(9)]
        public EffectSkill effect { get; set; } // tác dụng
        [ProtoMember(10)]
        public RangeSkill range { get; set; } // phạm vi
        [ProtoMember(11)]
        public Affliction afflictionSkill { get; set; } //hiệu ứng
        [ProtoMember(12)]
        public MainAttribute[] afflictionAttributes { get; set; }
        [ProtoMember(13)]
        public MainAttribute[] attributes { get; set; }
        [ProtoMember(14)]
        public int countTurn { get; set; } //số chiêu
        [ProtoMember(15)]
        public TypeSpawnSkill typeSpawnSkill { get; set; } //vị trí
        [ProtoMember(17)]
        public int afflictionDuration { get; set; } //thời gian hiệu ứng
        [ProtoMember(18)]
        public float afflictionProc { get; set; } //tỉ lệ sảy ra hiệu ứng

        public Skill()
        {

        }
    }
}
