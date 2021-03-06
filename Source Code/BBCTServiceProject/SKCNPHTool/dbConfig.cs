//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KDQHNPHTool
{
    using System;
    using System.Collections.Generic;
    
    public partial class dbConfig
    {
        public dbConfig()
        {
            this.dbCauCaConfigs = new HashSet<dbCauCaConfig>();
            this.dbChucPhucConfigs = new HashSet<dbChucPhucConfig>();
            this.dbGlobalBossConfigs = new HashSet<dbGlobalBossConfig>();
            this.dbGuildConfigs = new HashSet<dbGuildConfig>();
            this.dbHoatDongDiemDanhConfigs = new HashSet<dbHoatDongDiemDanhConfig>();
            this.dbLuanKiemConfigs = new HashSet<dbLuanKiemConfig>();
            this.dbNhiemVuChinhTuyenConfigs = new HashSet<dbNhiemVuChinhTuyenConfig>();
            this.dbNhiemVuHangNgayConfigs = new HashSet<dbNhiemVuHangNgayConfig>();
            this.dbThanThaps = new HashSet<dbThanThap>();
            this.dbVanTieux = new HashSet<dbVanTieu>();
        }
    
        public int id { get; set; }
        public Nullable<int> silverSellCommon { get; set; }
        public Nullable<int> maxLevelPlayer { get; set; }
        public Nullable<int> numberFriendsCanAdded { get; set; }
        public Nullable<int> maxPointSkillCanReach { get; set; }
        public Nullable<int> pointNeedToUpSkill { get; set; }
        public Nullable<int> minuteAutoUpPoint { get; set; }
        public Nullable<int> staminaMoiruou { get; set; }
        public Nullable<int> numberSuggestFriends { get; set; }
        public Nullable<int> giftStamina { get; set; }
        public Nullable<int> maxStarCanUp { get; set; }
        public Nullable<int> amountCharToSoul { get; set; }
        public Nullable<int> powerUpLevelUnlockPassiveSkill { get; set; }
        public Nullable<int> levelUnlockPassiveSkill2 { get; set; }
        public Nullable<int> prefixSilverUpSkill { get; set; }
        public Nullable<int> maxStamina { get; set; }
        public Nullable<int> maxPointSkill { get; set; }
        public Nullable<int> timeCooldownPlusStamina { get; set; }
        public Nullable<int> timeCooldownPlusPointSkill { get; set; }
        public Nullable<int> VanTieuTime { get; set; }
        public Nullable<int> VanTieuVipRequireToEnd { get; set; }
        public Nullable<int> VanTieuGoldRequireToEnd { get; set; }
        public Nullable<int> VanTieuGoldRefeshVehicle { get; set; }
        public Nullable<int> goldDoPhuongConfig { get; set; }
        public Nullable<int> idItemCanQuet { get; set; }
        public Nullable<int> maxItemCanSellMarket { get; set; }
        public Nullable<int> priceStartBuyMarket { get; set; }
        public Nullable<int> percentBuySuccessMarket { get; set; }
        public Nullable<double> percentBuySuccessMarket1 { get; set; }
        public Nullable<int> levelRequireVanTieu { get; set; }
        public Nullable<int> levelRequireMarket { get; set; }
        public Nullable<int> exchangeRubyToGoldConfig { get; set; }
        public Nullable<int> baseExpInStage { get; set; }
        public Nullable<int> levelRequireDoPhuong { get; set; }
        public Nullable<int> maxGoldDoPhuongConfig { get; set; }
    
        public virtual ICollection<dbCauCaConfig> dbCauCaConfigs { get; set; }
        public virtual ICollection<dbChucPhucConfig> dbChucPhucConfigs { get; set; }
        public virtual ICollection<dbGlobalBossConfig> dbGlobalBossConfigs { get; set; }
        public virtual ICollection<dbGuildConfig> dbGuildConfigs { get; set; }
        public virtual ICollection<dbHoatDongDiemDanhConfig> dbHoatDongDiemDanhConfigs { get; set; }
        public virtual ICollection<dbLuanKiemConfig> dbLuanKiemConfigs { get; set; }
        public virtual ICollection<dbNhiemVuChinhTuyenConfig> dbNhiemVuChinhTuyenConfigs { get; set; }
        public virtual ICollection<dbNhiemVuHangNgayConfig> dbNhiemVuHangNgayConfigs { get; set; }
        public virtual ICollection<dbThanThap> dbThanThaps { get; set; }
        public virtual ICollection<dbVanTieu> dbVanTieux { get; set; }
    }
}
