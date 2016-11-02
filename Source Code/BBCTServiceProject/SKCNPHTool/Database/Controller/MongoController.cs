
using LitJson;
using KDQHNPHTool.Common;
using KDQHNPHTool.Database.Model;
using KDQHNPHTool.Database.SubDatataseCollection;
using KDQHNPHTool.Database.MainDatabaseCollection;
using System.IO;
using KDQHNPHTool.Model;
using System.Collections.Generic;

namespace KDQHNPHTool.Database.Controller
{
    public class MongoController
    {
        public static DatabaseManager DatabaseManager;

        /// <summary>
        /// 
        /// </summary>
        private static UserActionGoldLogCollection userActionGoldLog;

        public static UserActionGoldLogCollection UserActionGoldLog
        {
            get { return userActionGoldLog; }
        }

        public static void LoadUserActionGoldLogCollection()
        {
            userActionGoldLog = new UserActionGoldLogCollection("action_gold_log");
        }

        /// <summary>
        /// 
        /// </summary>
        private static TyGiaQuyDoiCollection tyGiaQuyDoi;

        public static TyGiaQuyDoiCollection TyGiaQuyDoi
        {
            get { return tyGiaQuyDoi; }
        }

        public static void LoadTyGiaQuyDoiCollection()
        {
            tyGiaQuyDoi = new TyGiaQuyDoiCollection("ti_gia_quy_doi");
        }


        /// <summary>
        /// 
        /// </summary>
        private static SkDuaTopServerCollection skDuaTopServer;

        public static SkDuaTopServerCollection SkDuaTopServer
        {
            get { return skDuaTopServer; }
        }

