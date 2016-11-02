namespace KDQHDesignerTool.Form
{
    partial class frmPhucLoiTruongThanh
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
            this.dbPhucLoiTruongThanhConfigBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colruby_require = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colduration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.dbPhucLoiTruongThanhLevelRewardBindingSource = new System.Windows.Forms.BindingSource();
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypeReward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource();
            this.colstaticID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colamountMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colamountMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprocs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnDeleteLevel = new DevExpress.XtraEditors.SimpleButton();
            this.gcLevel = new DevExpress.XtraGrid.GridControl();
            this.dbPhucLoiTruongThanhLevelBindingSource = new System.Windows.Forms.BindingSource();
            this.gvLevel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collevels = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddLevel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcThongTin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPhucLoiTruongThanhConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPhucLoiTruongThanhLevelRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPhucLoiTruongThanhLevelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcThongTin);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(909, 87);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Thông tin ";
            // 
            // gcThongTin
            // 
            this.gcThongTin.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcThongTin.DataSource = this.dbPhucLoiTruongThanhConfigBindingSource;
            this.gcThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcThongTin.Location = new System.Drawing.Point(2, 21);
            this.gcThongTin.MainView = this.gridView1;
            this.gcThongTin.Name = "gcThongTin";
            this.gcThongTin.Size = new System.Drawing.Size(905, 64);
            this.gcThongTin.TabIndex = 0;
            this.gcThongTin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dbPhucLoiTruongThanhConfigBindingSource
            // 
            this.dbPhucLoiTruongThanhConfigBindingSource.DataSource = typeof(KDQHDesignerTool.dbPhucLoiTruongThanhConfig);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colruby_require,
            this.colduration});
            this.gridView1.GridControl = this.gcThongTin;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colruby_require
            // 
            this.colruby_require.Caption = "Số kim cương yêu cầu";
            this.colruby_require.FieldName = "ruby_require";
            this.colruby_require.Name = "colruby_require";
            this.colruby_require.Visible = true;
            this.colruby_require.VisibleIndex = 0;
            // 
            // colduration
            // 
            this.colduration.Caption = "Thời gian tồn tại tính từ ngày tạo tài khoản";
            this.colduration.FieldName = "duration";
            this.colduration.Name = "colduration";
            this.colduration.Visible = true;
            this.colduration.VisibleIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDelete);
            this.groupControl2.Controls.Add(this.btnAdd);
            this.groupControl2.Controls.Add(this.gcReward);
            this.groupControl2.Location = new System.Drawing.Point(250, 133);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(655, 438);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Vật phẩm nhận được";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::KDQHDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete.Location = new System.Drawing.Point(627, 53);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::KDQHDesignerTool.Properties.Resources.compose16x161;
            this.btnAdd.Location = new System.Drawing.Point(627, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gcReward
            // 
            this.gcReward.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcReward.DataSource = this.dbPhucLoiTruongThanhLevelRewardBindingSource;
            this.gcReward.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcReward.Location = new System.Drawing.Point(2, 21);
            this.gcReward.MainView = this.gvReward;
            this.gcReward.Name = "gcReward";
            this.gcReward.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueTypeReward,
            this.lueStaticID});
            this.gcReward.Size = new System.Drawing.Size(619, 415);
            this.gcReward.TabIndex = 0;
            this.gcReward.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReward});
            // 
            // dbPhucLoiTruongThanhLevelRewardBindingSource
            // 
            this.dbPhucLoiTruongThanhLevelRewardBindingSource.DataSource = typeof(KDQHDesignerTool.dbPhucLoiTruongThanhLevelReward);
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
            this.coltypeReward.Width = 143;
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
            // dbCTAfflictionBindingSource
            // 
            this.dbCTAfflictionBindingSource.DataSource = typeof(KDQHDesignerTool.dbCTAffliction);
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
            this.colstaticID.Width = 239;
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
            // 
            // colamountMin
            // 
            this.colamountMin.Caption = "SL Min";
            this.colamountMin.FieldName = "amountMin";
            this.colamountMin.Name = "colamountMin";
            this.colamountMin.OptionsColumn.AllowEdit = false;
            this.colamountMin.Visible = true;
            this.colamountMin.VisibleIndex = 2;
            this.colamountMin.Width = 71;
            // 
            // colamountMax
            // 
            this.colamountMax.Caption = "SL Max";
            this.colamountMax.FieldName = "amountMax";
            this.colamountMax.Name = "colamountMax";
            this.colamountMax.OptionsColumn.AllowEdit = false;
            this.colamountMax.Visible = true;
            this.colamountMax.VisibleIndex = 3;
            this.colamountMax.Width = 71;
            // 
            // colprocs
            // 
            this.colprocs.Caption = "Tỷ lệ";
            this.colprocs.FieldName = "procs";
            this.colprocs.Name = "colprocs";
            this.colprocs.OptionsColumn.AllowEdit = false;
            this.colprocs.Visible = true;
            this.colprocs.VisibleIndex = 4;
            this.colprocs.Width = 79;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnDeleteLevel);
            this.groupControl3.Controls.Add(this.gcLevel);
            this.groupControl3.Controls.Add(this.btnAddLevel);
            this.groupControl3.Location = new System.Drawing.Point(2, 133);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(242, 438);
            this.groupControl3.TabIndex = 5;
            this.groupControl3.Text = "Mốc Level";
            // 
            // btnDeleteLevel
            // 
            this.btnDeleteLevel.Image = global::KDQHDesignerTool.Properties.Resources.denied16x16;
            this.btnDeleteLevel.Location = new System.Drawing.Point(214, 53);
            this.btnDeleteLevel.Name = "btnDeleteLevel";
            this.btnDeleteLevel.Size = new System.Drawing.Size(23, 23);
            this.btnDeleteLevel.TabIndex = 1;
            this.btnDeleteLevel.Click += new System.EventHandler(this.btnDeleteLevel_Click);
            // 
            // gcLevel
            // 
            this.gcLevel.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcLevel.DataSource = this.dbPhucLoiTruongThanhLevelBindingSource;
            this.gcLevel.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcLevel.Location = new System.Drawing.Point(2, 21);
            this.gcLevel.MainView = this.gvLevel;
            this.gcLevel.Name = "gcLevel";
            this.gcLevel.Size = new System.Drawing.Size(206, 415);
            this.gcLevel.TabIndex = 0;
            this.gcLevel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLevel});
            // 
            // dbPhucLoiTruongThanhLevelBindingSource
            // 
            this.dbPhucLoiTruongThanhLevelBindingSource.DataSource = typeof(KDQHDesignerTool.dbPhucLoiTruongThanhLevel);
            // 
            // gvLevel
            // 
            this.gvLevel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid2,
            this.collevels});
            this.gvLevel.GridControl = this.gcLevel;
            this.gvLevel.Name = "gvLevel";
            this.gvLevel.OptionsView.ShowGroupPanel = false;
            this.gvLevel.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvLevel_FocusedRowChanged);
            // 
            // colid2
            // 
            this.colid2.FieldName = "id";
            this.colid2.Name = "colid2";
            // 
            // collevels
            // 
            this.collevels.Caption = "Level";
            this.collevels.FieldName = "levels";
            this.collevels.Name = "collevels";
            this.collevels.Visible = true;
            this.collevels.VisibleIndex = 0;
            // 
            // btnAddLevel
            // 
            this.btnAddLevel.Image = global::KDQHDesignerTool.Properties.Resources.compose16x161;
            this.btnAddLevel.Location = new System.Drawing.Point(214, 24);
            this.btnAddLevel.Name = "btnAddLevel";
            this.btnAddLevel.Size = new System.Drawing.Size(23, 23);
            this.btnAddLevel.TabIndex = 1;
            this.btnAddLevel.Click += new System.EventHandler(this.btnAddLevel_Click);
            // 
            // frmPhucLoiTruongThanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 577);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmPhucLoiTruongThanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phúc lợi trưởng thành";
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            this.Controls.SetChildIndex(this.groupControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcThongTin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPhucLoiTruongThanhConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPhucLoiTruongThanhLevelRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPhucLoiTruongThanhLevelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gcThongTin;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gcReward;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colruby_require;
        private DevExpress.XtraGrid.Columns.GridColumn colduration;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn coltypeReward;
        private DevExpress.XtraGrid.Columns.GridColumn colstaticID;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMin;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMax;
        private DevExpress.XtraGrid.Columns.GridColumn colprocs;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueStaticID;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnDeleteLevel;
        private DevExpress.XtraGrid.GridControl gcLevel;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLevel;
        private DevExpress.XtraEditors.SimpleButton btnAddLevel;
        private System.Windows.Forms.BindingSource dbPhucLoiTruongThanhConfigBindingSource;
        private System.Windows.Forms.BindingSource dbPhucLoiTruongThanhLevelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid2;
        private DevExpress.XtraGrid.Columns.GridColumn collevels;
        private System.Windows.Forms.BindingSource dbPhucLoiTruongThanhLevelRewardBindingSource;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
    }
}