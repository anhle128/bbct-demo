﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BBCTDesignerTool
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bbctdesignertoolv1Entities : DbContext
    {
        public bbctdesignertoolv1Entities()
            : base("name=bbctdesignertoolv1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<dbBadWord> dbBadWords { get; set; }
        public virtual DbSet<dbBattleConfig> dbBattleConfigs { get; set; }
        public virtual DbSet<dbBattlePoint2ArrayConfig> dbBattlePoint2ArrayConfig { get; set; }
        public virtual DbSet<dbBattlePoint2Config> dbBattlePoint2Config { get; set; }
        public virtual DbSet<dbCauCaConfig> dbCauCaConfigs { get; set; }
        public virtual DbSet<dbCauCaMainConfig> dbCauCaMainConfigs { get; set; }
        public virtual DbSet<dbCauCaReward> dbCauCaRewards { get; set; }
        public virtual DbSet<dbCharacter> dbCharacters { get; set; }
        public virtual DbSet<dbCharacterConfig> dbCharacterConfigs { get; set; }
        public virtual DbSet<dbCharacterLevelExp> dbCharacterLevelExps { get; set; }
        public virtual DbSet<dbCharAttribute> dbCharAttributes { get; set; }
        public virtual DbSet<dbCharDefaultConfig> dbCharDefaultConfigs { get; set; }
        public virtual DbSet<dbCharDuyenPhan> dbCharDuyenPhans { get; set; }
        public virtual DbSet<dbCharDuyenPhanAttribute> dbCharDuyenPhanAttributes { get; set; }
        public virtual DbSet<dbCharDuyenPhanID> dbCharDuyenPhanIDS { get; set; }
        public virtual DbSet<dbCharGoldNeedToFusion> dbCharGoldNeedToFusions { get; set; }
        public virtual DbSet<dbCharGoldNeedToPowerup> dbCharGoldNeedToPowerups { get; set; }
        public virtual DbSet<dbCharGoldNeedToStarup> dbCharGoldNeedToStarups { get; set; }
        public virtual DbSet<dbCharSelection> dbCharSelections { get; set; }
        public virtual DbSet<dbCharSkill> dbCharSkills { get; set; }
        public virtual DbSet<dbCharSkillAfflictionAttribute> dbCharSkillAfflictionAttributes { get; set; }
        public virtual DbSet<dbCharSkillAttribute> dbCharSkillAttributes { get; set; }
        public virtual DbSet<dbCharSkillStarLevel> dbCharSkillStarLevels { get; set; }
        public virtual DbSet<dbCharStarLevelExp> dbCharStarLevelExps { get; set; }
        public virtual DbSet<dbCharStarLevelExpConfig> dbCharStarLevelExpConfigs { get; set; }
        public virtual DbSet<dbChucPhucConfig> dbChucPhucConfigs { get; set; }
        public virtual DbSet<dbConfig> dbConfigs { get; set; }
        public virtual DbSet<dbCTAffliction> dbCTAfflictions { get; set; }
        public virtual DbSet<dbCTCategoryCharacter> dbCTCategoryCharacters { get; set; }
        public virtual DbSet<dbCTChacacterMain> dbCTChacacterMains { get; set; }
        public virtual DbSet<dbCTCharacterAttribute> dbCTCharacterAttributes { get; set; }
        public virtual DbSet<dbCTClassCharacter> dbCTClassCharacters { get; set; }
        public virtual DbSet<dbCTEffectSkill> dbCTEffectSkills { get; set; }
        public virtual DbSet<dbCTGiftcode> dbCTGiftcodes { get; set; }
        public virtual DbSet<dbCTOneorAll> dbCTOneorAlls { get; set; }
        public virtual DbSet<dbCTPromotionCharacter> dbCTPromotionCharacters { get; set; }
        public virtual DbSet<dbCTRangeSkill> dbCTRangeSkills { get; set; }
        public virtual DbSet<dbCTReasonActionGoldLog> dbCTReasonActionGoldLogs { get; set; }
        public virtual DbSet<dbCTReasonSpentGoldLog> dbCTReasonSpentGoldLogs { get; set; }
        public virtual DbSet<dbCTStatusSuKien> dbCTStatusSuKiens { get; set; }
        public virtual DbSet<dbCTTargetSkill> dbCTTargetSkills { get; set; }
        public virtual DbSet<dbCTTypeEquipment> dbCTTypeEquipments { get; set; }
        public virtual DbSet<dbCTTypeItem> dbCTTypeItems { get; set; }
        public virtual DbSet<dbCTTypeLeBaoActivationTime> dbCTTypeLeBaoActivationTimes { get; set; }
        public virtual DbSet<dbCTTypeLeBaoBuyTime> dbCTTypeLeBaoBuyTimes { get; set; }
        public virtual DbSet<dbCTTypeNhiemVuChinhTuyen> dbCTTypeNhiemVuChinhTuyens { get; set; }
        public virtual DbSet<dbCTTypeNhiemVuHangNgay> dbCTTypeNhiemVuHangNgays { get; set; }
        public virtual DbSet<dbCTTypeReward> dbCTTypeRewards { get; set; }
        public virtual DbSet<dbCTTypeRewardNPH> dbCTTypeRewardNPHs { get; set; }
        public virtual DbSet<dbCTTypeSkill> dbCTTypeSkills { get; set; }
        public virtual DbSet<dbCTTypeSkillCompare> dbCTTypeSkillCompares { get; set; }
        public virtual DbSet<dbCTTypeSpawnSkill> dbCTTypeSpawnSkills { get; set; }
        public virtual DbSet<dbCTTypeStage> dbCTTypeStages { get; set; }
        public virtual DbSet<dbCTTypeUseGold> dbCTTypeUseGolds { get; set; }
        public virtual DbSet<dbCuopTieuConfig> dbCuopTieuConfigs { get; set; }
        public virtual DbSet<dbCuuCuuTriTonConfig> dbCuuCuuTriTonConfigs { get; set; }
        public virtual DbSet<dbCuuCuuTriTonConfigReward> dbCuuCuuTriTonConfigRewards { get; set; }
        public virtual DbSet<dbEquipElementSupport> dbEquipElementSupports { get; set; }
        public virtual DbSet<dbEquipGoldNeedToPowerup> dbEquipGoldNeedToPowerups { get; set; }
        public virtual DbSet<dbEquipGoldNeedToStarup> dbEquipGoldNeedToStarups { get; set; }
        public virtual DbSet<dbEquipment> dbEquipments { get; set; }
        public virtual DbSet<dbEquipmentBonusAttribute> dbEquipmentBonusAttributes { get; set; }
        public virtual DbSet<dbEquipmentConfig> dbEquipmentConfigs { get; set; }
        public virtual DbSet<dbEquipmentElementAttribute> dbEquipmentElementAttributes { get; set; }
        public virtual DbSet<dbEquipProcElement> dbEquipProcElements { get; set; }
        public virtual DbSet<dbEquipStarLevelExp> dbEquipStarLevelExps { get; set; }
        public virtual DbSet<dbEquipStarLevelExpConfig> dbEquipStarLevelExpConfigs { get; set; }
        public virtual DbSet<dbEquipSupport> dbEquipSupports { get; set; }
        public virtual DbSet<dbExchangeGoldToSilverConfig> dbExchangeGoldToSilverConfigs { get; set; }
        public virtual DbSet<dbFreeStaminaConfig> dbFreeStaminaConfigs { get; set; }
        public virtual DbSet<dbGlobalAttackConfig> dbGlobalAttackConfigs { get; set; }
        public virtual DbSet<dbGlobalBonusRewardConfig> dbGlobalBonusRewardConfigs { get; set; }
        public virtual DbSet<dbGlobalBossConfig> dbGlobalBossConfigs { get; set; }
        public virtual DbSet<dbGMMailConfig> dbGMMailConfigs { get; set; }
        public virtual DbSet<dbGroupCharacter> dbGroupCharacters { get; set; }
        public virtual DbSet<dbGuildBoss> dbGuildBosses { get; set; }
        public virtual DbSet<dbGuildBossReward> dbGuildBossRewards { get; set; }
        public virtual DbSet<dbGuildConfig> dbGuildConfigs { get; set; }
        public virtual DbSet<dbGuildLevelContribution> dbGuildLevelContributions { get; set; }
        public virtual DbSet<dbGuildMission> dbGuildMissions { get; set; }
        public virtual DbSet<dbGuildRewardBangChien> dbGuildRewardBangChiens { get; set; }
        public virtual DbSet<dbGuildRewardsLuaTrai> dbGuildRewardsLuaTrais { get; set; }
        public virtual DbSet<dbHoatDongDiemDanhConfig> dbHoatDongDiemDanhConfigs { get; set; }
        public virtual DbSet<dbHoatDongDiemDanhMonth> dbHoatDongDiemDanhMonths { get; set; }
        public virtual DbSet<dbHoatDongDiemDanhMonthReward> dbHoatDongDiemDanhMonthRewards { get; set; }
        public virtual DbSet<dbHuaNguyenConfig> dbHuaNguyenConfigs { get; set; }
        public virtual DbSet<dbInviteFriendConfig> dbInviteFriendConfigs { get; set; }
        public virtual DbSet<dbInviteFriendReward> dbInviteFriendRewards { get; set; }
        public virtual DbSet<dbItem> dbItems { get; set; }
        public virtual DbSet<dbItemAttribute> dbItemAttributes { get; set; }
        public virtual DbSet<dbLevelNumCharInFormation> dbLevelNumCharInFormations { get; set; }
        public virtual DbSet<dbLevelReward_Reward> dbLevelReward_Reward { get; set; }
        public virtual DbSet<dbLevelRewardConfig> dbLevelRewardConfigs { get; set; }
        public virtual DbSet<dbLinkExportStatic> dbLinkExportStatics { get; set; }
        public virtual DbSet<dbLogKNBTool> dbLogKNBTools { get; set; }
        public virtual DbSet<dbLuanKiemConfig> dbLuanKiemConfigs { get; set; }
        public virtual DbSet<dbLuanKiemLoseReward> dbLuanKiemLoseRewards { get; set; }
        public virtual DbSet<dbLuanKiemPoint> dbLuanKiemPoints { get; set; }
        public virtual DbSet<dbLuanKiemRange> dbLuanKiemRanges { get; set; }
        public virtual DbSet<dbLuanKiemRangeOpponent> dbLuanKiemRangeOpponents { get; set; }
        public virtual DbSet<dbLuanKiemRank> dbLuanKiemRanks { get; set; }
        public virtual DbSet<dbLuanKiemRankReward> dbLuanKiemRankRewards { get; set; }
        public virtual DbSet<dbLuanKiemWinReward> dbLuanKiemWinRewards { get; set; }
        public virtual DbSet<dbMap> dbMaps { get; set; }
        public virtual DbSet<dbMapStage> dbMapStages { get; set; }
        public virtual DbSet<dbMapStageMonter> dbMapStageMonters { get; set; }
        public virtual DbSet<dbMapStageMonterSupper> dbMapStageMonterSuppers { get; set; }
        public virtual DbSet<dbMapStagePath> dbMapStagePaths { get; set; }
        public virtual DbSet<dbMapStageReward> dbMapStageRewards { get; set; }
        public virtual DbSet<dbMapStageSupper> dbMapStageSuppers { get; set; }
        public virtual DbSet<dbNhiemVuChinhTuyen> dbNhiemVuChinhTuyens { get; set; }
        public virtual DbSet<dbNhiemVuChinhTuyenConfig> dbNhiemVuChinhTuyenConfigs { get; set; }
        public virtual DbSet<dbNhiemVuChinhTuyenReward> dbNhiemVuChinhTuyenRewards { get; set; }
        public virtual DbSet<dbNhiemVuHangNgay> dbNhiemVuHangNgays { get; set; }
        public virtual DbSet<dbNhiemVuHangNgayConfig> dbNhiemVuHangNgayConfigs { get; set; }
        public virtual DbSet<dbNhiemVuHangNgayReward> dbNhiemVuHangNgayRewards { get; set; }
        public virtual DbSet<dbPhucLoiTruongThanhConfig> dbPhucLoiTruongThanhConfigs { get; set; }
        public virtual DbSet<dbPhucLoiTruongThanhLevel> dbPhucLoiTruongThanhLevels { get; set; }
        public virtual DbSet<dbPhucLoiTruongThanhLevelReward> dbPhucLoiTruongThanhLevelRewards { get; set; }
        public virtual DbSet<dbPlayerDefaultConfig> dbPlayerDefaultConfigs { get; set; }
        public virtual DbSet<dbPlayerLevelExp> dbPlayerLevelExps { get; set; }
        public virtual DbSet<dbPowerUpItem> dbPowerUpItems { get; set; }
        public virtual DbSet<dbPowerUpItemsAttribute> dbPowerUpItemsAttributes { get; set; }
        public virtual DbSet<dbPowerUpItemsReceipt> dbPowerUpItemsReceipts { get; set; }
        public virtual DbSet<dbPowRateByPromotion> dbPowRateByPromotions { get; set; }
        public virtual DbSet<dbPucLoiThangConfig> dbPucLoiThangConfigs { get; set; }
        public virtual DbSet<dbPucLoiThangReward> dbPucLoiThangRewards { get; set; }
        public virtual DbSet<dbRuongBauConfig> dbRuongBauConfigs { get; set; }
        public virtual DbSet<dbRuongBauReward> dbRuongBauRewards { get; set; }
        public virtual DbSet<dbShareFacebook> dbShareFacebooks { get; set; }
        public virtual DbSet<dbStarReward> dbStarRewards { get; set; }
        public virtual DbSet<dbStarRewardReward> dbStarRewardRewards { get; set; }
        public virtual DbSet<dbTaoNickReward> dbTaoNickRewards { get; set; }
        public virtual DbSet<dbThanThap> dbThanThaps { get; set; }
        public virtual DbSet<dbThanThapAttribute> dbThanThapAttributes { get; set; }
        public virtual DbSet<dbThanThapDetailMonster> dbThanThapDetailMonsters { get; set; }
        public virtual DbSet<dbThanThapFloorReward> dbThanThapFloorRewards { get; set; }
        public virtual DbSet<dbThanThapMoneyReset> dbThanThapMoneyResets { get; set; }
        public virtual DbSet<dbThanThapMonster> dbThanThapMonsters { get; set; }
        public virtual DbSet<dbThanThapPlusAttributeRequire> dbThanThapPlusAttributeRequires { get; set; }
        public virtual DbSet<dbThanThapStarReward> dbThanThapStarRewards { get; set; }
        public virtual DbSet<dbTimeAttackBoss> dbTimeAttackBosses { get; set; }
        public virtual DbSet<dbTip> dbTips { get; set; }
        public virtual DbSet<dbTutorialConfig> dbTutorialConfigs { get; set; }
        public virtual DbSet<dbUser> dbUsers { get; set; }
        public virtual DbSet<dbVanTieu> dbVanTieux { get; set; }
        public virtual DbSet<dbVanTieuProtectReward> dbVanTieuProtectRewards { get; set; }
        public virtual DbSet<dbVanTieuRobReward> dbVanTieuRobRewards { get; set; }
        public virtual DbSet<dbVipConfig> dbVipConfigs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
