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
using KDQHNPHTool.FormBase;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Model_View;
using MongoDB.Bson;
using KDQHNPHTool.Common;

namespace KDQHNPHTool.UserController
{
    public partial class ucBangHoi : ucManager
    {
        ListServer server = new ListServer();
        List<vGuild> lsGuild = new List<vGuild>();
        List<vGuildMember> lsGuildMember = new List<vGuildMember>();

        public ucBangHoi()
        {
            InitializeComponent();
            btnChiTiet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLamMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnTaoMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";
        }

        private void LoadDataToList(string idServer)
        {
            lsGuild.Clear();
            lsGuildMember.Clear();
            var tmpBangHoi = MongoController.Guild.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer).OrderByDescending(x => x.level);
            var tmpBangHoiMember = MongoController.GuildMember.GetListData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);

            foreach (var item in tmpBangHoi)
            {
                vGuild guild = new vGuild()
                {
                    _id = item._id.ToString(),
                    contribution = item.contribution,
                    level = item.level,
                    name = item.name,
                    notice = item.notice,
                    server_id = item.server_id,
                    username = item.username
                };
                lsGuild.Add(guild);

                foreach (var item1 in tmpBangHoiMember)
                {
                    if (item1.guild_id.ToString() == item._id.ToString())
                    {
                        vGuildMember member = new vGuildMember()
                        {
                            _id = item1._id.ToString(),
                            contribution = item1.contribution,
                            guild_id = item1.guild_id.ToString(),
                            server_id = item1.server_id,
                            username = item1.username
                        };
                        lsGuildMember.Add(member);
                    }
                }
            }
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                string idServer = lueChonServer.EditValue.ToString();
                LoadDataToList(idServer);
                gcBang.DataSource = lsGuild;
            }
        }

        private void gvBang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvBang.RowCount > 0)
            {
                string idGuild = (string)gvBang.GetRowCellValue(gvBang.FocusedRowHandle, "_id");
                gcMember.DataSource = lsGuildMember.Where(x => x.guild_id == idGuild);
            }
        }

        protected override void OnSave()
        {
            gvBang.FocusedRowHandle = -1;
            gvMember.FocusedRowHandle = -1;
            string idServer = lueChonServer.EditValue.ToString();
            foreach (var item in lsGuild)
            {
                MGuild guild = new MGuild()
                {
                    _id = ObjectId.Parse(item._id),
                    contribution = item.contribution,
                    level = item.level,
                    name = item.name,
                    notice = item.notice,
                    server_id = item.server_id,
                    username = item.username
                };
                MongoController.Guild.Update(server.GetConnectSubDB(idServer), guild);
            }

            foreach (var item in lsGuildMember)
            {
                MGuildMember member = new MGuildMember()
                {
                    _id = ObjectId.Parse(item._id),
                    contribution = item.contribution,
                    guild_id = ObjectId.Parse(item.guild_id),
                    server_id = item.server_id,
                    username = item.username
                };
                MongoController.GuildMember.Update(server.GetConnectSubDB(idServer), member);
            }

            CommonShowDialog.ShowSuccessfulDialog("Lưu  thành công!");
        }
    }
}
