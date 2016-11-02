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
using MongoDB.Bson;
using KDQHNPHTool.Model;
using KDQHNPHTool.Model_View;
using KDQHNPHTool.Models;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Common;
using MongoDBModel.SubDatabaseModels;
using StaticDB.Enum;
using System.Globalization;
using StaticDB.Models;

namespace KDQHNPHTool.Form
{
    public partial class frmChieuMo : frmFormChange
    {
        int addOrEdit = 0;
        ObjectId idSuKien;

        ListServer server = new ListServer();
        ListReward rewardHandler = new ListReward();

        List<vReward> lsGroupChieuMo = new List<vReward>();
        List<vReward> lsVipChieuMo = new List<vReward>();
        List<vReward> lsNhanVatNormal = new List<vReward>();
        List<vReward> lsNhanVatBonus = new List<vReward>();

        List<vReward> lsRewadVPNormal = new List<vReward>();
        List<vReward> lsRewadVPSpecial = new List<vReward>();

        public frmChieuMo()
        {
            InitializeComponent();
            btnSendMail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadDataToLUE();
            panelControl2.Enabled = false;
        }

        private void LoadDataToLUE()
        {
            lueChonServer.Properties.DataSource = server.GetListServer();
            lueChonServer.Properties.DisplayMember = "value";
            lueChonServer.Properties.ValueMember = "id";

            lueTypeRewardVPNormal.DataSource = rewardHandler.LoadTypeReward();
            lueTypeRewardVPSpecial.DataSource = rewardHandler.LoadTypeReward();
            lueTypeRewardNhanVatVip.DataSource = rewardHandler.LoadTypeReward();
            lueStaticIDNhanVatVip.DataSource = rewardHandler.LoadTotalReward();
            lueStaticIDVPNormal.DataSource = rewardHandler.LoadTotalReward();
            lueStaticIDVPSpecial.DataSource = rewardHandler.LoadTotalReward();
            lueTypeRewardNhanVatBonus.DataSource = rewardHandler.LoadTypeReward();
            lueStaticIDNhanVatBonus.DataSource = rewardHandler.LoadTotalReward();


            List<dbCTAffliction> lsAff = new List<dbCTAffliction>();

            dbCTAffliction af = new dbCTAffliction()
            {
                id = 0,
                value = "Normal"
            };
            lsAff.Add(af);

            dbCTAffliction af1 = new dbCTAffliction()
            {
                id = 1,
                value = "Special"
            };
            lsAff.Add(af1);

            lueLoaiQuayTuong.Properties.DataSource = lsAff;
            lueLoaiQuayTuong.Properties.DisplayMember = "value";
            lueLoaiQuayTuong.Properties.ValueMember = "id";
        }

        private void lueLoaiQuayTuong_EditValueChanged(object sender, EventArgs e)
        {
            if (lueLoaiQuayTuong.EditValue.ToString() != "")
            {
                ClearQuayTuong();
                int idLoai = int.Parse(lueLoaiQuayTuong.EditValue.ToString());
                if (idLoai == 0)
                {
                    txtFreeNgayNormal.Visible = true;
                    txtQuay10LanNormal.Visible = true;
                    txtQuay1LanNormal.Visible = true;
                    txtTimeFreeNormal.Visible = true;

                    txtLanNgaySpec.Visible = false;
                    txtQuay10LanSpec.Visible = false;
                    txtQuay1LanSpec.Visible = false;
                    txtWaitTimeSpec.Visible = false;
                    gcGroupChieuMoNormal.DataSource = lsGroupChieuMo.Where(x => x.status == 0);
                }
                else
                {
                    txtFreeNgayNormal.Visible = false;
                    txtQuay10LanNormal.Visible = false;
                    txtQuay1LanNormal.Visible = false;
                    txtTimeFreeNormal.Visible = false;

                    txtLanNgaySpec.Visible = true;
                    txtQuay10LanSpec.Visible = true;
                    txtQuay1LanSpec.Visible = true;
                    txtWaitTimeSpec.Visible = true;
                    gcGroupChieuMoNormal.DataSource = lsGroupChieuMo.Where(x => x.status == 1);
                }
            }
        }

