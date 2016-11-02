using GameServer.Database.SubDatataseCollection;
using MongoDB.Driver;

namespace GameServer.Database.Controller
{
    public class LogSubDbController
    {
        private readonly DoPhuongLogCollection _doPhuong;
        private readonly LuanKiemLogCollection _luanKiem;
        private readonly BuyLuanKiemShopItemLogCollection _buyLuanKiemShopItem;
        private readonly FreeStaminaLogCollection _freeStamina;
        private readonly MoiRuouLogCollection _moiRuou;
        private readonly ThachDauLogCollection _thachDau;
        private readonly BuyLeBaoLogCollection _buyLeBao;
        private readonly BuyShopItemLogCollection _buyShopItem;
        private readonly TopThanThapLogCollection _topThanThap;
        private readonly TopGlobalBossLogCollection _topGlobalBoss;
        private readonly ContributeGuildLogCollection _contributeLog;
        private readonly LuaTraiLogCollection _luaTraiLog;
        private readonly LuaTraiRewardLogCollection _luaTraiRewardLog;
        private readonly MissionGuildLogCollection _missionGuildLog;
        private readonly BossGuildLogCollection _bossGuildLog;
        private readonly NhiemVuHangNgayLogCollection _nhiemVuHangNgay;
        private readonly SuKienVongQuayMayManLogCollection _skVongQuayMayMan;
        private readonly SuKienTichLuyNapLogCollection _skTichLuyNap;
        private readonly SuKienTichLuyTieuLogCollection _skTichLuyTieu;
        private readonly SuKien7NgayNhanThuongLogCollection _sk7NgayNhanThuong;
        private readonly SuKienThanTaiLogCollection _skThanTai;
        private readonly SuKienDoiDoLogCollection _skDoiDo;
        private readonly SuKienRotDoLogCollection _skRotDo;
        private readonly SuKienTranhMuaServerLogCollection _skTranhMuaServer;
        private readonly SuKienPhucLoiTruongThanhLogCollection _skPhucLoiTruongThanh;
        private readonly MoRuongLogCollection _moRuong;
        private readonly ExchangeGoldToSilverLogCollection _exchangeGoldToSilver;
        private readonly HuaNguyenLogCollection _huaNguyen;
        private readonly BuyPointSkillLogCollection _buyPointSkill;
        

        public DoPhuongLogCollection DoPhuong
        {
            get { return _doPhuong; }
        }

        public LuanKiemLogCollection LuanKiem
        {
            get { return _luanKiem; }
        }

        public BuyLuanKiemShopItemLogCollection BuyLuanKiemShopItem
        {
            get { return _buyLuanKiemShopItem; }
        }
        public FreeStaminaLogCollection FreeStamina
        {
            get { return _freeStamina; }
        }

        public MoiRuouLogCollection MoiRuou
        {
            get { return _moiRuou; }
        }

        public BuyLeBaoLogCollection BuyLeBao
        {
            get { return _buyLeBao; }
        }

        public BuyShopItemLogCollection BuyShopItem
        {
            get { return _buyShopItem; }
        }

        public TopThanThapLogCollection TopThanThap
        {
            get { return _topThanThap; }
        }

        public TopGlobalBossLogCollection TopGlobalBoss
        {
            get { return _topGlobalBoss; }
        }

        public ContributeGuildLogCollection ContributeLog
        {
            get { return _contributeLog; }
        }

        public LuaTraiLogCollection LuaTraiLog
        {
            get { return _luaTraiLog; }
        }

        public LuaTraiRewardLogCollection LuaTraiRewardLog
        {
            get { return _luaTraiRewardLog; }
        }

        public MissionGuildLogCollection MissionGuildLog
        {
            get { return _missionGuildLog; }
        }


        public BossGuildLogCollection BossGuildLog
        {
            get { return _bossGuildLog; }
        }

        public NhiemVuHangNgayLogCollection NhiemVuHangNgay
        {
            get { return _nhiemVuHangNgay; }
        }

        public SuKienVongQuayMayManLogCollection SkVongQuayMayMan
        {
            get { return _skVongQuayMayMan; }
        }

        public SuKienTichLuyNapLogCollection SkTichLuyNap
        {
            get { return _skTichLuyNap; }
        }

        public SuKienTichLuyTieuLogCollection SkTichLuyTieu
        {
            get { return _skTichLuyTieu; }
        }

