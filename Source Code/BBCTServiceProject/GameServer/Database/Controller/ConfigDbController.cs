
using GameServer.Database.SubDatataseCollection;
using MongoDB.Driver;

namespace GameServer.Database.Controller
{
    public class ConfigDbController
    {
        #region Property
        private readonly ChieuMoConfigCollection _chieuMo;
        private readonly ThanThapConfigColletion _thanThap;
        private readonly GlobalBossConfigCollection _globalBoss;
        private readonly ChucPhucConfigCollection _chucPhuc;
        private readonly VipRewardConfigCollection _vipReward;
        private readonly SuKienVongQuoayMayManConfigCollection _skVongQuayMayMan;
        private readonly SuKienTickLuyNapConfigCollecion _skTichluyNap;
        private readonly SuKienTickLuyTieuConfigCollection _skTichluyTieu;
        private readonly SuKien7NgayNhanThuongConfigCollection _sk7NgayNhanThuong;
        private readonly SuKienThanTaiConfigCollection _skThanTai;
        private readonly SuKienDoiDoConfigCollecion _skDoiDo;
        private readonly SuKienRotDoConfigCollection _skRotDo;
        private readonly SuKienActivateCollection _suKienActivate;
        private readonly SuKienTranhMuaServerConfigCollection _skTranhMuaServer;
        private readonly ThuongNapLanDauCollection _thuongNapLanDau;
        private readonly SuKienx2NapConfig _skx2Nap;
        private readonly RuongBauConfigCollection _ruongBau;
        private readonly SuKienDuaTopServerConfigCollecion _skDuaTopServer;

        public ChieuMoConfigCollection ChieuMo
        {
            get { return _chieuMo; }
        }

        public GlobalBossConfigCollection GlobalBoss
        {
            get { return _globalBoss; }
        }

        public ThanThapConfigColletion ThanThap
        {
            get { return _thanThap; }
        }

        public ChucPhucConfigCollection ChucPhuc
        {
            get { return _chucPhuc; }
        }

        public SuKienVongQuoayMayManConfigCollection SkVongQuayMayMan
        {
            get { return _skVongQuayMayMan; }
        }

        public SuKienTickLuyNapConfigCollecion SkTichluyNap
        {
            get { return _skTichluyNap; }
        }

        public SuKienTickLuyTieuConfigCollection SkTichluyTieu
        {
            get { return _skTichluyTieu; }
        }

        public VipRewardConfigCollection VipReward
        {
            get { return _vipReward; }
        }

        public SuKien7NgayNhanThuongConfigCollection Sk7NgayNhanThuong
        {
            get { return _sk7NgayNhanThuong; }
        }

        public SuKienThanTaiConfigCollection SkThanTai
        {
            get { return _skThanTai; }
        }

        public SuKienDoiDoConfigCollecion SkDoiDo
        {
            get { return _skDoiDo; }
        }

        public SuKienActivateCollection SuKienActivate
        {
            get { return _suKienActivate; }
        }

        public SuKienRotDoConfigCollection SkRotDo
        {
            get { return _skRotDo; }
        }

        public SuKienTranhMuaServerConfigCollection SkTranhMuaServer
        {
            get { return _skTranhMuaServer; }
        }

        public ThuongNapLanDauCollection ThuongNapLanDau
        {
            get { return _thuongNapLanDau; }
        }

        public SuKienx2NapConfig Skx2Nap
        {
            get { return _skx2Nap; }
        }

        public RuongBauConfigCollection RuongBau
        {
            get { return _ruongBau; }
        }

        public SuKienDuaTopServerConfigCollecion SkDuaTopServer
        {
            get { return _skDuaTopServer; }
        }

        #endregion

        public ConfigDbController(IMongoDatabase database)
        {
            _chieuMo = new ChieuMoConfigCollection("chieu_mo_config", database);
            _thanThap = new ThanThapConfigColletion("than_thap_config", database);
            _globalBoss = new GlobalBossConfigCollection("global_boss_config", database);
            _chucPhuc = new ChucPhucConfigCollection("chuc_phuc_config", database);
            _skVongQuayMayMan = new SuKienVongQuoayMayManConfigCollection("sk_vong_quay_may_man_config", database);
            _skTichluyNap = new SuKienTickLuyNapConfigCollecion("sk_tich_luy_nap_config", database);
            _skTichluyTieu = new SuKienTickLuyTieuConfigCollection("sk_tich_luy_tieu_config", database);
            _vipReward = new VipRewardConfigCollection("vip_reward_config", database);
            _sk7NgayNhanThuong = new SuKien7NgayNhanThuongConfigCollection("sk_7_ngay_nhan_thuong_config", database);
            _skThanTai = new SuKienThanTaiConfigCollection("sk_than_tai_config", database);
            _skDoiDo = new SuKienDoiDoConfigCollecion("sk_doi_do_config", database);
            _suKienActivate = new SuKienActivateCollection("sk_activate", database);
            _skRotDo = new SuKienRotDoConfigCollection("sk_rot_do_config", database);
            _skTranhMuaServer = new SuKienTranhMuaServerConfigCollection("sk_tranh_mua_server_config", database);
            _skx2Nap = new SuKienx2NapConfig("sk_x2_nap_config", database);
            _thuongNapLanDau = new ThuongNapLanDauCollection("thuong_nap_lan_dau_config", database);
            _ruongBau = new RuongBauConfigCollection("ruong_bau_config", database);
            _skDuaTopServer = new SuKienDuaTopServerConfigCollecion("sk_dua_top_server_config", database);
        }
    }
}