        private void lueChonServer_EditValueChanged(object sender, EventArgs e)
        {
            if (lueChonServer.EditValue.ToString() != "" && lueChonServer.EditValue.ToString() != "0")
            {
                panelControl2.Enabled = true;
                string idServer = lueChonServer.EditValue.ToString();
                ClearAll();

                var tmpSk = MongoController.ChieuMoConfig.GetSingleData(server.GetConnectSubDB(idServer), a => a.server_id == idServer);
                if (tmpSk != null)
                {
                    idSuKien = tmpSk._id;
                    //Quay tuong
                    txtFreeNgayNormal.Text = tmpSk.quay_tuong.normal_config.max_free_in_day.ToString();
                    txtQuay10LanNormal.Text = tmpSk.quay_tuong.normal_config.x10_price.ToString();
                    txtQuay1LanNormal.Text = tmpSk.quay_tuong.normal_config.price.ToString();
                    txtTimeFreeNormal.Text = tmpSk.quay_tuong.normal_config.wait_time_free.ToString();

                    txtLanNgaySpec.Text = tmpSk.quay_tuong.special_config.max_free_in_day.ToString();
                    txtQuay10LanSpec.Text = tmpSk.quay_tuong.special_config.x10_price.ToString();
                    txtQuay1LanSpec.Text = tmpSk.quay_tuong.special_config.price.ToString();
                    txtWaitTimeSpec.Text = tmpSk.quay_tuong.special_config.wait_time_free.ToString();

                    for (int i = 0; i < tmpSk.quay_tuong.normal_config.group_chars.Count(); i++)
                    {
                        vReward stt = new vReward()
                        {
                            idFake = lsGroupChieuMo.Count(),
                            proc = tmpSk.quay_tuong.normal_config.group_chars[i].proc,
                            status = 0
                        };
                        lsGroupChieuMo.Add(stt);

                        for (int y = 0; y < tmpSk.quay_tuong.normal_config.group_chars[i].chars.Count(); y++)
                        {

                            vReward stt1 = new vReward()
                            {
                                idFake = stt.idFake,
                                type_reward = lsVipChieuMo.Count(),
                                static_id = y
                            };
                            lsVipChieuMo.Add(stt1);

                            if (tmpSk.quay_tuong.normal_config.group_chars[i].chars[y] != null)
                            {
                                for (int z = 0; z < tmpSk.quay_tuong.normal_config.group_chars[i].chars[y].Count(); z++)
                                {
                                    vReward chr = new vReward()
                                    {
                                        status = lsNhanVatNormal.Count(),
                                        type_reward = tmpSk.quay_tuong.normal_config.group_chars[i].chars[y][z].typeReward + 1,
                                        idFake = lsVipChieuMo.Count() - 1,
                                        static_id = rewardHandler.HandlerLoadStaticID(tmpSk.quay_tuong.normal_config.group_chars[i].chars[y][z].typeReward + 1, tmpSk.quay_tuong.normal_config.group_chars[i].chars[y][z].staticID),
                                        proc = tmpSk.quay_tuong.normal_config.group_chars[i].chars[y][z].proc,
                                        quantity = tmpSk.quay_tuong.normal_config.group_chars[i].chars[y][z].amountMin,
                                        price = tmpSk.quay_tuong.normal_config.group_chars[i].chars[y][z].amountMax
                                    };
                                    lsNhanVatNormal.Add(chr);
                                }
                            }
                        }
                    }

                    for (int i = 0; i < tmpSk.quay_tuong.special_config.group_chars.Count(); i++)
                    {
                        vReward stt = new vReward()
                        {
                            idFake = lsGroupChieuMo.Count(),
                            proc = tmpSk.quay_tuong.special_config.group_chars[i].proc,
                            status = 1
                        };
                        lsGroupChieuMo.Add(stt);

                        for (int y = 0; y < tmpSk.quay_tuong.special_config.group_chars[i].chars.Count(); y++)
                        {

                            vReward stt1 = new vReward()
                            {
                                idFake = stt.idFake,
                                type_reward = lsVipChieuMo.Count(),
                                static_id = y
                            };
                            lsVipChieuMo.Add(stt1);

                            if (tmpSk.quay_tuong.special_config.group_chars[i].chars[y] != null)
                            {
                                for (int z = 0; z < tmpSk.quay_tuong.special_config.group_chars[i].chars[y].Count(); z++)
                                {
                                    vReward chr = new vReward()
                                    {
                                        status = lsNhanVatNormal.Count(),
                                        type_reward = tmpSk.quay_tuong.special_config.group_chars[i].chars[y][z].typeReward + 1,
                                        idFake = lsVipChieuMo.Count() - 1,
                                        static_id = rewardHandler.HandlerLoadStaticID(tmpSk.quay_tuong.special_config.group_chars[i].chars[y][z].typeReward + 1, tmpSk.quay_tuong.special_config.group_chars[i].chars[y][z].staticID),
                                        proc = tmpSk.quay_tuong.special_config.group_chars[i].chars[y][z].proc,
                                        quantity = tmpSk.quay_tuong.special_config.group_chars[i].chars[y][z].amountMin,
                                        price = tmpSk.quay_tuong.special_config.group_chars[i].chars[y][z].amountMax
                                    };
                                    lsNhanVatNormal.Add(chr);
                                }
                            }
                        }
                    }

                    //quay tuong bonus
                    txtQuay10LanBonus.Text = tmpSk.quay_tuong.bonus_config.times_quay_tuong_x10_special.ToString();
                    foreach (var item in tmpSk.quay_tuong.bonus_config.chars)
                    {
                        vReward re = new vReward()
                        {
                            idFake = lsNhanVatBonus.Count(),
                            type_reward = item.typeReward + 1,
                            static_id = rewardHandler.HandlerLoadStaticID((int)item.typeReward + 1, (int)item.staticID),
                            quantity = item.amountMin,
                            price = item.amountMax,
                            proc = item.proc
                        };
                        lsNhanVatBonus.Add(re);
                    }

                    //vat pham
                    txtQuay10LanVatPham.Text = tmpSk.quay_vat_pham.normal_config.x10_price.ToString();
                    txtQuay1LanVatPham.Text = tmpSk.quay_vat_pham.normal_config.price.ToString();
                    txtTimeFreeVatPham.Text = tmpSk.quay_vat_pham.normal_config.wait_time_free.ToString();

                    foreach (var item in tmpSk.quay_vat_pham.normal_config.vat_phams)
                    {
                        vReward re = new vReward()
                        {
                            idFake = lsRewadVPNormal.Count(),
                            type_reward = (int)item.type + 1,
                            static_id = rewardHandler.HandlerLoadStaticID((int)item.type + 1, item.static_id),
                            quantity = item.quantity,
                            proc = item.proc
                        };
                        lsRewadVPNormal.Add(re);
                    }

                    foreach (var item in tmpSk.quay_vat_pham.special_vat_pham)
                    {
                        vReward re = new vReward()
                        {
                            idFake = lsRewadVPSpecial.Count(),
                            type_reward = (int)item.type + 1,
                            static_id = rewardHandler.HandlerLoadStaticID((int)item.type + 1, item.static_id),
                            quantity = item.quantity,
                            proc = item.proc
                        };
                        lsRewadVPSpecial.Add(re);
                    }

                    gcNhanVatBonus.DataSource = lsNhanVatBonus;
                    gcVatPhamNormal.DataSource = lsRewadVPNormal;
                    gcVatPhamSpecial.DataSource = lsRewadVPSpecial;
                    lueLoaiQuayTuong.EditValue = 0;
                    if (lueLoaiQuayTuong.EditValue.ToString() == "0")
                    {
                        lueLoaiQuayTuong.EditValue = 1;
                    }
                    else
                    {
                        lueLoaiQuayTuong.EditValue = 0;
                    }
                }
            }
        }

