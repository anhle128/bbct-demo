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
using KDQHNPHTool.Models;
using KDQHNPHTool.Common;
using KDQHNPHTool.FormBase;
using KDQHNPHTool.Model;
using KDQHNPHTool.Database.Controller;

namespace KDQHNPHTool.Form
{
    public partial class frmEditReward : frmFormChange
    {
        private vReward reward;

        public vReward Reward
        {
            get { return reward; }
            set { reward = value; }
        }

        ListReward stReward = new ListReward();
        ListServer server = new ListServer();

        public frmEditReward(vReward reTemp, int type, string tmpIDServer)
        {
            InitializeComponent();
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            reward = reTemp;
            LoadDataToLUE(tmpIDServer);
            LoadDataLUEtypeReward();
            lbMax.Visible = false;
            lbMin.Visible = false;
            lbRuongBau.Visible = false;
            lueRuongBau.Visible = false;

            if (reward != null && type == 1)
            {
                lueTypeReward.EditValue = reward.type_reward;
                lueReward.EditValue = reward.static_id;
                lueRuongBau.EditValue = reward.idRuong;
                txtQuantity.Text = reward.quantity.ToString();
                txtProc.Enabled = false;
                txtPrice.Enabled = false;
            }
            if (reward != null && type == 2)
            {
                lueTypeReward.EditValue = reward.type_reward;
                lueReward.EditValue = reward.static_id;
                lueRuongBau.EditValue = reward.idRuong;
                txtQuantity.Text = reward.quantity.ToString();
                txtProc.Text = reward.proc.ToString();
                txtPrice.Enabled = false;
            }
            if (reward != null && type == 3)
            {
                lueTypeReward.EditValue = reward.type_reward;
                lueReward.EditValue = reward.static_id;
                lueRuongBau.EditValue = reward.idRuong;
                txtProc.Text = reward.proc.ToString();
                txtPrice.Enabled = false;
                txtQuantity.Enabled = false;
            }
            if (reward != null && type == 4)
            {
                lueTypeReward.EditValue = reward.type_reward;
                lueReward.EditValue = reward.static_id;
                lueRuongBau.EditValue = reward.idRuong;
                txtQuantity.Text = reward.quantity.ToString();
                txtPrice.Text = reward.price.ToString();
                txtProc.Enabled = false;
            }
            if (reward != null && type == 5)
            {
                lueTypeReward.EditValue = reward.type_reward;
                lueReward.EditValue = reward.static_id;
                lueRuongBau.EditValue = reward.idRuong;
                txtQuantity.Text = reward.quantity.ToString();
                txtPrice.Text = reward.price.ToString();
                txtProc.Text = reward.proc.ToString();
                lbPrice.Visible = false;
                lbQuan.Visible = false;
                lbMin.Visible = true;
                lbMax.Visible = true;
            }
        }

        private void LoadDataToLUE(string idServer)
        {
            if (idServer != "")
            {
                var tmpRuongBau = MongoController.RuongBau.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);
                List<RuongBauModel> lsTotalReward = new List<RuongBauModel>();
                if (tmpRuongBau.Count > 0)
                {
                    foreach (var item in tmpRuongBau)
                    {
                        RuongBauModel chr = new RuongBauModel()
                        {
                            value = item.name,
                            id_ruong = item._id.ToString()
                        };
                        lsTotalReward.Add(chr);
                    }
                }
                lueRuongBau.Properties.DataSource = lsTotalReward;
                lueRuongBau.Properties.DisplayMember = "value";
                lueRuongBau.Properties.ValueMember = "id_ruong";
            }
        }

        private void LoadDataLUEtypeReward()
        {
            lueTypeReward.Properties.DataSource = stReward.LoadTypeReward();
            lueTypeReward.Properties.DisplayMember = "value";
            lueTypeReward.Properties.ValueMember = "id";
        }

