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
using KDQHNPHTool.Model;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Common;

namespace KDQHNPHTool.UserController
{
    public partial class ucThongKeNapTien : DevExpress.XtraEditors.XtraUserControl
    {
        ListServer server = new ListServer();
        List<vChart1730> lsChart = new List<vChart1730>();
        public ucThongKeNapTien()
        {
            InitializeComponent();
            ckeXemTatCa.Checked = true;
            dteChonNgay.Enabled = false;
            dteDenNgay.Enabled = false;
            dteChonNgay.EditValue = DateTime.Today;
            dteDenNgay.EditValue = DateTime.Today.AddDays(1);
        }

        private void btnXemKetQua_Click(object sender, EventArgs e)
        {
            lsChart.Clear();
            double countSum = 0;
            if (ckeXemTatCa.Checked == true)
            {
                var tmpTrans = MongoController.UserTransaction.GetListData(MongoController.DatabaseManager.main_database, a => true);
                foreach (var item in server.GetListServer())
                {
                    double count = 0;
                    foreach (var item1 in tmpTrans.Where(x => x.server_id == item.id))
                    {
                        count += item1.money;
                    }

                    countSum += count;

                    vChart1730 chart = new vChart1730()
                    {
                        date = item.value,
                        value = (int)count
                    };
                    lsChart.Add(chart);
                }
                chartThongKe.DataSource = lsChart;
            }
            else
            {
                if (dteChonNgay.Text != "" && dteDenNgay.Text != "")
                {
                    DateTime chonNgay = DateTime.Parse(dteChonNgay.EditValue.ToString());
                    DateTime denNgay = DateTime.Parse(dteDenNgay.EditValue.ToString());
                    var tmpTrans = MongoController.UserTransaction.GetListData(MongoController.DatabaseManager.main_database, a => a.created_at >= chonNgay && a.created_at <= denNgay);
                    foreach (var item in server.GetListServer())
                    {
                        double count = 0;
                        foreach (var item1 in tmpTrans.Where(x => x.server_id == item.id))
                        {
                            count += item1.money;
                        }

                        countSum += count;

                        vChart1730 chart = new vChart1730()
                        {
                            date = item.value,
                            value = (int)count
                        };
                        lsChart.Add(chart);
                    }
                    chartThongKe.DataSource = lsChart;
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("Phải chọn ngày");
                }
            }

            lbTotal.Text = countSum.ToString("n0");
        }

        private void ckeXemTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (ckeXemTatCa.Checked == true)
            {
                dteChonNgay.Enabled = false;
                dteDenNgay.Enabled = false;
            }
            else
            {
                dteChonNgay.Enabled = true;
                dteDenNgay.Enabled = true;
            }
        }
    }
}
