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
using KDQHNPHTool.Model;
using KDQHNPHTool.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Common;
using DynamicDBModel.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmGuiThuHeThong : frmFormChange
    {
        List<vReward> lsReward = new List<vReward>();
        List<SubRewardItem> lsRewardSaveDB = new List<SubRewardItem>();
        ListServer server = new ListServer();
        List<vCharacterSelection> lsCharacterSelection = new List<vCharacterSelection>();
        ListReward reward = new ListReward();

        public frmGuiThuHeThong()
        {
            InitializeComponent();
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLue();
            lbChonNguoiChoi.Text = "Chưa chọn môn phái nào";
        }

        private void LoadDataToLue()
        {
            lueTypeReward.DataSource = reward.LoadTypeReward();
            lueReward.DataSource = reward.LoadTotalReward();

            lueServer.Properties.DataSource = server.GetListServer();
            lueServer.Properties.DisplayMember = "value";
            lueServer.Properties.ValueMember = "id";
            lueServer.EditValue = 0;
        }

        private void btnAddReward_Click(object sender, EventArgs e)
        {
            vReward re = new vReward()
            {
                idFake = lsReward.Count + 1,
                type_reward = 2,
                static_id = 1,
                quantity = 1,
                status = 1
            };
            lsReward.Add(re);
            gcReward.DataSource = null;
            gcReward.DataSource = lsReward.Where(x => x.status == 1);
            gvReward.MoveLast();
        }

        private void btnDeleteReward_Click(object sender, EventArgs e)
        {
            if (gvReward.RowCount > 0)
            {
                int idFake = (int)gvReward.GetRowCellValue(gvReward.FocusedRowHandle, "idFake");
                lsReward.Where(x => x.idFake == idFake).ToList().ForEach(y => y.status = 2);
                gcReward.DataSource = null;
                gcReward.DataSource = lsReward.Where(x => x.status == 1);
            }
        }

        private void gvReward_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueServer.EditValue.ToString();
            if (idServer != "")
            {
                vReward rewardSelect = (vReward)gvReward.GetRow(gvReward.FocusedRowHandle);
                frmEditReward formTask = new frmEditReward(rewardSelect, 1, idServer);
                formTask.ShowDialog();
            }
        }

        private void btnChonNguoiChoi_Click(object sender, EventArgs e)
        {
            frmCharacterSelection frm = new frmCharacterSelection(lsCharacterSelection);
            frm.ShowDialog();

            int countChoose = lsCharacterSelection.Where(x => x.choose == true).Count();
            if (countChoose > 0)
            {
                lbChonNguoiChoi.Text = "Đã chọn " + countChoose + " người chơi";
            }
            else
            {
                lbChonNguoiChoi.Text = "Chưa chọn môn phái nào";
            }
        }

        private void ckeNguoiChoi_CheckedChanged(object sender, EventArgs e)
        {
            if (ckeNguoiChoi.Checked)
            {
                lbChonNguoiChoi.Text = "Đã chọn tất cả người chơi";
                btnChonNguoiChoi.Enabled = false;
            }
            else
            {
                btnChonNguoiChoi.Enabled = true;
                lbChonNguoiChoi.Text = "Hãy chọn lại";
            }
        }

        private void ckeServer_CheckedChanged(object sender, EventArgs e)
        {
            if (ckeServer.Checked)
            {
                lbChonNguoiChoi.Text = "Gửi thư đến tất cả các server";
                btnChonNguoiChoi.Enabled = false;
                ckeNguoiChoi.Enabled = false;
                lueServer.Enabled = false;
            }
            else
            {
                btnChonNguoiChoi.Enabled = true;
                ckeNguoiChoi.Enabled = true;
                lueServer.Enabled = true;
                lbChonNguoiChoi.Text = "Đã chọn tất cả người chơi";
            }
        }

        protected override void OnSendMail()
        {
            if (txtTieuDe.Text != "" && txtNoiDung.Text != "")
            {
                CommonShowDialog.ShowWaitForm();
                ReturnReward();
                List<MUserMail> lsMailSaveDB = new List<MUserMail>();

                if (ckeServer.Checked)
                {
                    foreach (var item in server.GetListServer())
                    {
                        List<MUserInfo> listUserInfos = MongoController.UserInfo.GetListData(server.GetConnectSubDB(item.id), a => a.server_id == item.id && a.isBot == false);
                        foreach (var item1 in listUserInfos)
                        {
                            MUserMail mail = new MUserMail()
                            {
                                username = item1.username,
                                content = txtNoiDung.Text,
                                title = txtTieuDe.Text,
                                readed = false,
                                server_id = item.id,
                                type = MongoDBModel.Enum.UserMailType.Normal,
                                rewards = lsRewardSaveDB
                            };
                            lsMailSaveDB.Add(mail);
                        }
                        MongoController.UserMail.CreateAll(server.GetConnectSubDB(item.id), lsMailSaveDB);
                        lsReward.Clear();
                        lsRewardSaveDB.Clear();
                        gcReward.DataSource = null;
                        CommonShowDialog.CloseWaitForm();
                        CommonShowDialog.ShowSuccessfulDialog("Gửi thư thành công!");
                    }
                }
                else
                {
                    string idServer = lueServer.EditValue.ToString();
                    if (ckeNguoiChoi.Checked)
                    {
                        List<MUserInfo> listUserInfos = MongoController.UserInfo.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer && a.isBot == false);
                        foreach (var item1 in listUserInfos)
                        {
                            MUserMail mail = new MUserMail()
                            {
                                username = item1.username,
                                content = txtNoiDung.Text,
                                title = txtTieuDe.Text,
                                readed = false,
                                server_id = idServer,
                                type = MongoDBModel.Enum.UserMailType.Normal,
                                rewards = lsRewardSaveDB
                            };
                            lsMailSaveDB.Add(mail);
                        }
                        MongoController.UserMail.CreateAll(server.GetConnectSubDB(idServer), lsMailSaveDB);
                        lsReward.Clear();
                        lsRewardSaveDB.Clear();
                        gcReward.DataSource = null;
                        CommonShowDialog.CloseWaitForm();
                        CommonShowDialog.ShowSuccessfulDialog("Gửi thư thành công!");
                    }
                    else
                    {
                        if (lsCharacterSelection.Where(x => x.choose == true).Count() > 0)
                        {
                            List<MUserInfo> listUserInfos = MongoController.UserInfo.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer && a.isBot == false);
                            foreach (var item1 in listUserInfos)
                            {
                                foreach (var item2 in lsCharacterSelection)
                                {
                                    if (item2.username == item1.username && item2.choose == true)
                                    {
                                        MUserMail mail = new MUserMail()
                                        {
                                            username = item1.username,
                                            content = txtNoiDung.Text,
                                            title = txtTieuDe.Text,
                                            readed = false,
                                            server_id = idServer,
                                            type = MongoDBModel.Enum.UserMailType.Normal,
                                            rewards = lsRewardSaveDB
                                        };
                                        lsMailSaveDB.Add(mail);
                                    }
                                }
                            }
                            MongoController.UserMail.CreateAll(server.GetConnectSubDB(idServer), lsMailSaveDB);
                            lsReward.Clear();
                            lsRewardSaveDB.Clear();
                            gcReward.DataSource = null;
                            CommonShowDialog.CloseWaitForm();
                            CommonShowDialog.ShowSuccessfulDialog("Gửi thư thành công!");

                        }
                        else
                        {
                            CommonShowDialog.CloseWaitForm();
                            CommonShowDialog.ShowErrorDialog("Phải chọn ít nhất 1 người chơi để gửi thư");
                        }
                    }

                }
            }
            else
            {
                CommonShowDialog.CloseWaitForm();
                CommonShowDialog.ShowErrorDialog("Phải nhập tiêu đề và nội dung thư!");
            }
        }

        private List<SubRewardItem> ReturnReward()
        {
            lsRewardSaveDB.Clear();
            foreach (var item in lsReward)
            {
                if (item.status == 1)
                {
                    SubRewardItem re = new SubRewardItem()
                    {
                        type_reward = item.type_reward - 1,
                        quantity = item.quantity,
                        static_id = reward.HandlerSaveStaticID(item.type_reward, (int)item.static_id),
                        ruong_bau_id = item.idRuong
                    };
                    lsRewardSaveDB.Add(re);
                }
            }
            return lsRewardSaveDB;
        }

        private void lueServer_EditValueChanged(object sender, EventArgs e)
        {
            lsCharacterSelection.Clear();
            string idServer = lueServer.EditValue.ToString();
            if (idServer != "" && idServer != "0")
            {
                CommonShowDialog.ShowWaitForm();
                List<MUserInfo> listUserInfos = MongoController.UserInfo.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer && a.isBot == false);
                foreach (var item in listUserInfos)
                {
                    vCharacterSelection cs = new vCharacterSelection()
                    {
                        username = item.username,
                        nickname = item.nickname,
                        choose = false
                    };
                    lsCharacterSelection.Add(cs);
                }
                CommonShowDialog.CloseWaitForm();
            }
        }
    }
}