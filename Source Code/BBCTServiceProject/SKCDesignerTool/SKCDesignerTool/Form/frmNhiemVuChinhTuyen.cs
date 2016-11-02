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
using BBCTDesignerTool.FormBase;
using BBCTDesignerTool.Models;
using BBCTDesignerTool.Common;

namespace BBCTDesignerTool.Form
{
    public partial class frmNhiemVuChinhTuyen : frmFormChange
    {
        ListReward rewardHandler = new ListReward();
        List<dbNhiemVuChinhTuyen> lsNhiemVu = new List<dbNhiemVuChinhTuyen>();
        List<dbNhiemVuChinhTuyenReward> lsReward = new List<dbNhiemVuChinhTuyenReward>();

        public frmNhiemVuChinhTuyen()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
        }

        private void LoadDataToLUE()
        {
            var tmpType = from tmp in ConnectDB.Entities.dbCTTypeRewards
                          select tmp;

            lueTypeReward.DataSource = tmpType.ToList();

            var tmpLoai = from tmp in ConnectDB.Entities.dbCTTypeNhiemVuChinhTuyens
                          select tmp;
            lueTypeNhiemVu.DataSource = tmpLoai.ToList();
            lueStaticID.DataSource = rewardHandler.LoadTotalReward();
        }

        private void LoadDataToList()
        {
            lsNhiemVu.Clear();
            lsReward.Clear();

            var tmpNhiemVu = from tmp in ConnectDB.Entities.dbNhiemVuChinhTuyens
                             where tmp.status == 1
                             select tmp;

            foreach (var item in tmpNhiemVu)
            {
                dbNhiemVuChinhTuyen nhiem = new dbNhiemVuChinhTuyen()
                {
                    des = item.des,
                    id = item.id,
                    idChinhTuyen = item.idChinhTuyen,
                    idNhiemVu = item.idNhiemVu,
                    name = item.name,
                    number = item.number,
                    numberRequire = item.numberRequire,
                    status = item.status,
                    stepUpNumber = item.stepUpNumber,
                    types = item.types
                };
                lsNhiemVu.Add(nhiem);

                var tmpReward = from tmp1 in ConnectDB.Entities.dbNhiemVuChinhTuyenRewards
                                where tmp1.status == 1 && tmp1.idNhiemVu == item.id
                                select tmp1;

                foreach (var item1 in tmpReward)
                {
                    dbNhiemVuChinhTuyenReward re = new dbNhiemVuChinhTuyenReward()
                    {
                        id = item1.id,
                        idNhiemVu = item1.idNhiemVu,
                        quantity = item1.quantity,
                        staticID = rewardHandler.HandlerLoadStaticID((int)item1.typeReward, (int)item1.staticID),
                        status = item1.status,
                        stepUpQuantity = item1.stepUpQuantity,
                        typeReward = item1.typeReward
                    };
                    lsReward.Add(re);
                }

            }
            gcNhiemVu.DataSource = null;
            gcReward.DataSource = null;
            gcNhiemVu.DataSource = lsNhiemVu.Where(x => x.status == 1);
        }

