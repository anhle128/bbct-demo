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
using KDQHNPHTool.Database.Controller;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Common;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Models;
using KDQHNPHTool.Model;
using MongoDBModel.MainDatabaseModels;

namespace KDQHNPHTool.Form
{
    public partial class frmChiTietTaiKhoan : frmFormChange
    {
        string username = "";
        string idServer;
        string nickname = "";
        List<vReward> lsReward = new List<vReward>();
        ListServer server = new ListServer();
        ListReward reward = new ListReward();

        public frmChiTietTaiKhoan(string server, string tmpUsername)
        {
            InitializeComponent();
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            username = tmpUsername;
            idServer = server;
            LoadDataCBBE();
            LoadDataToLue();
            LoadDataAcount();
            LoadDataCharacter();
            LoadDataCharacterSoul();
            LoadDataEquipment();
            LoadDataEquipmentPiece();
            LoadDataItem();
            LoadDataMail();
            LoadDataLogUseGold();
            LoadDataTransaction();
        }

        private void LoadDataCBBE()
        {
            List<dbCTOneorAll> lsString = new List<dbCTOneorAll>();
            dbCTOneorAll one = new dbCTOneorAll()
            {
                id = 0,
                value = "Có"
            };
            lsString.Add(one);

            dbCTOneorAll all = new dbCTOneorAll()
            {
                id = 1,
                value = "Không"
            };
            lsString.Add(all);
            lueTrangThai.Properties.DataSource = lsString;

            List<dbCTOneorAll> lsString1 = new List<dbCTOneorAll>();
            dbCTOneorAll one1 = new dbCTOneorAll()
            {
                id = 0,
                value = "Nhận KNB"
            };
            lsString1.Add(one1);

            dbCTOneorAll all1 = new dbCTOneorAll()
            {
                id = 1,
                value = "Tiêu KNB"
            };
            lsString1.Add(all1);
            lueTypeAction.DataSource = lsString1;

            List<dbCTOneorAll> lsString2 = new List<dbCTOneorAll>();
            var tmpString2 = from tmp in ConnectDB.Entities.dbCTReasonActionGoldLogs
                             select tmp;

            foreach (var item in tmpString2)
            {
                dbCTOneorAll conf = new dbCTOneorAll()
                {
                    id = item.id,
                    value = item.value
                };
                lsString2.Add(conf);
            }

            var tmpString3 = from tmp in ConnectDB.Entities.dbCTReasonSpentGoldLogs
                             select tmp;

            foreach (var item in tmpString3)
            {
                dbCTOneorAll conf = new dbCTOneorAll()
                {
                    id = lsString2.Count(),
                    value = item.value
                };
                lsString2.Add(conf);
            }

            lueReason.DataSource = lsString2;
        }

        private void LoadDataAcount()
        {
            var tmpUser = MongoController.UserInfo.GetSingleData(server.GetConnectSubDB(idServer), a => a.username == username && a.server_id == idServer);
            txtGold.Text = tmpUser.gold.ToString();
            txtLevel.Text = tmpUser.level.ToString();
            txtNickname.Text = tmpUser.nickname;
            txtSilver.Text = tmpUser.silver.ToString();
            txtUserName.Text = tmpUser.username;
            txtVip.Text = tmpUser.vip.ToString();
            txtStamina.Text = tmpUser.stamina.ToString();
            nickname = tmpUser.nickname;
            lueTrangThai.EditValue = HandlerTrangThai(tmpUser.isLocked);
        }

