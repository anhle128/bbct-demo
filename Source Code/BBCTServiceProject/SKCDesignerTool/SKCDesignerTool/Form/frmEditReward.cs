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
using KDQHDesignerTool.FormBase;
using KDQHDesignerTool.Models;
using KDQHDesignerTool.Common;

namespace KDQHDesignerTool.Form
{
    public partial class frmEditReward : frmFormChange
    {
        List<Models.TotalReward> lsTotalReward = new List<Models.TotalReward>();
        private dbMapStageReward mapReward;
        public dbMapStageReward MapReward
        {
            get { return mapReward; }
            set { mapReward = value; }
        }
        private dbVanTieuProtectReward protectReward;
        public dbVanTieuProtectReward ProtectReward
        {
            get { return protectReward; }
            set { protectReward = value; }
        }
        private dbVanTieuRobReward robReward;
        public dbVanTieuRobReward RobReward
        {
            get { return robReward; }
            set { robReward = value; }
        }
        private dbThanThapFloorReward rewardThanThap;
        public dbThanThapFloorReward RewardThanThap
        {
            get { return rewardThanThap; }
            set { rewardThanThap = value; }
        }
        private dbCauCaReward rewardCauCa;
        public dbCauCaReward RewardCauCa
        {
            get { return rewardCauCa; }
            set { rewardCauCa = value; }
        }
        private dbLuanKiemRankReward rewardLuanKiem;
        public dbLuanKiemRankReward RewardLuanKiem
        {
            get { return rewardLuanKiem; }
            set { rewardLuanKiem = value; }
        }
        private dbGuildRewardsLuaTrai rewardLuaTrai;
        public dbGuildRewardsLuaTrai RewardLuaTrai
        {
            get { return rewardLuaTrai; }
            set { rewardLuaTrai = value; }
        }
        private dbGuildBossReward rewardBoss;

        private dbNhiemVuHangNgayReward rewardNhiemVuHangNgay;
        public dbNhiemVuHangNgayReward RewardNhiemVuHangNgay
        {
            get { return rewardNhiemVuHangNgay; }
            set { rewardNhiemVuHangNgay = value; }
        }
        private dbMapStageSupper rewardStageSupper;

        public dbMapStageSupper RewardStageSupper
        {
            get { return rewardStageSupper; }
            set { rewardStageSupper = value; }
        }
        public dbGuildBossReward RewardBoss
        {
            get { return rewardBoss; }
            set { rewardBoss = value; }
        }

        private dbGuildRewardBangChien rewardBangChien;

        public dbGuildRewardBangChien RewardBangChien
        {
            get { return rewardBangChien; }
            set { rewardBangChien = value; }
        }

        private dbHoatDongDiemDanhMonthReward rewardiemDanh;

        public dbHoatDongDiemDanhMonthReward RewardiemDanh
        {
            get { return rewardiemDanh; }
            set { rewardiemDanh = value; }
        }

        private dbPucLoiThangReward rewardPhucLoi;

        public dbPucLoiThangReward RewardPhucLoi
        {
            get { return rewardPhucLoi; }
            set { rewardPhucLoi = value; }
        }

        private dbLevelReward_Reward rewardLevel;

        public dbLevelReward_Reward RewardLevel
        {
            get { return rewardLevel; }
            set { rewardLevel = value; }
        }

        private dbShareFacebook rewardFacebook;

        public dbShareFacebook RewardFacebook
        {
            get { return rewardFacebook; }
            set { rewardFacebook = value; }
        }

        private dbStarRewardReward rewardMap3Star;

        public dbStarRewardReward RewardMap3Star
        {
            get { return rewardMap3Star; }
            set { rewardMap3Star = value; }
        }

        private dbCuuCuuTriTonConfigReward rewardCuuCuuChiTon;

        public dbCuuCuuTriTonConfigReward RewardCuuCuuChiTon
        {
            get { return rewardCuuCuuChiTon; }
            set { rewardCuuCuuChiTon = value; }
        }

        private dbPhucLoiTruongThanhLevelReward rewardPhucLoiTruongThanh;

        public dbPhucLoiTruongThanhLevelReward RewardPhucLoiTruongThanh
        {
            get { return rewardPhucLoiTruongThanh; }
            set { rewardPhucLoiTruongThanh = value; }
        }

        private dbRuongBauReward rewardRuongBau;

