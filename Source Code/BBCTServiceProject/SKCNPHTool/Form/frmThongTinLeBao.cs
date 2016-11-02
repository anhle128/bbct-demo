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
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Models;
using KDQHNPHTool.Common;
using KDQHNPHTool.Database.Controller;

namespace KDQHNPHTool.Form
{
    public partial class frmThongTinLeBao : frmFormChange
    {
        List<vLeBao> lsLeBao = new List<vLeBao>();
        List<vReward> lsVip = new List<vReward>();
        string idLeBao = "";

        public frmThongTinLeBao(string tmpIDLeBao, List<vLeBao> tmpLeBao, List<vReward> tmpVip)
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            lsLeBao = tmpLeBao;
            idLeBao = tmpIDLeBao;
            lsVip = tmpVip;
            LoadDataToLUE();
            LoadData();
        }

        private void LoadDataToLUE()
        {
            var tmpTypeTimeLeBao = from tmp in ConnectDB.Entities.dbCTTypeLeBaoBuyTimes
                                   select tmp;
            lueThoiGianMua.Properties.DataSource = tmpTypeTimeLeBao.ToList();
            lueThoiGianMua.Properties.DisplayMember = "value";
            lueThoiGianMua.Properties.ValueMember = "id";

            var tmpTypeActiveLeBao = from tmp in ConnectDB.Entities.dbCTTypeLeBaoActivationTimes
                                     select tmp;
            lueActive.Properties.DataSource = tmpTypeActiveLeBao.ToList();
            lueActive.Properties.DisplayMember = "value";
            lueActive.Properties.ValueMember = "id";

            var tmpTrangThai = from tmp in ConnectDB.Entities.dbCTStatusSuKiens
                               select tmp;
            lueTrangThai.Properties.DataSource = tmpTrangThai.ToList();
            lueTrangThai.Properties.DisplayMember = "value";
            lueTrangThai.Properties.ValueMember = "id";
        }

        private void LoadData()
        {
            var tmpLeBao = lsLeBao.Where(x => x.id == idLeBao).FirstOrDefault();

            txtBatDau.Text = tmpLeBao.start;
            txtGiaBan.Text = tmpLeBao.gold.ToString();
            txtGiaThuc.Text = tmpLeBao.real_gold.ToString();
            txtKetThuc.Text = tmpLeBao.end;
            txtSoLanMuaToiDa.Text = tmpLeBao.max_buy_times.ToString();
            txtTenLeBao.Text = tmpLeBao.name.ToString();
            txtYeuCauVip.Text = tmpLeBao.vip_require.ToString();
            lueActive.EditValue = tmpLeBao.activation;
            lueTrangThai.EditValue = tmpLeBao.status;
            lueThoiGianMua.EditValue = tmpLeBao.buy_times;
            gcVip.DataSource = null;
            gcVip.DataSource = lsVip.Where(x => x.idFakeString == idLeBao);
        }

        private void lueThoiGianMua_EditValueChanged(object sender, EventArgs e)
        {
            string thoiGianMua = lueThoiGianMua.EditValue.ToString();
            if (thoiGianMua == "0")
            {
                txtYeuCauVip.Enabled = false;
                txtYeuCauVip.Text = "0";
                txtSoLanMuaToiDa.Enabled = false;
                txtSoLanMuaToiDa.Text = "0";
                groupVip.Enabled = false;
            }
            else if (thoiGianMua == "1")
            {
                groupVip.Enabled = false;
                txtYeuCauVip.Enabled = true;
                txtSoLanMuaToiDa.Enabled = true;
            }
            else
            {
                groupVip.Enabled = true;
                txtYeuCauVip.Enabled = false;
                txtYeuCauVip.Text = "0";
                txtSoLanMuaToiDa.Enabled = false;
                txtSoLanMuaToiDa.Text = "0";
            }
        }

        private void lueActive_EditValueChanged(object sender, EventArgs e)
        {
            string active = lueActive.EditValue.ToString();
            if (active == "0")
            {
                txtBatDau.Enabled = false;
                txtKetThuc.Enabled = false;
                dteStart.Visible = false;
                dteEnd.Visible = false;
            }
            else if (active == "1" || active == "2" || active == "3")
            {
                txtBatDau.Enabled = true;
                txtKetThuc.Enabled = true;
                dteStart.Visible = false;
                dteEnd.Visible = false;
            }
            else
            {
                dteStart.Visible = true;
                dteEnd.Visible = true;
                txtBatDau.Enabled = false;
                txtKetThuc.Enabled = false;
            }
        }

        protected override void OnSave()
        {
            gvVip.FocusedRowHandle = -1;
            string thoiGianMua = lueThoiGianMua.EditValue.ToString();
            string active = lueActive.EditValue.ToString();

            if (txtTenLeBao.Text != "" && txtGiaBan.Text != "" && txtGiaThuc.Text != "" && txtSoLanMuaToiDa.Text != "" && txtYeuCauVip.Text != "")
            {
                var result = lsLeBao.Where(x => x.id == idLeBao).FirstOrDefault();
                result.name = txtTenLeBao.Text;
                result.gold = int.Parse(txtGiaBan.Text);
                result.real_gold = int.Parse(txtGiaThuc.Text);
                result.activation = int.Parse(lueActive.EditValue.ToString());
                result.buy_times = int.Parse(lueThoiGianMua.EditValue.ToString());
                result.start = HandlerStartEnd(1);
                result.end = HandlerStartEnd(2);
                result.vip_require = int.Parse(txtYeuCauVip.Text);
                result.max_buy_times = int.Parse(txtYeuCauVip.Text);
                result.status = int.Parse(lueTrangThai.EditValue.ToString());
                this.Close();
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Không được để trống tên và giá bán");
            }
        }

        private string HandlerStartEnd(int type)
        {
            string active = lueActive.EditValue.ToString();

            if (type == 1)
            {
                if (active == "0")
                {
                    return "";
                }
                else if (active == "1" || active == "2" || active == "3")
                {
                    return txtBatDau.Text;
                }
                else
                {
                    DateTime tmpTime = DateTime.Parse(dteStart.EditValue.ToString());
                    return tmpTime.ToString();
                }
            }
            else
            {
                if (active == "0")
                {
                    return "";
                }
                else if (active == "1" || active == "2" || active == "3")
                {
                    return txtKetThuc.Text;
                }
                else
                {
                    DateTime tmpTime = DateTime.Parse(dteEnd.EditValue.ToString());
                    return tmpTime.ToString();
                }
            }
        }
    }
}