using StaticDB.Models;

namespace BattleSimulator
{
    public class SkillCalculator
    {
        public Skill info;
        public int level;

        private MainAttribute[] attributes;
        private float[] afflictionAttributes;

        public SkillCalculator(Skill info, int level)
        {
            this.info = info;
            this.level = level;
        }

        public void Calculate()
        {
            if (info.attributes != null)
            {
                attributes = new MainAttribute[info.attributes.Length];
                for (int i = 0; i < attributes.Length; i++)
                {
                    attributes[i] = new MainAttribute()
                    {
                        mod = info.attributes[i].mod + info.attributes[i].growthMod * level,
                        attribute = info.attributes[i].attribute,
                    };
                }
            }
            if (info.afflictionAttributes != null)
            {
                afflictionAttributes = new float[info.afflictionAttributes.Length];
                for (int i = 0; i < afflictionAttributes.Length; i++)
                {
                    afflictionAttributes[i] = info.afflictionAttributes[i].mod + info.afflictionAttributes[i].growthMod * level;
                }
            }
        }

        public int GetCooldown()
        {
            return info.cooldown;
        }

        public MainAttribute[] GetAttributes()
        {
            if (attributes != null)
            {
                return attributes;
            }
            return new MainAttribute[] { };
        }

        public float[] GetAfflictionAttributes()
        {
            if (afflictionAttributes != null)
            {
                return afflictionAttributes;
            }
            return new float[] { 0f };
        }

        public float[] GetAttributesFloat()
        {
            if (attributes != null)
            {
                float[] attTmp = new float[attributes.Length];
                for (int i = 0; i < attTmp.Length; i++)
                {
                    attTmp[i] = attributes[i].mod;
                }
                return attTmp;
            }
            return new float[] { 0f };
        }

        public float GetModAttribute()
        {
            return attributes[0].mod;
        }
    }
}
