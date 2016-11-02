using StaticDB.Enum;

namespace BattleSimulator
{
    public class BAfflictionController
    {
        public BAffliction[] afflictions;
        public BCharacter owner;

        public BAfflictionController(BCharacter owner)
        {
            this.owner = owner;
            afflictions = new BAffliction[21];
            for (int i = 0; i < afflictions.Length; i++)
            {
                afflictions[i] = new BAffliction((Affliction)i + 1, owner);
            }
        }

        public void StartAffliction(Affliction aff, float attribute, int duration)
        {
            if (!owner.affController.GetAffliction(Affliction.KhangHieuUng).IsStart())
            {
                if (aff == Affliction.DongBang || aff == Affliction.Choang)
                {
                    duration += 1;
                }
                afflictions[(int)aff - 1].StartAffliction(attribute, duration);
            }
        }

        public float Minus()
        {
            float totalDmg = 0;
            for (int i = 0; i < afflictions.Length; i++)
            {
                totalDmg += afflictions[i].Minus();
            }
            return totalDmg;
        }

        public void EndAffliction(Affliction aff)
        {
            afflictions[(int)aff - 1].EndAffliction();
        }

        public BAffliction GetAffliction(Affliction aff)
        {
            return afflictions[(int)aff - 1];
        }
    }
}
