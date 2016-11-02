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
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Database.Model;
using KDQHNPHTool.Common;

namespace KDQHNPHTool.Form
{
    public partial class frmTyGiaQuyDoi : frmFormChange
    {
        List<vReward> lsReward = new List<vReward>();
        ObjectId idSuKien;

        public frmTyGiaQuyDoi()
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToList();
        }

        private void LoadDataToList()
        {
            lsReward.Clear();
            gcTyGia.DataSource = null;

            var tmpSk = MongoController.TyGiaQuyDoi.GetListData(MongoController.DatabaseManager.main_database, a => true);
            if (tmpSk.Count > 0)
            {
                foreach (var item in tmpSk.OrderBy(x => x.ruby))
                {
                    vReward reward = new vReward()
                    {
                        idFakeString = item._id.ToString(),
                        idFake = item.ruby,
                        type_reward = item.vnd,
                        status = 1
                    };
                    lsReward.Add(reward);
                }
                gcTyGia.DataSource = lsReward.Where(x => x.status == 1);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            vReward re = new vReward()
            {
                idFake = 1,
                idFakeString = (-(lsReward.Count)).ToString(),
                type_reward = 1,
                status = 1
            };
            lsReward.Add(re);
            gcTyGia.DataSource = null;
            gcTyGia.DataSource = lsReward.Where(x => x.status == 1);
            gvTyGia.MoveLast();
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvTyGia.RowCount > 0)
            {
                string idReward = (string)gvTyGia.GetRowCellValue(gvTyGia.FocusedRowHandle, "idFakeString");

                lsReward.Where(x => x.idFakeString == idReward).ToList().ForEach(x => x.status = 2);
                gcTyGia.DataSource = null;
                gcTyGia.DataSource = lsReward.Where(x => x.status == 1);
            }
        }

        protected override void OnSave()
        {
            gvTyGia.FocusedRowHandle = -1;

            foreach (var item in lsReward.Where(x => x.status == 1))
            {
                int tmp;
                bool isInt = int.TryParse(item.idFakeString, out tmp);
                if (isInt == true)
                {
                    MTyGiaQuyDoi tyGia = new MTyGiaQuyDoi()
                    {
                        ruby = item.idFake,
                        vnd = item.type_reward
                    };
                    MongoController.TyGiaQuyDoi.Create(MongoController.DatabaseManager.main_database, tyGia);
                }
                else
                {
                    idSuKien = ObjectId.Parse(item.idFakeString);
                    var result = MongoController.TyGiaQuyDoi.GetSingleData(MongoController.DatabaseManager.main_database, a => a._id == idSuKien);
                    result.ruby = item.idFake;
                    result.vnd = item.type_reward;
                    MongoController.TyGiaQuyDoi.Update(MongoController.DatabaseManager.main_database, result);
                }
            }

            foreach (var item in lsReward.Where(x => x.status == 2))
            {
                int tmp;
                bool isInt = int.TryParse(item.idFakeString, out tmp);
                if (isInt == false)
                {
                    idSuKien = ObjectId.Parse(item.idFakeString);
                    MongoController.TyGiaQuyDoi.DeleteAsync(MongoController.DatabaseManager.main_database, idSuKien);
                }
            }

            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}