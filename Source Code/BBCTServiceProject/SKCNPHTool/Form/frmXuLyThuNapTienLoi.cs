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
using KDQHNPHTool.Common;
using MongoDBModel.MainDatabaseModels;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model;
using DynamicDBModel.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmXuLyThuNapTienLoi : DevExpress.XtraEditors.XtraForm
    {
        ListServer server = new ListServer();

        public frmXuLyThuNapTienLoi()
        {
            InitializeComponent();
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            if (dteFromDate.Text != "" && dteToDate.Text != "")
            {
                CommonShowDialog.ShowWaitForm();
                DateTime fromDate = DateTime.Parse(dteFromDate.EditValue.ToString());
                DateTime toDate = DateTime.Parse(dteToDate.EditValue.ToString());

                List<MTransaction> listTransaction = MongoController.UserTransaction.GetListData(MongoController.DatabaseManager.main_database, a => a.created_at >= fromDate && a.created_at <= toDate && a.status == MongoDBModel.Enum.TransactionStatus.Done);

                foreach (var item in listTransaction)
                {
                    string idTrans = item._id.ToString();
                    List<MUserMail> listMail = MongoController.UserMail.GetListData(server.GetConnectSubDB(item.server_id), a => a.username == item.username && a.trans_id == idTrans);

                    if (listMail.Count <= 0)
                    {
                        MUserMail mail = new MUserMail()
                        {
                            username = item.username,
                            content = "Chúc mừng bạn đã nạp thẻ thành công và nhận được " + item.ruby + " kim cương",
                            title = "Thư nhận kim cương",
                            readed = false,
                            server_id = item.server_id,
                            trans_id = idTrans,
                            type = MongoDBModel.Enum.UserMailType.DenBuNapThe,
                            rewards = HandlerReward((int)item.ruby)
                        };
                        MongoController.UserMail.Create(server.GetConnectSubDB(item.server_id), mail);
                    }
                }

                CommonShowDialog.CloseWaitForm();
                CommonShowDialog.ShowSuccessfulDialog("Gửi thư thành công!");
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Phải nhập ngày bắt đầu và ngày kết thúc trước khi xử lý!");
            }
        }

        private List<SubRewardItem> HandlerReward(int ruby)
        {
            List<SubRewardItem> tmpLsReward = new List<SubRewardItem>();
            SubRewardItem it = new SubRewardItem()
            {
                type_reward = 7,
                static_id = 0,
                quantity = ruby
            };
            tmpLsReward.Add(it);
            return tmpLsReward;
        }
    }
}