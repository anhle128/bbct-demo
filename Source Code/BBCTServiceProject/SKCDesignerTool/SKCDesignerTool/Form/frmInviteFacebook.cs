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
    public partial class frmInviteFacebook : frmFormChange
    {
        ListReward rewardHandler = new ListReward();
        List<dbInviteFriendConfig> lsMoc = new List<dbInviteFriendConfig>();
        List<dbInviteFriendReward> lsreward = new List<dbInviteFriendReward>();

        public frmInviteFacebook()
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            LoadDataToList();
            LoadDataToGC();
        }

        private void LoadDataToLUE()
        {
            var tmpType = from tmp in ConnectDB.Entities.dbCTTypeRewards
                          select tmp;

            lueTypeReward.DataSource = tmpType.ToList();
            lueVatPham.DataSource = rewardHandler.LoadTotalReward();
        }

        private void LoadDataToList()
        {
            lsMoc.Clear();
            lsreward.Clear();

            var tmpMoc = from tmp in ConnectDB.Entities.dbInviteFriendConfigs
                         where tmp.status == 1
                         select tmp;

            foreach (var item in tmpMoc)
            {
                dbInviteFriendConfig conf = new dbInviteFriendConfig()
                {
                    id = item.id,
                    require = item.require,
                    status = item.status
                };
                lsMoc.Add(conf);
            }

            var tmpReward = from tmp in ConnectDB.Entities.dbInviteFriendRewards
                            where tmp.status == 1
                            select tmp;

            foreach (var item in tmpReward)
            {
                dbInviteFriendReward conf = new dbInviteFriendReward()
                {
                    amountMax = item.amountMax,
                    amountMin = item.amountMin,
                    id = item.id,
                    idInvite = item.idInvite,
                    procs = item.procs,
                    staticID = rewardHandler.HandlerLoadStaticID((int)item.typeReward, (int)item.staticID),
                    status = item.status,
                    typeReward = item.typeReward
                };
                lsreward.Add(conf);
            }
        }

        private void LoadDataToGC()
        {
            gcMoc.DataSource = null;
            gcReward.DataSource = null;
            gcMoc.DataSource = lsMoc.Where(x => x.status == 1);
        }

        private void gvMoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvMoc.RowCount > 0)
            {
                int idGen = (int)gvMoc.GetRowCellValue(gvMoc.FocusedRowHandle, "id");
                gcReward.DataSource = null;
                gcReward.DataSource = lsreward.Where(x => x.status == 1 && x.idInvite == idGen);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            dbInviteFriendConfig conf = new dbInviteFriendConfig()
            {
                id = -(lsMoc.Count),
                require = 0,
                status = 1
            };
            lsMoc.Add(conf);
            gcMoc.DataSource = null;
            gcMoc.DataSource = lsMoc.Where(x => x.status == 1);
            gvMoc.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (gvMoc.RowCount > 0)
            {
                int idGen = (int)gvMoc.GetRowCellValue(gvMoc.FocusedRowHandle, "id");
                lsMoc.Where(x => x.id == idGen).ToList().ForEach(x => x.status = 2);
                gcMoc.DataSource = null;
                gcMoc.DataSource = lsMoc.Where(x => x.status == 1);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (gvMoc.RowCount > 0)
            {
                int idGen = (int)gvMoc.GetRowCellValue(gvMoc.FocusedRowHandle, "id");

                dbInviteFriendReward conf = new dbInviteFriendReward()
                {
                    amountMax = 0,
                    amountMin = 0,
                    id = -(lsreward.Count),
                    idInvite = idGen,
                    procs = 0,
                    staticID = 1,
                    status = 1,
                    typeReward = 2
                };
                lsreward.Add(conf);
                gcReward.DataSource = null;
                gcReward.DataSource = lsreward.Where(x => x.status == 1 && x.idInvite == idGen);
                gvReward.MoveLast();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idGen = (int)gvMoc.GetRowCellValue(gvMoc.FocusedRowHandle, "id");
                int idReward = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "id");

                lsreward.Where(x => x.id == idReward).ToList().ForEach(x => x.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsreward.Where(x => x.status == 1 && x.idInvite == idGen);
            }
        }

        protected override void OnSave()
        {
            CommonShowDialog.ShowWaitForm();
            gvMoc.FocusedRowHandle = -1;
            gvReward.FocusedRowHandle = -1;

            foreach (var item in lsMoc)
            {
                if (item.id <= 0)
                {
                    dbInviteFriendConfig conf = new dbInviteFriendConfig()
                    {
                        require = item.require,
                        status = item.status
                    };
                    ConnectDB.Entities.dbInviteFriendConfigs.Add(conf);
                    ConnectDB.Entities.SaveChanges();

                    foreach (var item1 in lsreward.Where(x => x.idInvite == item.id))
                    {
                        dbInviteFriendReward re = new dbInviteFriendReward()
                        {
                            amountMax = item1.amountMax,
                            amountMin = item1.amountMin,
                            idInvite = conf.id,
                            procs = item1.procs,
                            staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                            status = item1.status,
                            typeReward = item1.typeReward
                        };
                        ConnectDB.Entities.dbInviteFriendRewards.Add(re);
                        ConnectDB.Entities.SaveChanges();
                    }
                }
                else
                {
                    var result = ConnectDB.Entities.dbInviteFriendConfigs.Where(x => x.id == item.id).FirstOrDefault();
                    result.require = item.require;
                    result.status = item.status;

                    foreach (var item1 in lsreward.Where(x => x.idInvite == item.id))
                    {
                        if (item1.id <= 0)
                        {
                            dbInviteFriendReward re = new dbInviteFriendReward()
                            {
                                amountMax = item1.amountMax,
                                amountMin = item1.amountMin,
                                idInvite = item.id,
                                procs = item1.procs,
                                staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID),
                                status = item1.status,
                                typeReward = item1.typeReward
                            };
                            ConnectDB.Entities.dbInviteFriendRewards.Add(re);
                        }
                        else
                        {
                            var result1 = ConnectDB.Entities.dbInviteFriendRewards.Where(x => x.id == item1.id).FirstOrDefault();
                            result1.amountMax = item1.amountMax;
                            result1.amountMin = item1.amountMin;
                            result1.idInvite = item.id;
                            result1.procs = item1.procs;
                            result1.staticID = rewardHandler.HandlerSaveStaticID((int)item1.typeReward, (int)item1.staticID);
                            result1.status = item1.status;
                            result1.typeReward = item1.typeReward;
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

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            dbInviteFriendReward rewardSelect = (dbInviteFriendReward)gvReward.GetRow(gvReward.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, rewardSelect, null, null);
            formTask.ShowDialog();
        }
    }
}