        public static void LoadSkDuaTopServerCollection()
        {
            skDuaTopServer = new SkDuaTopServerCollection("sk_dua_top_server_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static RuongbauCollection ruongBau;

        public static RuongbauCollection RuongBau
        {
            get { return ruongBau; }
        }

        public static void LoadRuongbauCollection()
        {
            ruongBau = new RuongbauCollection("ruong_bau_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static Skx2NapTheCollection skX2NapThe;

        public static Skx2NapTheCollection SkX2NapThe
        {
            get { return skX2NapThe; }
        }

        public static void LoadSkx2NapTheCollection()
        {
            skX2NapThe = new Skx2NapTheCollection("sk_x2_nap_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static SkNapLanDauCollection skNapLanDau;

        public static SkNapLanDauCollection SkNapLanDau
        {
            get { return skNapLanDau; }
        }

        public static void LoadSkNapLanDauCollection()
        {
            skNapLanDau = new SkNapLanDauCollection("thuong_nap_lan_dau_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static UserTransactionCollection userTransaction;

        public static UserTransactionCollection UserTransaction
        {
            get { return userTransaction; }
        }

        public static void LoadUserTransactionCollection()
        {
            userTransaction = new UserTransactionCollection("transactions");
        }

        /// <summary>
        /// 
        /// </summary>
        private static ChieuMoConfigCollection chieuMoConfig;

        public static ChieuMoConfigCollection ChieuMoConfig
        {
            get { return chieuMoConfig; }
        }

        public static void LoadChieuMoConfigCollection()
        {
            chieuMoConfig = new ChieuMoConfigCollection("chieu_mo_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static GMMailCollection gmMail;

        public static GMMailCollection GmMail
        {
            get { return gmMail; }
        }

        public static void LoadGMMailCollection()
        {
            gmMail = new GMMailCollection("gm_mails");
        }

        /// <summary>
        /// 
        /// </summary>
        private static SkRotDoCollection skRotDo;

        public static SkRotDoCollection SkRotDo
        {
            get { return skRotDo; }
        }

        public static void LoadSkRotDoCollection()
        {
            skRotDo = new SkRotDoCollection("sk_rot_do_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static SkTranhMuaServerCollection skTranhMuaServer;

        public static SkTranhMuaServerCollection SkTranhMuaServer
        {
            get { return skTranhMuaServer; }
        }

        public static void LoadSkTranhMuaServerCollection()
        {
            skTranhMuaServer = new SkTranhMuaServerCollection("sk_tranh_mua_server_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static GiftCodeCollection giftCode;

        public static GiftCodeCollection GiftCode
        {
            get { return giftCode; }
        }

        public static void LoadGiftCodeCollection()
        {
            giftCode = new GiftCodeCollection("gift_code");
        }

        /// <summary>
        /// 
        /// </summary>
        private static GiftCodeCategoryCollection giftCodeCategory;

        public static GiftCodeCategoryCollection GiftCodeCategory
        {
            get { return giftCodeCategory; }
        }

        public static void LoadGiftCodeCategoryCollection()
        {
            giftCodeCategory = new GiftCodeCategoryCollection("gift_code_category");
        }

        /// <summary>
        /// 
        /// </summary>
        private static ShopLuanKiemCollection shopLuanKiem;

        public static ShopLuanKiemCollection ShopLuanKiem
        {
            get { return shopLuanKiem; }
        }

        public static void LoadShopLuanKiemCollection()
        {
            shopLuanKiem = new ShopLuanKiemCollection("shop_luan_kiem");
        }

        /// <summary>
        /// 
        /// </summary>
        private static ShopItemCollection shopItem;

        public static ShopItemCollection ShopItem
        {
            get { return shopItem; }
        }

        public static void LoadShopItemCollection()
        {
            shopItem = new ShopItemCollection("shop_items");
        }

        /// <summary>
        /// 
        /// </summary>
        private static LeBaoCollection leBao;

        public static LeBaoCollection LeBao
        {
            get { return leBao; }
        }

        public static void LoadLeBaoCollection()
        {
            leBao = new LeBaoCollection("le_baos");
        }

        /// <summary>
        /// 
        /// </summary>
        private static GlobalBossConfigCollection globalBossConfig;

        public static GlobalBossConfigCollection GlobalBossConfig
        {
            get { return globalBossConfig; }
        }

        public static void LoadGlobalBossConfigCollection()
        {
            globalBossConfig = new GlobalBossConfigCollection("global_boss_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static ChucPhucConfigCollection chucPhucConfig;

        public static ChucPhucConfigCollection ChucPhucConfig
        {
            get { return chucPhucConfig; }
        }

        public static void LoadChucPhucConfigCollection()
        {
            chucPhucConfig = new ChucPhucConfigCollection("chuc_phuc_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static VipConfigCollection vipConfig;

        public static VipConfigCollection VipConfig
        {
            get { return vipConfig; }
        }

        public static void LoadVipConfigCollection()
        {
            vipConfig = new VipConfigCollection("vip_reward_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static ThanThapConfigCollection thanThapConfig;

        public static ThanThapConfigCollection ThanThapConfig
        {
            get { return thanThapConfig; }
        }

        public static void LoadThanThapConfigCollection()
        {
            thanThapConfig = new ThanThapConfigCollection("than_thap_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static SkThanTaiCollection skThanTai;

        public static SkThanTaiCollection SkThanTai
        {
            get { return skThanTai; }
        }

        public static void LoadSkThanTaiCollection()
        {
            skThanTai = new SkThanTaiCollection("sk_than_tai_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static SkDoiDoCollection skDoiDo;

        public static SkDoiDoCollection SkDoiDo
        {
            get { return skDoiDo; }
        }

        public static void LoadSkDoiDoCollection()
        {
            skDoiDo = new SkDoiDoCollection("sk_doi_do_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static SkTichLuyTieuCollection skTichLuyTieu;

        public static SkTichLuyTieuCollection SkTichLuyTieu
        {
            get { return skTichLuyTieu; }
        }

        public static void LoadSkTichLuyTieuCollection()
        {
            skTichLuyTieu = new SkTichLuyTieuCollection("sk_tich_luy_tieu_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static SkTichLuyNapCollection skTichLuyNap;

        public static SkTichLuyNapCollection SkTichLuyNap
        {
            get { return skTichLuyNap; }
        }

        public static void LoadSkTichLuyNapCollection()
        {
            skTichLuyNap = new SkTichLuyNapCollection("sk_tich_luy_nap_config");
        }

        /// <summary>
        /// 
        /// </summary>
        private static SkVongQuayMayManCollection skVongQuayMayMan;

        public static SkVongQuayMayManCollection SkVongQuayMayMan
        {
            get { return skVongQuayMayMan; }
        }

        public static void LoadSkVongQuayMayManCollection()
        {
            skVongQuayMayMan = new SkVongQuayMayManCollection("sk_vong_quay_may_man_config");
        }
        /// <summary>
        /// 
        /// </summary>
        private static Sk7NgayNhanThuongCollection sk7NgayNhanThuong;

        public static Sk7NgayNhanThuongCollection Sk7NgayNhanThuong
        {
            get { return sk7NgayNhanThuong; }
        }

        public static void LoadSk7NgayNhanThuongCollection()
        {
            sk7NgayNhanThuong = new Sk7NgayNhanThuongCollection("sk_7_ngay_nhan_thuong_config");
        }
        /// <summary>
        /// 
        /// </summary>
        private static GuildMemberCollection guildMember;

        public static GuildMemberCollection GuildMember
        {
            get { return guildMember; }
        }

        public static void LoadGuildMemberCollection()
        {
            guildMember = new GuildMemberCollection("guild_members");
        }

        /// <summary>
        /// 
        /// </summary>
        private static GuildCollection guild;

        public static GuildCollection Guild
        {
            get { return guild; }
        }

        public static void LoadGuildCollection()
        {
            guild = new GuildCollection("guild");
        }

        /// <summary>
        /// 
        /// </summary>
        private static UserMapCollection userMap;

        public static UserMapCollection UserMap
        {
            get { return userMap; }
        }

        public static void LoadUserMapCollection()
        {
            userMap = new UserMapCollection("user_stages");
        }

        /// <summary>
        /// 
        /// </summary>
        private static UserLevelUpCollection userLevelUp;

        public static UserLevelUpCollection UserLevelUp
        {
            get { return userLevelUp; }
        }

        public static void LoadUserLevelUpCollection()
        {
            userLevelUp = new UserLevelUpCollection("level_up_log");
        }

        /// <summary>
        /// 
        /// </summary>
        private static LogNhiemVuHangNgayCollection logNhiemVuHangNgay;

        public static LogNhiemVuHangNgayCollection LogNhiemVuHangNgay
        {
            get { return logNhiemVuHangNgay; }
        }

        public static void LoadLogNhiemVuHangNgayCollection()
        {
            logNhiemVuHangNgay = new LogNhiemVuHangNgayCollection("nhiem_vu_hang_ngay_log");
        }

        /// <summary>
        /// 
        /// </summary>
        private static UseSilverCollection useSilver;

        public static UseSilverCollection UseSilver
        {
            get { return useSilver; }
        }

        public static void LoadUseSilverCollection()
        {
            useSilver = new UseSilverCollection("used_silver_log");
        }

        /// <summary>
        /// 
        /// </summary>
        private static UseGoldCollection useGold;

        public static UseGoldCollection UseGold
        {
            get { return useGold; }
        }

        public static void LoadUseGoldCollection()
        {
            useGold = new UseGoldCollection("used_gold_log");
        }

        /// <summary>
        /// 
        /// </summary>
        private static ServerCollection server;

        public static ServerCollection Server
        {
            get { return server; }
        }

        public static void LoadServerCollection()
        {
            server = new ServerCollection("servers");
        }


        /// <summary>
        /// 
        /// </summary>
        private static LoginLogCollection userLogin;

        public static LoginLogCollection UserLogin
        {
            get { return userLogin; }
        }

        public static void LoadLoginLogCollection()
        {
            userLogin = new LoginLogCollection("login_log");
        }

        /// <summary>
        /// 
        /// </summary>
        private static UserMailCollection userMail;

        public static UserMailCollection UserMail
        {
            get { return userMail; }
        }

        public static void LoadUserMailCollection()
        {
            userMail = new UserMailCollection("user_mails");
        }

        /// <summary>
        /// 
        /// </summary>
        private static UserInfoCollection userInfo;

        public static UserInfoCollection UserInfo
        {
            get { return userInfo; }
        }

        public static void LoadUserInforCollection()
        {
            userInfo = new UserInfoCollection("user_infos");
        }

        /// <summary>
        /// 
        /// </summary>
        private static UserCharacterCollection userCharacter;

        public static UserCharacterCollection UserCharacter
        {
            get { return userCharacter; }
        }

        public static void LoadUserCharacterCollection()
        {
            userCharacter = new UserCharacterCollection("user_chars");
        }

        /// <summary>
        /// 
        /// </summary>
        private static UserCharacterSoulCollection userCharacterSoul;

        public static UserCharacterSoulCollection UserCharacterSoul
        {
            get { return userCharacterSoul; }
        }

        public static void LoadUserCharacterSoulCollection()
        {
            userCharacterSoul = new UserCharacterSoulCollection("user_char_souls");
        }

        /// <summary>
        /// 
        /// </summary>
        private static UserEquipmentCollection userEquip;

        public static UserEquipmentCollection UserEquip
        {
            get { return userEquip; }
        }

        public static void LoadUserEquipmentCollection()
        {
            userEquip = new UserEquipmentCollection("user_equips");
        }

        /// <summary>
        /// 
        /// </summary>
        private static UserItemCollection userItem;

        public static UserItemCollection UserItem
        {
            get { return userItem; }
        }

        public static void LoadUserItemCollection()
        {
            userItem = new UserItemCollection("user_items");
        }

        /// <summary>
        /// 
        /// </summary>
        private static UserEquipmentPieceCollection userEquipPiece;

        public static UserEquipmentPieceCollection UserEquipPiece
        {
            get { return userEquipPiece; }
        }

        public static void LoadUserEquipmentPieceCollection()
        {
            userEquipPiece = new UserEquipmentPieceCollection("user_equip_pieces");
        }

        #region LoadThongTinServer
        public static void LoadThongTinDatabase()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "DatabaseInfo.json");

            string jsonData = CommonFunc.ReadFile(path);
            DatabaseManager = JsonMapper.ToObject<DatabaseManager>(jsonData);
            LoadSubDatabase();
        }

        public static void LoadSubDatabase()
        {
            List<ServerInMain> lsServer = new List<ServerInMain>();
            MongoController.LoadServerCollection();
            var tmpMongo = MongoController.Server.GetListData(MongoController.DatabaseManager.main_database, a => a.status == 1 || a.status == 2);

            foreach (var item in tmpMongo)
            {
                ServerInMain ser = new ServerInMain()
                {
                    idServer = item._id.ToString(),
                    nameServer = item.name,
                    statusServer = item.status,
                    inforConnectSub = item.mongo_connection,
                    inforConnectPhoton = item.photon_connection
                };
                lsServer.Add(ser);
            }
            DatabaseManager.sub_database = lsServer;
        }
        #endregion
    }
}
