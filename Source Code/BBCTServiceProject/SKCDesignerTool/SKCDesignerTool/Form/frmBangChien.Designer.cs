namespace BBCTDesignerTool.Form
{
    partial class frmBangChien
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcThongTin = new DevExpress.XtraGrid.GridControl();
            this.dbGuildConfigBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhourStartBangChien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colminuteStartBangChien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldayOfWeekBangChien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueNgay = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource();
            this.colminuteDurationBattleBangChien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colwaitTimeBangChien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.dbGuildRewardBangChienBindingSource = new System.Windows.Forms.BindingSource();
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypeReward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colstaticID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colamountMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colamountMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprocs = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcThongTin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGuildConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGuildRewardBangChienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcThongTin);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(884, 100);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Thông tin bang chiến";
            // 
            // gcThongTin
            // 
            this.gcThongTin.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcThongTin.DataSource = this.dbGuildConfigBindingSource;
            this.gcThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcThongTin.Location = new System.Drawing.Point(2, 21);
            this.gcThongTin.MainView = this.gridView1;
            this.gcThongTin.Name = "gcThongTin";
            this.gcThongTin.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueNgay});
            this.gcThongTin.Size = new System.Drawing.Size(880, 77);
            this.gcThongTin.TabIndex = 0;
            this.gcThongTin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dbGuildConfigBindingSource
            // 
            this.dbGuildConfigBindingSource.DataSource = typeof(BBCTDesignerTool.dbGuildConfig);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colhourStartBangChien,
            this.colminuteStartBangChien,
            this.coldayOfWeekBangChien,
            this.colminuteDurationBattleBangChien,
            this.colwaitTimeBangChien,
            this.gridColumn1});
            this.gridView1.GridControl = this.gcThongTin;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colhourStartBangChien
            // 
            this.colhourStartBangChien.Caption = "Giờ bắt đầu";
            this.colhourStartBangChien.FieldName = "hourStartBangChien";
            this.colhourStartBangChien.Name = "colhourStartBangChien";
            this.colhourStartBangChien.Visible = true;
            this.colhourStartBangChien.VisibleIndex = 1;
            // 
            // colminuteStartBangChien
            // 
            this.colminuteStartBangChien.Caption = "Phú bắt đầu";
            this.colminuteStartBangChien.FieldName = "minuteStartBangChien";
            this.colminuteStartBangChien.Name = "colminuteStartBangChien";
            this.colminuteStartBangChien.Visible = true;
            this.colminuteStartBangChien.VisibleIndex = 2;
            // 
            // coldayOfWeekBangChien
            // 
            this.coldayOfWeekBangChien.Caption = "Ngày diễn ra";
            this.coldayOfWeekBangChien.ColumnEdit = this.lueNgay;
            this.coldayOfWeekBangChien.FieldName = "dayOfWeekBangChien";
            this.coldayOfWeekBangChien.Name = "coldayOfWeekBangChien";
            this.coldayOfWeekBangChien.Visible = true;
            this.coldayOfWeekBangChien.VisibleIndex = 0;
            // 
            // lueNgay
            // 
            this.lueNgay.AutoHeight = false;
            this.lueNgay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueNgay.DataSource = this.dbCTAfflictionBindingSource;
            this.lueNgay.DisplayMember = "value";
            this.lueNgay.Name = "lueNgay";
            this.lueNgay.ValueMember = "id";
            // 
            // dbCTAfflictionBindingSource
            // 
            this.dbCTAfflictionBindingSource.DataSource = typeof(BBCTDesignerTool.dbCTAffliction);
            // 
            // colminuteDurationBattleBangChien
            // 
            this.colminuteDurationBattleBangChien.Caption = "Thời gian trận đấu bang";
            this.colminuteDurationBattleBangChien.FieldName = "minuteDurationBattleBangChien";
            this.colminuteDurationBattleBangChien.Name = "colminuteDurationBattleBangChien";
            this.colminuteDurationBattleBangChien.Visible = true;
            this.colminuteDurationBattleBangChien.VisibleIndex = 3;
            // 
            // colwaitTimeBangChien
            // 
            this.colwaitTimeBangChien.Caption = "Thời gian chờ";
            this.colwaitTimeBangChien.FieldName = "waitTimeBangChien";
            this.colwaitTimeBangChien.Name = "colwaitTimeBangChien";
            this.colwaitTimeBangChien.Visible = true;
            this.colwaitTimeBangChien.VisibleIndex = 4;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Min member/ bang ";
            this.gridColumn1.FieldName = "bangChienMinMember";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDelete1);
            this.groupControl2.Controls.Add(this.btnAdd);
            this.groupControl2.Controls.Add(this.gcReward);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 140);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(884, 375);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Quà bang chiến";
            // 
            // btnDelete1
            // 
            this.btnDelete1.Image = global::BBCTDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete1.Location = new System.Drawing.Point(856, 53);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(23, 23);
            this.btnDelete1.TabIndex = 1;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::BBCTDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd.Location = new System.Drawing.Point(856, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gcReward
            // 
            this.gcReward.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcReward.DataSource = this.dbGuildRewardBangChienBindingSource;
            this.gcReward.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcReward.Location = new System.Drawing.Point(2, 21);
            this.gcReward.MainView = this.gvReward;
            this.gcReward.Name = "gcReward";
            this.gcReward.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueTypeReward,
            this.lueStaticID});
            this.gcReward.Size = new System.Drawing.Size(848, 352);
            this.gcReward.TabIndex = 0;
            this.gcReward.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReward});
            // 
            // dbGuildRewardBangChienBindingSource
            // 
            this.dbGuildRewardBangChienBindingSource.DataSource = typeof(BBCTDesignerTool.dbGuildRewardBangChien);
            // 
            // gvReward
            // 
            this.gvReward.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid1,
            this.coltypeReward,
            this.colstaticID,
            this.colamountMin,
            this.colamountMax,
            this.colprocs});
            this.gvReward.GridControl = this.gcReward;
            this.gvReward.Name = "gvReward";
            this.gvReward.OptionsView.ShowGroupPanel = false;
            this.gvReward.DoubleClick += new System.EventHandler(this.gvReward_DoubleClick);
            // 
            // colid1
            // 
            this.colid1.FieldName = "id";
            this.colid1.Name = "colid1";
            // 
            // coltypeReward
            // 
            this.coltypeReward.Caption = "Loại";
            this.coltypeReward.ColumnEdit = this.lueTypeReward;
            this.coltypeReward.FieldName = "typeReward";
            this.coltypeReward.Name = "coltypeReward";
            this.coltypeReward.OptionsColumn.AllowEdit = false;
            this.coltypeReward.Visible = true;
            this.coltypeReward.VisibleIndex = 0;
            this.coltypeReward.Width = 166;
            // 
            // lueTypeReward
            // 
            this.lueTypeReward.AutoHeight = false;
            this.lueTypeReward.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeReward.DataSource = this.dbCTAfflictionBindingSource;
            this.lueTypeReward.DisplayMember = "value";
            this.lueTypeReward.Name = "lueTypeReward";
            this.lueTypeReward.ValueMember = "id";
            // 
            // colstaticID
            // 
            this.colstaticID.Caption = "Vật phẩm";
            this.colstaticID.ColumnEdit = this.lueStaticID;
            this.colstaticID.FieldName = "staticID";
            this.colstaticID.Name = "colstaticID";
            this.colstaticID.OptionsColumn.AllowEdit = false;
            this.colstaticID.Visible = true;
            this.colstaticID.VisibleIndex = 1;
            this.colstaticID.Width = 282;
            // 
            // lueStaticID
            // 
            this.lueStaticID.AutoHeight = false;
            this.lueStaticID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStaticID.DataSource = this.dbCTAfflictionBindingSource;
            this.lueStaticID.DisplayMember = "value";
            this.lueStaticID.Name = "lueStaticID";
            this.lueStaticID.ValueMember = "id";
            this.lueStaticID.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colamountMin
            // 
            this.colamountMin.Caption = "SL Min";
            this.colamountMin.FieldName = "amountMin";
            this.colamountMin.Name = "colamountMin";
            this.colamountMin.OptionsColumn.AllowEdit = false;
            this.colamountMin.Visible = true;
            this.colamountMin.VisibleIndex = 2;
            this.colamountMin.Width = 127;
            // 
            // colamountMax
            // 
            this.colamountMax.Caption = "SL Max";
            this.colamountMax.FieldName = "amountMax";
            this.colamountMax.Name = "colamountMax";
            this.colamountMax.OptionsColumn.AllowEdit = false;
            this.colamountMax.Visible = true;
            this.colamountMax.VisibleIndex = 3;
            this.colamountMax.Width = 127;
            // 
            // colprocs
            // 
            this.colprocs.Caption = "Tỷ lệ";
            this.colprocs.FieldName = "procs";
            this.colprocs.Name = "colprocs";
            this.colprocs.OptionsColumn.AllowEdit = false;
            this.colprocs.Visible = true;
            this.colprocs.VisibleIndex = 4;
            this.colprocs.Width = 130;
            // 
            // frmBangChien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 515);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmBangChien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bang chiến";
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcThongTin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGuildConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGuildRewardBangChienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gcThongTin;
        private System.Windows.Forms.BindingSource dbGuildConfigBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colhourStartBangChien;
        private DevExpress.XtraGrid.Columns.GridColumn colminuteStartBangChien;
        private DevExpress.XtraGrid.Columns.GridColumn coldayOfWeekBangChien;
        private DevExpress.XtraGrid.Columns.GridColumn colminuteDurationBattleBangChien;
        private DevExpress.XtraGrid.Columns.GridColumn colwaitTimeBangChien;
        private DevExpress.XtraEditors.SimpleButton btnDelete1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl gcReward;
        private System.Windows.Forms.BindingSource dbGuildRewardBangChienBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn coltypeReward;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colstaticID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueStaticID;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMin;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMax;
        private DevExpress.XtraGrid.Columns.GridColumn colprocs;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueNgay;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}