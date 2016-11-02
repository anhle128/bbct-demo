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

namespace BBCTDesignerTool.Form
{
    public partial class frmEquipmentConfig : frmFormChange
    {
        List<dbPieceNeedToImport> lsImport = new List<dbPieceNeedToImport>();
        List<dbpieceExportReceive> lsReceive = new List<dbpieceExportReceive>();
        List<dbPowRateByPromotion> lsPowRateByPromotion = new List<dbPowRateByPromotion>();
        List<dbEquipStarUpConfig> lsEquipStarUpConfig = new List<dbEquipStarUpConfig>();
        List<dbEquipStarUpDetail> lsEquipStarUpDetail = new List<dbEquipStarUpDetail>();

        public frmEquipmentConfig()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToList();
            LoadDataToGC();
        }

        private void LoadDataToList()
        {
            lsImport.Clear();
            lsReceive.Clear();
            lsPowRateByPromotion.Clear();
            lsEquipStarUpConfig.Clear();
            lsEquipStarUpDetail.Clear();

            var tmpImport = from tmp in ConnectDB.Entities.dbPieceNeedToImports
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpImport)
            {
                dbPieceNeedToImport import = new dbPieceNeedToImport()
                {
                    id = item.id,
                    idEquipmentConfig = item.idEquipmentConfig,
                    status = item.status,
                    value = item.value
                };
                lsImport.Add(import);
            }

