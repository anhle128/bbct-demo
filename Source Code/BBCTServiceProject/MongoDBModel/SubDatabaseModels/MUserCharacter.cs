using DynamicDBModel.Models;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserCharacter : IStaticObj
    {
        public int level { get; set; }
        public int exp { get; set; }
        public int powerup_level { get; set; } // cường hóa
        public int star_level { get; set; } // sao
        public List<LevelSkill> active_skills { get; set; }
        public LevelSkill passive_skill { get; set; }
        public List<string> equipments { get; set; } // trang bi
    }
}
