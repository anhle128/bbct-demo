using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class EquipmentConfig
    {

        [ProtoMember(1)]
        public EquipDefaultConfig defaultConfig { get; set; }
        public int sellPrice { get; set; }
        [ProtoMember(3)]
        public float[] procElements { get; set; }
        [ProtoMember(4)]
        public Equip2Equip[] equipSupports { get; set; } // kích hoạt theo trang bị
        [ProtoMember(5)]
        public Element2Element[] elementSupports { get; set; } // kích hoạt theo thuộc tính
        [ProtoMember(6)]
        public StarLevelExp[] charStarLevelExpConfigs { get; set; }
        [ProtoMember(7)]
        public int[] goldNeedToPowerups { get; set; }
        [ProtoMember(8)]
        public int[] goldNeedToStarups { get; set; }

        public int GetExpReceiveToPowerup(int currentStar, int otherStar)
        {
            StarLevelExp starLevelExp = charStarLevelExpConfigs[currentStar];
            return starLevelExp.exp[otherStar - 1];
        }

        public int GetGoldNeedToStarUp(int currentStar)
        {
            return goldNeedToStarups[currentStar - 1];
        }
    }
}