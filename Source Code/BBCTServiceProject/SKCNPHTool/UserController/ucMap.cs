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
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using KDQHNPHTool.Model;
using KDQHNPHTool.Models;
using KDQHNPHTool.Common;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model_View;

namespace KDQHNPHTool.UserController
{
    public partial class ucMap : DevExpress.XtraEditors.XtraUserControl
    {
        ListServer server = new ListServer();
        List<vUserBook> lsTmpMap = new List<vUserBook>();
        List<vChartPCUInTime> lsNameMap = new List<vChartPCUInTime>();
        public ucMap()
        {
            InitializeComponent();
            LoadDataToLUE();
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";

            var tmpMap = from tmp in ConnectDB.Entities.dbMaps
                         where tmp.status == 1
                         orderby tmp.id ascending
                         select new
                         {
                             tmp.id,
                             tmp.name
                         };


            var tmpStage = from tmp in ConnectDB.Entities.dbMapStages
                           where tmp.status == 1
                           orderby tmp.id ascending
                           select new
                           {
                               tmp.id,
                               tmp.idMap,
                               tmp.name
                           };

            List<dbCTAffliction> lsAff = new List<dbCTAffliction>();
            int countID = 0;
            foreach (var item in tmpMap)
            {
                dbCTAffliction aff = new dbCTAffliction()
                {
                    id = countID++,
                    value = item.name
                };
                lsAff.Add(aff);

                int countIDStage = 0;
                foreach (var item1 in tmpStage)
                {
                    if (item1.idMap == item.id)
                    {
                        vChartPCUInTime chart = new vChartPCUInTime()
                        {
                            aven = countIDStage++,
                            date = item1.name,
                            value = countID - 1
                        };
                        lsNameMap.Add(chart);
                    }
                }
                countIDStage = 0;
            }

            lueChonMap.Properties.DataSource = lsAff;
            lueChonMap.Properties.DisplayMember = "value";
            lueChonMap.Properties.ValueMember = "id";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (.xlsx)|*.xlsx";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var printingSystem = new PrintingSystemBase();
                    var compositeLink = new CompositeLinkBase();
                    compositeLink.PrintingSystemBase = printingSystem;

                    var link1 = new PrintableComponentLinkBase();
                    link1.Component = chartMap;

                    compositeLink.Links.Add(link1);

                    var options = new XlsxExportOptions();
                    options.ExportMode = XlsxExportMode.SingleFilePageByPage;

                    compositeLink.CreatePageForEachLink();
                    compositeLink.ExportToXlsx(saveDialog.FileName, options);
                }
            }
        }

        private void btnXemKetQua_Click(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                string idServer = lueChonServer.EditValue.ToString();
                if (lueChonMap.EditValue.ToString() != "")
                {
                    int idMap = int.Parse(lueChonMap.EditValue.ToString());
                    LoadDataToList(idServer, idMap);

                    List<vChartPCUInTime> lsChartMap = new List<vChartPCUInTime>();

                    foreach (var item in lsNameMap.Where(x => x.value == idMap))
                    {
                        vChartPCUInTime chart = new vChartPCUInTime()
                        {
                            date = item.date,
                            aven = lsTmpMap.Where(x => x.staticID == 1 || x.staticID == 2 || x.staticID == 3 && x.star_level == item.aven).Count(),
                            value = lsTmpMap.Where(x => x.staticID == 0 && x.star_level == item.aven).Count(),
                        };
                        lsChartMap.Add(chart);
                    }

                    chartMap.DataSource = lsChartMap;
                }
                else
                {
                    CommonShowDialog.ShowErrorDialog("Phải chọn map");
                }
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Phải chọn server");
            }
        }

        private void LoadDataToList(string idServer, int idMap)
        {
            lsTmpMap.Clear();
            var tmpMap = MongoController.UserMap.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);

            foreach (var item in tmpMap.Where(x => x.stage_info.stage.map_index == idMap))
            {
                vUserBook user = new vUserBook()
                {
                    powerup_level = item.stage_info.stage.map_index,
                    star_level = item.stage_info.stage.stage_index,
                    staticID = item.stage_info.star
                };
                lsTmpMap.Add(user);
            }

        }
    }
}