        public dbRuongBauReward RewardRuongBau
        {
            get { return rewardRuongBau; }
            set { rewardRuongBau = value; }
        }

        private dbTaoNickReward rewardTaoNick;

        public dbTaoNickReward RewardTaoNick
        {
            get { return rewardTaoNick; }
            set { rewardTaoNick = value; }
        }


        private dbGlobalBonusRewardConfig rewardBossReward;

        public dbGlobalBonusRewardConfig RewardBossReward
        {
            get { return rewardBossReward; }
            set { rewardBossReward = value; }
        }

        private dbInviteFriendReward rewardInvite;

        public dbInviteFriendReward RewardInvite
        {
            get { return rewardInvite; }
            set { rewardInvite = value; }
        }

        private dbLuanKiemWinReward rewardWinLuanKiem;

        public dbLuanKiemWinReward RewardWinLuanKiem
        {
            get { return rewardWinLuanKiem; }
            set { rewardWinLuanKiem = value; }
        }

        private dbLuanKiemLoseReward rewardLoseReward;

        public dbLuanKiemLoseReward RewardLoseReward
        {
            get { return rewardLoseReward; }
            set { rewardLoseReward = value; }
        }

        public frmEditReward(dbMapStageReward tmpMapReward, dbVanTieuProtectReward tmpProReward, dbVanTieuRobReward tmpRobReward, dbThanThapFloorReward tmpThanThap, dbCauCaReward tmpCauCa, dbLuanKiemRankReward tmpLuanKiem, dbGuildRewardsLuaTrai tmpLuaTrai, dbGuildBossReward tmpBossGuild, dbNhiemVuHangNgayReward tmpNhiemVuHangNgay, dbMapStageSupper tmpRewardSupper, dbGuildRewardBangChien tmpRewardBangChien, dbHoatDongDiemDanhMonthReward tmpDiemDanh, dbPucLoiThangReward tmpRewardPhucLoi, dbLevelReward_Reward tmpRewardLevel, dbShareFacebook tmpRewardFace, dbStarRewardReward tmpStarRewad, dbCuuCuuTriTonConfigReward tmpRewardCuuCuu, dbPhucLoiTruongThanhLevelReward tmpTruongThanh, dbRuongBauReward tmpRuongBau, dbTaoNickReward tmpTaoNick, dbGlobalBonusRewardConfig tmpBossReward, dbInviteFriendReward tmpInviteReward, dbLuanKiemWinReward tmpRewardWinLuanKiem, dbLuanKiemLoseReward tmpRewardLoseLuanKiem)
        {
            InitializeComponent();
            btnUpload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            mapReward = tmpMapReward;
            protectReward = tmpProReward;
            robReward = tmpRobReward;
            rewardThanThap = tmpThanThap;
            rewardCauCa = tmpCauCa;
            rewardLuanKiem = tmpLuanKiem;
            rewardBoss = tmpBossGuild;
            rewardLuaTrai = tmpLuaTrai;
            rewardNhiemVuHangNgay = tmpNhiemVuHangNgay;
            rewardStageSupper = tmpRewardSupper;
            rewardBangChien = tmpRewardBangChien;
            rewardiemDanh = tmpDiemDanh;
            rewardPhucLoi = tmpRewardPhucLoi;
            rewardLevel = tmpRewardLevel;
            rewardFacebook = tmpRewardFace;
            rewardMap3Star = tmpStarRewad;
            rewardCuuCuuChiTon = tmpRewardCuuCuu;
            rewardPhucLoiTruongThanh = tmpTruongThanh;
            rewardRuongBau = tmpRuongBau;
            rewardTaoNick = tmpTaoNick;
            rewardBossReward = tmpBossReward;
            rewardInvite = tmpInviteReward;
            rewardWinLuanKiem = tmpRewardWinLuanKiem;
            rewardLoseReward = tmpRewardLoseLuanKiem;

            LoadTotalReward();
            LoadDataLUEtypeReward();
            if (mapReward != null)
            {
                lueTypeReward.EditValue = mapReward.typeReward;
                slueTypeReward.EditValue = mapReward.staticID;
                txtAmountMax.Text = mapReward.amountMax.ToString();
                txtAmountMin.Text = mapReward.amountMin.ToString();
                txtProc.Text = mapReward.procs.ToString();
            }
            else if (protectReward != null)
            {
                lueTypeReward.EditValue = protectReward.typeReward;
                slueTypeReward.EditValue = protectReward.staticID;
                txtAmountMax.Text = protectReward.amountMax.ToString();
                txtAmountMin.Text = protectReward.amountMin.ToString();
                txtProc.Text = protectReward.procs.ToString();
            }
            else if (robReward != null)
            {
                lueTypeReward.EditValue = robReward.typeReward;
                slueTypeReward.EditValue = robReward.staticID;
                txtAmountMax.Text = robReward.amountMax.ToString();
                txtAmountMin.Text = robReward.amountMin.ToString();
                txtProc.Text = robReward.procs.ToString();
            }
            else if (rewardThanThap != null)
            {
                lueTypeReward.EditValue = rewardThanThap.typeReward;
                slueTypeReward.EditValue = rewardThanThap.staticID;
                txtAmountMax.Text = rewardThanThap.amountMax.ToString();
                txtAmountMin.Text = rewardThanThap.amountMin.ToString();
                txtProc.Text = rewardThanThap.procs.ToString();
            }
            else if (rewardCauCa != null)
            {
                lueTypeReward.EditValue = rewardCauCa.typeReward;
                slueTypeReward.EditValue = rewardCauCa.staticID;
                txtAmountMax.Text = rewardCauCa.amountMax.ToString();
                txtAmountMin.Text = rewardCauCa.amountMin.ToString();
                txtProc.Text = rewardCauCa.procs.ToString();
            }
            else if (rewardLuanKiem != null)
            {
                lueTypeReward.EditValue = rewardLuanKiem.typeReward;
                slueTypeReward.EditValue = rewardLuanKiem.staticID;
                txtAmountMax.Text = rewardLuanKiem.amountMax.ToString();
                txtAmountMin.Text = rewardLuanKiem.amountMin.ToString();
                txtProc.Text = rewardLuanKiem.procs.ToString();
                txtAmountMax.Enabled = false;
                txtProc.Enabled = false;
            }
            else if (rewardLuaTrai != null)
            {
                lueTypeReward.EditValue = rewardLuaTrai.typeReward;
                slueTypeReward.EditValue = rewardLuaTrai.staticID;
                txtAmountMax.Text = rewardLuaTrai.amountMax.ToString();
                txtAmountMin.Text = rewardLuaTrai.amountMin.ToString();
                txtProc.Text = rewardLuaTrai.procs.ToString();
            }
            else if (rewardBoss != null)
            {
                lueTypeReward.EditValue = rewardBoss.typeReward;
                slueTypeReward.EditValue = rewardBoss.staticID;
                txtAmountMax.Text = rewardBoss.amountMax.ToString();
                txtAmountMin.Text = rewardBoss.amountMin.ToString();
                txtProc.Text = rewardBoss.procs.ToString();
                txtAmountMax.Enabled = false;
                txtProc.Enabled = false;
            }
            else if (rewardNhiemVuHangNgay != null)
            {
                lueTypeReward.EditValue = rewardNhiemVuHangNgay.typeReward;
                slueTypeReward.EditValue = rewardNhiemVuHangNgay.staticID;
                txtAmountMax.Text = rewardNhiemVuHangNgay.amountMax.ToString();
                txtAmountMin.Text = rewardNhiemVuHangNgay.amountMin.ToString();
                txtProc.Text = rewardNhiemVuHangNgay.procs.ToString();
                txtAmountMax.Enabled = false;
                txtProc.Enabled = false;
            }
            else if (rewardStageSupper != null)
            {
                lueTypeReward.EditValue = rewardStageSupper.typeReward;
                slueTypeReward.EditValue = rewardStageSupper.staticID;
                txtAmountMax.Text = rewardStageSupper.amountMax.ToString();
                txtAmountMin.Text = rewardStageSupper.amountMin.ToString();
                txtProc.Text = rewardStageSupper.procs.ToString();
            }
            else if (rewardBangChien != null)
            {
                lueTypeReward.EditValue = rewardBangChien.typeReward;
                slueTypeReward.EditValue = rewardBangChien.staticID;
                txtAmountMax.Text = rewardBangChien.amountMax.ToString();
                txtAmountMin.Text = rewardBangChien.amountMin.ToString();
                txtProc.Text = rewardBangChien.procs.ToString();
            }
            else if (rewardiemDanh != null)
            {
                lueTypeReward.EditValue = rewardiemDanh.typeReward;
                slueTypeReward.EditValue = rewardiemDanh.staticID;
                txtAmountMax.Text = rewardiemDanh.amountMax.ToString();
                txtAmountMin.Text = rewardiemDanh.amountMin.ToString();
                txtProc.Text = rewardiemDanh.procs.ToString();
                txtAmountMax.Enabled = false;
                txtProc.Enabled = false;
            }
            else if (rewardPhucLoi != null)
            {
                lueTypeReward.EditValue = rewardPhucLoi.typeReward;
                slueTypeReward.EditValue = rewardPhucLoi.staticID;
                txtAmountMax.Text = rewardPhucLoi.amountMax.ToString();
                txtAmountMin.Text = rewardPhucLoi.amountMin.ToString();
                txtProc.Text = rewardPhucLoi.procs.ToString();
            }
            else if (rewardLevel != null)
            {
                lueTypeReward.EditValue = rewardLevel.typeReward;
                slueTypeReward.EditValue = rewardLevel.staticID;
                txtAmountMax.Text = rewardLevel.amountMax.ToString();
                txtAmountMin.Text = rewardLevel.amountMin.ToString();
                txtProc.Text = rewardLevel.procs.ToString();
                txtAmountMax.Enabled = false;
                txtProc.Enabled = false;
            }
            else if (rewardFacebook != null)
            {
                lueTypeReward.EditValue = rewardFacebook.typeReward;
                slueTypeReward.EditValue = rewardFacebook.staticID;
                txtAmountMax.Text = rewardFacebook.amountMax.ToString();
                txtAmountMin.Text = rewardFacebook.amountMin.ToString();
                txtProc.Text = rewardFacebook.procs.ToString();
                txtAmountMax.Enabled = false;
                txtProc.Enabled = false;
            }
            else if (rewardMap3Star != null)
            {
                lueTypeReward.EditValue = rewardMap3Star.typeReward;
                slueTypeReward.EditValue = rewardMap3Star.staticID;
                txtAmountMax.Text = rewardMap3Star.amountMax.ToString();
                txtAmountMin.Text = rewardMap3Star.amountMin.ToString();
                txtProc.Text = rewardMap3Star.procs.ToString();
                txtAmountMax.Enabled = false;
                txtProc.Enabled = false;
            }
            else if (rewardCuuCuuChiTon != null)
            {
                lueTypeReward.EditValue = rewardCuuCuuChiTon.typeReward;
                slueTypeReward.EditValue = rewardCuuCuuChiTon.staticID;
                txtAmountMax.Text = rewardCuuCuuChiTon.amountMax.ToString();
                txtAmountMin.Text = rewardCuuCuuChiTon.amountMin.ToString();
                txtProc.Text = rewardCuuCuuChiTon.procs.ToString();
                txtAmountMax.Enabled = false;
                txtProc.Enabled = false;
            }
            else if (rewardPhucLoiTruongThanh != null)
            {
                lueTypeReward.EditValue = rewardPhucLoiTruongThanh.typeReward;
                slueTypeReward.EditValue = rewardPhucLoiTruongThanh.staticID;
                txtAmountMax.Text = rewardPhucLoiTruongThanh.amountMax.ToString();
                txtAmountMin.Text = rewardPhucLoiTruongThanh.amountMin.ToString();
                txtProc.Text = rewardPhucLoiTruongThanh.procs.ToString();
                txtAmountMax.Enabled = false;
                txtProc.Enabled = false;
            }
            else if (rewardRuongBau != null)
            {
                lueTypeReward.EditValue = rewardRuongBau.typeReward;
                slueTypeReward.EditValue = rewardRuongBau.staticID;
                txtAmountMax.Text = rewardRuongBau.amountMax.ToString();
                txtAmountMin.Text = rewardRuongBau.amountMin.ToString();
                txtProc.Text = rewardRuongBau.procs.ToString();
            }
            else if (rewardTaoNick != null)
            {
                lueTypeReward.EditValue = rewardTaoNick.typeReward;
                slueTypeReward.EditValue = rewardTaoNick.staticID;
                txtAmountMax.Text = rewardTaoNick.amountMax.ToString();
                txtAmountMin.Text = rewardTaoNick.amountMin.ToString();
                txtProc.Text = rewardTaoNick.procs.ToString();
                txtAmountMax.Enabled = false;
                txtProc.Enabled = false;
            }
            else if (rewardBossReward != null)
            {
                lueTypeReward.EditValue = rewardBossReward.typeReward;
                slueTypeReward.EditValue = rewardBossReward.staticID;
                txtAmountMax.Text = rewardBossReward.amountMax.ToString();
                txtAmountMin.Text = rewardBossReward.amountMin.ToString();
                txtProc.Text = rewardBossReward.procs.ToString();
            }
            else if (rewardInvite != null)
            {
                lueTypeReward.EditValue = rewardInvite.typeReward;
                slueTypeReward.EditValue = rewardInvite.staticID;
                txtAmountMax.Text = rewardInvite.amountMax.ToString();
                txtAmountMin.Text = rewardInvite.amountMin.ToString();
                txtProc.Text = rewardInvite.procs.ToString();
            }
            else if (rewardWinLuanKiem != null)
            {
                lueTypeReward.EditValue = rewardWinLuanKiem.typeReward;
                slueTypeReward.EditValue = rewardWinLuanKiem.staticID;
                txtAmountMax.Text = rewardWinLuanKiem.amountMax.ToString();
                txtAmountMin.Text = rewardWinLuanKiem.amountMin.ToString();
                txtProc.Text = rewardWinLuanKiem.procs.ToString();
            }
            else if (rewardLoseReward != null)
            {
                lueTypeReward.EditValue = rewardLoseReward.typeReward;
                slueTypeReward.EditValue = rewardLoseReward.staticID;
                txtAmountMax.Text = rewardLoseReward.amountMax.ToString();
                txtAmountMin.Text = rewardLoseReward.amountMin.ToString();
                txtProc.Text = rewardLoseReward.procs.ToString();
            }
        }

