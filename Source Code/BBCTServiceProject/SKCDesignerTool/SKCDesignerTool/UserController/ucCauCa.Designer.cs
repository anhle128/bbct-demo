namespace BBCTDesignerTool.UserController
{
    partial class ucCauCa
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd2 = new DevExpress.XtraEditors.SimpleButton();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.dbCauCaRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypeReward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTTypeRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colstaticID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colamountMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colamountMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprocs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete1 = new DevExpress.XtraEditors.SimpleButton();
            this.gcChung = new DevExpress.XtraGrid.GridControl();
            this.dbCauCaConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvChung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgold = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsilver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvipRequire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colduration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCauCaRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTTypeRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCauCaConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChung)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDelete2);
            this.groupControl1.Controls.Add(this.btnAdd2);
            this.groupControl1.Controls.Add(this.gcReward);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(767, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(599, 442);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Quà nhận được của cần câu";
            // 
            // btnDelete2
            // 
            this.btnDelete2.Image = global::BBCTDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete2.Location = new System.Drawing.Point(571, 53);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(23, 23);
            this.btnDelete2.TabIndex = 1;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = global::BBCTDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd2.Location = new System.Drawing.Point(571, 24);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(23, 23);
            this.btnAdd2.TabIndex = 1;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // gcReward
            // 
            this.gcReward.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcReward.DataSource = this.dbCauCaRewardBindingSource;
            this.gcReward.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcReward.Location = new System.Drawing.Point(2, 21);
            this.gcReward.MainView = this.gvReward;
            this.gcReward.Name = "gcReward";
            this.gcReward.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueTypeReward,
            this.lueStaticID});
            this.gcReward.Size = new System.Drawing.Size(563, 419);
            this.gcReward.TabIndex = 0;
            this.gcReward.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReward});
            // 
            // dbCauCaRewardBindingSource
            // 
            this.dbCauCaRewardBindingSource.DataSource = typeof(BBCTDesignerTool.dbCauCaReward);
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
            this.coltypeReward.Width = 98;
            // 
            // lueTypeReward
            // 
            this.lueTypeReward.AutoHeight = false;
            this.lueTypeReward.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeReward.DataSource = this.dbCTTypeRewardBindingSource;
            this.lueTypeReward.DisplayMember = "value";
            this.lueTypeReward.Name = "lueTypeReward";
            this.lueTypeReward.ValueMember = "id";
            // 
            // dbCTTypeRewardBindingSource
            // 
            this.dbCTTypeRewardBindingSource.DataSource = typeof(BBCTDesignerTool.dbCTTypeReward);
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
            this.colstaticID.Width = 184;
            // 
            // lueStaticID
            // 
            this.lueStaticID.AutoHeight = false;
            this.lueStaticID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStaticID.DataSource = this.dbCTTypeRewardBindingSource;
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
            this.colamountMin.Caption = "S.L Min";
            this.colamountMin.FieldName = "amountMin";
            this.colamountMin.Name = "colamountMin";
            this.colamountMin.OptionsColumn.AllowEdit = false;
            this.colamountMin.Visible = true;
            this.colamountMin.VisibleIndex = 2;
            this.colamountMin.Width = 74;
            // 
            // colamountMax
            // 
            this.colamountMax.Caption = "S.L Max";
            this.colamountMax.FieldName = "amountMax";
            this.colamountMax.Name = "colamountMax";
            this.colamountMax.OptionsColumn.AllowEdit = false;
            this.colamountMax.Visible = true;
            this.colamountMax.VisibleIndex = 3;
            // 
            // colprocs
            // 
            this.colprocs.Caption = "Tỷ lệ";
            this.colprocs.FieldName = "procs";
            this.colprocs.Name = "colprocs";
            this.colprocs.OptionsColumn.AllowEdit = false;
            this.colprocs.Visible = true;
            this.colprocs.VisibleIndex = 4;
            this.colprocs.Width = 41;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDelete1);
            this.groupControl2.Controls.Add(this.gcChung);
            this.groupControl2.Controls.Add(this.btnAdd1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 40);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(767, 442);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Danh sách cần câu";
            // 
            // btnDelete1
            // 
            this.btnDelete1.Image = global::BBCTDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete1.Location = new System.Drawing.Point(724, 53);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(23, 23);
            this.btnDelete1.TabIndex = 1;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // gcChung
            // 
            this.gcChung.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcChung.DataSource = this.dbCauCaConfigBindingSource;
            this.gcChung.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcChung.Location = new System.Drawing.Point(2, 21);
            this.gcChung.MainView = this.gvChung;
            this.gcChung.Name = "gcChung";
            this.gcChung.Size = new System.Drawing.Size(716, 419);
            this.gcChung.TabIndex = 0;
            this.gcChung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChung});
            // 
            // dbCauCaConfigBindingSource
            // 
            this.dbCauCaConfigBindingSource.DataSource = typeof(BBCTDesignerTool.dbCauCaConfig);
            // 
            // gvChung
            // 
            this.gvChung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colname,
            this.colgold,
            this.colsilver,
            this.colvipRequire,
            this.colduration});
            this.gvChung.GridControl = this.gcChung;
            this.gvChung.Name = "gvChung";
            this.gvChung.OptionsView.ShowGroupPanel = false;
            this.gvChung.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvChung_FocusedRowChanged);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colname
            // 
            this.colname.Caption = "Tên cần câu";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 0;
            this.colname.Width = 294;
            // 
            // colgold
            // 
            this.colgold.Caption = "KNB";
            this.colgold.FieldName = "gold";
            this.colgold.Name = "colgold";
            this.colgold.Visible = true;
            this.colgold.VisibleIndex = 1;
            this.colgold.Width = 120;
            // 
            // colsilver
            // 
            this.colsilver.Caption = "Bạc";
            this.colsilver.FieldName = "silver";
            this.colsilver.Name = "colsilver";
            this.colsilver.Visible = true;
            this.colsilver.VisibleIndex = 2;
            this.colsilver.Width = 120;
            // 
            // colvipRequire
            // 
            this.colvipRequire.Caption = "Vip yêu cầu";
            this.colvipRequire.FieldName = "vipRequire";
            this.colvipRequire.Name = "colvipRequire";
            this.colvipRequire.Visible = true;
            this.colvipRequire.VisibleIndex = 3;
            this.colvipRequire.Width = 120;
            // 
            // colduration
            // 
            this.colduration.Caption = "Thời gian tồn tại";
            this.colduration.FieldName = "duration";
            this.colduration.Name = "colduration";
            this.colduration.Visible = true;
            this.colduration.VisibleIndex = 4;
            this.colduration.Width = 126;
            // 
            // btnAdd1
            // 
            this.btnAdd1.Image = global::BBCTDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd1.Location = new System.Drawing.Point(724, 24);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(23, 23);
            this.btnAdd1.TabIndex = 1;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // ucCauCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "ucCauCa";
            this.Size = new System.Drawing.Size(1366, 482);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCauCaRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTTypeRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcChung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCauCaConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gcReward;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private DevExpress.XtraGrid.GridControl gcChung;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChung;
        private DevExpress.XtraEditors.SimpleButton btnDelete2;
        private DevExpress.XtraEditors.SimpleButton btnAdd2;
        private DevExpress.XtraEditors.SimpleButton btnDelete1;
        private DevExpress.XtraEditors.SimpleButton btnAdd1;
        private System.Windows.Forms.BindingSource dbCauCaConfigBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn colgold;
        private DevExpress.XtraGrid.Columns.GridColumn colsilver;
        private DevExpress.XtraGrid.Columns.GridColumn colvipRequire;
        private DevExpress.XtraGrid.Columns.GridColumn colduration;
        private System.Windows.Forms.BindingSource dbCauCaRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn coltypeReward;
        private DevExpress.XtraGrid.Columns.GridColumn colstaticID;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMin;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMax;
        private DevExpress.XtraGrid.Columns.GridColumn colprocs;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private System.Windows.Forms.BindingSource dbCTTypeRewardBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueStaticID;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
    }
}
