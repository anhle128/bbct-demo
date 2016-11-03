using StaticDB.Enum;

namespace BattleSimulator
{
    public class BAffliction
    {
        public Affliction id;
        public BCharacter owner;
        public float attribute;
        private bool isStart = false;
        public int duration;

        public BAffliction(Affliction id, BCharacter owner)
        {
            this.id = id;
            this.owner = owner;
        }

        public void StartAffliction(float attribute, int duration)
        {
            this.attribute = attribute;
            this.duration = duration;

            isStart = true;
            if (id == Affliction.TangCong)
            {
                owner.calculator.Buff(CharacterAttribute.Physic, attribute);
                owner.calculator.Buff(CharacterAttribute.Magic, attribute);
            }
            if (id == Affliction.GiamCong)
            {
                owner.calculator.Debuff(CharacterAttribute.Physic, attribute);
                owner.calculator.Debuff(CharacterAttribute.Magic, attribute);
            }
            if (id == Affliction.TangGiap)
            {
                owner.calculator.Buff(CharacterAttribute.Def, attribute);
            }
            if (id == Affliction.PhaGiap)
            {
                owner.calculator.Debuff(CharacterAttribute.Def, attribute);
            }
            if (id == Affliction.TangBao)
            {
                owner.calculator.Buff(CharacterAttribute.CritRate, attribute);
            }
        }

        public float Minus()
        {
            if (isStart)
            {
                if (duration > 0)
                {
                    duration--;
                }
                if (duration == 0)
                {
                    EndAffliction();
                }
                if (id == Affliction.TrungDoc || id == Affliction.DotChay)
                {
                    float dmg = owner.calculator.GetAttribute(CharacterAttribute.Hp) * attribute / 100f;
                    owner.MinusHP(dmg);
                    return dmg;
                }
            }
            return 0f;
        }

        public void EndAffliction()
        {
            isStart = false;
            if (id == Affliction.TangCong)
            {
                owner.calculator.Debuff(CharacterAttribute.Physic, attribute);
                owner.calculator.Debuff(CharacterAttribute.Magic, attribute);
            }
            if (id == Affliction.GiamCong)
            {
                owner.calculator.Buff(CharacterAttribute.Physic, attribute);
                owner.calculator.Buff(CharacterAttribute.Magic, attribute);
            }
            if (id == Affliction.TangGiap)
            {
                owner.calculator.Debuff(CharacterAttribute.Def, attribute);
            }
            if (id == Affliction.PhaGiap)
            {
                owner.calculator.Buff(CharacterAttribute.Def, attribute);
            }
            if (id == Affliction.TangBao)
            {
                owner.calculator.Debuff(CharacterAttribute.CritRate, attribute);
            }
        }

        public bool IsStart()
        {
            return isStart;
        }
    }
}
