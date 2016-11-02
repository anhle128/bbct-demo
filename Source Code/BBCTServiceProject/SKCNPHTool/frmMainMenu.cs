using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.UserController;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraTab;
using KDQHNPHTool.Form;
using KDQHNPHTool.Model;

namespace KDQHNPHTool
{
    public partial class frmMainMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMainMenu(int tmpIdUser, string username, string tmpPassword, int tmpTypeUser)
        {
            InitializeComponent();
            UserSession.IdUser = tmpIdUser;
            UserSession.Username = username;
            UserSession.TypeUser = tmpTypeUser;
            UserSession.Password = tmpPassword;
            DisplayVersionApp();
            LoadDatabase();

            if (tmpTypeUser == 3)
            {
                rpChung.Visible = false;
                rpThongKe.Visible = false;
                rpSuKien.Visible = false;
                btnQuanLyNguoiDungTool.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (tmpTypeUser == 2)
            {
                btnQuanLyNguoiDungTool.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        Version myVersion;

        private void DisplayVersionApp()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                myVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                this.Text = "";
                this.Text = String.Concat("Phiên bản: ", myVersion) + " - " + SettingApp.toolVersion + " " + SettingApp.gameVersion;
            }
            else
            {
                this.Text = "Xin chào, " + UserSession.Username;
            }
        }

        private void LoadDatabase()
        {
            MongoController.LoadThongTinDatabase();
            MongoController.LoadUserInforCollection();
            MongoController.LoadLoginLogCollection();
            MongoController.LoadUserCharacterCollection();
            MongoController.LoadUserCharacterSoulCollection();
            MongoController.LoadUserEquipmentCollection();
            MongoController.LoadUserEquipmentPieceCollection();
            MongoController.LoadUserItemCollection();
            MongoController.LoadUserMailCollection();
            MongoController.LoadUseGoldCollection();
            MongoController.LoadUseSilverCollection();
            MongoController.LoadLogNhiemVuHangNgayCollection();
            MongoController.LoadUserLevelUpCollection();
            MongoController.LoadUserMapCollection();
            MongoController.LoadGuildCollection();
            MongoController.LoadGuildMemberCollection();
            MongoController.LoadSk7NgayNhanThuongCollection();
            MongoController.LoadSkVongQuayMayManCollection();
            MongoController.LoadSkTichLuyNapCollection();
            MongoController.LoadSkTichLuyTieuCollection();
            MongoController.LoadSkDoiDoCollection();
            MongoController.LoadSkThanTaiCollection();
            MongoController.LoadThanThapConfigCollection();
            MongoController.LoadVipConfigCollection();
            MongoController.LoadChucPhucConfigCollection();
            MongoController.LoadGlobalBossConfigCollection();
            MongoController.LoadLeBaoCollection();
            MongoController.LoadShopItemCollection();
            MongoController.LoadShopLuanKiemCollection();
            MongoController.LoadGiftCodeCategoryCollection();
            MongoController.LoadGiftCodeCollection();
            MongoController.LoadSkTranhMuaServerCollection();
            MongoController.LoadSkRotDoCollection();
            MongoController.LoadGMMailCollection();
            MongoController.LoadChieuMoConfigCollection();
            MongoController.LoadUserTransactionCollection();
            MongoController.LoadSkNapLanDauCollection();
            MongoController.LoadSkx2NapTheCollection();
            MongoController.LoadRuongbauCollection();
            MongoController.LoadSkDuaTopServerCollection();
            MongoController.LoadTyGiaQuyDoiCollection();
            MongoController.LoadUserActionGoldLogCollection();
        }

        private void btnQuanLyTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucQuanLyTaiKhoan nv = new ucQuanLyTaiKhoan();
            Common.CommonFunc.AddTab(tabControl, nv, "Quản lý tài khoản", "Quản lý tài khoản");
        }

