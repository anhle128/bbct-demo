using DynamicDBModel;
using DynamicDBModel.Enum;
using DynamicDBModel.Models;
using DynamicDBModel.Models.Battle;
using ProtoBuf.Meta;
using System.Collections.Generic;

namespace DynamicDBSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = TypeModel.Create();

            model.Add(typeof(Entity), true);
            // normal
            model.Add(typeof(UserInfo), true);
            model.Add(typeof(UserCharacter), true);
            model.Add(typeof(UserEquip), true);
            model.Add(typeof(UserItem), true);
            model.Add(typeof(UserEquipPiece), true);
            model.Add(typeof(UserCharSoul), true);
            model.Add(typeof(UserStage), true);
            model.Add(typeof(RewardItem), true);
            model.Add(typeof(Dictionary<string, int>), true);
            model.Add(typeof(UserMail), true);
            model.Add(typeof(SystemMail), true);
            model.Add(typeof(ChieuMo), true);
            model.Add(typeof(ChieuMoPrice), true);
            model.Add(typeof(StringArray), true);
            model.Add(typeof(UserPowerUpItem), true);
            model.Add(typeof(UserStage), true);
            model.Add(typeof(StageMode), true);
            model.Add(typeof(UserFriend), true);
            model.Add(typeof(CharBattleResult), true);
            model.Add(typeof(LevelSkill), true);
            model.Add(typeof(LeBao), true);
            model.Add(typeof(ShopItem), true);
            model.Add(typeof(CurVehicle), true);
            model.Add(typeof(UserVanTieu), true);
            model.Add(typeof(TopReward), true);
            model.Add(typeof(TopUserThanThap), true);
            model.Add(typeof(TopUsersGlobalBoss), true);
            model.Add(typeof(TopUserPrivateBoss), true);
            model.Add(typeof(LuanKiemLog), true);
            model.Add(typeof(LuanKiemShopItem), true);
            model.Add(typeof(PlayerLuanKiem), true);
            model.Add(typeof(SubDataPlayer), true);
            model.Add(typeof(Player), true);
            model.Add(typeof(NhiemVuHangNgayData), true);
            model.Add(typeof(NhiemVuChinhTuyenData), true);
            model.Add(typeof(SubRewardItem), true);
            model.Add(typeof(TypeSuKienTichLuyNap), true);
            model.Add(typeof(GoldReward), true);
            model.Add(typeof(VipReward), true);
            model.Add(typeof(DayReward), true);
            model.Add(typeof(TopUser), true);
            model.Add(typeof(PointDoiDoReward), true);
            model.Add(typeof(TypeSuKien), true);
            model.Add(typeof(ItemDoiDo), true);
            model.Add(typeof(TopUserDoiDo), true);
            model.Add(typeof(TopRewardDoiDo), true);
            model.Add(typeof(RotDoReward), true);
            model.Add(typeof(IndexReceived), true);
            model.Add(typeof(DayTranhMua), true);
            model.Add(typeof(ItemTranhMua), true);
            model.Add(typeof(PointVongQuayMayManReward), true);
            model.Add(typeof(TopUserVongQuayMayMan), true);
            model.Add(typeof(UserStarReward), true);
            model.Add(typeof(ChatData), true);
            // battle
            model.Add(typeof(BattleReplay), true);
            model.Add(typeof(CharacterReplay), true);
            model.Add(typeof(TurnReplay), true);
            model.Add(typeof(TargetReplay), true);

            model.Add(typeof(Guild), true);
            model.Add(typeof(GuildMember), true);
            model.Add(typeof(RequestJoinGuild), true);

            model.Add(typeof(ItemOnMarket), true);

            model.Add(typeof(BangChien), true);
            model.Add(typeof(BattleBangChien), true);

            model.Add(typeof(DuBi), true);

            model.AllowParseableTypes = true;
            model.AutoAddMissingTypes = true;

            model.Compile("DynamicDBSerializer", "DynamicDBSerializer.dll");
        }
    }
}