        private void LoadTotalReward()
        {
            Models.TotalReward reward = new Models.TotalReward()
            {
                id = 0,
                value = "Không"
            };
            lsTotalReward.Add(reward);

            var lsCharacter = from chr in ConnectDB.Entities.dbCharacters
                              where chr.status == 1
                              select chr;

            foreach (var item in lsCharacter)
            {
                Models.TotalReward chr = new Models.TotalReward()
                {
                    id = (int)item.idCharacter,
                    value = item.name
                };
                lsTotalReward.Add(chr);
            }

            var lsEquipment = from chr in ConnectDB.Entities.dbEquipments
                              where chr.status == 1
                              select chr;

            foreach (var item in lsEquipment)
            {
                Models.TotalReward chr = new Models.TotalReward()
                {
                    id = 1000 + (int)item.idEquipment,
                    value = item.name
                };
                lsTotalReward.Add(chr);
            }

            var lsItem = from chr in ConnectDB.Entities.dbItems
                         where chr.status == 1
                         select chr;

            foreach (var item in lsItem)
            {
                Models.TotalReward chr = new Models.TotalReward()
                 {
                     id = 2000 + (int)item.idItem,
                     value = item.name
                 };
                lsTotalReward.Add(chr);
            }

            var lsPower = from chr in ConnectDB.Entities.dbPowerUpItems
                          where chr.status == 1
                          select chr;

            foreach (var item in lsPower)
            {
                Models.TotalReward chr = new Models.TotalReward()
                {
                    id = 3000 + (int)item.idPowerUpItems,
                    value = item.name
                };
                lsTotalReward.Add(chr);
            }
        }

