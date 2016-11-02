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
using KDQHNPHTool.Common;
using KDQHNPHTool.Models;
using KDQHNPHTool.Model;

namespace KDQHNPHTool.Form
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
            lbVersion.Text = SettingApp.toolVersion + " " + SettingApp.gameVersion;
            txtmatKhau.Properties.PasswordChar = '*';
            txtTenDangNhap.Text = KDQHNPHTool.Properties.Settings.Default.UserName;
            txtmatKhau.Text = KDQHNPHTool.Properties.Settings.Default.Password;
            if (KDQHNPHTool.Properties.Settings.Default.UserName != "")
            {
                ckeRememberMe.Checked = true;
            }
        }
        
        private void HandlerLogin()
        {
            CommonShowDialog.ShowWaitForm();
            if (txtTenDangNhap.Text != "" && txtmatKhau.Text != "")
            {
                var tmpUser = ConnectDB.Entities.dbUsers.Where(x => x.name == txtTenDangNhap.Text && x.passwords == txtmatKhau.Text && x.typeTool == 2).FirstOrDefault();
                if (tmpUser != null)
                {
                    if (tmpUser.status == 1)
                    {
                        frmMainMenu frm = new frmMainMenu(tmpUser.id, tmpUser.name, tmpUser.passwords, (int)tmpUser.typeUser);
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        CommonShowDialog.ShowErrorDialog("Tài khoản đã bị khóa!");
                    }
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("Sai tài khoản hoặc mật khẩu!");
                }
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Sai tài khoản hoặc mật khẩu!");
            }
            CommonShowDialog.CloseWaitForm();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (ckeRememberMe.Checked == true)
            {
                KDQHNPHTool.Properties.Settings.Default.UserName = txtTenDangNhap.Text;
                KDQHNPHTool.Properties.Settings.Default.Password = txtmatKhau.Text;
                KDQHNPHTool.Properties.Settings.Default.Save();
            }

            HandlerLogin();
        }

        private void txtmatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                HandlerLogin();
            }
        }
    }
}