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
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model;
using KDQHNPHTool.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmGMMail : DevExpress.XtraEditors.XtraForm
    {
        List<vGmMail> lsMail = new List<vGmMail>();
        ListServer server = new ListServer();

        public frmGMMail()
        {
            InitializeComponent();
            LoadDataToLUE();
            LoadData();
        }

        public void LoadData()
        {
            lsMail.Clear();
            var tmpMail = MongoController.GmMail.GetListData(MongoController.DatabaseManager.main_database, a => true).OrderByDescending(x => x.status);

            if (tmpMail != null)
            {
                foreach (var item in tmpMail)
                {
                    vGmMail gm = new vGmMail()
                    {
                        idMail = item._id.ToString(),
                        content = item.content,
                        createTime = item.created_at,
                        server_id = item.server_id,
                        status = (int)item.status,
                        title = item.title,
                        username = item.username
                    };
                    lsMail.Add(gm);
                }

                gcMail.DataSource = null;
                gcMail.DataSource = lsMail;
            }

        }

        private void LoadDataToLUE()
        {
            lueChonServer.DataSource = server.GetListServer();
            lueChonServer.DisplayMember = "value";
            lueChonServer.ValueMember = "id";

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

            lueTrangThai.DataSource = lsSukien;
        }

        private void btnXemChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string idMail = (string)gvMail.GetRowCellValue(gvMail.FocusedRowHandle, "idMail");
            frmChiTietGMMail frm = new frmChiTietGMMail(idMail);
            frm.ShowDialog();
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void gvMail_DoubleClick(object sender, EventArgs e)
        {
            string idMail = (string)gvMail.GetRowCellValue(gvMail.FocusedRowHandle, "idMail");
            frmChiTietGMMail frm = new frmChiTietGMMail(idMail);
            frm.ShowDialog();
        }
    }
}