        private void LoadDataLUEtypeReward()
        {
            var tmpTypeReward = from stage in ConnectDB.Entities.dbCTTypeRewards
                                select stage;
            lueTypeReward.Properties.DataSource = tmpTypeReward.ToList();
            lueTypeReward.Properties.DisplayMember = "value";
            lueTypeReward.Properties.ValueMember = "id";
        }

        private void lueTypeReward_EditValueChanged(object sender, EventArgs e)
        {
            int num = int.Parse(lueTypeReward.EditValue.ToString());
            slueTypeReward.ReadOnly = false;
            if (num == 1)
            {
                slueTypeReward.Properties.DataSource = lsTotalReward.Where(x => x.id >= 2000 && x.id < 3000).OrderBy(y => y.id).ToList();
                slueTypeReward.EditValue = 2001;
            }
            else if (num == 2 || num == 3)
            {
                slueTypeReward.Properties.DataSource = lsTotalReward.Where(x => x.id > 0 && x.id < 1000).OrderBy(y => y.id).ToList();
                slueTypeReward.EditValue = 1;
            }
            else if (num == 4 || num == 5)
            {
                slueTypeReward.Properties.DataSource = lsTotalReward.Where(x => x.id >= 1000 && x.id < 2000).OrderBy(y => y.id).ToList();
                slueTypeReward.EditValue = 1001;
            }
            else if (num == 6)
            {
                slueTypeReward.Properties.DataSource = lsTotalReward.Where(x => x.id >= 3000).OrderBy(y => y.id).ToList();
                slueTypeReward.EditValue = 3001;
            }
            else
            {
                slueTypeReward.Properties.DataSource = lsTotalReward;
                slueTypeReward.EditValue = 0;
                slueTypeReward.ReadOnly = true;
            }
            slueTypeReward.Properties.DisplayMember = "value";
            slueTypeReward.Properties.ValueMember = "id";
        }

