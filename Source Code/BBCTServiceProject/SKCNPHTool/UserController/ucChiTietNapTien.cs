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
using KDQHNPHTool.Model;
using MongoDBModel.MainDatabaseModels;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Common;
using DynamicDBModel.Models;
using MongoDBModel.SubDatabaseModels;

namespace KDQHNPHTool.UserController
{
    public partial class ucChiTietNapTien : DevExpress.XtraEditors.XtraUserControl
    {
        ListServer server = new ListServer();
        public ucChiTietNapTien()
        {
            InitializeComponent();
            LoadDataToLUE();
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";
            lueChonServer.EditValue = 0;

            List<dbCTOneorAll> lsLoaiTrans = new List<dbCTOneorAll>();
            dbCTOneorAll all = new dbCTOneorAll()
            {
                id = 1,
                value = "Scratch Card"
            };
            lsLoaiTrans.Add(all);
            dbCTOneorAll all1 = new dbCTOneorAll()
            {
                id = 10,
                value = "WCPAY"
            };
            lsLoaiTrans.Add(all1);
            dbCTOneorAll all2 = new dbCTOneorAll()
            {
                id = 20,
                value = "Google Play"
            };
            lsLoaiTrans.Add(all2);
            dbCTOneorAll all3 = new dbCTOneorAll()
            {
                id = 30,
                value = "Itune"
            };
            lsLoaiTrans.Add(all3);
            dbCTOneorAll all4 = new dbCTOneorAll()
            {
                id = 100,
                value = "Gift"
            };
            lsLoaiTrans.Add(all4);
            lueKenhThanhToan.DataSource = lsLoaiTrans;

            List<dbCTOneorAll> lsTrangThaiTrans = new List<dbCTOneorAll>();
            dbCTOneorAll all6 = new dbCTOneorAll()
            {
                id = 0,
                value = "Đang kiểm tra"
            };
            lsTrangThaiTrans.Add(all6);
            dbCTOneorAll all7 = new dbCTOneorAll()
            {
                id = 1,
                value = "Thành công"
            };
            lsTrangThaiTrans.Add(all7);
            lueTrangThai.DataSource = lsTrangThaiTrans;
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            CommonShowDialog.ShowWaitForm();
            string idServer = lueChonServer.EditValue.ToString();

            if (idServer != "" && idServer != "0")
            {
                List<MTransaction> tmpUserCharacter = MongoController.UserTransaction.GetListData(MongoController.DatabaseManager.main_database, a => a.server_id == idServer);
                List<MUserInfo> lsUser = MongoController.UserInfo.GetListData(server.GetConnectSubDB(idServer), a => a.isBot == false && a.server_id == idServer);

                List<vUserTransaction> lsUserCharacter = new List<vUserTransaction>();

                foreach (var item in tmpUserCharacter.OrderByDescending(x => x.created_at))
                {
                    vUserTransaction user = new vUserTransaction()
                    {
                        username = item.username,
                        type = (int)item.type,
                        time = item.created_at,
                        status = (int)item.status,
                        nickname = GetNickName(item.username, lsUser),
                        money = item.money,
                        ruby = item.ruby
                    };
                    lsUserCharacter.Add(user);
                }

                gcChiTiet.DataSource = null;
                gvChiTiet.Columns["money"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "money", "Tổng = {0:n0}");
                gcChiTiet.DataSource = lsUserCharacter;
            }
            CommonShowDialog.CloseWaitForm();
        }

        private string GetNickName(string username, List<MUserInfo> lsUser)
        {
            var tmp = lsUser.Where(x => x.username == username).FirstOrDefault();

            if (tmp != null)
            {
                if (tmp.nickname == null)
                {
                    return "Không có";
                }
                else
                {
                    return tmp.nickname;
                }
            }
            else { return null; }
        }
    }
}
