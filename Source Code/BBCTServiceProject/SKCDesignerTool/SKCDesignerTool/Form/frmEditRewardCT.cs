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
using KDQHDesignerTool.FormBase;
using KDQHDesignerTool.Models;
using KDQHDesignerTool.Common;

namespace KDQHDesignerTool.Form
{
    public partial class frmEditRewardCT : frmFormChange
    {
        List<Models.TotalReward> lsTotalReward = new List<Models.TotalReward>();
        private dbNhiemVuChinhTuyenReward rewardNhiemVu;

        public dbNhiemVuChinhTuyenReward RewardNhiemVu
        {
            get { return rewardNhiemVu; }
            set { rewardNhiemVu = value; }
        }

        public frmEditRewardCT(dbNhiemVuChinhTuyenReward tmpReward)
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            rewardNhiemVu = tmpReward;

            LoadTotalReward();
            LoadDataLUEtypeReward();
            if (rewardNhiemVu != null)
            {
                lueTypeReward.EditValue = rewardNhiemVu.typeReward;
                slueTypeReward.EditValue = rewardNhiemVu.staticID;
                txtAmountMax.Text = rewardNhiemVu.stepUpQuantity.ToString();
                txtAmountMin.Text = rewardNhiemVu.quantity.ToString();
            }
        }

        private void LoadTotalReward()
        {
            Models.TotalReward reward = new Models.TotalReward()
            {
                id = 0,
                value = "Không"
            };
            lsTotalReward.Add(reward);

            var lsCharacter = from chr in ConnectDB.Entities.dbCharacters
                              where chr.status == 1
                              select chr;

            foreach (var item in lsCharacter)
            {
                Models.TotalReward chr = new Models.TotalReward()
                {
                    id = (int)item.idCharacter,
                    value = item.name
                };
                lsTotalReward.Add(chr);
            }

            var lsEquipment = from chr in ConnectDB.Entities.dbEquipments
                              where chr.status == 1
                              select chr;

            foreach (var item in lsEquipment)
            {
                Models.TotalReward chr = new Models.TotalReward()
                {
                    id = 1000 + (int)item.idEquipment,
                    value = item.name
                };
                lsTotalReward.Add(chr);
            }

            var lsItem = from chr in ConnectDB.Entities.dbItems
                         where chr.status == 1
                         select chr;

            foreach (var item in lsItem)
            {
                Models.TotalReward chr = new Models.TotalReward()
                 {
                     id = 2000 + (int)item.idItem,
                     value = item.name
                 };
                lsTotalReward.Add(chr);
            }

            var lsPower = from chr in ConnectDB.Entities.dbPowerUpItems
                          where chr.status == 1
                          select chr;

            foreach (var item in lsPower)
            {
                Models.TotalReward chr = new Models.TotalReward()
                {
                    id = 3000 + (int)item.idPowerUpItems,
                    value = item.name
                };
                lsTotalReward.Add(chr);
            }
        }

        private void LoadDataLUEtypeReward()
        {
            var tmpTypeReward = from stage in ConnectDB.Entities.dbCTTypeRewards
                                select stage;
            lueTypeReward.Properties.DataSource = tmpTypeReward.ToList();
            lueTypeReward.Properties.DisplayMember = "value";
            lueTypeReward.Properties.ValueMember = "id";
        }

        private void lueTypeReward_EditValueChanged(object sender, EventArgs e)
        {
            int num = int.Parse(lueTypeReward.EditValue.ToString());
            slueTypeReward.ReadOnly = false;
            if (num == 1)
            {
                slueTypeReward.Properties.DataSource = lsTotalReward.Where(x => x.id >= 2000 && x.id < 3000).OrderBy(y => y.id).ToList();
                slueTypeReward.EditValue = 2001;
            }
            else if (num == 2 || num == 3)
            {
                slueTypeReward.Properties.DataSource = lsTotalReward.Where(x => x.id > 0 && x.id < 1000).OrderBy(y => y.id).ToList();
                slueTypeReward.EditValue = 1;
            }
            else if (num == 4 || num == 5)
            {
                slueTypeReward.Properties.DataSource = lsTotalReward.Where(x => x.id >= 1000 && x.id < 2000).OrderBy(y => y.id).ToList();
                slueTypeReward.EditValue = 1001;
            }
            else if (num == 6)
            {
                slueTypeReward.Properties.DataSource = lsTotalReward.Where(x => x.id >= 3000).OrderBy(y => y.id).ToList();
                slueTypeReward.EditValue = 3001;
            }
            else
            {
                slueTypeReward.Properties.DataSource = lsTotalReward;
                slueTypeReward.EditValue = 0;
                slueTypeReward.ReadOnly = true;
            }
            slueTypeReward.Properties.DisplayMember = "value";
            slueTypeReward.Properties.ValueMember = "id";
        }

        protected override void OnSave()
        {
            if (txtAmountMax.Text != "" && txtAmountMin.Text != "")
            {
                if (rewardNhiemVu != null)
                {
                    rewardNhiemVu.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardNhiemVu.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardNhiemVu.quantity = int.Parse(txtAmountMin.Text);
                    rewardNhiemVu.stepUpQuantity = int.Parse(txtAmountMax.Text);
                }
                this.Close();
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Không được để textbox trống!");
            }
        }
    }
}