        private void ClearAll()
        {
            gcChacracterNormal.DataSource = null;
            gcGroupChieuMoNormal.DataSource = null;
            gcVatPhamNormal.DataSource = null;
            gcVatPhamSpecial.DataSource = null;
            gcVipChieuMoNormal.DataSource = null;
            gcNhanVatBonus.DataSource = null;

            lsGroupChieuMo.Clear();
            lsNhanVatBonus.Clear();
            lsNhanVatNormal.Clear();
            lsRewadVPNormal.Clear();
            lsRewadVPSpecial.Clear();
            lsVipChieuMo.Clear();
        }

        private void ClearQuayTuong()
        {
            gcChacracterNormal.DataSource = null;
            gcGroupChieuMoNormal.DataSource = null;
            gcVipChieuMoNormal.DataSource = null;
        }

        private void HandlerGridSave()
        {
            gvChacracterNormal.FocusedRowHandle = -1;
            gvGroupChieuMoNormal.FocusedRowHandle = -1;
            gvNhanVatBonus.FocusedRowHandle = -1;
            gvVatPhamNormal.FocusedRowHandle = -1;
            gvVatPhamSpecial.FocusedRowHandle = -1;
            gvVipChieuMoNormal.FocusedRowHandle = -1;
        }

        private void gvGroupChieuMoNormal_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvGroupChieuMoNormal.RowCount > 0)
            {
                int idGroup = (int)gvGroupChieuMoNormal.GetRowCellValue(gvGroupChieuMoNormal.FocusedRowHandle, "idFake");
                gcVipChieuMoNormal.DataSource = null;
                gcChacracterNormal.DataSource = null;
                gcVipChieuMoNormal.DataSource = lsVipChieuMo.Where(x => x.idFake == idGroup);
            }
        }

        private void gvVipChieuMoNormal_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvVipChieuMoNormal.RowCount > 0)
            {
                int idVip = (int)gvVipChieuMoNormal.GetRowCellValue(gvVipChieuMoNormal.FocusedRowHandle, "type_reward");
                gcChacracterNormal.DataSource = null;
                gcChacracterNormal.DataSource = lsNhanVatNormal.Where(x => x.idFake == idVip);
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            int idVip = (int)gvVipChieuMoNormal.GetRowCellValue(gvVipChieuMoNormal.FocusedRowHandle, "type_reward");
            vReward re = new vReward()
            {
                status = -(lsNhanVatNormal.Count),
                type_reward = 2,
                idFake = idVip,
                static_id = 1,
                quantity = 1,
                price = 1,
                proc = 0

            };
            lsNhanVatNormal.Add(re);
            gcChacracterNormal.DataSource = null;
            gcChacracterNormal.DataSource = lsNhanVatNormal.Where(x => x.idFake == idVip);
            gvChacracterNormal.MoveLast();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            vReward idNhanVat = (vReward)gvChacracterNormal.GetRow(gvChacracterNormal.FocusedRowHandle);
            int idVip = (int)gvVipChieuMoNormal.GetRowCellValue(gvVipChieuMoNormal.FocusedRowHandle, "type_reward");
            if (gvChacracterNormal.RowCount > 0)
            {
                lsNhanVatNormal.Remove(idNhanVat);
                gcChacracterNormal.DataSource = null;
                gcChacracterNormal.DataSource = lsNhanVatNormal.Where(x => x.idFake == idVip);
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            vReward re = new vReward()
            {
                type_reward = 2,
                idFake = -(lsNhanVatBonus.Count),
                quantity = 0,
                static_id = 1,
                price = 0,
                proc = 0
            };
            lsNhanVatBonus.Add(re);
            gcNhanVatBonus.DataSource = null;
            gcNhanVatBonus.DataSource = lsNhanVatBonus;
            gvNhanVatBonus.MoveLast();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            int idNhanVat = (int)gvNhanVatBonus.GetRowCellValue(gvNhanVatBonus.FocusedRowHandle, "idFake");
            if (gvNhanVatBonus.RowCount > 0)
            {
                lsNhanVatBonus.RemoveAll(x => x.idFake == idNhanVat);
                gcNhanVatBonus.DataSource = null;
                gcNhanVatBonus.DataSource = lsNhanVatBonus;
            }
        }

        private void btnAddVatPham1_Click(object sender, EventArgs e)
        {
            vReward re = new vReward()
            {
                idFake = -(lsRewadVPNormal.Count()),
                type_reward = 2,
                static_id = 1,
                quantity = 0,
                status = 0
            };
            lsRewadVPNormal.Add(re);
            gcVatPhamNormal.DataSource = null;
            gcVatPhamNormal.DataSource = lsRewadVPNormal;
            gvVatPhamNormal.MoveLast();
        }

        private void btnDeleteVatPham1_Click(object sender, EventArgs e)
        {
            int idNhanVat = (int)gvVatPhamNormal.GetRowCellValue(gvVatPhamNormal.FocusedRowHandle, "idFake");
            if (gvVatPhamNormal.RowCount > 0)
            {
                lsRewadVPNormal.RemoveAll(x => x.idFake == idNhanVat);
                gcVatPhamNormal.DataSource = null;
                gcVatPhamNormal.DataSource = lsRewadVPNormal;
            }
        }

        private void btnAddVatPham2_Click(object sender, EventArgs e)
        {
            vReward re = new vReward()
            {
                idFake = -(lsRewadVPSpecial.Count()),
                type_reward = 2,
                static_id = 1,
                quantity = 0,
                status = 0
            };
            lsRewadVPSpecial.Add(re);
            gcVatPhamSpecial.DataSource = null;
            gcVatPhamSpecial.DataSource = lsRewadVPSpecial;
            gvVatPhamSpecial.MoveLast();
        }

        private void btnDeleteVatPham2_Click(object sender, EventArgs e)
        {
            int idNhanVat = (int)gvVatPhamSpecial.GetRowCellValue(gvVatPhamSpecial.FocusedRowHandle, "idFake");
            if (gvVatPhamSpecial.RowCount > 0)
            {
                lsRewadVPSpecial.RemoveAll(x => x.idFake == idNhanVat);
                gcVatPhamSpecial.DataSource = null;
                gcVatPhamSpecial.DataSource = lsRewadVPSpecial;
            }
        }

        private void gvVatPhamNormal_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvVatPhamNormal.GetRow(gvVatPhamNormal.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 2, idServer);
            formTask.ShowDialog();
        }

        private void gvVatPhamSpecial_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvVatPhamSpecial.GetRow(gvVatPhamSpecial.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 2, idServer);
            formTask.ShowDialog();
        }

        protected override void OnSave()
        {
            HandlerGridSave();

            string idServer = lueChonServer.EditValue.ToString();
            var result = MongoController.ChieuMoConfig.GetSingleData(server.GetConnectSubDB(idServer), a => a._id == idSuKien);
            result.server_id = idServer;
            result.quay_vat_pham = HandlerQuayVatPham();
            result.quay_tuong = HandlerQuayTuong();
            MongoController.ChieuMoConfig.Update(server.GetConnectSubDB(idServer), result);
            CommonShowDialog.ShowSuccessfulDialog("Lưu thành công!");
        }

        private MQuayTuongGroup HandlerQuayTuong()
        {
            MQuayTuongGroup quay = new MQuayTuongGroup()
            {
                normal_config = HandlerMQuayTuongPrice(1),
                special_config = HandlerMQuayTuongPrice(2),
                bonus_config = HandlerBonusPrice()
            };
            return quay;
        }

        private MBonusQuayTuongPrice HandlerBonusPrice()
        {
            MBonusQuayTuongPrice bonus = new MBonusQuayTuongPrice()
            {
                times_quay_tuong_x10_special = int.Parse(txtQuay10LanBonus.Text),
                chars = HandlerCharacterBonus()
            };
            return bonus;
        }

        private List<Reward> HandlerCharacterBonus()
        {
            List<Reward> lsTMPReward = new List<Reward>();
            foreach (var item in lsNhanVatBonus.OrderBy(x => x.proc))
            {
                Reward re = new Reward()
                {
                    typeReward = item.type_reward - 1,
                    staticID = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                    amountMin = item.quantity,
                    amountMax = item.price,
                    proc = item.proc
                };
                lsTMPReward.Add(re);
            }
            return lsTMPReward;
        }

        private List<int> HandlerListInt()
        {
            List<int> lsInt = new List<int>();
            foreach (var item in lsNhanVatBonus)
            {
                lsInt.Add(item.type_reward);
            }
            return lsInt;
        }

        private MQuayTuongPrice HandlerMQuayTuongPrice(int type)
        {
            if (type == 1)
            {
                MQuayTuongPrice quay = new MQuayTuongPrice()
                {
                    max_free_in_day = int.Parse(txtFreeNgayNormal.Text),
                    price = int.Parse(txtQuay1LanNormal.Text),
                    wait_time_free = int.Parse(txtTimeFreeNormal.Text),
                    x10_price = int.Parse(txtQuay10LanNormal.Text),
                    group_chars = HandlerMGroupChar(0)
                };
                return quay;
            }
            else
            {
                MQuayTuongPrice quay = new MQuayTuongPrice()
                {
                    max_free_in_day = int.Parse(txtLanNgaySpec.Text),
                    price = int.Parse(txtQuay1LanSpec.Text),
                    wait_time_free = int.Parse(txtWaitTimeSpec.Text),
                    x10_price = int.Parse(txtQuay10LanSpec.Text),
                    group_chars = HandlerMGroupChar(1)
                };
                return quay;
            }
        }

        private MGroupChar[] HandlerMGroupChar(int status)
        {
            List<MGroupChar> tmpLsGroup = new List<MGroupChar>();
            foreach (var item in lsGroupChieuMo.Where(x => x.status == status).OrderBy(x => x.proc))
            {
                MGroupChar chr = new MGroupChar()
                {
                    proc = (double)item.proc,
                    chars = HandlerListCharacter(item.idFake)
                };
                tmpLsGroup.Add(chr);
            }

            return tmpLsGroup.ToArray();
        }

        private List<Reward[]> HandlerListCharacter(int idGr)
        {
            List<Reward[]> lsArrInt = new List<Reward[]>();
            foreach (var item in lsVipChieuMo.Where(x => x.idFake == idGr))
            {
                lsArrInt.Add(HandlerArrInt(item.type_reward));
            }
            return lsArrInt;
        }

        private Reward[] HandlerArrInt(int idVip)
        {
            List<Reward> lsInt = new List<Reward>();
            if (lsNhanVatNormal.Where(x => x.idFake == idVip).Count() == 0)
            {
                return null;
            }
            else
            {
                foreach (var item in lsNhanVatNormal.Where(x => x.idFake == idVip).OrderBy(x => x.proc))
                {
                    Reward re = new Reward()
                    {
                        typeReward = item.type_reward - 1,
                        staticID = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                        amountMax = item.price,
                        amountMin = item.quantity,
                        proc = item.proc
                    };
                    lsInt.Add(re);
                }
                return lsInt.ToArray();
            }
        }

        private MQuayVatPhamGroup HandlerQuayVatPham()
        {
            MQuayVatPhamGroup quay = new MQuayVatPhamGroup()
            {
                normal_config = HandlerMQuayVatPhamPrice(),
                special_vat_pham = HandlerMVatPham(2)
            };
            return quay;
        }

        private MQuayVatPhamPrice HandlerMQuayVatPhamPrice()
        {
            MQuayVatPhamPrice quay = new MQuayVatPhamPrice()
            {
                price = int.Parse(txtQuay1LanVatPham.Text),
                x10_price = int.Parse(txtQuay10LanVatPham.Text),
                wait_time_free = int.Parse(txtTimeFreeVatPham.Text),
                vat_phams = HandlerMVatPham(1)
            };
            return quay;
        }

        private MVatPham[] HandlerMVatPham(int type)
        {
            List<MVatPham> lsTMPVatPham = new List<MVatPham>();
            if (type == 1)
            {
                foreach (var item in lsRewadVPNormal.OrderBy(x => x.proc))
                {
                    MVatPham vat = new MVatPham()
                    {
                        type = (TypeReward)(item.type_reward - 1),
                        static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                        quantity = item.quantity,
                        proc = item.proc
                    };
                    lsTMPVatPham.Add(vat);
                }
            }
            else
            {
                foreach (var item in lsRewadVPSpecial.OrderBy(x => x.proc))
                {
                    MVatPham vat = new MVatPham()
                    {
                        type = (TypeReward)(item.type_reward - 1),
                        static_id = rewardHandler.HandlerSaveStaticID(item.type_reward, item.static_id),
                        quantity = item.quantity,
                        proc = item.proc
                    };
                    lsTMPVatPham.Add(vat);
                }
            }
            return lsTMPVatPham.ToArray();
        }

        private void gvChacracterNormal_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvChacracterNormal.GetRow(gvChacracterNormal.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 5, idServer);
            formTask.ShowDialog();
        }

        private void gvNhanVatBonus_DoubleClick(object sender, EventArgs e)
        {
            string idServer = lueChonServer.EditValue.ToString();
            vReward rewardSelect = (vReward)gvNhanVatBonus.GetRow(gvNhanVatBonus.FocusedRowHandle);
            frmEditReward formTask = new frmEditReward(rewardSelect, 5, idServer);
            formTask.ShowDialog();
        }
    }
}