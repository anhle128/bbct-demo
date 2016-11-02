namespace KDQHDesignerTool.UserController
{
    partial class ucVipConfig
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gcVip = new DevExpress.XtraGrid.GridControl();
            this.dbVipConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvVip = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgoldRequire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colarenaTimes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colchallengeTimes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colresetStageTimes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcVip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbVipConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVip)).BeginInit();
            this.SuspendLayout();
            // 
            // gcVip
            // 
            this.gcVip.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcVip.DataSource = this.dbVipConfigBindingSource;
            this.gcVip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcVip.Location = new System.Drawing.Point(0, 40);
            this.gcVip.MainView = this.gvVip;
            this.gcVip.Name = "gcVip";
            this.gcVip.Size = new System.Drawing.Size(1366, 434);
            this.gcVip.TabIndex = 4;
            this.gcVip.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVip});
            // 
            // dbVipConfigBindingSource
            // 
            this.dbVipConfigBindingSource.DataSource = typeof(KDQHDesignerTool.dbVipConfig);
            // 
            // gvVip
            // 
            this.gvVip.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colgoldRequire,
            this.colarenaTimes,
            this.colchallengeTimes,
            this.colresetStageTimes,
            this.colvip,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gvVip.GridControl = this.gcVip;
            this.gvVip.Name = "gvVip";
            this.gvVip.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colgoldRequire
            // 
            this.colgoldRequire.Caption = "Kim cương yêu cầu lên Vip";
            this.colgoldRequire.FieldName = "goldRequire";
            this.colgoldRequire.Name = "colgoldRequire";
            this.colgoldRequire.Visible = true;
            this.colgoldRequire.VisibleIndex = 1;
            this.colgoldRequire.Width = 157;
            // 
            // colarenaTimes
            // 
            this.colarenaTimes.Caption = "Số lần Đánh luận kiếm";
            this.colarenaTimes.FieldName = "arenaTimes";
            this.colarenaTimes.Name = "colarenaTimes";
            this.colarenaTimes.Visible = true;
            this.colarenaTimes.VisibleIndex = 2;
            this.colarenaTimes.Width = 134;
            // 
            // colchallengeTimes
            // 
            this.colchallengeTimes.Caption = "Số lần Thách đấu";
            this.colchallengeTimes.FieldName = "challengeTimes";
            this.colchallengeTimes.Name = "colchallengeTimes";
            this.colchallengeTimes.Visible = true;
            this.colchallengeTimes.VisibleIndex = 3;
            this.colchallengeTimes.Width = 116;
            // 
            // colresetStageTimes
            // 
            this.colresetStageTimes.Caption = "Số lần làm mới Stage";
            this.colresetStageTimes.FieldName = "resetStageTimes";
            this.colresetStageTimes.Name = "colresetStageTimes";
            this.colresetStageTimes.Visible = true;
            this.colresetStageTimes.VisibleIndex = 4;
            this.colresetStageTimes.Width = 125;
            // 
            // colvip
            // 
            this.colvip.Caption = "VIP";
            this.colvip.FieldName = "vip";
            this.colvip.Name = "colvip";
            this.colvip.OptionsColumn.AllowEdit = false;
            this.colvip.Visible = true;
            this.colvip.VisibleIndex = 0;
            this.colvip.Width = 36;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số lần Vận tiêu";
            this.gridColumn1.FieldName = "vanTieuTimes";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 102;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Số lần Mời rượu";
            this.gridColumn2.FieldName = "moiRuouTimes";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 8;
            this.gridColumn2.Width = 133;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Số lần Cướp tiêu";
            this.gridColumn3.FieldName = "cuopTieuTimes";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 9;
            this.gridColumn3.Width = 140;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Số Item tối đa bán trên Market";
            this.gridColumn4.FieldName = "maxSellMarket";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 10;
            this.gridColumn4.Width = 225;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Câu cá";
            this.gridColumn5.FieldName = "cauCaTimes";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 79;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Đổ phường";
            this.gridColumn6.FieldName = "doPhuongTimes";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 101;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Hứa nguyện";
            this.gridColumn7.FieldName = "huaNguyenTimes";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 11;
            this.gridColumn7.Width = 86;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Mua điểm skill";
            this.gridColumn8.FieldName = "buyPointSkillTimes";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 12;
            this.gridColumn8.Width = 103;
            // 
            // ucVipConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcVip);
            this.Name = "ucVipConfig";
            this.Size = new System.Drawing.Size(1366, 474);
            this.Controls.SetChildIndex(this.gcVip, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcVip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbVipConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcVip;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVip;
        private System.Windows.Forms.BindingSource dbVipConfigBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colgoldRequire;
        private DevExpress.XtraGrid.Columns.GridColumn colarenaTimes;
        private DevExpress.XtraGrid.Columns.GridColumn colchallengeTimes;
        private DevExpress.XtraGrid.Columns.GridColumn colresetStageTimes;
        private DevExpress.XtraGrid.Columns.GridColumn colvip;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}
