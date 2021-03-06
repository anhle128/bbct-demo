//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KDQHNPHTool
{
    using System;
    using System.Collections.Generic;
    
    public partial class dbCharSkill
    {
        public dbCharSkill()
        {
            this.dbCharSkillAfflictionAttributes = new HashSet<dbCharSkillAfflictionAttribute>();
            this.dbCharSkillAttributes = new HashSet<dbCharSkillAttribute>();
        }
    
        public int id { get; set; }
        public Nullable<int> idCharacter { get; set; }
        public string name { get; set; }
        public string descriptions { get; set; }
        public Nullable<int> types { get; set; }
        public Nullable<int> slot { get; set; }
        public Nullable<int> category { get; set; }
        public Nullable<int> cooldown { get; set; }
        public Nullable<int> targets { get; set; }
        public Nullable<int> effect { get; set; }
        public Nullable<int> ranges { get; set; }
        public Nullable<int> afflictionSkill { get; set; }
        public Nullable<int> orders { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> countTurn { get; set; }
        public Nullable<int> typeSpawnSkill { get; set; }
        public Nullable<int> manaCost { get; set; }
        public Nullable<int> afflictionDuration { get; set; }
        public Nullable<double> afflictionProc { get; set; }
        public Nullable<int> categoryMain { get; set; }
    
        public virtual dbCharacter dbCharacter { get; set; }
        public virtual ICollection<dbCharSkillAfflictionAttribute> dbCharSkillAfflictionAttributes { get; set; }
        public virtual ICollection<dbCharSkillAttribute> dbCharSkillAttributes { get; set; }
    }
}
