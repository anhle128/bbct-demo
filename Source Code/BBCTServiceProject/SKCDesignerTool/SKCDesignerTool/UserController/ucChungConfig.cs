using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BBCTDesignerTool.FormBase;
using BBCTDesignerTool.Models;
using BBCTDesignerTool.Common;

namespace BBCTDesignerTool.UserController
{
    public partial class ucChungConfig : ucManager
    {
        List<dbFreeStaminaConfig> lsFree = new List<dbFreeStaminaConfig>();
        List<dbPlayerLevelExp> lsPlayer = new List<dbPlayerLevelExp>();
        public ucChungConfig()
        {
            InitializeComponent();
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToList();
            LoadDataToGC();
        }

        private void LoadDataToList()
        {
            lsFree.Clear();
            lsPlayer.Clear();

            var tmpFree = from tmp in ConnectDB.Entities.dbFreeStaminaConfigs
                          where tmp.status == 1
                          select tmp;

            foreach (var item in tmpFree)
            {
                dbFreeStaminaConfig free = new dbFreeStaminaConfig()
                {
                    froms = item.froms,
                    id = item.id,
                    stamina = item.stamina,
                    status = item.status,
                    tos = item.tos
                };
                lsFree.Add(free);
            }

            var tmpPlayer = from tmp in ConnectDB.Entities.dbPlayerLevelExps
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpPlayer)
            {
                dbPlayerLevelExp free = new dbPlayerLevelExp()
                {
                    exps = item.exps,
                    id = item.id,
                    levels = item.levels,
                    status = item.status,
                };
                lsPlayer.Add(free);
            }
        }

        private void LoadDataToGC()
        {
            var tmpConfig = from tmp in ConnectDB.Entities.dbConfigs
                            select tmp;

            gcChung.DataSource = null;
            gcChung.DataSource = tmpConfig.ToList();
            gcPointSkill.DataSource = null;
            gcPointSkill.DataSource = tmpConfig.ToList();
            gcFriend.DataSource = null;
            gcFriend.DataSource = tmpConfig.ToList();
            gcFreeStamina.DataSource = null;
            gcFreeStamina.DataSource = lsFree;
            gcPlayerLevel.DataSource = null;
            gcPlayerLevel.DataSource = lsPlayer;
            gcDauGia.DataSource = null;
            gcDauGia.DataSource = tmpConfig.ToList();
            gcExchange.DataSource = null;
            gcExchange.DataSource = tmpConfig.ToList();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbFreeStaminaConfig point = new dbFreeStaminaConfig()
            {
                id = -(lsFree.Count),
                froms = 0,
                status = 1,
                stamina = 0,
                tos = 0
            };
            lsFree.Add(point);
            gcFreeStamina.DataSource = null;
            gcFreeStamina.DataSource = lsFree.Where(x => x.status == 1);
            gvFreeStamina.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvFreeStamina.RowCount > 0)
            {
                int idGen = (int)gvFreeStamina.GetRowCellValue(gvFreeStamina.FocusedRowHandle, "id");
                lsFree.Where(x => x.id == idGen).ToList().ForEach(y => y.status = 2);
                gcFreeStamina.DataSource = null;
                gcFreeStamina.DataSource = lsFree.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            dbPlayerLevelExp point = new dbPlayerLevelExp()
            {
                id = -(lsPlayer.Count),
                levels = lsPlayer.Count + 1,
                status = 1,
                exps = 0
            };
            lsPlayer.Add(point);
            gcPlayerLevel.DataSource = null;
            gcPlayerLevel.DataSource = lsPlayer.Where(x => x.status == 1);
            gvPlayerLevel.MoveLast();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvPlayerLevel.RowCount > 0)
            {
                int idGen = (int)gvPlayerLevel.GetRowCellValue(gvPlayerLevel.FocusedRowHandle, "id");
                lsPlayer.Where(x => x.id == idGen).ToList().ForEach(y => y.status = 2);
                gcPlayerLevel.DataSource = null;
                gcPlayerLevel.DataSource = lsPlayer.Where(x => x.status == 1);
            }
        }

        private void SaveDataColmumnFocus()
        {
            gvChung.FocusedRowHandle = -1;
            gvFreeStamina.FocusedRowHandle = -1;
            gvFriend.FocusedRowHandle = -1;
            gvPlayerLevel.FocusedRowHandle = -1;
        }

        protected override void OnSave()
        {
            SaveDataColmumnFocus();
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsFree)
            {
                if (item.id <= 0)
                {
                    dbFreeStaminaConfig point = new dbFreeStaminaConfig()
                    {
                        froms = item.froms,
                        status = item.status,
                        stamina = item.stamina,
                        tos = item.tos
                    };
                    ConnectDB.Entities.dbFreeStaminaConfigs.Add(point);
                }
                else
                {
                    int idFree = item.id;
                    var result = ConnectDB.Entities.dbFreeStaminaConfigs.Where(x => x.id == idFree).FirstOrDefault();
                    result.froms = item.froms;
                    result.status = item.status;
                    result.stamina = item.stamina;
                    result.tos = item.tos;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsPlayer)
            {
                if (item.id <= 0)
                {
                    dbPlayerLevelExp point = new dbPlayerLevelExp()
                    {
                        levels = item.levels,
                        status = item.status,
                        exps = item.exps
                    };
                    ConnectDB.Entities.dbPlayerLevelExps.Add(point);
                }
                else
                {
                    int idFree = item.id;
                    var result = ConnectDB.Entities.dbPlayerLevelExps.Where(x => x.id == idFree).FirstOrDefault();
                    result.levels = item.levels;
                    result.status = item.status;
                    result.exps = item.exps;
                }
                ConnectDB.Entities.SaveChanges();
            }

            LoadDataToList();
            LoadDataToGC();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}
