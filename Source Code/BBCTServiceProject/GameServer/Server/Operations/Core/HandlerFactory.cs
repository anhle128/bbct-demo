
using GameServer.Common.Enum;
using GameServer.Server.Operations.Handler;
using System.Collections.Generic;

namespace GameServer.Server.Operations.Core
{
    public class HandlerFactory
    {
        public Dictionary<byte, IOperationHandler> Handlers = new Dictionary<byte, IOperationHandler>()
        {
            {(byte) OperationCode.SignIn, new SignInOperationHandler()},
            {(byte) OperationCode.SignOut, new SignOutOperationHandler()},
            {(byte) OperationCode.EnterWorld, new EnterWorldOperationHandler()},
            {(byte) OperationCode.ExitWorld, new ExitWorldOperationHandler()},
            {(byte) OperationCode.CountOnlineUser, new CountOnlineUserOperationHandler()},
            {(byte) OperationCode.MoveTo, new MoveToOperationHandler()},
            {(byte) OperationCode.CreateAccount, new CreateAccountOperationHandler()},
            {(byte) OperationCode.ChonTuongBanDau, new ChonTuongBanDauOperationHandler()},
            {(byte) OperationCode.ChangeFormation, new ChangeFormationOperationHandler()},
            {(byte) OperationCode.EquipEquipment, new EquipEquipmentOperationHandler()},
            {(byte) OperationCode.UnequipEquipment, new UnequipEquipmentOperationHandler()},
            {(byte) OperationCode.UpStarLevelCharacter, new UpStarLevelCharOperationHandler()},
            {(byte) OperationCode.UpStarLevelEquipment, new UpStarEquipOperationHandler()},
            {(byte) OperationCode.ChangeAvatar, new ChangeAvatarOperationHandler()},
            {(byte) OperationCode.ChatServer, new ChatServerOperationHandler()},
            {(byte) OperationCode.ChatGuild, new ChatGuildOperationHandler()},
            {(byte) OperationCode.MoiRuou, new MoiRuouOperationHandler()},
            {(byte) OperationCode.GetFriend, new GetFriendOperationHandler()},
            {(byte) OperationCode.AddFriend, new AddFriendOperationHandler()},
            {(byte) OperationCode.GetFreeStamina, new GetFreeStamineOperationHandler()},
            {(byte) OperationCode.ThachDau, new ThachDauOperationHandler()},
            {(byte) OperationCode.StartAttackStage, new StartAttackStageOperationHandler()},
            {(byte) OperationCode.EndAttackStage, new EndAttackStageOperationHandler()},
            {(byte) OperationCode.QuayTuong, new QuayTuongOperationHandler()},
            {(byte) OperationCode.QuayVatPham, new QuayVatPhamOperationHandler()},
            {(byte) OperationCode.GetRewardMail, new GetRewardMailOperationHandler()},
            {(byte) OperationCode.RefeshMail, new RefeshMailOperationHandler()},
            {(byte) OperationCode.GetDataShop, new GetDataShopOperationHandler()},
            {(byte) OperationCode.BuyLeBao, new BuyLeBaoOperationHandler()},
            {(byte) OperationCode.BuyShopItem, new BuyShopItemOperationHandler()},
            {(byte) OperationCode.GetDataChieuMo, new GetDataChieuMoOperationHandler()},
            {(byte) OperationCode.UsedExpItem, new UsedExpItemOperationHandler()},
            {(byte) OperationCode.GetStamina, new GetStaminaOperationHandler()},
            {(byte) OperationCode.GetPointSkill, new GetPointSkillOperationHandler()},
            {(byte) OperationCode.ViewDetailPlayer, new ViewDetailPlayerOperationHandler()},
            {(byte) OperationCode.UseGiftCode, new UseGiftCodeOperationHandler()},
            {(byte) OperationCode.UsedStaminaItem, new UsedStaminaItemOperationHandler()},
            {(byte) OperationCode.CanQuet, new CanQuetOperationHandler()},
            {(byte) OperationCode.GetRewadNhiemVuHangNgay, new GetRewardNhiemVuHangNgayOperationHandler()},
            {(byte) OperationCode.GetRewadNhiemVuChinhTuyen, new GetRewardNhiemVuChinhTuyenOperationHandler()},
            {(byte) OperationCode.SendNotifyMessage, new NotifyMessageOperationHandler()},
            {(byte) OperationCode.GetVipReward, new GetVipRewardOperationHandler()},
            {(byte) OperationCode.GetDataBXH, new GetDataBXHOperationHander()},
            {(byte) OperationCode.GetRewardLevel, new GetRewardLevelOperationHandler()},
            {(byte) OperationCode.GetDataPhucLoiThang, new GetDataPhucLoiThangOperationHandler()},
            {(byte) OperationCode.GetRewardShareFacebook, new GetRewardShareFacebookOperationHandler()},
            {(byte) OperationCode.SetTutorial, new SetTutorialOperationHandler()},
            {(byte) OperationCode.GetCharTutorial, new GetRewardCharTutorialOperationHandler()},
            {(byte) OperationCode.SendGMMail, new SendGMMailOperationHandler()},
            {(byte) OperationCode.UpMaxLevelCharacter, new UpMaxLevelCharOperationHandler()},
            {(byte) OperationCode.CheckGetFreeStamina, new CheckGetFreeStaminaOperationHandler()},
            {(byte) OperationCode.ChucPhuc, new ChucPhucOperationHandler()},
            {(byte) OperationCode.ExchangeRubyToGold, new ExchangeRubyToGoldOperationHandler()},
            {(byte) OperationCode.GetDataThuongNapLanDau, new GetDataThuongNapLanDauOperationHandler()},
            {(byte) OperationCode.GetRewardStarMap, new GetRewardStarMapOperationHandler()},
            {(byte) OperationCode.MoRuong, new MoRuongOperationHandler()},
            {(byte) OperationCode.ExchangGoldToSilver, new ExchangeGoldToSilverOperationHandler()},
            {(byte) OperationCode.GetDataExchangGoldToSilver, new GetDataExchangeGoldToSilverOperationHandler()},
            {(byte) OperationCode.CheckTrans, new CheckTransactionOperationHandler()},
            {(byte) OperationCode.HuaNguyen, new HuaNguyenOperationHandler()},
            {(byte) OperationCode.OpendSlotDoiHinhDuBi, new OpendSlotDoiHinhDuBiOperationHandler()},
            {(byte) OperationCode.RemoveFriend, new RemoveFriendRewardOperationHandler()},

            // van tieu
            {(byte) OperationCode.GetDataVanTieu, new GetDataVanTieuOperationHandler()},
            {(byte) OperationCode.GetVehicleVanTieu, new GetVehicleVanTieuOperationHandler()},
            {(byte) OperationCode.StartVanTieu, new StartVanTieuOperationHandler()},
            {(byte) OperationCode.GetRewardVanTieu, new GetRewardVanTieuOperationHandler()},
            {(byte) OperationCode.GetDataCuopTieu, new GetDataCuopTieuOperationHandler()},
            {(byte) OperationCode.CuopTieu, new CuopTieuOperationHandler()},
            // than thap
            {(byte) OperationCode.GetDataThanThap, new GetDataThanThapOperationHandler()},
            {(byte) OperationCode.PlushAttributeThan, new PlushAttributeThanThapOperationHandler()},
            {(byte) OperationCode.AttackThanThap, new AttackThanThapOperationHandler()},
            {(byte) OperationCode.ResetAttackThanThap, new ResetAttackThanThapOperationHandler()},
            // global boss
            {(byte) OperationCode.GetDataGlobalBoss, new GetDataGlobalBossOperationHandler()},
            {(byte) OperationCode.AttackGlobalBoss, new AttackGlobalBossOperationHandler()},
            // luan kiem
            {(byte) OperationCode.GetDataLuanKiem, new GetDataLuanKiemOperationHandler()},
            {(byte) OperationCode.AttackLuanKiem, new AttackLuanKiemOperationHandler()},
            {(byte) OperationCode.GetDataLuanKiemShop, new GetDataLuanKiemShopOperationHandler()},
            {(byte) OperationCode.BuyLuanKiemShopItem, new BuyLuanKiemShopItemOperationHandler()},
            {(byte) OperationCode.GetRewardLuanKiemRank, new GetRewardLuanKiemRankOperationHandler()},
            {(byte) OperationCode.ViewReplayLuanKiem, new ViewReplayLuanKiemOperationHandler()},
            {(byte) OperationCode.ResetLuanKiemAttackTime, new ResetLuanKiemAttackTimeOperationHander()},
            // cau ca
            {(byte) OperationCode.GetDataCauCa, new GetDataCauCaOperationHandler()},
            {(byte) OperationCode.StartCauCa, new StartCauCaOperationHandler()},
            {(byte) OperationCode.EndCauCa, new EndCauCaOperationHandler()},
            // do phuong
            {(byte) OperationCode.GetDataDoPhuong, new GetDataDoPhuongOperationHandler()},
            {(byte) OperationCode.DoXucXacDoPhuong, new DoXucXacDoPhuongOperationHandler()},
            // vong quay may man
            {(byte) OperationCode.GetDataVongQuayMayMan, new GetDataVongQuayMayManOperationHandler()},
            {(byte) OperationCode.GetRewadVongQuayMayMan, new GetRewardVongQuayMayManOperationHandler()},
            {(byte) OperationCode.GetLogVongQuayMayMan, new GetLogVongQuayMayManOperationHandler()},
            {(byte) OperationCode.GetRewardPointVongQuayMayMan, new GetRewardPointVongQuayMayManOperationHandler()},
            {(byte) OperationCode.GetTopVongQuayMayMan, new GetTopUserVongQuayMayManOperationHander()},
            // tich luy nap
            {(byte) OperationCode.GetDataSkTichLuyNap, new GetDataTichLuyNapOperationHandler()},
            {(byte) OperationCode.GetRewardSkTichLuyNap, new GetRewardTichLuyNapOperationHandler()},
            // tich luy tieu
            {(byte) OperationCode.GetDataSkTichLuyTieu, new GetDataTichLuyTieuOperationHandler()},
            {(byte) OperationCode.GetRewardSkTichLuyTieu, new GetRewardTichLuyTieuOperationHandler()},
            // 7 ngay nhan thuong
            {(byte) OperationCode.GetDataSk7NgayNhanThuong, new GetData7NgayNhanThuongOperationHandler()},
            {(byte) OperationCode.GetRewardSk7NgayNhanThuong, new GetReward7NgayNhanThuongOperationHandler()},
            // doi do
            {(byte) OperationCode.GetDataSkDoiDo, new GetDataDoiDoOperationHandler()},
            {(byte) OperationCode.RefeshItemDoiDo, new RefeshDoiDoOperationHandler()},
            {(byte) OperationCode.GetTopSkDoiDo, new GetTopDoiDoOperationHandler()},
            {(byte) OperationCode.GetRewardPointDoiDo, new GetRewardPointDoiDoOperationHandler()},
            {(byte) OperationCode.ExchangeItemDoiDo, new ExchangeItemOperationHandler()},
            // rot do
            {(byte) OperationCode.GetDataSkRotDo, new GetDataRotDoOperationHandler()},
            {(byte) OperationCode.GetRewardSkRotDo, new GetRewardRotDoOperationHandler()},
            // than tai
            {(byte) OperationCode.GetDataSkThanTai, new GetDataThanTaiOperationHandler()},
            {(byte) OperationCode.GetRewardSkThanTai, new GetRewardThanTaiOperationHandler()},
            // diem danh thang
            {(byte) OperationCode.GetDataHoatDongDiemDanh, new GetDataHoatDongDiemDanhOperationHandler()},
            {(byte) OperationCode.GetRewardHoatDongDiemDanh, new GetRewardHoatDongDiemDanhOperationHandler()},
            // tranh mua server
            {(byte) OperationCode.GetDataSkTranhMuaServer, new GetDataTranhMuaServerOperationHandler()},
            {(byte) OperationCode.BuyItemSkTranhMuaServer, new BuyItemTranhMuaServerOperationHandler()},
            // x2 nap
            {(byte) OperationCode.GetDatax2Nap, new GetDatax2NapOperationHandler()},
            // phuc loi truong thanh
             {(byte) OperationCode.GetDataPhucLoiTruongThanh, new GetDataPhucLoiTruongThanhOperationHandler()},
             {(byte) OperationCode.GetRewardPhucLoiTruongThanh, new GetRewardPhucLoiTruongThanhOperationHandler()},
             // cuu cuu tri ton
             {(byte) OperationCode.GetRewardCuuCuuTriTon, new GetRewardCuuCuuTriTonOperationHandler()},
            // guild
            {(byte) OperationCode.CreateGuild, new CreateGuildOperationHandler()},
            {(byte) OperationCode.FindGuild, new FindGuildOperationHandler()},
            {(byte) OperationCode.GetTopLevelGuild, new GetTopLevelGuildOperationHandler()},
            {(byte) OperationCode.RequestJoinGuild, new JoinGuildOperationHandler()},
            {(byte) OperationCode.GetRequestJoinGuild, new GetRequestJoinGuildOperationHandler()},
            {(byte) OperationCode.AcceptRequestJoinGuild, new AcceptRequestJoinGuildOperationHandler()},
            {(byte) OperationCode.RejectRequestJoinGuild, new RejectRequestJoinGuildOperationHandler()},
            {(byte) OperationCode.GetGuildMember, new GetGuildMemberOperationHandler()},
            {(byte) OperationCode.SackMember, new SackGuildMemberOperationHandler()},
            {(byte) OperationCode.OutMember, new OutGuildMemberOperationHandler()},
            {(byte) OperationCode.ChangeMasterOfGuild, new ChangeMasterGuildOperationHandler()},
            {(byte) OperationCode.GetDataGuild, new GetDataGuildOperationHandler()},
            {(byte) OperationCode.EditNoticeGuild, new EditNoticeGuildOperationHandler()},
            {(byte) OperationCode.DisbandGuild, new DisbandGuildOperationHandler()},
            {(byte) OperationCode.GetDataContributeGuild, new GetDataContributeOperationHandler()},
            {(byte) OperationCode.ContributeGuild, new ContributeGuildOperationHandler()},
            {(byte) OperationCode.GetDataLuaTrai, new GetDataLuaTraiOperationHandler()},
            {(byte) OperationCode.StartLuaTrai, new StartLuaTraiOperationHandler()},
            {(byte) OperationCode.GetDataMission, new GetDataMissionGuildOperationHandler()},
            {(byte) OperationCode.GetRewardLuaTrai, new GetRewardLuaTraiOperationHandler()},
            {(byte) OperationCode.StartGuildMission, new StartMissionGuildOperationHandler()},
            {(byte) OperationCode.FinishGuildMission, new FinishMissionGuildOperationHandler()},
            {(byte) OperationCode.FinishNowGuildMission, new FinishNowMissionGuildOperationHandler()},
            {(byte) OperationCode.GetDataBossGuild, new GetDataBossGuildOperationHandler()},
            {(byte) OperationCode.StartAttackBossGuild, new StartAttackBossGuildOperationHandler()},
            {(byte) OperationCode.EndAttackBossGuild, new EndAttackBossGuildOperationHandler()},
            {(byte) OperationCode.GetDataRankBossGuild, new GetDataRankBossGuildOperationHandler()},
            // market
            {(byte) OperationCode.StartSellItemOnMarket, new StartSellOnMarketOperationHandler()},
            {(byte) OperationCode.FindItemOnMarket, new FindItemOnMarketOperationHandler()},
            {(byte) OperationCode.GetMyItemOnMarket, new GetMyItemOnMarketOperationHandler()},
            {(byte) OperationCode.BuyItemOnMarket, new BuyItemOnMarketOperationHandler()},
            {(byte) OperationCode.StopSellItemOnMarket, new StopItemOnMarketOperationHandler()},
            // bang chien
            {(byte) OperationCode.GetDataBangChien, new GetDataBangChienOperationHandler()},
            {(byte) OperationCode.GetDataBattleBangChien, new GetDataChienSuBangChienOperationHandler()},
            {(byte) OperationCode.GoToBattleBangChien, new GoToBattleBangChienOperationHandler()},
            {(byte) OperationCode.GetTopGuildSelectBangChien, new GetTopGuildSelectBangChienOperationHandler()},
            // ruong bau
            {(byte) OperationCode.GetRewardRuongBau, new GetRewardRuongBauOperationHandler()},
            //SuKien DuaTopServer
            {(byte) OperationCode.GetDataSkDuaTopServer, new GetDataSkDuaTopServerOperationHandler()},
            //Invite Friend
            {(byte) OperationCode.InviteFriend, new InviteFriendOperationHandler()},
            {(byte) OperationCode.GetInviteFriendReward, new GetInviteFriendRewardOperationHandler()}
        };


    }
}