        private void lueTypeReward_EditValueChanged(object sender, EventArgs e)
        {
            int num = int.Parse(lueTypeReward.EditValue.ToString());
            lueReward.ReadOnly = false;
            if (num == 1)
            {
                lueReward.Properties.DataSource = stReward.LoadTotalReward().Where(x => x.id >= 2000 && x.id < 3000).OrderBy(y => y.id).ToList();
                lueReward.EditValue = 2001;
            }
            else if (num == 2 || num == 3)
            {
                lueReward.Properties.DataSource = stReward.LoadTotalReward().Where(x => x.id > 0 && x.id < 1000).OrderBy(y => y.id).ToList();
                lueReward.EditValue = 1;
            }
            else if (num == 4 || num == 5)
            {
                lueReward.Properties.DataSource = stReward.LoadTotalReward().Where(x => x.id >= 1000 && x.id < 2000).OrderBy(y => y.id).ToList();
                lueReward.EditValue = 1001;
            }
            else if (num == 6)
            {
                lueReward.Properties.DataSource = stReward.LoadTotalReward().Where(x => x.id >= 3000 && x.id < 4000).OrderBy(y => y.id).ToList();
                lueReward.EditValue = 3001;
            }
            else
            {
                lueReward.Properties.DataSource = stReward.LoadTotalReward();
                lueReward.EditValue = 0;
                lueReward.ReadOnly = true;
            }
            lueReward.Properties.DisplayMember = "value";
            lueReward.Properties.ValueMember = "id";
        }

        protected override void OnSave()
        {
            if (txtQuantity.Text != "" && txtProc.Text == "" && txtPrice.Text == "")
            {
                reward.quantity = int.Parse(txtQuantity.Text);
                reward.static_id = int.Parse(lueReward.EditValue.ToString());
                reward.type_reward = int.Parse(lueTypeReward.EditValue.ToString());
                if (lueRuongBau.EditValue == null)
                {
                    reward.idRuong = null;
                }
                else
                {
                    reward.idRuong = lueRuongBau.EditValue.ToString();
                }
                this.Close();
            }
            else if (txtQuantity.Text != "" && txtProc.Text != "" && txtPrice.Text == "")
            {
                reward.quantity = int.Parse(txtQuantity.Text);
                reward.static_id = int.Parse(lueReward.EditValue.ToString());
                reward.type_reward = int.Parse(lueTypeReward.EditValue.ToString());
                reward.proc = double.Parse(txtProc.Text);
                if (lueRuongBau.EditValue == null)
                {
                    reward.idRuong = null;
                }
                else
                {
                    reward.idRuong = lueRuongBau.EditValue.ToString();
                }
                this.Close();
            }
            else if (txtQuantity.Text == "" && txtProc.Text != "" && txtPrice.Text == "")
            {
                reward.static_id = int.Parse(lueReward.EditValue.ToString());
                reward.type_reward = int.Parse(lueTypeReward.EditValue.ToString());
                reward.proc = int.Parse(txtProc.Text);
                if (lueRuongBau.EditValue == null)
                {
                    reward.idRuong = null;
                }
                else
                {
                    reward.idRuong = lueRuongBau.EditValue.ToString();
                }
                this.Close();
            }
            else if (txtQuantity.Text != "" && txtProc.Text == "" && txtPrice.Text != "")
            {
                reward.quantity = int.Parse(txtQuantity.Text);
                reward.static_id = int.Parse(lueReward.EditValue.ToString());
                reward.type_reward = int.Parse(lueTypeReward.EditValue.ToString());
                reward.price = int.Parse(txtPrice.Text);
                if (lueRuongBau.EditValue == null)
                {
                    reward.idRuong = null;
                }
                else
                {
                    reward.idRuong = lueRuongBau.EditValue.ToString();
                }
                this.Close();
            }
            else if (txtQuantity.Text != "" && txtProc.Text != "" && txtPrice.Text != "")
            {
                reward.quantity = int.Parse(txtQuantity.Text);
                reward.static_id = int.Parse(lueReward.EditValue.ToString());
                reward.type_reward = int.Parse(lueTypeReward.EditValue.ToString());
                reward.price = int.Parse(txtPrice.Text);
                reward.proc = double.Parse(txtProc.Text);
                if (lueRuongBau.EditValue == null)
                {
                    reward.idRuong = null;
                }
                else
                {
                    reward.idRuong = lueRuongBau.EditValue.ToString();
                }
                this.Close();
            }

            else
            {
                CommonShowDialog.ShowErrorDialog("Không được để textbox trống!");
            }
        }

        private void lueReward_EditValueChanged(object sender, EventArgs e)
        {
            int num = int.Parse(lueReward.EditValue.ToString());
            lbRuongBau.Visible = false;
            lueRuongBau.Visible = false;

            if (num == 2060)
            {
                lbRuongBau.Visible = true;
                lueRuongBau.Visible = true;
            }
        }
    }
}