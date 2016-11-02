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
using KDQHNPHTool.Models;
using KDQHNPHTool.Common;
using KDQHNPHTool.Model;

namespace KDQHNPHTool.Form
{
    public partial class frmQuanLyNguoiDung : frmFormChange
    {
        List<dbUser> lsUser = new List<dbUser>();
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToGC();
        }

        private void LoadDataToLUE()
        {
            List<dbCTAffliction> lsRole = new List<dbCTAffliction>();
            List<dbCTAffliction> lsStatus = new List<dbCTAffliction>();

            dbCTAffliction ct = new dbCTAffliction()
            {
                id = 1,
                value = "Full quyền"
            };
            lsRole.Add(ct);

            dbCTAffliction ct1 = new dbCTAffliction()
            {
                id = 2,
                value = "Chỉ xem"
            };
            lsRole.Add(ct1);

            dbCTAffliction ct3 = new dbCTAffliction()
            {
                id = 3,
                value = "GM"
            };
            lsRole.Add(ct3);

            lueQuyen.DataSource = lsRole;

            dbCTAffliction ct4 = new dbCTAffliction()
            {
                id = 1,
                value = "Đang hoạt động"
            };
            lsStatus.Add(ct4);

            dbCTAffliction ct5 = new dbCTAffliction()
            {
                id = 2,
                value = "Khóa"
            };
            lsStatus.Add(ct5);

            lueTrangThai.DataSource = lsStatus;
        }

        private void LoadDataToGC()
        {
            var tmpUser = from tmp in ConnectDB.Entities.dbUsers.Where(x => x.id != UserSession.IdUser && x.typeTool == 2)
                          select tmp;

            foreach (var item in tmpUser)
            {
                dbUser db = new dbUser()
                {
                    id = item.id,
                    name = item.name,
                    passwords = item.passwords,
                    status = item.status,
                    typeUser = item.typeUser,
                    typeTool = item.typeTool
                };
                lsUser.Add(db);
            }
            gcNguoiDung.DataSource = null;
            gcNguoiDung.DataSource = lsUser;
        }

        protected override void OnAdd()
        {
            if (CommonShowDialog.ShowYesNoDialog("Bạn chắc chắn muốn thêm người dùng mới? Lưu ý:(Mật khẩu mặc định: 12345678)") == DialogResult.Yes)
            {
                dbUser db = new dbUser()
                {
                    id = -(lsUser.Count),
                    name = "tên người dùng",
                    passwords = "12345678",
                    status = 1,
                    typeUser = 3,
                    typeTool = 2
                };
                lsUser.Add(db);
                gcNguoiDung.DataSource = null;
                gcNguoiDung.DataSource = lsUser;
                gvNguoiDung.MoveLast();
            }
        }

        protected override void OnSave()
        {
            gvNguoiDung.FocusedRowHandle = -1;
            foreach (var item in lsUser)
            {
                if (item.id <= 0)
                {
                    dbUser db = new dbUser()
                    {
                        name = item.name,
                        passwords = item.passwords,
                        typeUser = item.typeUser,
                        status = item.status,
                        typeTool = item.typeTool
                    };
                    ConnectDB.Entities.dbUsers.Add(db);
                }
                else
                {
                    var result = ConnectDB.Entities.dbUsers.Where(x => x.id == item.id).FirstOrDefault();
                    result.name = item.name;
                    result.passwords = item.passwords;
                    result.typeUser = item.typeUser;
                    result.status = item.status;
                    result.typeTool = item.typeTool;
                }
                ConnectDB.Entities.SaveChanges();
            }

            LoadDataToGC();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}