        private int HandlerTrangThai(bool isLock)
        {
            if (isLock == true)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private bool HandlerSaveTrangThai(int isLock)
        {
            if (isLock == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LoadDataCharacter()
        {
            List<MUserCharacter> tmpUserCharacter = MongoController.UserCharacter.GetListData(server.GetConnectSubDB(idServer), a => a.username == username && a.server_id == idServer);
            List<vUserCharacter> lsUserCharacter = new List<vUserCharacter>();

            foreach (var item in tmpUserCharacter)
            {
                vUserCharacter user = new vUserCharacter()
                {
                    appellation = item.appellation,
                    idCharacter = item.static_id,
                    level = item.level,
                    exp = item.exp,
                    promotion_level = item.promotion,
                    powerup_level = item.powerup_level,
                    star_level = item.star_level,
                    isMain = item.is_main
                };
                lsUserCharacter.Add(user);
            }

            gcNhanVat.DataSource = lsUserCharacter;
        }

        private void LoadDataCharacterSoul()
        {
            List<MUserCharacterSoul> tmpUserCharacter = MongoController.UserCharacterSoul.GetListData(server.GetConnectSubDB(idServer), a => a.username == username && a.server_id == idServer);
            List<vPiece> lsUserCharacter = new List<vPiece>();

            foreach (var item in tmpUserCharacter)
            {
                vPiece user = new vPiece()
                {
                    staticID = item.static_id,
                    quantity = item.quantity
                };
                lsUserCharacter.Add(user);
            }

            gcCharacterSoul.DataSource = lsUserCharacter;
        }

        private void LoadDataEquipment()
        {
            List<MUserEquip> tmpUserCharacter = MongoController.UserEquip.GetListData(server.GetConnectSubDB(idServer), a => a.username == username && a.server_id == idServer);
            List<vUserEquipment> lsUserCharacter = new List<vUserEquipment>();

            foreach (var item in tmpUserCharacter)
            {
                vUserEquipment user = new vUserEquipment()
                {
                    staicID = item.static_id,
                    star_level = item.star_level,
                    level = item.level,
                    promotion = item.promotion,
                    durability = item.durability
                };
                lsUserCharacter.Add(user);
            }

            gcEquipment.DataSource = lsUserCharacter;
        }

        private void LoadDataEquipmentPiece()
        {
            List<MUserEquipPiece> tmpUserCharacter = MongoController.UserEquipPiece.GetListData(server.GetConnectSubDB(idServer), a => a.username == username && a.server_id == idServer);
            List<vPiece> lsUserCharacter = new List<vPiece>();

            foreach (var item in tmpUserCharacter)
            {
                vPiece user = new vPiece()
                {
                    staticID = item.static_id,
                    quantity = item.quantity
                };
                lsUserCharacter.Add(user);
            }

            gcEquipPiece.DataSource = lsUserCharacter;
        }

        private void LoadDataItem()
        {
            List<MUserItem> tmpUserCharacter = MongoController.UserItem.GetListData(server.GetConnectSubDB(idServer), a => a.username == username && a.server_id == idServer);
            List<vPiece> lsUserCharacter = new List<vPiece>();

            foreach (var item in tmpUserCharacter)
            {
                vPiece user = new vPiece()
                {
                    staticID = item.static_id,
                    quantity = item.quantity
                };
                lsUserCharacter.Add(user);
            }

            gcItem.DataSource = lsUserCharacter;
        }

        private void LoadDataMail()
        {
            List<MUserMail> tmpUserCharacter = MongoController.UserMail.GetListData(server.GetConnectSubDB(idServer), a => a.username == username && a.server_id == idServer);
            List<vUserMail> lsUserCharacter = new List<vUserMail>();
            int count = 0;
            foreach (var item in tmpUserCharacter.OrderByDescending(x => x.created_at))
            {
                count++;
                vUserMail user = new vUserMail()
                {
                    typeMail = (int)item.type,
                    title = item.title,
                    content = item.content,
                    readed = item.readed,
                    idFake = count
                };

                if (item.rewards != null)
                {
                    foreach (var item1 in item.rewards)
                    {
                        vReward re = new vReward()
                        {
                            idFake = count,
                            quantity = item1.quantity,
                            static_id = reward.HandlerLoadStaticID((int)item1.type_reward + 1, (int)item1.static_id),
                            type_reward = item1.type_reward + 1
                        };
                        lsReward.Add(re);
                    }
                }

                lsUserCharacter.Add(user);
            }

            gcThu.DataSource = lsUserCharacter;
        }

        private void LoadDataLogUseGold()
        {
            List<MActionGoldLog> tmpUserCharacter = MongoController.UserActionGoldLog.GetListData(MongoController.DatabaseManager.main_database, a => a.username == username && a.server_id == idServer);
            List<vLogUseGold> lsUserCharacter = new List<vLogUseGold>();

            foreach (var item in tmpUserCharacter.OrderByDescending(x => x.created_at))
            {
                vLogUseGold user = new vLogUseGold()
                {
                    old_glod = item.old_glod,
                    new_gold = item.new_gold,
                    reward_glod = item.reward_glod,
                    reason = (int)item.reason,
                    type = (int)item.type,
                    timeUse = item.created_at
                };
                lsUserCharacter.Add(user);
            }
            gvLichSuTieuXu.Columns["reward_glod"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "reward_glod", "Tổng = {0:n0}");
            gcLichSuTieuXu.DataSource = lsUserCharacter;
        }

        private void LoadDataTransaction()
        {
            List<MTransaction> tmpUserCharacter = MongoController.UserTransaction.GetListData(MongoController.DatabaseManager.main_database, a => a.username == username && a.server_id == idServer);
            List<vUserTransaction> lsUserCharacter = new List<vUserTransaction>();

            foreach (var item in tmpUserCharacter.OrderByDescending(x => x.created_at))
            {
                vUserTransaction user = new vUserTransaction()
                {
                    type = (int)item.type,
                    time = item.created_at,
                    status = (int)item.status,
                    money = item.money
                };
                lsUserCharacter.Add(user);
            }

            gcLichSuNapTien.DataSource = lsUserCharacter;
        }

        private void LoadDataToLue()
        {
            var tmpChar = from tmp in ConnectDB.Entities.dbCharacters
                          where tmp.status == 1
                          orderby tmp.idCharacter ascending
                          select new
                          {
                              tmp.idCharacter,
                              tmp.name
                          };

            slueTenNhanVat.DataSource = tmpChar.ToList();
            lueTenNhanVatSoul.DataSource = tmpChar.ToList();

            //var tmpPromo = from tmp in ConnectDB.Entities.dbCTPromotionCharacters
            //               select tmp;

            //luePhamChat.DataSource = tmpPromo.ToList();
            //luePowerUpEquip.DataSource = tmpPromo.ToList();
            //luePowerUpNhanVat.DataSource = tmpPromo.ToList();

            var tmpEquip = from tmp in ConnectDB.Entities.dbEquipments
                           where tmp.status == 1
                           select new
                           {
                               tmp.idEquipment,
                               tmp.name
                           };

            lueEquipment.DataSource = tmpEquip.ToList();
            lueEquipmentPiece.DataSource = tmpEquip.ToList();

            var tmpItem = from tmp in ConnectDB.Entities.dbItems
                          where tmp.status == 1
                          select new
                          {
                              tmp.idItem,
                              tmp.name
                          };

            lueItem.DataSource = tmpItem.ToList();

            var tmpTypeReward = from tmp in ConnectDB.Entities.dbCTTypeRewards
                                select tmp;

            lueTypeReward.DataSource = tmpTypeReward.ToList();
            lueReward.DataSource = reward.LoadTotalReward();

            var tmpTypeUseGold = from tmp in ConnectDB.Entities.dbCTTypeUseGolds
                                 select tmp;

            lueTypeUseGold.DataSource = tmpTypeUseGold.ToList();

            List<dbCTOneorAll> lsLoaiTrans = new List<dbCTOneorAll>();
            dbCTOneorAll all = new dbCTOneorAll()
            {
                id = 1,
                value = "Scratch Card"
            };
            lsLoaiTrans.Add(all);
            dbCTOneorAll all1 = new dbCTOneorAll()
            {
                id = 10,
                value = "WCPAY"
            };
            lsLoaiTrans.Add(all1);
            dbCTOneorAll all2 = new dbCTOneorAll()
            {
                id = 20,
                value = "Google Play"
            };
            lsLoaiTrans.Add(all2);
            dbCTOneorAll all3 = new dbCTOneorAll()
            {
                id = 30,
                value = "Itune"
            };
            lsLoaiTrans.Add(all3);
            dbCTOneorAll all4 = new dbCTOneorAll()
            {
                id = 100,
                value = "Gift"
            };
            lsLoaiTrans.Add(all4);
            lueLoaiTransaction.DataSource = lsLoaiTrans;

            List<dbCTOneorAll> lsTrangThaiTrans = new List<dbCTOneorAll>();
            dbCTOneorAll all6 = new dbCTOneorAll()
            {
                id = 0,
                value = "Đang kiểm tra"
            };
            lsTrangThaiTrans.Add(all6);
            dbCTOneorAll all7 = new dbCTOneorAll()
            {
                id = 1,
                value = "Thành công"
            };
            lsTrangThaiTrans.Add(all7);
            lueTrangThaiTransaction.DataSource = lsTrangThaiTrans;

            List<dbCTOneorAll> lsLoaiThu = new List<dbCTOneorAll>();
            dbCTOneorAll al = new dbCTOneorAll()
            {
                id = 0,
                value = "Hệ thống"
            };
            lsLoaiThu.Add(al);
            dbCTOneorAll al1 = new dbCTOneorAll()
            {
                id = 1,
                value = "Thưởng nạp thẻ"
            };
            lsLoaiThu.Add(al1);
            dbCTOneorAll al2 = new dbCTOneorAll()
            {
                id = 2,
                value = "Nạp thẻ"
            };
            lsLoaiThu.Add(al2);
            dbCTOneorAll al3 = new dbCTOneorAll()
            {
                id = 3,
                value = "Nạp thẻ bù"
            };
            lsLoaiThu.Add(al3);

            lueLoaiThu.DataSource = lsLoaiThu;
        }

        protected override void OnSave()
        {
            if (txtGold.Text != "" && txtLevel.Text != "" && txtSilver.Text != "" && txtNickname.Text != "" && txtVip.Text != "" && txtStamina.Text != "")
            {
                if (nickname == txtNickname.Text)
                {
                    SaveInfomationCharacter();
                }
                else
                {
                    var checkUser = MongoController.UserInfo.GetSingleData(server.GetConnectSubDB(idServer), a => a.nickname == txtNickname.Text && a.server_id == idServer);
                    if (checkUser == null)
                    {
                        SaveInfomationCharacter();
                    }
                    else
                    {
                        CommonShowDialog.ShowErrorDialog("Nickname đã tồn tại!");
                    }
                }
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Không được để ô trống!");
            }
        }

        private void SaveInfomationCharacter()
        {
            var tmpUser = MongoController.UserInfo.GetSingleData(server.GetConnectSubDB(idServer), a => a.username == username && a.server_id == idServer);
            if (tmpUser.gold != int.Parse(txtGold.Text))
            {
                dbLogKNBTool conf = new dbLogKNBTool()
                {
                    hanhDong = 1,
                    userName = username,
                    paraLast = txtGold.Text,
                    nickTool = UserSession.Username,
                    para = tmpUser.gold.ToString(),
                    thoiGian = DateTime.Now,
                    status = 1,
                    serverID = idServer
                };
                ConnectDB.Entities.dbLogKNBTools.Add(conf);
                ConnectDB.Entities.SaveChanges();
            }
            tmpUser.gold = int.Parse(txtGold.Text);

            //
            if (tmpUser.level != int.Parse(txtLevel.Text))
            {
                dbLogKNBTool conf = new dbLogKNBTool()
                {
                    hanhDong = 2,
                    userName = username,
                    paraLast = txtLevel.Text,
                    nickTool = UserSession.Username,
                    para = tmpUser.level.ToString(),
                    thoiGian = DateTime.Now,
                    status = 1,
                    serverID = idServer
                };
                ConnectDB.Entities.dbLogKNBTools.Add(conf);
                ConnectDB.Entities.SaveChanges();
            }
            tmpUser.level = int.Parse(txtLevel.Text);

            //
            if (tmpUser.nickname != txtNickname.Text)
            {
                dbLogKNBTool conf = new dbLogKNBTool()
                {
                    hanhDong = 3,
                    userName = username,
                    paraLast = txtNickname.Text,
                    nickTool = UserSession.Username,
                    para = tmpUser.nickname,
                    thoiGian = DateTime.Now,
                    status = 1,
                    serverID = idServer
                };
                ConnectDB.Entities.dbLogKNBTools.Add(conf);
                ConnectDB.Entities.SaveChanges();
            }
            tmpUser.nickname = txtNickname.Text;

            //
            if (tmpUser.silver != int.Parse(txtSilver.Text))
            {
                dbLogKNBTool conf = new dbLogKNBTool()
                {
                    hanhDong = 4,
                    userName = username,
                    paraLast = txtSilver.Text,
                    nickTool = UserSession.Username,
                    para = tmpUser.silver.ToString(),
                    thoiGian = DateTime.Now,
                    status = 1,
                    serverID = idServer
                };
                ConnectDB.Entities.dbLogKNBTools.Add(conf);
                ConnectDB.Entities.SaveChanges();
            }
            tmpUser.silver = int.Parse(txtSilver.Text);

            //
            if (tmpUser.vip != int.Parse(txtVip.Text))
            {
                dbLogKNBTool conf = new dbLogKNBTool()
                {
                    hanhDong = 5,
                    userName = username,
                    paraLast = txtVip.Text,
                    nickTool = UserSession.Username,
                    para = tmpUser.vip.ToString(),
                    thoiGian = DateTime.Now,
                    status = 1,
                    serverID = idServer
                };
                ConnectDB.Entities.dbLogKNBTools.Add(conf);
                ConnectDB.Entities.SaveChanges();
            }
            tmpUser.vip = int.Parse(txtVip.Text);

            //
            if (tmpUser.stamina != int.Parse(txtStamina.Text))
            {
                dbLogKNBTool conf = new dbLogKNBTool()
                {
                    hanhDong = 6,
                    userName = username,
                    paraLast = txtStamina.Text,
                    nickTool = UserSession.Username,
                    para = tmpUser.stamina.ToString(),
                    thoiGian = DateTime.Now,
                    status = 1,
                    serverID = idServer
                };
                ConnectDB.Entities.dbLogKNBTools.Add(conf);
                ConnectDB.Entities.SaveChanges();
            }
            tmpUser.stamina = int.Parse(txtStamina.Text);

            tmpUser.isLocked = HandlerSaveTrangThai(int.Parse(lueTrangThai.EditValue.ToString()));
            MongoController.UserInfo.Update(server.GetConnectSubDB(idServer), tmpUser);
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private void gvThu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvThu.RowCount > 0)
            {
                int idFake = (int)gvThu.GetRowCellValue(gvThu.FocusedRowHandle, "idFake");
                gcChiTietThu.DataSource = null;
                gcChiTietThu.DataSource = lsReward.Where(x => x.idFake == idFake);
            }
        }
    }
}