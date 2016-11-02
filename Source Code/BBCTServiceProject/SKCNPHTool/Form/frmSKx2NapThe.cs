using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KDQHNPHTool.FormBase;
using MongoDB.Bson;
using KDQHNPHTool.Model;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Models;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Common;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;

namespace KDQHNPHTool.Form
{
    public partial class frmSKx2NapThe : frmFormChange
    {
        int addOrEdit = 0;
        ObjectId idSuKien;

        ListServer server = new ListServer();
        public frmSKx2NapThe(string nameForm, int status)
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            addOrEdit = status;
            this.Text = nameForm;
            LoadDataToLUE();
            panelControl2.Enabled = false;
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";

            var tmpStatus = from tmp in ConnectDB.Entities.dbCTStatusSuKiens
                            select tmp;

            lueTrangThai.Properties.DataSource = tmpStatus.ToList();
            lueTrangThai.Properties.DisplayMember = "value";
            lueTrangThai.Properties.ValueMember = "id";
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();

                if (addOrEdit == 1)
                {
                    var tmpSk = MongoController.SkX2NapThe.GetListData(server.GetConnectSubDB(idServer), a => true).OrderByDescending(x => x.created_at).FirstOrDefault();
                    if (tmpSk != null)
                    {
                        dteFromDate.EditValue = tmpSk.start;
                        dteToDate.EditValue = tmpSk.end;
                        idSuKien = tmpSk._id;
                        lueTrangThai.EditValue = (int)tmpSk.status;
                    }
                    else
                    {
                        CommonShowDialog.ShowErrorDialog("Server này hiện tại chưa có sự kiện nào, thoát ra và tạo sự kiện mới");
                        this.Close();
                    }
                }
                else
                {
                    lueTrangThai.EditValue = 0;
                    dteFromDate.EditValue = DateTime.Now;
                    dteToDate.EditValue = DateTime.Now;
                }
            }
        }

        protected override void OnSave()
        {
            string idServer = lueChonServer.EditValue.ToString();

            DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
            DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());
            int status = int.Parse(lueTrangThai.EditValue.ToString());

            if (addOrEdit == 1)
            {
                var result = MongoController.SkX2NapThe.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
                result.start = fromDate;
                result.end = toDate;
                result.server_id = idServer;
                result.status = (Status)status;
                MongoController.SkX2NapThe.Update(server.GetConnectSubDB(idServer), result);
            }
            else
            {
                var deActiveSK = MongoController.SkX2NapThe.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);

                foreach (var item in deActiveSK)
                {
                    var tmpCheck = MongoController.SkX2NapThe.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == item._id);
                    tmpCheck.status = Status.Deactivate;
                    MongoController.SkX2NapThe.Update(server.GetConnectSubDB(idServer), tmpCheck);
                }

                MSKx2NapConfig conf = new MSKx2NapConfig()
                {
                    start = fromDate,
                    end = toDate,
                    server_id = idServer,
                    status = (Status)status
                };

                MongoController.SkX2NapThe.Create(server.GetConnectSubDB(idServer), conf);
            }
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}