        private void gvNhiemVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvNhiemVu.RowCount > 0)
            {
                int idNhiemVu = (int)gvNhiemVu.GetRowCellValue(gvNhiemVu.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idNhiemVu == idNhiemVu);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbNhiemVuChinhTuyen nhiem = new dbNhiemVuChinhTuyen()
            {
                des = "mô tả",
                id = -(lsNhiemVu.Count),
                idChinhTuyen = 1,
                idNhiemVu = lsNhiemVu.Count + 1,
                name = "tên nhiệm vụ",
                number = 0,
                numberRequire = 0,
                status = 1,
                stepUpNumber = 0,
                types = 0
            };
            lsNhiemVu.Add(nhiem);
            gcNhiemVu.DataSource = null;
            gcNhiemVu.DataSource = lsNhiemVu.Where(x => x.status == 1);
            gvNhiemVu.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvNhiemVu.RowCount > 0)
            {
                int idNhiem = (int)gvNhiemVu.GetRowCellValue(gvNhiemVu.FocusedRowHandle, "id");
                lsNhiemVu.Where(x => x.id == idNhiem).ToList().ForEach(x => x.status = 2);
                gcNhiemVu.DataSource = null;
                gcNhiemVu.DataSource = lsNhiemVu.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvNhiemVu.RowCount > 0)
            {
                int idNhiem = (int)gvNhiemVu.GetRowCellValue(gvNhiemVu.FocusedRowHandle, "id");
                dbNhiemVuChinhTuyenReward nhiem = new dbNhiemVuChinhTuyenReward()
                {
                    id = -(lsReward.Count),
                    idNhiemVu = idNhiem,
                    quantity = 0,
                    staticID = 1,
                    status = 1,
                    stepUpQuantity = 0,
                    typeReward = 2
                };
                lsReward.Add(nhiem);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idNhiemVu == idNhiem);
                gvReward.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idNhiem = (int)gvNhiemVu.GetRowCellValue(gvNhiemVu.FocusedRowHandle, "id");
                int idReward = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");
                lsReward.Where(x => x.id == idReward).ToList().ForEach(x => x.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1 && x.idNhiemVu == idNhiem);
            }
        }

        protected override void OnSave()
        {
            gvNhiemVu.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;
            CommonShowDialog.ShowWaitForm();
            foreach (var item in lsNhiemVu)
            {
                if (item.id <= 0)
                {
                    dbNhiemVuChinhTuyen nhiem = new dbNhiemVuChinhTuyen()
                    {
                        des = item.des,
                        idChinhTuyen = item.idChinhTuyen,
                        idNhiemVu = item.idNhiemVu,
                        name = item.name,
                        number = item.number,
                        numberRequire = item.numberRequire,
                        status = item.status,
                        stepUpNumber = item.stepUpNumber,
                        types = item.types
                    };
                    ConnectDB.Entities.dbNhiemVuChinhTuyens.Add(nhiem);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsReward.Where(x => x.idNhiemVu == item.id))
                    {
                        dbNhiemVuChinhTuyenReward re = new dbNhiemVuChinhTuyenReward()
                        {
                            idNhiemVu = nhiem.id,
                            quantity = item1.quantity,
                            staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                            status = item1.status,
                            stepUpQuantity = item1.stepUpQuantity,
                            typeReward = item1.typeReward
                        };
                        ConnectDB.Entities.dbNhiemVuChinhTuyenRewards.Add(re);
                        ConnectDB.Entities.SaveChanges();
                    }
                }
                else
                {
                    var result = ConnectDB.Entities.dbNhiemVuChinhTuyens.Where(x => x.id == item.id).FirstOrDefault();
                    result.des = item.des;
                    result.idChinhTuyen = item.idChinhTuyen;
                    result.idNhiemVu = item.idNhiemVu;
                    result.name = item.name;
                    result.number = item.number;
                    result.numberRequire = item.numberRequire;
                    result.status = item.status;
                    result.stepUpNumber = item.stepUpNumber;
                    result.types = item.types;

                    foreach (var item1 in lsReward.Where(x => x.idNhiemVu == item.id))
                    {
                        if (item1.id <= 0)
                        {
                            dbNhiemVuChinhTuyenReward re = new dbNhiemVuChinhTuyenReward()
                            {
                                idNhiemVu = item.id,
                                quantity = item1.quantity,
                                staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                status = item1.status,
                                stepUpQuantity = item1.stepUpQuantity,
                                typeReward = item1.typeReward
                            };
                            ConnectDB.Entities.dbNhiemVuChinhTuyenRewards.Add(re);
                        }
                        else
                        {
                            var result1 = ConnectDB.Entities.dbNhiemVuChinhTuyenRewards.Where(x => x.id == item1.id).FirstOrDefault();
                            result1.idNhiemVu = item.id;
                            result1.quantity = item1.quantity;
                            result1.staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID);
                            result1.status = item1.status;
                            result1.stepUpQuantity = item1.stepUpQuantity;
                            result1.typeReward = item1.typeReward;
                        }
                        ConnectDB.Entities.SaveChanges();
                    }
                }
            }

            LoadDataToList();
            CommonShowDialog.CloseWaitForm();
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbNhiemVuChinhTuyenReward rewardSelect = (dbNhiemVuChinhTuyenReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditRewardCT formTask = new frmEditRewardCT(rewardSelect);
            formTask.ShowDialog();
        }
    }
}