﻿using ProtoBuf;

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
        public int[] goldNeedToPowerups { get; set; }

        [ProtoMember(6)]
        public int[] goldNeedToStarups { get; set; }

        [ProtoMember(7)]
        public int[] goldneedToFusions { get; set; }

        [ProtoMember(8)]
        public StarLevelExp[] arrCharStarLevelExpConfig { get; set; }

        [ProtoMember(9)]
        public int sellPrice { get; set; }
        [ProtoMember(10)]
        public float maxResKH { get; set; } // max % kháng hệ
        [ProtoMember(11)]
        public SkillStarLevel[] skillStarLevels { get; set; }

        public int GetGoldNeedToPowerup(int currentStar)
        {
            return goldNeedToPowerups[currentStar - 1];
        }

        public int GetGoldNeedToStarUp(int currentStar)
        {
            return goldNeedToStarups[currentStar - 1];
        }

        public int GetGoldNeedToFusion(int currentStar)
        {
            return goldNeedToStarups[currentStar - 1];
        }

        public int GetExpReceiveToPowerup(int currentStar, int otherStar)
        {
            StarLevelExp starLevelExp = arrCharStarLevelExpConfig[currentStar];
            return starLevelExp.exp[otherStar - 1];
        }
    }
}