using MongoDBModel.Implement;
using StaticDB.Enum;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserEquip : IStaticObj
    {
        public TypeElement element { get; set; }
        public int powerup_level { get; set; }
        public int star_level { get; set; }
        public CharacterAttribute bonus_attribute { get; set; }
        public float bonus_attribute_grow_mod { get; set; }
        public float bonus_attribute_mod { get; set; }
        public string char_equip { get; set; }
    }
}
