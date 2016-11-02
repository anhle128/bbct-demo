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
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Common;
using MongoDBModel.MainDatabaseModels;

namespace KDQHNPHTool.Form
{
    public partial class frmTaoGiftCode : frmFormChange
    {
        List<MGiftCode> lsGiftCode = new List<MGiftCode>();
        public frmTaoGiftCode()
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
        }

        private void LoadDataToLUE()
        {
            List<vGiftCode> lsTmp = new List<vGiftCode>();
            var tmpSk = MongoController.GiftCodeCategory.GetListData(MongoController.DatabaseManager.main_database, a => true);
            if (tmpSk.Count > 0)
            {
                foreach (var item in tmpSk)
                {
                    vGiftCode gift = new vGiftCode()
                    {
                        category = item._id.ToString(),
                        code = item.name
                    };
                    lsTmp.Add(gift);
                }
                lueChonServer.Properties.DataSource = lsTmp;
                lueChonServer.Properties.DisplayMember = "code";
                lueChonServer.Properties.ValueMember = "category";
                lueChonServer.EditValue = "0";
            }
        }

        protected override void OnSave()
        {
            lsGiftCode.Clear();
            if (lueChonServer.EditValue.ToString() != "0" && lueChonServer.EditValue.ToString() != null)
            {
                if (txtSoLuong.Text != "" && txtTienTo.Text != "")
                {
                    int tmp;
                    bool isCheckInt = int.TryParse(txtSoLuong.Text, out tmp);
                    if (txtTienTo.Text.Length == 3)
                    {
                        if (isCheckInt == true)
                        {
                            CommonShowDialog.ShowWaitForm();
                            var tmpGift = MongoController.GiftCode.GetListData(MongoController.DatabaseManager.main_database, a => a.code.Contains(txtTienTo.Text));

                            if (tmpGift.Count <= 0)
                            {
                                int quantity = int.Parse(txtSoLuong.Text);
                                string idLoai = lueChonServer.EditValue.ToString();

                                for (int i = 0; i < quantity; i++)
                                {
                                    lsGiftCode.Add(HandlerCreateGiftCode(idLoai, txtTienTo.Text));
                                }

                                if (lsGiftCode.Count > 0)
                                {
                                    MongoController.GiftCode.CreateAll(MongoController.DatabaseManager.main_database, lsGiftCode);
                                    CommonShowDialog.ShowSuccessfulDialog("Tạo " + txtSoLuong.Text + " Gift Code thành công!");
                                }
                            }
                            else
                            {
                                CommonShowDialog.ShowErrorDialog("Tiền tố đã tồn tại");
                            }
                        }
                        else
                        {
                            CommonShowDialog.ShowErrorDialog("Số lượng phải nhập số tự nhiên!");
                        }
                    }
                    else
                    {
                        CommonShowDialog.ShowErrorDialog("Tiền tố chỉ được có 3 ký tự!");
                    }
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("Textbox không được để trống!");
                }
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Phải chọn loại gift code!");
            }
            CommonShowDialog.CloseWaitForm();
        }

        private MGiftCode HandlerCreateGiftCode(string idLoai, string tiento)
        {
            string tmpCode = txtTienTo.Text + GenerateCode(6);

            if (lsGiftCode.Find(x => x.code == tmpCode) == null)
            {
                MGiftCode gift = new MGiftCode()
                {
                    category = idLoai,
                    code = tmpCode
                };

                return gift;
            }
            else
            {
                return HandlerCreateGiftCode(idLoai, tiento);
            }
        }

        private string GenerateCode(int lengthStringResult)
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            string stringRandom = BitConverter.ToInt64(buffer, 0).ToString();
            Random rnd = new Random();
            int startPosition = rnd.Next(0, stringRandom.Length - lengthStringResult);
            string resultCode = "";
            IEnumerable<char> ienumChar = stringRandom.Skip(startPosition).Take(lengthStringResult);
            foreach (var c in ienumChar)
            {
                resultCode = resultCode + c;
            }
            return resultCode;
        }
    }
}