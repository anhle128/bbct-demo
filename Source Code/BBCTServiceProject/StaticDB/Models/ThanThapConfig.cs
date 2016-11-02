using ProtoBuf;
using StaticDB.Enum;
using System.Collections.Generic;

namespace StaticDB.Models
{
    [ProtoContract]
    public class ThanThapConfig
    {

        [ProtoMember(1)]
        public int hourEnd;
        [ProtoMember(2)]
        public int[] starRewards;
        [ProtoMember(3)]
        public MoneyResetThanThap[] moneyRest;
        [ProtoMember(4)]
        public int prefixRestPlusGold;
        [ProtoMember(5)]
        public int[] attributes;
        [ProtoMember(6)]
        public PlusAttributeRequire[] plushAttributeRequires;
        [ProtoMember(7)]
        public int levelRequire;
        [ProtoMember(8)]
        public int stepFloorGetBonusAttribute;
        [ProtoMember(9)]
        public int stepFloorGetBonusReward;
        [ProtoMember(10)]
        public float modLevel;
        [ProtoMember(11)]
        public float modPower;
        [ProtoMember(12)]
        public float modStar;
        [ProtoMember(13)]
        public float modDifficult;
        [ProtoMember(14)]
        public Reward[] floorRewards;
        [ProtoMember(15)]
        public List<ThanThapFormation> monsters;

        public MoneyResetThanThap GetMoneyResestThanThap(int times)
        {
            if (times < moneyRest.Length)
            {
                return moneyRest[times];
            }
            else
            {
                int goldNeedAtFirstTime = moneyRest[moneyRest.Length - 1].quantity;
                int timeUserGold = times - moneyRest.Length + 1;
                int totalGoldNeed = goldNeedAtFirstTime;
                for (int i = 0; i < timeUserGold; i++)
                {
                    totalGoldNeed = totalGoldNeed + prefixRestPlusGold;
                }
                return new MoneyResetThanThap()
                {
                    quantity = totalGoldNeed,
                    type = (int)TypeReward.Gold
                };

            }
        }
    }
}