        public SuKien7NgayNhanThuongLogCollection Sk7NgayNhanThuong
        {
            get { return _sk7NgayNhanThuong; }
        }

        public SuKienThanTaiLogCollection SkThanTai
        {
            get { return _skThanTai; }
        }

        public SuKienDoiDoLogCollection SkDoiDo
        {
            get { return _skDoiDo; }
        }

        public SuKienRotDoLogCollection SkRotDo
        {
            get { return _skRotDo; }
        }

        public SuKienTranhMuaServerLogCollection SkTranhMuaServer
        {
            get { return _skTranhMuaServer; }
        }

        public ThachDauLogCollection ThachDau
        {
            get { return _thachDau; }
        }

        public SuKienPhucLoiTruongThanhLogCollection SkPhucLoiTruongThanh
        {
            get { return _skPhucLoiTruongThanh; }
        }

        public MoRuongLogCollection MoRuong
        {
            get { return _moRuong; }
        }

        public ExchangeGoldToSilverLogCollection ExchangeGoldToSilver
        {
            get { return _exchangeGoldToSilver; }
        }

        public HuaNguyenLogCollection HuaNguyen
        {
            get { return _huaNguyen; }
        }

        public BuyPointSkillLogCollection BuyPointSkill
        {
            get { return _buyPointSkill; }
        }

        public LogSubDbController(IMongoDatabase database)
        {
            _topThanThap = new TopThanThapLogCollection("top_than_thap_log", database);
            _topGlobalBoss = new TopGlobalBossLogCollection("top_global_boss_log", database);

            _doPhuong = new DoPhuongLogCollection("do_phuong_log", database);
            _luanKiem = new LuanKiemLogCollection("luan_kiem_log", database);
            _buyLuanKiemShopItem = new BuyLuanKiemShopItemLogCollection("buy_luan_kiem_shop_item_log", database);
            _freeStamina = new FreeStaminaLogCollection("free_stamina_log", database);
            _moiRuou = new MoiRuouLogCollection("moi_ruou_log", database);
            _thachDau = new ThachDauLogCollection("thach_dau_log", database);
            _buyLeBao = new BuyLeBaoLogCollection("buy_le_bao_log", database);
            _buyShopItem = new BuyShopItemLogCollection("buy_shop_item_log", database);
            _contributeLog = new ContributeGuildLogCollection("contribute_guild_log", database);
            _luaTraiLog = new LuaTraiLogCollection("lua_trai_log", database);
            _luaTraiRewardLog = new LuaTraiRewardLogCollection("lua_trai_reward_log", database);
            _missionGuildLog = new MissionGuildLogCollection("mission_guild_log", database);
            _bossGuildLog = new BossGuildLogCollection("boss_guild_log", database);
            _nhiemVuHangNgay = new NhiemVuHangNgayLogCollection("nhiem_vu_hang_ngay_log", database);
            _moRuong = new MoRuongLogCollection("mo_ruong_log", database);
            _exchangeGoldToSilver = new ExchangeGoldToSilverLogCollection("exchange_gold_to_silver_log", database);
            _skVongQuayMayMan = new SuKienVongQuayMayManLogCollection("sk_vong_quay_may_man_log", database);
            _skTichLuyNap = new SuKienTichLuyNapLogCollection("sk_tich_luy_nap_log", database);
            _skTichLuyTieu = new SuKienTichLuyTieuLogCollection("sk_tich_luy_tieu_log", database);
            _sk7NgayNhanThuong = new SuKien7NgayNhanThuongLogCollection("sk_7_ngay_nhan_thuong_log", database);
            _skThanTai = new SuKienThanTaiLogCollection("sk_than_tai_log", database);
            _skDoiDo = new SuKienDoiDoLogCollection("sk_doi_do_log", database);
            _skRotDo = new SuKienRotDoLogCollection("sk_rot_do_log", database);
            _skTranhMuaServer = new SuKienTranhMuaServerLogCollection("sk_tranh_mua_server_log", database);
            _skPhucLoiTruongThanh = new SuKienPhucLoiTruongThanhLogCollection("sk_phuc_loi_truong_thanh_log", database);
            _huaNguyen = new HuaNguyenLogCollection("hua_nguyen_log",database);
            _buyPointSkill = new BuyPointSkillLogCollection("buy_point_skill_log",database);

        }
    }
}
