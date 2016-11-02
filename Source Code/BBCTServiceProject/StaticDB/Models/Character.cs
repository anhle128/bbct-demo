using ProtoBuf;
using StaticDB.Enum;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Character
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public string name { get; set; } //tên
        [ProtoMember(3)]
        public string description { get; set; } //giới thiệu
        [ProtoMember(4)]
        public CategoryCharacter category { get; set; } //nội ngoại
        [ProtoMember(6)]
        public MainAttribute[] attributes { get; set; }
        [ProtoMember(7)]
        public DuyenPhan[] duyenphans { get; set; }
        [ProtoMember(9)]
        public Skill normalSkill { get; set; } // chiêu tấn công thường
        [ProtoMember(10)]
        public Skill[] ultimateSkill { get; set; } //chiêu kĩ năng 1
        [ProtoMember(12)]
        public Skill passiveSkill { get; set; } // chiêu nội tại
        [ProtoMember(14)]
        public ClassCharacter classChar { get; set; } //class

        [ProtoMember(15)]
        public bool isCreep { get; set; }
        [ProtoMember(16)]
        public int idCharHuaNguyen { get; set; }
        [ProtoMember(17)]
        public bool isMale { get; set; } //giới tính
        [ProtoMember(18)]
        public TypeElement element { get; set; } //ngũ hành
        [ProtoMember(19)]
        public int idGroup { get; set; } //nhóm
        [ProtoMember(20)]
        public string quote { get; set; } //câu nói
        [ProtoMember(21)]
        public TypeCharacter type { get; set; } //Kiểu Anh Hùng or Ngũ Hành
        [ProtoMember(22)]
        public int lowestStarLevel { get; set; } // số sao nhỏ nhất của nhân vật
        [ProtoMember(23)]
        public int highestStarLevel { get; set; } // số sao lớn nhất của nhân vật

        public Character()
        {

        }
    }

}
