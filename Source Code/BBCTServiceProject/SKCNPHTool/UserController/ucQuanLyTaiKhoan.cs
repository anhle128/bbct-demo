using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KDQHNPHTool.FormBase;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Database.Model;
using KDQHNPHTool.Common;
using KDQHNPHTool.Model;
using KDQHNPHTool.Form;

namespace KDQHNPHTool.UserController
{
    public partial class ucQuanLyTaiKhoan : ucManager
    {
        ListServer server = new ListServer();
        public ucQuanLyTaiKhoan()
        {
            InitializeComponent();
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            MongoController.LoadThongTinDatabase();
            LoadDataToLUE();
        }

        private void LoadDataGC(string idServer)
        {
            List<MUserInfo> listUserInfos = MongoController.UserInfo.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer && a.isBot == false);
            List<vUserInfor> lsUser = new List<vUserInfor>();
            foreach (var item in listUserInfos)
            {
                vUserInfor cs = new vUserInfor()
                {
                    avatar = item.avatar,
                    exp = item.exp,
                    gold = item.gold,
                    level = item.level,
                    nickname = item.nickname,
                    posX = item.posX,
                    posY = item.posY,
                    silver = item.silver,
                    stamina = item.stamina,
                    username = item.username,
                    vip = item.vip,
                    hash_code_login_time = item.hash_code_login_time,
                    create_at = item.created_at,
                    update_at = item.updated_at,
                    gold_lock = item.ruby,
                    isBot = item.isBot
                };
                lsUser.Add(cs);
            }

            lbNumber.Text = lsUser.Count.ToString("n0");

            gcUser.DataSource = null;
            gcUser.DataSource = lsUser;
        }

        private void LoadDataToLUE()
        {
            lueServer.Properties.DataSource = server.GetListServer();
            lueServer.Properties.DisplayMember = "value";
            lueServer.Properties.ValueMember = "id";
            lueServer.EditValue = 0;
        }

        protected override void OnDetail()
        {
            string username = (string)gvUser.GetRowCellValue(gvUser.FocusedRowHandle, "username");
            frmChiTietTaiKhoan frm = new frmChiTietTaiKhoan(lueServer.EditValue.ToString(), username);
            frm.ShowDialog();
        }

        private void lueServer_EditValueChanged(object sender, EventArgs e)
        {
            string idServer = lueServer.EditValue.ToString();
            if (idServer != "" && idServer != "0")
            {
                CommonShowDialog.ShowWaitForm();
                LoadDataGC(idServer);
                CommonShowDialog.CloseWaitForm();
            }
        }

        protected override void OnRefesh()
        {
            string idServer = lueServer.EditValue.ToString();
            CommonShowDialog.ShowWaitForm();
            LoadDataGC(idServer);
            CommonShowDialog.CloseWaitForm();
        }
    }
}