        private void tabControl_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            XtraTabPage page = (arg.Page as XtraTabPage);
            tabControl.TabPages.Remove(page);
            page.Dispose();
        }

        private void btnGuiThuHeThong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGuiThuHeThong frm = new frmGuiThuHeThong();
            frm.ShowDialog();
        }

        private void btnGuiThuNapTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGuiThuNapTien frm = new frmGuiThuNapTien();
            frm.ShowDialog();
        }

        private void btnPCU_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucPCUACU nv = new ucPCUACU();
            Common.CommonFunc.AddTab(tabControl, nv, "PCU-ACU", "PCU-ACU");
        }

        private void btnCCU_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucCCU nv = new ucCCU();
            Common.CommonFunc.AddTab(tabControl, nv, "CCU", "CCU");
        }

        private void btn1730_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            uc1730 nv = new uc1730();
            Common.CommonFunc.AddTab(tabControl, nv, "Lượng người chơi online", "Lượng người chơi online");
        }

        private void btnOnlineTime510152030_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucOnlineTime510152030 nv = new ucOnlineTime510152030();
            Common.CommonFunc.AddTab(tabControl, nv, "Số tài khoản mới online 5-10-15-20-30", "Số tài khoản mới online 5-10-15-20-30");
        }

        private void btnKhongDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucNguoiChoiKhongDangNhap nv = new ucNguoiChoiKhongDangNhap();
            Common.CommonFunc.AddTab(tabControl, nv, "Số tài khoản không đăng nhập 1-7-30", "Số tài khoản không đăng nhập 1-7-30");
        }

        private void btnGoldSilver_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucGoldSilver nv = new ucGoldSilver();
            Common.CommonFunc.AddTab(tabControl, nv, "Lượng tiền trong server", "Lượng tiền trong server");
        }

        private void btnNhiemVuHangNgay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucLogNhiemVuHangNgay nv = new ucLogNhiemVuHangNgay();
            Common.CommonFunc.AddTab(tabControl, nv, "Người chơi hoàn thành nhiệm vụ hàng ngày", "Người chơi hoàn thành nhiệm vụ hàng ngày");
        }

        private void btnPhanCapLevel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucLevelUpLog nv = new ucLevelUpLog();
            Common.CommonFunc.AddTab(tabControl, nv, "Phân cấp level theo thời gian", "Phân cấp level theo thời gian");
        }

        private void btnVuotMap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucMap nv = new ucMap();
            Common.CommonFunc.AddTab(tabControl, nv, "Thống kê người chơi vượt map", "Thống kê người chơi vượt map");
        }

        private void btnBangHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucBangHoi nv = new ucBangHoi();
            Common.CommonFunc.AddTab(tabControl, nv, "Thống kê Bang hội", "Thống kê Bang hội");
        }

        private void btnSuaHienTai7NgayNT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSK7NgayNhanThuong frm = new frmSK7NgayNhanThuong("Sửa sự kiện đang diễn ra", 1);
            frm.ShowDialog();
        }

        private void btnTaoMoi7ngay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSK7NgayNhanThuong frm = new frmSK7NgayNhanThuong("Tạo mới sự kiện", 2);
            frm.ShowDialog();
        }

        private void btnSuaHienTaiVQMM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKVongQuayMayMan frm = new frmSKVongQuayMayMan("Sửa sự kiện đang diễn ra", 1);
            frm.ShowDialog();
        }

        private void btnTaoMoiVongQuay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKVongQuayMayMan frm = new frmSKVongQuayMayMan("Tạo mới sự kiện", 2);
            frm.ShowDialog();
        }

        private void btnAountNewUseGold_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucTaiKhoanMoiTraTien nv = new ucTaiKhoanMoiTraTien();
            Common.CommonFunc.AddTab(tabControl, nv, "Tài khoản đăng ký mới đã trả tiền", "Tài khoản đăng ký mới đã trả tiền");
        }

        private void btnSuaHienTaiTichLuyNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKTichLuyNap frm = new frmSKTichLuyNap("Sửa sự kiện đang diễn ra", 1);
            frm.ShowDialog();
        }

        private void btnTaoMoiTichLuyNap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKTichLuyNap frm = new frmSKTichLuyNap("Tạo mới sự kiện", 2);
            frm.ShowDialog();
        }

        private void btnSuaHienTaiTichLuyTieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKTichLuyTieu frm = new frmSKTichLuyTieu("Sửa sự kiện đang diễn ra", 1);
            frm.ShowDialog();
        }

        private void btnTaoMoiTichLuyTieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKTichLuyTieu frm = new frmSKTichLuyTieu("Tạo mới sự kiện", 2);
            frm.ShowDialog();
        }

        private void btnSuaHienTaiDoiDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKDoiDo frm = new frmSKDoiDo("Sửa sự kiện đang diễn ra", 1);
            frm.ShowDialog();
        }

        private void btnTaoMoiDoiDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKDoiDo frm = new frmSKDoiDo("Tạo mới sự kiện", 2);
            frm.ShowDialog();
        }

        private void btnSuaHienTaiThanTai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKThanTai frm = new frmSKThanTai("Sửa sự kiện đang diễn ra", 1);
            frm.ShowDialog();
        }

        private void btnTaoMoiThanTai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKThanTai frm = new frmSKThanTai("Tạo mới sự kiện", 2);
            frm.ShowDialog();
        }

        private void btnThanThapConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThanThapConfig frm = new frmThanThapConfig();
            frm.ShowDialog();
        }

        private void btnVipConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmVipConfig frm = new frmVipConfig();
            frm.ShowDialog();
        }

        private void btnChucPhuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChucPhucConfig frm = new frmChucPhucConfig();
            frm.ShowDialog();
        }

        private void btnBossTheGioi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGlobalBossConfig frm = new frmGlobalBossConfig();
            frm.ShowDialog();
        }

        private void btnLeBao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLeBao frm = new frmLeBao();
            frm.ShowDialog();
        }

        private void btnShopItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmShopItem frm = new frmShopItem();
            frm.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmShopLuanKiem frm = new frmShopLuanKiem();
            frm.ShowDialog();
        }

        private void btnLoaiGiftCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGiftCodeCategory frm = new frmGiftCodeCategory();
            frm.ShowDialog();
        }

        private void btnGiftCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGiftCode frm = new frmGiftCode();
            frm.ShowDialog();
        }

        private void btnHienTaiDoiDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKDoiDo frm = new frmSKDoiDo("Sửa sự kiện đang diễn ra", 1);
            frm.ShowDialog();
        }

        private void btnSuaHienTaiTranhMua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKTranhMuaServer frm = new frmSKTranhMuaServer("Sửa sự kiện đang diễn ra", 1);
            frm.ShowDialog();
        }

        private void btnTaoMoiTranhMua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKTranhMuaServer frm = new frmSKTranhMuaServer("Tạo mới sự kiện", 2);
            frm.ShowDialog();
        }

        private void btnSuaHienTaiRotDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKRotDo frm = new frmSKRotDo("Sửa sự kiện đang diễn ra", 1);
            frm.ShowDialog();
        }

        private void btnTaoMoiRotDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKRotDo frm = new frmSKRotDo("Tạo mới sự kiện", 2);
            frm.ShowDialog();
        }

        private void btnGMMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGMMail frm = new frmGMMail();
            frm.ShowDialog();
        }

        private void frmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void btnQuanLyNguoiDungTool_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung();
            frm.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChieuMo frm = new frmChieuMo();
            frm.ShowDialog();
        }

        private void btnThongKeNapTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucThongKeNapTien nv = new ucThongKeNapTien();
            Common.CommonFunc.AddTab(tabControl, nv, "Thống kê nạp tiền", "Thống kê nạp  tiền");
        }

        private void btnChiTietNapTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucChiTietNapTien nv = new ucChiTietNapTien();
            Common.CommonFunc.AddTab(tabControl, nv, "Chi tiết nạp tiền theo server", "Chi tiết nạp tiền theo server");
        }

        private void btnNapLanDau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSkThuongNapLanDau frm = new frmSkThuongNapLanDau();
            frm.ShowDialog();
        }

        private void btnNapLanDau1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSkThuongNapLanDau frm = new frmSkThuongNapLanDau();
            frm.ShowDialog();
        }

        private void btnSuaHienTaiX2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKx2NapThe frm = new frmSKx2NapThe("Sửa sự kiện đang diễn ra", 1);
            frm.ShowDialog();
        }

        private void btnTaoMoiX2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKx2NapThe frm = new frmSKx2NapThe("Tạo mới sự kiện", 2);
            frm.ShowDialog();
        }

        private void btnRuongBau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRuongBau frm = new frmRuongBau();
            frm.ShowDialog();
        }

        private void btnSuaHienTaiDauTop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKDuaTopServer frm = new frmSKDuaTopServer("Sửa sự kiện đang diễn ra", 1);
            frm.ShowDialog();
        }

        private void btnTaoMoiDauTop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSKDuaTopServer frm = new frmSKDuaTopServer("Tạo mới sự kiện", 2);
            frm.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmXuLyThuNapTienLoi frm = new frmXuLyThuNapTienLoi();
            frm.ShowDialog();
        }

        private void btnTyGiaQuyDoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTyGiaQuyDoi frm = new frmTyGiaQuyDoi();
            frm.ShowDialog();
        }

        private void btnThongKeTheoVip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucThongKeTheoVip nv = new ucThongKeTheoVip();
            Common.CommonFunc.AddTab(tabControl, nv, "Thống kê người chơi theo Vip", "Thống kê người chơi theo Vip");
        }

        private void btnThongKeTheoLevel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucThongKeTheoLevel nv = new ucThongKeTheoLevel();
            Common.CommonFunc.AddTab(tabControl, nv, "Thống kê người chơi theo Level", "Thống kê người chơi theo Level");
        }

        private void btnThongKeTieuKNB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucThongKeTinhNangTieuKNB nv = new ucThongKeTinhNangTieuKNB();
            Common.CommonFunc.AddTab(tabControl, nv, "Thống kê tính năng tiêu KNB", "Thống kê tính năng tiêu KNB");
        }
    }
}
