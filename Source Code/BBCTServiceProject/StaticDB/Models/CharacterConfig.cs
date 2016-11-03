using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class CharacterConfig
    {
        [ProtoMember(1)]
        public CharDefaultConfig defaultConfig { get; set; }
        [ProtoMember(2)]
        public CharSelection[] defaultCharSelections { get; set; }
        [ProtoMember(3)]
        public int maxLevel { get; set; }
        [ProtoMember(4)]
        public int maxPowerup { get; set; }

        [ProtoMember(5)]
        public int[] silverNeedToPowerups { get; set; }

        [ProtoMember(6)]
        public int[] silverNeedToStarups { get; set; }

        [ProtoMember(7)]
        public int[] silverneedToFusions { get; set; }

        [ProtoMember(8)]
        public StarLevelExp[] arrCharStarLevelExpConfig { get; set; }

        [ProtoMember(9)]
        public int sellPrice { get; set; }
        [ProtoMember(10)]
        public float maxResKH { get; set; } // max % kháng hệ
        [ProtoMember(11)]
        public SkillStarLevel[] skillStarLevels { get; set; }

        [ProtoMember(12)]
        public int maxStar { get; set; }

        public int GetSilverNeedToPowerup(int currentStar)
        {
            return silverNeedToPowerups[currentStar - 1];
        }

        public int GetSilverNeedToStarUp(int currentStar)
        {
            return silverNeedToStarups[currentStar - 1];
        }

        public int GetSilverNeedToFusion(int currentStar)
        {
            return silverNeedToStarups[currentStar - 1];
        }

        public int GetExpReceiveToPowerup(int currentStar, int otherStar)
        {
            StarLevelExp starLevelExp = arrCharStarLevelExpConfig[currentStar];
            return starLevelExp.exp[otherStar - 1];
        }
    }
}
