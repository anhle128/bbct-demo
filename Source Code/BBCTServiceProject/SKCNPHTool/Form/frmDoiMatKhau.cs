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
using KDQHNPHTool.Models;
using KDQHNPHTool.Model;
using KDQHNPHTool.Common;

namespace KDQHNPHTool.Form
{
    public partial class frmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            txtNguoiDung.Text = UserSession.Username;
            txtMatKhauHienTai.Text = UserSession.Password;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMatKhauMoi.Text != "") 
            {
                if (CommonShowDialog.ShowYesNoDialog("Bạn chắc chắn đổi mật khẩu?") == DialogResult.Yes)
                {
                    var tmpUser = ConnectDB.Entities.dbUsers.Where(x => x.id == UserSession.IdUser).FirstOrDefault();
                    if (tmpUser != null)
                    {
                        tmpUser.passwords = txtMatKhauMoi.Text;
                        ConnectDB.Entities.SaveChanges();
                    }
                    CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
                }
            }
            else 
            {
                CommonShowDialog.ShowErrorDialog("Mật khẩu mới trống!");
            }
        }
    }
}