        protected override void OnSave()
        {
            if (txtAmountMax.Text != "" && txtAmountMin.Text != "" && txtProc.Text != "")
            {
                if (mapReward != null)
                {
                    mapReward.procs = double.Parse(txtProc.Text);
                    mapReward.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    mapReward.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    mapReward.amountMin = int.Parse(txtAmountMin.Text);
                    mapReward.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (protectReward != null)
                {
                    protectReward.procs = double.Parse(txtProc.Text);
                    protectReward.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    protectReward.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    protectReward.amountMin = int.Parse(txtAmountMin.Text);
                    protectReward.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (robReward != null)
                {
                    robReward.procs = double.Parse(txtProc.Text);
                    robReward.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    robReward.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    robReward.amountMin = int.Parse(txtAmountMin.Text);
                    robReward.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (rewardThanThap != null)
                {
                    rewardThanThap.procs = double.Parse(txtProc.Text);
                    rewardThanThap.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardThanThap.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardThanThap.amountMin = int.Parse(txtAmountMin.Text);
                    rewardThanThap.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (rewardCauCa != null)
                {
                    rewardCauCa.procs = double.Parse(txtProc.Text);
                    rewardCauCa.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardCauCa.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardCauCa.amountMin = int.Parse(txtAmountMin.Text);
                    rewardCauCa.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (rewardLuanKiem != null)
                {
                    rewardLuanKiem.procs = double.Parse(txtProc.Text);
                    rewardLuanKiem.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardLuanKiem.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardLuanKiem.amountMin = int.Parse(txtAmountMin.Text);
                    rewardLuanKiem.amountMax = int.Parse(txtAmountMin.Text);
                }
                else if (rewardLuaTrai != null)
                {
                    rewardLuaTrai.procs = double.Parse(txtProc.Text);
                    rewardLuaTrai.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardLuaTrai.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardLuaTrai.amountMin = int.Parse(txtAmountMin.Text);
                    rewardLuaTrai.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (rewardBoss != null)
                {
                    rewardBoss.procs = double.Parse(txtProc.Text);
                    rewardBoss.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardBoss.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardBoss.amountMin = int.Parse(txtAmountMin.Text);
                    rewardBoss.amountMax = int.Parse(txtAmountMin.Text);
                }
                else if (rewardNhiemVuHangNgay != null)
                {
                    rewardNhiemVuHangNgay.procs = double.Parse(txtProc.Text);
                    rewardNhiemVuHangNgay.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardNhiemVuHangNgay.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardNhiemVuHangNgay.amountMin = int.Parse(txtAmountMin.Text);
                    rewardNhiemVuHangNgay.amountMax = int.Parse(txtAmountMin.Text);
                }
                else if (rewardStageSupper != null)
                {
                    rewardStageSupper.procs = double.Parse(txtProc.Text);
                    rewardStageSupper.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardStageSupper.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardStageSupper.amountMin = int.Parse(txtAmountMin.Text);
                    rewardStageSupper.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (rewardBangChien != null)
                {
                    rewardBangChien.procs = double.Parse(txtProc.Text);
                    rewardBangChien.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardBangChien.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardBangChien.amountMin = int.Parse(txtAmountMin.Text);
                    rewardBangChien.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (rewardiemDanh != null)
                {
                    rewardiemDanh.procs = double.Parse(txtProc.Text);
                    rewardiemDanh.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardiemDanh.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardiemDanh.amountMin = int.Parse(txtAmountMin.Text);
                    rewardiemDanh.amountMax = int.Parse(txtAmountMin.Text);
                }
                else if (rewardPhucLoi != null)
                {
                    rewardPhucLoi.procs = double.Parse(txtProc.Text);
                    rewardPhucLoi.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardPhucLoi.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardPhucLoi.amountMin = int.Parse(txtAmountMin.Text);
                    rewardPhucLoi.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (rewardLevel != null)
                {
                    rewardLevel.procs = double.Parse(txtProc.Text);
                    rewardLevel.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardLevel.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardLevel.amountMin = int.Parse(txtAmountMin.Text);
                    rewardLevel.amountMax = int.Parse(txtAmountMin.Text);
                }
                else if (rewardFacebook != null)
                {
                    rewardFacebook.procs = double.Parse(txtProc.Text);
                    rewardFacebook.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardFacebook.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardFacebook.amountMin = int.Parse(txtAmountMin.Text);
                    rewardFacebook.amountMax = int.Parse(txtAmountMin.Text);
                }
                else if (rewardMap3Star != null)
                {
                    rewardMap3Star.procs = double.Parse(txtProc.Text);
                    rewardMap3Star.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardMap3Star.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardMap3Star.amountMin = int.Parse(txtAmountMin.Text);
                    rewardMap3Star.amountMax = int.Parse(txtAmountMin.Text);
                }
                else if (rewardCuuCuuChiTon != null)
                {
                    rewardCuuCuuChiTon.procs = double.Parse(txtProc.Text);
                    rewardCuuCuuChiTon.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardCuuCuuChiTon.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardCuuCuuChiTon.amountMin = int.Parse(txtAmountMin.Text);
                    rewardCuuCuuChiTon.amountMax = int.Parse(txtAmountMin.Text);
                }
                else if (rewardPhucLoiTruongThanh != null)
                {
                    rewardPhucLoiTruongThanh.procs = double.Parse(txtProc.Text);
                    rewardPhucLoiTruongThanh.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardPhucLoiTruongThanh.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardPhucLoiTruongThanh.amountMin = int.Parse(txtAmountMin.Text);
                    rewardPhucLoiTruongThanh.amountMax = int.Parse(txtAmountMin.Text);
                }
                else if (rewardRuongBau != null)
                {
                    rewardRuongBau.procs = double.Parse(txtProc.Text);
                    rewardRuongBau.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardRuongBau.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardRuongBau.amountMin = int.Parse(txtAmountMin.Text);
                    rewardRuongBau.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (rewardTaoNick != null)
                {
                    rewardTaoNick.procs = double.Parse(txtProc.Text);
                    rewardTaoNick.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardTaoNick.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardTaoNick.amountMin = int.Parse(txtAmountMin.Text);
                    rewardTaoNick.amountMax = int.Parse(txtAmountMin.Text);
                }
                else if (rewardBossReward != null)
                {
                    rewardBossReward.procs = double.Parse(txtProc.Text);
                    rewardBossReward.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardBossReward.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardBossReward.amountMin = int.Parse(txtAmountMin.Text);
                    rewardBossReward.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (rewardInvite != null)
                {
                    rewardInvite.procs = double.Parse(txtProc.Text);
                    rewardInvite.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardInvite.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardInvite.amountMin = int.Parse(txtAmountMin.Text);
                    rewardInvite.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (rewardWinLuanKiem != null)
                {
                    rewardWinLuanKiem.procs = double.Parse(txtProc.Text);
                    rewardWinLuanKiem.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardWinLuanKiem.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardWinLuanKiem.amountMin = int.Parse(txtAmountMin.Text);
                    rewardWinLuanKiem.amountMax = int.Parse(txtAmountMax.Text);
                }
                else if (rewardLoseReward != null)
                {
                    rewardLoseReward.procs = double.Parse(txtProc.Text);
                    rewardLoseReward.staticID = int.Parse(slueTypeReward.EditValue.ToString());
                    rewardLoseReward.typeReward = int.Parse(lueTypeReward.EditValue.ToString());
                    rewardLoseReward.amountMin = int.Parse(txtAmountMin.Text);
                    rewardLoseReward.amountMax = int.Parse(txtAmountMax.Text);
                }
                this.Close();
            }
            else
            {
                CommonShowDialog.ShowErrorDialog("Không được để textbox trống!");
            }
        }
    }
}