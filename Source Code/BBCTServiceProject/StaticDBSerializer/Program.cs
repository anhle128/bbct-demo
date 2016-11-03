using ProtoBuf.Meta;
using StaticDB;
using StaticDB.Enum;
using StaticDB.Models;
using System;
using System.Collections.Generic;

namespace StaticDBSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = TypeModel.Create();

            model.Add(typeof(Entity), true);
            model.Add(typeof(Character), true);
            model.Add(typeof(PowerUpItem), true);
            model.Add(typeof(PowerUpReceipt), true);
            model.Add(typeof(Receipt), true);
            model.Add(typeof(CharacterConfig), true);
            model.Add(typeof(CharacterLevelExp), true);
            model.Add(typeof(CharDefaultConfig), true);
            model.Add(typeof(CharSelection), true);
            model.Add(typeof(EquipDefaultConfig), true);
            model.Add(typeof(Equipment), true);
            model.Add(typeof(EquipDefaultConfig), true);
            model.Add(typeof(EquipmentConfig), true);
            model.Add(typeof(FreeStaminaConfig), true);
            model.Add(typeof(PlayerLevelExp), true);
            model.Add(typeof(VipConfig), true);
            model.Add(typeof(Configs), true);
            model.Add(typeof(Item), true);
            model.Add(typeof(Point2), true);
            model.Add(typeof(Point2Array), true);
            model.Add(typeof(StarUpReceipt), true);
            model.Add(typeof(PointSkillConfig), true);
            model.Add(typeof(MoiRuouConfig), true);
            model.Add(typeof(FriendConfig), true);
            model.Add(typeof(Reward), true);
            model.Add(typeof(EquipStarUpConfig), true);
            model.Add(typeof(VanTieuConfig), true);
            model.Add(typeof(VehicleConfig), true);
            model.Add(typeof(CuopTieuConfig), true);
            model.Add(typeof(GlobalBossConfig), true);
            model.Add(typeof(Hour), true);
            model.Add(typeof(AttackGlobalBossConfig), true);
            model.Add(typeof(MoneyResetThanThap), true);
            model.Add(typeof(CauCaConfig), true);
            model.Add(typeof(LuanKiemConfig), true);
            model.Add(typeof(Range), true);
            model.Add(typeof(RangeLuanKiemOpponent), true);
            model.Add(typeof(RankLuanKiemPoint), true);
            model.Add(typeof(RankLuanKiemReward), true);
            model.Add(typeof(ChucPhucConfig), true);
            model.Add(typeof(NhiemVuHangNgay), true);
            model.Add(typeof(NhiemVuHangNgayConfig), true);
            model.Add(typeof(NhiemVuChinhTuyen), true);
            model.Add(typeof(NhiemVuChinhTuyenConfig), true);
            model.Add(typeof(NhiemVuChinhTuyenReward), true);
            model.Add(typeof(HoatDongDiemDanhConfig), true);
            model.Add(typeof(MonthReward), true);
            model.Add(typeof(Dictionary<string, string>), true);
            model.Add(typeof(LevelReward), true);
            model.Add(typeof(PhucLoiThangConfig), true);
            model.Add(typeof(TutorialConfig), true);
            model.Add(typeof(GMMailConfig), true);
            model.Add(typeof(PlayerDefaultConfig), true);
            model.Add(typeof(PhucLoiTruongThanhConfig), true);
            model.Add(typeof(CuuCuuTriTonConfig), true);
            model.Add(typeof(StarReward), true);
            model.Add(typeof(BadWord), true);
            model.Add(typeof(RuongRewardConfig), true);
            model.Add(typeof(LevelNumCharInFormation), true);
            model.Add(typeof(ExchangeGoldToSilverConfig), true);
            model.Add(typeof(EquipLevelUpConfig), true);
            model.Add(typeof(FormationConfig), true);
            model.Add(typeof(LevelOpendSlotMainFormation), true);

            model.Add(typeof(GuildConfig), true);
            model.Add(typeof(RewardBossGuild), true);
            model.Add(typeof(InviteFriendConfig), true);
            model.Add(typeof(TimeAttackBoss), true);
            model.Add(typeof(HuaNguyenConfig), true);
            model.Add(typeof(DoiHinhDuBiRequire), true);
            model.Add(typeof(GroupCharacter), true);
            model.Add(typeof(PlayerLevelNumberChar), true);
            model.Add(typeof(StarLevelExp), true);
            model.Add(typeof(BonusAttribute), true);
            model.Add(typeof(ElementBonusAttribute), true);
            model.Add(typeof(Equip2Equip), true);
            model.Add(typeof(Element2Element), true);

            model.Add(typeof(DayOfWeek), true);
            model.Add(typeof(TypeNhiemVuHangNgay), true);

            model.Add(typeof(Affliction), true);
            model.Add(typeof(CategoryCharacter), true);
            model.Add(typeof(CategoryDuyenPhan), true);
            model.Add(typeof(CategoryEquipment), true);
            model.Add(typeof(CharacterAttribute), true);
            model.Add(typeof(ClassCharacter), true);
            model.Add(typeof(EffectSkill), true);
            model.Add(typeof(RangeSkill), true);
            model.Add(typeof(TargetSkill), true);
            model.Add(typeof(TypeAttackGlobalBoss), true);
            model.Add(typeof(TypeCharacter), true);
            model.Add(typeof(TypeElement), true);
            model.Add(typeof(TypeItem), true);
            model.Add(typeof(TypeNhiemVuChinhTuyen), true);
            model.Add(typeof(TypeReward), true);
            model.Add(typeof(TypeSkill), true);
            model.Add(typeof(TypeSpawnSkill), true);
            model.Add(typeof(TypeStage), true);
            model.Add(typeof(TypeVehicle), true);

            model.AllowParseableTypes = true;
            model.AutoAddMissingTypes = true;

            model.Compile("StaticDBSerializer", "StaticDBSerializer.dll");
        }
    }
}
