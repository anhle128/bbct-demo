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
using KDQHNPHTool.Model;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Common;
using MongoDBModel.MainDatabaseModels;
using DynamicDBModel.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmGuiThuNapTien : frmFormChange
    {
        ListServer server = new ListServer();
        List<vCharacterSelection> lsCharacterSelection = new List<vCharacterSelection>();

        public frmGuiThuNapTien()
        {
            InitializeComponent();
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLue();
            lbThongBao.Text = "Chưa chọn môn phái nào";
            lueServer.EditValue = 0;
            lueLoaiNTraoBu.EditValue = 0;
        }

        private void LoadDataToLue()
        {
            lueServer.Properties.DataSource = server.GetListServer();
            lueServer.Properties.DisplayMember = "value";
            lueServer.Properties.ValueMember = "id";
            lueServer.EditValue = 0;

            List<dbCTAffliction> tmpAff = new List<dbCTAffliction>();
            dbCTAffliction aff = new dbCTAffliction()
            {
                id = 0,
                value = "Trao thưởng bù"
            };
            tmpAff.Add(aff);

            dbCTAffliction aff1 = new dbCTAffliction()
            {
                id = 1,
                value = "Nạp thẻ bù"
            };
            tmpAff.Add(aff1);
            lueLoaiNTraoBu.Properties.DataSource = tmpAff;
            lueLoaiNTraoBu.Properties.DisplayMember = "value";
            lueLoaiNTraoBu.Properties.ValueMember = "id";
        }

        private void btnChonNguoiChoi_Click(object sender, EventArgs e)
        {
            frmCharacterSelection frm = new frmCharacterSelection(lsCharacterSelection);
            frm.ShowDialog();

            int countChoose = lsCharacterSelection.Where(x => x.choose == true).Count();
            if (countChoose > 0)
            {
                lbThongBao.Text = "Đã chọn " + countChoose + " người chơi";
            }
            else
            {
                lbThongBao.Text = "Chưa chọn người chơi nào";
            }
        }

        protected override void OnSendMail()
        {
            if (txtKNB.Text != "")
            {
                CommonShowDialog.ShowWaitForm();
                string idServer = lueServer.EditValue.ToString();
                List<MUserMail> lsMailSaveDB = new List<MUserMail>();
                if (lsCharacterSelection.Where(x => x.choose == true).Count() > 0)
                {
                    List<MUserInfo> listUserInfos = MongoController.UserInfo.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer && a.isBot == false);
                    foreach (var item1 in listUserInfos)
                    {
                        foreach (var item2 in lsCharacterSelection)
                        {
                            if (item2.username == item1.username && item2.choose == true)
                            {
                                if (int.Parse(lueLoaiNTraoBu.EditValue.ToString()) == 0)
                                {
                                    MUserMail mail = new MUserMail()
                                    {
                                        username = item1.username,
                                        content = "Thưởng nạp thẻ",
                                        title = "Thưởng nạp thẻ",
                                        readed = false,
                                        server_id = item1.server_id,
                                        trans_id = null,
                                        type = MongoDBModel.Enum.UserMailType.ThuongNapThe,
                                        rewards = HandlerReward()
                                    };
                                    lsMailSaveDB.Add(mail);
                                }
                                else
                                {
                                    MUserMail mail = new MUserMail()
                                    {
                                        username = item1.username,
                                        content = "Chúc mừng bạn đã nạp thẻ thành công và nhận được " + txtKNB.Text + " kim cương",
                                        title = "Thư nhận kim cương",
                                        readed = false,
                                        server_id = item1.server_id,
                                        trans_id = HandlerTranID(int.Parse(txtKNB.Text), item1.server_id, item1.username),
                                        type = MongoDBModel.Enum.UserMailType.DenBuNapThe,
                                        rewards = HandlerReward()
                                    };
                                    lsMailSaveDB.Add(mail);
                                }
                            }
                        }
                    }

                    MMongoConnection mongo = server.GetConnectSubDB(idServer);
                    if (MongoController.UserMail != null)
                    {
                        MongoController.UserMail.CreateAll(mongo, lsMailSaveDB);
                        CommonShowDialog.CloseWaitForm();
                        CommonShowDialog.ShowSuccessfulDialog("Gửi thư thành công!");
                    }
                }
            }
            else
            {
                CommonShowDialog.CloseWaitForm();
                CommonShowDialog.ShowErrorDialog("Phải nhập số KNB!");
            }
        }

        private string HandlerTranID(int ruby, string idServer, string username)
        {
            MTransaction trans = new MTransaction()
            {
                money = 1000 * ruby,
                ruby = ruby,
                server_id = idServer,
                username = username,
                type = MongoDBModel.Enum.TransactionType.scratch_card,
                status = MongoDBModel.Enum.TransactionStatus.Done
            };
            MongoController.UserTransaction.Create(MongoController.DatabaseManager.main_database, trans);

            return trans._id.ToString();
        }

        private List<SubRewardItem> HandlerReward()
        {
            List<SubRewardItem> tmpLsReward = new List<SubRewardItem>();
            SubRewardItem it = new SubRewardItem()
            {
                type_reward = 7,
                static_id = 0,
                quantity = int.Parse(txtKNB.Text)
            };
            tmpLsReward.Add(it);
            return tmpLsReward;
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