            var tmpExport = from tmp in ConnectDB.Entities.dbpieceExportReceives
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpExport)
            {
                dbpieceExportReceive export = new dbpieceExportReceive()
                {
                    id = item.id,
                    idEquipmentConfig = item.idEquipmentConfig,
                    status = item.status,
                    value = item.value
                };
                lsReceive.Add(export);
            }

            var tmpPow = from tmp in ConnectDB.Entities.dbPowRateByPromotions
                         where tmp.status == 1
                         select tmp;

            foreach (var item in tmpPow)
            {
                dbPowRateByPromotion export = new dbPowRateByPromotion()
                {
                    id = item.id,
                    status = item.status,
                    powRateByPromotion = item.powRateByPromotion
                };
                lsPowRateByPromotion.Add(export);
            }

            var tmpStarUp = from tmp in ConnectDB.Entities.dbEquipStarUpConfigs
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpStarUp)
            {
                dbEquipStarUpConfig equip = new dbEquipStarUpConfig()
                {
                    id = item.id,
                    idEquipmentConfig = item.idEquipmentConfig,
                    promotion = item.promotion,
                    equipStockStar = item.equipStockStar,
                    status = 1
                };
                lsEquipStarUpConfig.Add(equip);
            }

            var tmpDetatil = from tmp in ConnectDB.Entities.dbEquipStarUpDetails
                             where tmp.status == 1
                             select tmp;

            foreach (var item in tmpDetatil)
            {
                dbEquipStarUpDetail export = new dbEquipStarUpDetail()
                {
                    id = item.id,
                    idStarUp = item.idStarUp,
                    status = item.status,
                    value = item.value
                };
                lsEquipStarUpDetail.Add(export);
            }
        }

        private void LoadDataToGC()
        {
            var tmpEqui = from tmp in ConnectDB.Entities.dbEquipmentConfigs
                          select tmp;

            gcEquipment.DataSource = null;
            gcEquipment.DataSource = tmpEqui.ToList();
            gcBaseGold.DataSource = null;
            gcBaseGold.DataSource = tmpEqui.ToList();
            gcImport.DataSource = null;
            gcImport.DataSource = lsImport;
            gcReceive.DataSource = null;
            gcReceive.DataSource = lsReceive;
            gcPowRateByPromotion.DataSource = null;
            gcPowRateByPromotion.DataSource = lsPowRateByPromotion;
            gcStarUpConfig.DataSource = null;
            gcStarUpConfig.DataSource = lsEquipStarUpConfig;
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbPieceNeedToImport point = new dbPieceNeedToImport()
            {
                id = -(lsImport.Count),
                idEquipmentConfig = 1,
                status = 1,
                value = 0,
            };
            lsImport.Add(point);
            gcImport.DataSource = null;
            gcImport.DataSource = lsImport.Where(x => x.status == 1);
            gvImport.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvImport.RowCount > 0)
            {
                int idGen = (int)gvImport.GetRowCellValue(gvImport.FocusedRowHandle, "id");
                lsImport.Where(x => x.id == idGen).ToList().ForEach(y => y.status = 2);
                gcImport.DataSource = null;
                gcImport.DataSource = lsImport.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            dbpieceExportReceive point = new dbpieceExportReceive()
            {
                id = -(lsReceive.Count),
                idEquipmentConfig = 1,
                status = 1,
                value = 0,
            };
            lsReceive.Add(point);
            gcReceive.DataSource = null;
            gcReceive.DataSource = lsReceive.Where(x => x.status == 1);
            gvReceive.MoveLast();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvReceive.RowCount > 0)
            {
                int idGen = (int)gvReceive.GetRowCellValue(gvReceive.FocusedRowHandle, "id");
                lsReceive.Where(x => x.id == idGen).ToList().ForEach(y => y.status = 2);
                gcReceive.DataSource = null;
                gcReceive.DataSource = lsImport.Where(x => x.status == 1);
            }
        }

        protected override void OnSave()
        {
            gvEquipment.FocusedRowHandle = -1;
            gvImport.FocusedRowHandle = -1;
            gvReceive.FocusedRowHandle = -1;
            gvPowRateByPromotion.FocusedRowHandle = -1;
            gvBaseGold.FocusedRowHandle = -1;
            gvStarUpConfig.FocusedRowHandle = -1;
            gvRateByPromotion.FocusedRowHandle = -1;

            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsImport)
            {
                if (item.id <= 0)
                {
                    dbPieceNeedToImport import = new dbPieceNeedToImport()
                    {
                        idEquipmentConfig = item.idEquipmentConfig,
                        status = item.status,
                        value = item.value
                    };
                    ConnectDB.Entities.dbPieceNeedToImports.Add(import);
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbPieceNeedToImports.Where(x => x.id == idGen).FirstOrDefault();
                    result.idEquipmentConfig = item.idEquipmentConfig;
                    result.status = item.status;
                    result.value = item.value;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsReceive)
            {
                if (item.id <= 0)
                {
                    dbpieceExportReceive import = new dbpieceExportReceive()
                    {
                        idEquipmentConfig = item.idEquipmentConfig,
                        status = item.status,
                        value = item.value
                    };
                    ConnectDB.Entities.dbpieceExportReceives.Add(import);
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbpieceExportReceives.Where(x => x.id == idGen).FirstOrDefault();
                    result.idEquipmentConfig = item.idEquipmentConfig;
                    result.status = item.status;
                    result.value = item.value;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsPowRateByPromotion)
            {
                if (item.id <= 0)
                {
                    dbPowRateByPromotion import = new dbPowRateByPromotion()
                    {
                        status = item.status,
                        powRateByPromotion = item.powRateByPromotion
                    };
                    ConnectDB.Entities.dbPowRateByPromotions.Add(import);
                }
                else
                {
                    int idGen = item.id;
                    var result = ConnectDB.Entities.dbPowRateByPromotions.Where(x => x.id == idGen).FirstOrDefault();
                    result.status = item.status;
                    result.powRateByPromotion = item.powRateByPromotion;
                }
                ConnectDB.Entities.SaveChanges();
            }

            foreach (var item in lsEquipStarUpConfig)
            {
                if (item.id <= 0)
                {
                    dbEquipStarUpConfig equip = new dbEquipStarUpConfig()
                    {
                        equipStockStar = item.equipStockStar,
                        promotion = item.promotion,
                        status = item.status,
                        idEquipmentConfig = item.idEquipmentConfig
                    };
                    ConnectDB.Entities.dbEquipStarUpConfigs.Add(equip);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsEquipStarUpDetail.Where(x => x.idStarUp == item.id))
                    {
                        dbEquipStarUpDetail detai = new dbEquipStarUpDetail()
                        {
                            idStarUp = equip.id,
                            status = item1.status,
                            value = item1.value
                        };
                        ConnectDB.Entities.dbEquipStarUpDetails.Add(detai);
                        ConnectDB.Entities.SaveChanges();
                    }
                }
                else
                {
                    var result = ConnectDB.Entities.dbEquipStarUpConfigs.Where(x => x.id == item.id).FirstOrDefault();
                    result.equipStockStar = item.equipStockStar;
                    result.promotion = item.promotion;
                    result.status = item.status;
                    result.idEquipmentConfig = item.idEquipmentConfig;

                    foreach (var item1 in lsEquipStarUpDetail.Where(x => x.idStarUp == item.id))
                    {
                        if (item1.id <= 0)
                        {
                            dbEquipStarUpDetail detai = new dbEquipStarUpDetail()
                            {
                                idStarUp = item.id,
                                status = item1.status,
                                value = item1.value
                            };
                            ConnectDB.Entities.dbEquipStarUpDetails.Add(detai);
                        }
                        else
                        {
                            var result1 = ConnectDB.Entities.dbEquipStarUpDetails.Where(x => x.id == item1.id).FirstOrDefault();
                            result1.idStarUp = item.id;
                            result1.status = item1.status;
                            result1.value = item1.value;
                        }
                        ConnectDB.Entities.SaveChanges();
                    }
                }
            }

            LoadDataToList();
            LoadDataToGC();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            dbPowRateByPromotion point = new dbPowRateByPromotion()
            {
                id = -(lsPowRateByPromotion.Count),
                status = 1,
                powRateByPromotion = 0
            };
            lsPowRateByPromotion.Add(point);
            gcPowRateByPromotion.DataSource = null;
            gcPowRateByPromotion.DataSource = lsPowRateByPromotion.Where(x => x.status == 1);
            gvPowRateByPromotion.MoveLast();
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            if (gvPowRateByPromotion.RowCount > 0)
            {
                int idGen = (int)gvPowRateByPromotion.GetRowCellValue(gvPowRateByPromotion.FocusedRowHandle, "id");
                lsPowRateByPromotion.Where(x => x.id == idGen).ToList().ForEach(y => y.status = 2);
                gcPowRateByPromotion.DataSource = null;
                gcPowRateByPromotion.DataSource = lsPowRateByPromotion.Where(x => x.status == 1);
            }
        }

        private void btnAdd4_Click(object sender, EventArgs e)
        {
            dbEquipStarUpConfig equip = new dbEquipStarUpConfig()
            {
                id = -(lsEquipStarUpConfig.Count),
                equipStockStar = 1,
                promotion = 1,
                status = 1,
                idEquipmentConfig = 1
            };
            lsEquipStarUpConfig.Add(equip);
            gcStarUpConfig.DataSource = null;
            gcStarUpConfig.DataSource = lsEquipStarUpConfig.Where(x => x.status == 1);
            gvStarUpConfig.MoveLast();
        }

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            if (gvStarUpConfig.RowCount > 0)
            {
                int idGen = (int)gvStarUpConfig.GetRowCellValue(gvStarUpConfig.FocusedRowHandle, "id");
                lsEquipStarUpConfig.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcStarUpConfig.DataSource = null;
                gcStarUpConfig.DataSource = lsEquipStarUpConfig.Where(x => x.status == 1);
            }
        }

        private void btnAdd5_Click(object sender, EventArgs e)
        {
            if (gvStarUpConfig.RowCount > 0)
            {
                int idGen = (int)gvStarUpConfig.GetRowCellValue(gvStarUpConfig.FocusedRowHandle, "id");
                dbEquipStarUpDetail equip = new dbEquipStarUpDetail()
                {
                    id = -(lsEquipStarUpDetail.Count),
                    idStarUp = idGen,
                    status = 1,
                    value = 0
                };
                lsEquipStarUpDetail.Add(equip);
                gcRateByPromotion.DataSource = null;
                gcRateByPromotion.DataSource = lsEquipStarUpDetail.Where(x => x.status == 1 && x.idStarUp == idGen);
                gvRateByPromotion.MoveLast();
            }
        }

        private void btnDelete5_Click(object sender, EventArgs e)
        {
            if (gvStarUpConfig.RowCount > 0)
            {
                int idGen = (int)gvStarUpConfig.GetRowCellValue(gvStarUpConfig.FocusedRowHandle, "id");
                int idDetail = (int)gvRateByPromotion.GetRowCellValue(gvRateByPromotion.FocusedRowHandle, "id");
                lsEquipStarUpDetail.Where(x => x.id == idDetail).ToList().ForEach(x => x.status = 2);
                gcRateByPromotion.DataSource = null;
                gcRateByPromotion.DataSource = lsEquipStarUpDetail.Where(x => x.status == 1 && x.idStarUp == idGen);
            }
        }

        private void gvStarUpConfig_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvStarUpConfig.RowCount > 0)
            {
                int idGen = (int)gvStarUpConfig.GetRowCellValue(gvStarUpConfig.FocusedRowHandle, "id");
                gcRateByPromotion.DataSource = null;
                gcRateByPromotion.DataSource = lsEquipStarUpDetail.Where(x => x.status == 1 && x.idStarUp == idGen);
            }
        }
    }
}
