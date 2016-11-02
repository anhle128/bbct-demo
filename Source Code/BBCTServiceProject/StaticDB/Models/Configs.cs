using ProtoBuf;
using StaticDB.Enum;
using System;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Configs
    {

        [ProtoMember(1)]
        public BattleConfig battleConfig { get; set; }

        [ProtoMember(2)]
        public EquipmentConfig equipmentConfig { get; set; }

        [ProtoMember(3)]
        public CharacterConfig characterConfig { get; set; }

        [ProtoMember(4)]
        public CharacterLevelExp[] characterLevelExps { get; set; }

        [ProtoMember(5)]
        public int silverSellCommon { get; set; }

        [ProtoMember(6)]
        public VipConfig[] vipConfigs { get; set; }

        [ProtoMember(7)]
        public PlayerLevelExp[] playerLevelExps { get; set; }

        [ProtoMember(8)]
        public int maxLevelPlayer { get; set; }

        [ProtoMember(9)]
        public FreeStaminaConfig[] freeStaminaTimeConfig { get; set; }

        [ProtoMember(10)]
        public PointSkillConfig pointSkillConfig { get; set; }

        [ProtoMember(11)]
        public MoiRuouConfig moiRuouConfig { get; set; }

        [ProtoMember(12)]
        public FriendConfig friendConfig { get; set; }

        [ProtoMember(13)]
        public int maxStamina { get; set; }

        [ProtoMember(14)]
        public int maxPointSkill { get; set; }

        [ProtoMember(15)]
        public int timeCooldownPlusStamina { get; set; }

        [ProtoMember(16)]
        public int timeCooldownPlusPointSkill { get; set; }

        [ProtoMember(17)]
        public VanTieuConfig vanTieuConfig { get; set; }

        [ProtoMember(18)]
        public CuopTieuConfig cuopTieuConfig { get; set; }

        [ProtoMember(19)]
        public ThanThapConfig thanThapConfig { get; set; }

        [ProtoMember(20)]
        public GlobalBossConfig globalBossConfig { get; set; }

        [ProtoMember(21)]
        public int goldDoPhuongConfig { get; set; }

        [ProtoMember(22)]
        public CauCaConfig cauCaConfig { get; set; }

        [ProtoMember(23)]
        public LuanKiemConfig luanKiemConfig { get; set; }

        [ProtoMember(24)]
        public GuildConfig guildConfig { get; set; }

        [ProtoMember(25)]
        public ChucPhucConfig chucPhucConfig { get; set; }

        [ProtoMember(26)]
        public NhiemVuHangNgayConfig nhiemVuHangNgayConfig { get; set; }

        [ProtoMember(27)]
        public NhiemVuChinhTuyenConfig nhiemVuChinhTuyenConfig { get; set; }

        [ProtoMember(29)]
        public HoatDongDiemDanhConfig hoatDongDiemDanhConfig { get; set; }

        [ProtoMember(30)]
        public BadWord badWord { get; set; }

        [ProtoMember(31)]
        public LevelReward[] levelRewardConfig { get; set; }

        [ProtoMember(32)]
        public PhucLoiThangConfig phucLoiThangConfig { get; set; }

        [ProtoMember(33)]
        public int priceStartBuyMarket { get; set; }
        [ProtoMember(34)]
        public float percentBuySuccessMarket { get; set; }

        [ProtoMember(36)]
        public int levelRequireMarket { get; set; }

        [ProtoMember(37)]
        public Reward[] shareFacebookRewards { get; set; }

        [ProtoMember(38)]
        public TutorialConfig tutorialConfig { get; set; }

        [ProtoMember(39)]
        public GMMailConfig mailGMConfig { get; set; }

        [ProtoMember(40)]
        public int exchangeRubyToGoldConfig { get; set; }

        [ProtoMember(41)]
        public PlayerDefaultConfig playerDefaultConfig { get; set; }

        [ProtoMember(42)]
        public PhucLoiTruongThanhConfig phucLoiTruongThanhConfig { get; set; }

        [ProtoMember(43)]
        public CuuCuuTriTonConfig cuuCuuTriTonConfig { get; set; }

        [ProtoMember(44)]
        public RuongRewardConfig[] ruongRewardConfigs { get; set; }

        [ProtoMember(46)]
        public ExchangeGoldToSilverConfig exchangeGoldToSilverConfig { get; set; }

        [ProtoMember(47)]
        public int levelRequireDoPhuong { get; set; }

        [ProtoMember(48)]
        public InviteFriendConfig[] inviteFriendConfigs { get; set; }

        [ProtoMember(49)]
        public int maxGoldDoPhuongConfig { get; set; }

        [ProtoMember(50)]
        public HuaNguyenConfig huaNguyenConfig { get; set; }

        [ProtoMember(51)]
        public DoiHinhDuBiConfig doiHinhDuBiConfig { get; set; }
        [ProtoMember(52)]
        public PlayerLevelNumberChar[] playerLevelNumberChars { get; set; }
        [ProtoMember(53)]
        public FormationConfig formationConfig { get; set; }

        public Configs()
        {

        }

        public int GetSilverSellByPromotion(int promotion)
        {
            return promotion * silverSellCommon;
        }

        public int GetSilverSell()
        {
            return 10 * silverSellCommon;
        }

        public VipConfig GetVipConfig(int vip)
        {
            return vipConfigs[vip];
        }

        public Double GetTotalRubyVip(int vip)
        {
            if (vip == vipConfigs.Length - 1)
                return 0;
            double totalRuby = 0;
            for (int i = 0; i < vip; i++)
            {
                totalRuby = totalRuby + vipConfigs[i].rubyRequire;
            }
            return totalRuby;
        }

        public double GetSecondCoolDownPlusStamina()
        {
            return 60 * timeCooldownPlusStamina;
        }

        public double GetSecondCoolDownPlusPointSkill()
        {
            return 60 * timeCooldownPlusPointSkill;
        }

        public int GetSilverVanTieuReward(int countTimesBiCuop, TypeVehicle typeVehicle)
        {
            int silverReward = vanTieuConfig.vehicles[(int)typeVehicle].silverReward;
            if (countTimesBiCuop == 0)
                return silverReward;
            double proc = (double)cuopTieuConfig.procLoseSilver / 100;
            silverReward = (int)(silverReward - silverReward * countTimesBiCuop * proc);
            return silverReward;
        }

        public int GetSilverCuopTieuReward(TypeVehicle typeVehicle)
        {
            int silverReward =
                   vanTieuConfig.vehicles[(int)typeVehicle]
                       .silverReward;
            double proc = (double)cuopTieuConfig.procGetSilver / 100;
            return (int)(silverReward * proc);
        }
    }
}
