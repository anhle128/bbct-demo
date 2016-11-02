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
using KDQHDesignerTool.FormBase;
using KDQHDesignerTool.Models;
using KDQHDesignerTool.Common;

namespace KDQHDesignerTool.UserController
{
    public partial class ucBattleConfig : ucManager
    {
        List<dbBattlePoint2ArrayConfig> lsArrPoint = new List<dbBattlePoint2ArrayConfig>();
        List<dbBattlePoint2Config> lsPoint = new List<dbBattlePoint2Config>();
        public ucBattleConfig()
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
            lsArrPoint.Clear();
            lsPoint.Clear();

            var tmpArrpoint = from tmp in ConnectDB.Entities.dbBattlePoint2ArrayConfig
                              where tmp.status == 1
                              select tmp;

            foreach (var item in tmpArrpoint)
            {
                dbBattlePoint2ArrayConfig battle = new dbBattlePoint2ArrayConfig()
                {
                    id = item.id,
                    status = item.status
                };
                lsArrPoint.Add(battle);

                var tmpPoint = from tmp in ConnectDB.Entities.dbBattlePoint2Config
                               where tmp.status == 1 && tmp.idPoint2Array == item.id
                               select tmp;

                foreach (var item1 in tmpPoint)
                {
                    dbBattlePoint2Config point = new dbBattlePoint2Config()
                    {
                        id = item1.id,
                        idPoint2Array = item1.idPoint2Array,
                        status = item1.status,
                        x = item1.x,
                        y = item1.y
                    };
                    lsPoint.Add(point);
                }
            }
        }

        private void LoadDataToGC()
        {
            var tmpBattleConfig = from tmp in ConnectDB.Entities.dbBattleConfigs
                                  select tmp;

            gcBattle.DataSource = null;
            gcBattle.DataSource = tmpBattleConfig.ToList();
            gcBackground.DataSource = null;
            gcBackground.DataSource = tmpBattleConfig.ToList();
            gcPoint.DataSource = null;
            gcPoint.DataSource = lsArrPoint;
        }

        private void gvPoint_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvPoint.RowCount > 0)
            {
                int idPoint = (int)gvPoint.GetRowCellValue(gvPoint.FocusedRowHandle, "id");
                gcDetailPoint.DataSource = null;
                gcDetailPoint.DataSource = lsPoint.Where(x => x.status == 1 && x.idPoint2Array == idPoint);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbBattlePoint2ArrayConfig battle = new dbBattlePoint2ArrayConfig()
            {
                id = -(lsArrPoint.Count),
                status = 1
            };
            lsArrPoint.Add(battle);
            gcPoint.DataSource = null;
            gcPoint.DataSource = lsArrPoint.Where(x => x.status == 1);
            gvPoint.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvPoint.RowCount > 0)
            {
                int idEqui = (int)gvPoint.GetRowCellValue(gvPoint.FocusedRowHandle, "id");
                lsPoint.Where(x => x.idPoint2Array == idEqui).ToList().ForEach(y => y.status = 2);
                lsArrPoint.Where(x => x.id == idEqui).ToList().ForEach(y => y.status = 2);
                gcPoint.DataSource = null;
                gcPoint.DataSource = lsArrPoint.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            int idEqui = (int)gvPoint.GetRowCellValue(gvPoint.FocusedRowHandle, "id");
            dbBattlePoint2Config point = new dbBattlePoint2Config()
            {
                id = -(lsPoint.Count),
                idPoint2Array = idEqui,
                status = 1,
                x = 0,
                y = 0
            };
            lsPoint.Add(point);
            gcDetailPoint.DataSource = null;
            gcDetailPoint.DataSource = lsPoint.Where(x => x.status == 1 && x.idPoint2Array == idEqui);
            gvDetailPoint.MoveLast();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvDetailPoint.RowCount > 0)
            {
                int idEqui = (int)gvPoint.GetRowCellValue(gvPoint.FocusedRowHandle, "id");
                int idDetail = (int)gvDetailPoint.GetRowCellValue(gvDetailPoint.FocusedRowHandle, "id");

                lsPoint.Where(x => x.id == idDetail).ToList().ForEach(y => y.status = 2);
                gcDetailPoint.DataSource = null;
                gcDetailPoint.DataSource = lsPoint.Where(x => x.status == 1 && x.idPoint2Array == idEqui);
            }
        }

        protected override void OnSave()
        {
            gvBattle.FocusedRowHandle = -1;
            gvDetailPoint.FocusedRowHandle = -1;
            gvPoint.FocusedRowHandle = -1;
            gvBackground.FocusedRowHandle = -1;

            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsArrPoint)
            {
                if (item.id <= 0)
                {
                    dbBattlePoint2ArrayConfig battle = new dbBattlePoint2ArrayConfig()
                    {
                        status = item.status
                    };
                    ConnectDB.Entities.dbBattlePoint2ArrayConfig.Add(battle);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsPoint)
                    {
                        if (item1.idPoint2Array == item.id)
                        {
                            dbBattlePoint2Config point = new dbBattlePoint2Config()
                            {
                                idPoint2Array = battle.id,
                                status = item1.status,
                                x = item1.x,
                                y = item1.y
                            };
                            ConnectDB.Entities.dbBattlePoint2Config.Add(point);
                            ConnectDB.Entities.SaveChanges();
                        }
                    }
                }
                else
                {
                    int idPoint = item.id;
                    var result = ConnectDB.Entities.dbBattlePoint2ArrayConfig.Where(x => x.id == idPoint).FirstOrDefault();
                    result.status = item.status;

                    foreach (var item1 in lsPoint)
                    {
                        if (item1.idPoint2Array == idPoint)
                        {
                            if (item1.id < 0)
                            {
                                dbBattlePoint2Config point = new dbBattlePoint2Config()
                                {
                                    idPoint2Array = idPoint,
                                    status = item1.status,
                                    x = item1.x,
                                    y = item1.y
                                };
                                ConnectDB.Entities.dbBattlePoint2Config.Add(point);
                            }
                            else
                            {
                                int idDetail = item1.id;
                                var result1 = ConnectDB.Entities.dbBattlePoint2Config.Where(x => x.id == idDetail).FirstOrDefault();
                                result1.idPoint2Array = idPoint;
                                result1.status = item1.status;
                                result1.x = item1.x;
                                result1.y = item1.y;
                            }
                            ConnectDB.Entities.SaveChanges();
                        }
                    }
                }
            }

            LoadDataToList();
            LoadDataToGC();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }
    }
}
