using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ProtoBuf;
using System.IO;
using System.Net;
using BBCTDesignerTool.Common;
using LitJson;
using BBCTDesignerTool.Models;
using System.Deployment.Application;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraTab;
using BBCTDesignerTool.Form;
using StaticDB;
using BBCTDesignerTool.UserController;
using System.Text.RegularExpressions;
using System.Diagnostics;
using BBCTDesignerTool.Database.Controller;
using MongoDBModel.MainDatabaseModels;

namespace BBCTDesignerTool
{
    public partial class frmMainMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMainMenu()
        {
            InitializeComponent();
            DisplayVersionApp();
            //CreateBadWord(); 
        }


        Version myVersion;
        WebClient client = new WebClient();

        //dung khi tao list badword
        private void CreateBadWord()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\quang\Desktop\BanWord.txt");
            string[] arrBad = text.Split('|');
            foreach (var item in arrBad)
            {
                dbBadWord bad = new dbBadWord()
                {
                    keys = item,
                    status = 1
                };
                ConnectDB.Entities.dbBadWords.Add(bad);
                ConnectDB.Entities.SaveChanges();
            }
        }

        private void DisplayVersionApp()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                myVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                this.Text = "";
                this.Text = String.Concat("Phiên bản: ", myVersion) + " - " + SettingApp.toolVersion + " " + SettingApp.gameVersion;
            }
        }

        public void Serialize(Entity entities, string path)
        {
            try
            {
                using (var file = File.Create(path))
                {
                    Serializer.Serialize(file, entities);
                }
            }
            catch (DirectoryNotFoundException)
            {
                string[] arrPath = path.Split('\\');
                string folderName = arrPath[arrPath.Length - 2];
                Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\" + folderName);
                Serialize(entities, path);
            }
        }

        private void btnUploadBunder_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUploadBunder frm = new frmUploadBunder();
            CommonFunc.ShowForm(frm);
        }

        private void btnDeleteAsset_ItemClick(object sender, ItemClickEventArgs e)
        {
            //CreateFileLanguage();
            CommonShowDialog.ShowErrorDialog("Chưa làm!");
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucQuanLyNhanVat nv = new ucQuanLyNhanVat();
            Common.CommonFunc.AddTab(tabControl, nv, "Quản lý môn phái", "Quản lý môn phái");
        }

        private void btnXuatfile_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<MChooseLinkStaticDB> lsLink = new List<MChooseLinkStaticDB>();
            MongoController.LoadThongTinDatabase();
            MongoController.LoadStaticDBCollection();

            var tmpLink = from tmp in ConnectDB.Entities.dbLinkExportStatics
                          where tmp.status == 1
                          select tmp;

            foreach (var item in tmpLink)
            {
                MChooseLinkStaticDB choose = new MChooseLinkStaticDB()
                {
                    name = item.name,
                    link = item.link,
                    choose = false
                };
                lsLink.Add(choose);
            }

            frmLinkExportStaticDB frm = new frmLinkExportStaticDB(lsLink);
            frm.ShowDialog();
            int countChoose = lsLink.Where(x => x.choose == true).Count();
            if (countChoose > 0)
            {
                ExportStaticData export = new ExportStaticData();
                CommonShowDialog.ShowWaitForm();
                Entity entities = export.HandlerExportFile();
                entities.version = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second;
                Serialize(entities, "static.bytes");
                export.CreateFileLanguage();

                //Dictionary<string, object> postParameters = new Dictionary<string, object>();

                //byte[] bytesStatic = System.IO.File.ReadAllBytes("static.bytes");
                //byte[] bytesLanguage = System.IO.File.ReadAllBytes("language.json");
                //postParameters.Add("staticDB", new FormUpload.FileParameter(bytesStatic, "static.bytes", "application/x-www-form-urlencoded"));
                //postParameters.Add("language", new FormUpload.FileParameter(bytesLanguage, "language.json", "application/x-www-form-urlencoded"));
                //postParameters.Add("version", entities.version);

                try
                {
                    foreach (var item in lsLink.Where(x => x.choose == true))
                    {
                        //HttpWebResponse webResponse = FormUpload.MultipartFormDataPost(item.link, "tool-design", postParameters);
                        client.Credentials = new NetworkCredential(SettingApp.accountFPTUploadFile, SettingApp.passwordFPTUploadFile);
                        client.UploadFile(item.link + SettingApp.gameVersion + "/StaticDB/static.bytes", "static.bytes");
                        client.UploadFile(item.link + SettingApp.gameVersion + "/Language/language.json", "language.json");

                        MStaticDB staticDB = new MStaticDB()
                        {
                            url = SettingApp.urlUploadFileStatic,
                            url_language = SettingApp.urlUploadFileLanguage,
                            version = entities.version,
                            game_version = SettingApp.gameVersion
                        };
                        MongoController.StaticDB.Create(MongoController.DatabaseManager.main_database, staticDB);
                    }

                    CommonShowDialog.CloseWaitForm();
                    CommonShowDialog.ShowSuccessfulDialog("Upload dữ liệu lên server thành công!");
                }
                catch (Exception ex)
                {
                    CommonShowDialog.CloseWaitForm();
                    CommonShowDialog.ShowErrorDialog("Đã có lỗi xảy ra trên server: " + ex.ToString());
                }
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Chưa có server nào được chọn");
            }
        }

        private void btnQuanLyItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucQuanLyItem nv = new ucQuanLyItem();
            Common.CommonFunc.AddTab(tabControl, nv, "Quản lý Item", "Quản lý Item");
        }

        private void btnQuanlyEquipment_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucQuanLyEquipment nv = new ucQuanLyEquipment();
            Common.CommonFunc.AddTab(tabControl, nv, "Quản lý Equipment", "Quản lý Equipment");
        }

        private void btnQuanLyBook_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ucQuanLyBook nv = new ucQuanLyBook();
            //Common.CommonFunc.AddTab(tabControl, nv, "Quản lý Bí kíp", "Quản lý Bí kíp");
        }

        private void btnQuanLyMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmQuanLyMap map = new frmQuanLyMap();
            map.ShowDialog();
        }

        private void tabControl_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            XtraTabPage page = (arg.Page as XtraTabPage);
            tabControl.TabPages.Remove(page);
            page.Dispose();
        }

        private void btnCharacterConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucCharacterConfig nv = new ucCharacterConfig();
            Common.CommonFunc.AddTab(tabControl, nv, "Character Config", "Character Config");
        }

        private void btnQuanLyBigMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ucQuanLyBigMapTrue nv = new ucQuanLyBigMapTrue();
            //Common.CommonFunc.AddTab(tabControl, nv, "Quản lý Big Map", "Quản lý Big Map");
        }

        private void btnEquipmentConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmEquipmentConfig nv = new frmEquipmentConfig();
            nv.ShowDialog();
        }

        private void btnQuanLyMapConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmMapConfig frm = new frmMapConfig();
            //frm.ShowDialog();
        }

        private void btnBookConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmBookConfig frm = new frmBookConfig();
            //frm.ShowDialog();
        }

        private void btnQuanLyDataLevel_ItemClick(object sender, ItemClickEventArgs e)
        {
            //    frmDataLevelConfig frm = new frmDataLevelConfig();
            //    frm.ShowDialog();
        }

        private void btnBattleConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucBattleConfig nv = new ucBattleConfig();
            Common.CommonFunc.AddTab(tabControl, nv, "Battle Config", "Battle Config");
        }

        private void btnAfflictionConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmAfflictionConfig frm = new frmAfflictionConfig();
            //frm.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmCharacterLevelEXPConfig frm = new frmCharacterLevelEXPConfig();
            //frm.ShowDialog();
        }

        private void btnVipConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucVipConfig nv = new ucVipConfig();
            Common.CommonFunc.AddTab(tabControl, nv, "Vip Config", "Vip Config");
        }

        private void btnPlayerLevelEXP_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucChungConfig nv = new ucChungConfig();
            Common.CommonFunc.AddTab(tabControl, nv, "Chung", "Chung");
        }

        private void btnMoneyConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmSiver frm = new frmSiver();
            //frm.ShowDialog();
        }

        private void btnCharacterSelection_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmCharSelection frm = new frmCharSelection();
            //frm.ShowDialog();
        }

        private void btnPowerUpItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucPowerupItem nv = new ucPowerupItem();
            Common.CommonFunc.AddTab(tabControl, nv, "Power Up Items", "Power Up Items");
        }

        private void btnVanTieuConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucVanTieu nv = new ucVanTieu();
            Common.CommonFunc.AddTab(tabControl, nv, "Vận tiêu", "Vận tiêu");
        }

        private void btnCuopTieu_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucCuopTieu nv = new ucCuopTieu();
            Common.CommonFunc.AddTab(tabControl, nv, "Cướp tiêu", "Cướp tiêu");
        }

        private void btnThanThap_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThanThap frm = new frmThanThap();
            frm.ShowDialog();
        }

        private void btnBossTheGioi_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucGlobalBoss nv = new ucGlobalBoss();
            Common.CommonFunc.AddTab(tabControl, nv, "Boss thế giới", "Boss thế giới");
        }

        private void btnCauCa_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucCauCa nv = new ucCauCa();
            Common.CommonFunc.AddTab(tabControl, nv, "Câu cá", "Câu cá");
        }

        private void btnLuanKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLuanKiem frm = new frmLuanKiem();
            frm.ShowDialog();
        }

        private void btnGuild_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmGuildConfig frm = new frmGuildConfig();
            frm.ShowDialog();
        }

        private void btnNhiemVuHangNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            ucNhiemVuHangNgay nv = new ucNhiemVuHangNgay();
            Common.CommonFunc.AddTab(tabControl, nv, "Nhiệm vụ Hàng ngày", "Nhiệm vụ Hàng ngày");
        }

        private void btnBangChien_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBangChien frm = new frmBangChien();
            frm.ShowDialog();
        }

        private void btnNhiemVuChinhTuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNhiemVuChinhTuyen frm = new frmNhiemVuChinhTuyen();
            frm.ShowDialog();
        }

        private void btnHoatDongDiemDanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDiemDanh frm = new frmDiemDanh();
            frm.ShowDialog();
        }

        private void btnPhucLoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPhucLoiThang frm = new frmPhucLoiThang();
            frm.ShowDialog();
        }

        private void btnTuNguXau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBadWord frm = new frmBadWord();
            frm.ShowDialog();
        }

        private void btnLevelReward_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLevelReward frm = new frmLevelReward();
            frm.ShowDialog();
        }

        private void btnShareFacebook_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFacebook frm = new frmFacebook();
            frm.ShowDialog();
        }

        private void btnTutorial_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTutorial frm = new frmTutorial();
            frm.ShowDialog();
        }

        private void btnThuGuiGM_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThuGuiGM frm = new frmThuGuiGM();
            frm.ShowDialog();
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmThuGuiGM frm = new frmThuGuiGM();
            frm.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTutorial frm = new frmTutorial();
            frm.ShowDialog();
        }

        private void frmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnPlayer_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPlayerDefaultConfig frm = new frmPlayerDefaultConfig();
            frm.ShowDialog();
        }

        private void btnTips_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTips frm = new frmTips();
            frm.ShowDialog();
        }

        private void btnThuongMap3Sao_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmStarReward frm = new frmStarReward();
            frm.ShowDialog();
        }

        private void btnCuuChiTon_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCuuChiTon frm = new frmCuuChiTon();
            frm.ShowDialog();
        }

        private void btnPhucLoiTruongThanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPhucLoiTruongThanh frm = new frmPhucLoiTruongThanh();
            frm.ShowDialog();
        }

        private void btnRuongBau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRuongBau frm = new frmRuongBau();
            frm.ShowDialog();
        }

        private void btnInviteFacebook_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmInviteFacebook frm = new frmInviteFacebook();
            frm.ShowDialog();
        }

        private void btnThangLuanKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLuanKiemWinReward frm = new frmLuanKiemWinReward();
            frm.ShowDialog();
        }

        private void btnDoiHinhDuBi_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoiHinhDuBi frm = new frmDoiHinhDuBi();
            frm.ShowDialog();
        }
    }
}