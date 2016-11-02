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
using KDQHNPHTool.Model;
using KDQHNPHTool.Database.Controller;
using MongoDB.Bson;
using KDQHNPHTool.Common;
using MongoDBModel.SubDatabaseModels;

namespace KDQHNPHTool.Form
{
    public partial class frmChiTietGMMail : DevExpress.XtraEditors.XtraForm
    {
        ObjectId idmail;
        ListServer server = new ListServer();

        public frmChiTietGMMail(string tmpIdMail)
        {
            InitializeComponent();
            idmail = ObjectId.Parse(tmpIdMail);
            LoadDataToLUE();
            LoadData();
        }

        private void LoadData()
        {
            var tmpMail = MongoController.GmMail.GetSingleData(MongoController.DatabaseManager.main_database, a => a._id == idmail);

            if (tmpMail != null)
            {
                txtIDThu.Text = tmpMail._id.ToString();
                txtNguoiGui.Text = tmpMail.username;
                txtNoiDung.Text = tmpMail.content;
                txtThoiGianGui.Text = tmpMail.created_at.ToShortDateString();
                txtTieuDe.Text = tmpMail.title;
                lueChonServer.EditValue = tmpMail.server_id;
                lueTrangThai.EditValue = tmpMail.status;
            }
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";

            List<dbCTStatusSuKien> lsSukien = new List<dbCTStatusSuKien>();

            dbCTStatusSuKien ct = new dbCTStatusSuKien()
            {
                id = 0,
                value = "Đã trả lời"
            };
            lsSukien.Add(ct);

            dbCTStatusSuKien ct1 = new dbCTStatusSuKien()
            {
                id = 1,
                value = "Chưa trả lời"
            };
            lsSukien.Add(ct1);

            lueTrangThai.Properties.DataSource = lsSukien;
            lueTrangThai.Properties.DisplayMember = "value";
            lueTrangThai.Properties.ValueMember = "id";
        }

        private void btnGuiThu_Click(object sender, EventArgs e)
        {
            if (txtTraLoiThu.Text != "")
            {
                MUserMail mail = new MUserMail()
                {
                    username = txtNguoiGui.Text,
                    content = txtTraLoiThu.Text,
                    title = "GM trả lời thư",
                    readed = false,
                    server_id = lueChonServer.EditValue.ToString(),
                    type = MongoDBModel.Enum.UserMailType.Normal,
                    rewards = null
                };
                MongoController.UserMail.Create(server.GetConnectSubDB(lueChonServer.EditValue.ToString()), mail);

                var result = MongoController.GmMail.GetSingleData(MongoController.DatabaseManager.main_database, a => a._id == idmail);
                result.status = MongoDBModel.Enum.Status.Activate;
                MongoController.GmMail.Update(MongoController.DatabaseManager.main_database, result);

                CommonShowDialog.ShowSuccessfulDialog("Gửi thành công!");


            }
        }
    }
}