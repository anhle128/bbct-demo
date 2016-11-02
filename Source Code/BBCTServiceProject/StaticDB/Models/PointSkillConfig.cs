
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class PointSkillConfig
    {
        [ProtoMember(1)]
        public int maxPointSkillCanReach { get; set; } // max point người dùng có thể có
        [ProtoMember(2)]
        public int pointNeedToUpSkill { get; set; } // số point cần để nâng cấp skill
        [ProtoMember(3)]
        public int minuteAutoUpPoint { get; set; } // thời gian để hồi point up skill (minute)
        [ProtoMember(4)]
        public int baseGoldToBuy { get; set; } // số gold cơ bản cần để mua point skill
        [ProtoMember(5)]
        public int stepGoldToBuy { get; set; } // số gold được cộng sau mỗi lần mua point skill

        public int GetGoldNeedToBuy(int times)
        {
            return baseGoldToBuy + (times - 1)*stepGoldToBuy;
        }
    }
}
