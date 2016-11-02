using ProtoBuf;
using System;

namespace StaticDB.Models
{
    [ProtoContract]
    public class ExchangeGoldToSilverConfig
    {
        [ProtoMember(1)]
        public int levelRequire { get; set; }

        [ProtoMember(2)]
        public int freeTimes { get; set; } // số lần đổi bạc miễn phí

        [ProtoMember(3)]
        public double procBonusSilver { get; set; } // tỉ lệ bạo kích (0 ~ 1)

        [ProtoMember(4)]
        public double bonusSilver { get; set; }

        [ProtoMember(5)]
        public double stepUpGold { get; set; } // bước tiến tăng gold sau mỗi lần đổi

        [ProtoMember(6)]
        public int baseGold { get; set; }
        
        [ProtoMember(7)]
        public int baseSilver { get; set; }

        public int GetGoldNeed(int times)
        {
            if (times > freeTimes)
            {
                int totalGoldNeed = baseGold;
                for (int i = 0; i < (times-freeTimes); i++)
                {
                    if (i == 0)
                        continue;
                    totalGoldNeed = Convert.ToInt32(totalGoldNeed * stepUpGold);
                }
                return totalGoldNeed;
            }
            else
            {
                return baseGold;
            }
        }

        public int GetBonusSilver()
        {
            return Convert.ToInt32(baseSilver * bonusSilver);
        }
    }
}
