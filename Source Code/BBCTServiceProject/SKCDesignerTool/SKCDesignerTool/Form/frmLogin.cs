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
using KDQHDesignerTool.Common;
using KDQHDesignerTool.Models;

namespace KDQHDesignerTool.Form
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
            lbVersion.Text = SettingApp.toolVersion + SettingApp.gameVersion;
            txtmatKhau.Properties.PasswordChar = '*';
            txtTenDangNhap.Text = KDQHDesignerTool.Properties.Settings.Default.UserName;
            txtmatKhau.Text = KDQHDesignerTool.Properties.Settings.Default.Password;

            if (KDQHDesignerTool.Properties.Settings.Default.UserName != "")
            {
                ckeRememberMe.Checked = true;
            }
        }

        private void HandlerLogin()
        {
            CommonShowDialog.ShowWaitForm();
            if (txtTenDangNhap.Text != "" && txtmatKhau.Text != "")
            {
                var tmpUser = ConnectDB.Entities.dbUsers.Where(x => x.name == txtTenDangNhap.Text && x.passwords == txtmatKhau.Text && x.typeTool == 1).FirstOrDefault();
                if (tmpUser != null)
                {
                    if (tmpUser.status == 1)
                    {
                        frmMainMenu frm = new frmMainMenu();
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
                KDQHDesignerTool.Properties.Settings.Default.UserName = txtTenDangNhap.Text;
                KDQHDesignerTool.Properties.Settings.Default.Password = txtmatKhau.Text;
                KDQHDesignerTool.Properties.Settings.Default.Save();
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

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}