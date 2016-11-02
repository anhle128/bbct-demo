namespace KDQHDesignerTool.Form
{
    partial class frmLuanKiemWinReward
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
            this.components = new System.ComponentModel.Container();
            this.gcThang = new DevExpress.XtraGrid.GridControl();
            this.dbLuanKiemWinRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvThang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypeReward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colstaticID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colamountMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colamountMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprocs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd2 = new DevExpress.XtraEditors.SimpleButton();
            this.gcThua = new DevExpress.XtraGrid.GridControl();
            this.dbLuanKiemLoseRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvThua = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypeReward1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeRewardLose = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colstaticID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticIDLose = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colamountMin1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colamountMax1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprocs1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbLuanKiemWinRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcThua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbLuanKiemLoseRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeRewardLose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticIDLose)).BeginInit();
            this.SuspendLayout();
            // 
            // gcThang
            // 
            this.gcThang.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcThang.DataSource = this.dbLuanKiemWinRewardBindingSource;
            this.gcThang.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcThang.Location = new System.Drawing.Point(2, 21);
            this.gcThang.MainView = this.gvThang;
            this.gcThang.Name = "gcThang";
            this.gcThang.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueTypeReward,
            this.lueStaticID});
            this.gcThang.Size = new System.Drawing.Size(532, 335);
            this.gcThang.TabIndex = 4;
            this.gcThang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvThang});
            // 
            // dbLuanKiemWinRewardBindingSource
            // 
            this.dbLuanKiemWinRewardBindingSource.DataSource = typeof(KDQHDesignerTool.dbLuanKiemWinReward);
            // 
            // gvThang
            // 
            this.gvThang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.coltypeReward,
            this.colstaticID,
            this.colamountMin,
            this.colamountMax,
            this.colprocs});
            this.gvThang.GridControl = this.gcThang;
            this.gvThang.Name = "gvThang";
            this.gvThang.OptionsView.ShowGroupPanel = false;
            this.gvThang.DoubleClick += new System.EventHandler(this.gvThang_DoubleClick);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
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
            this.coltypeReward.Width = 126;
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
            this.colstaticID.Width = 210;
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
            this.colamountMin.Caption = "S.L Min";
            this.colamountMin.FieldName = "amountMin";
            this.colamountMin.Name = "colamountMin";
            this.colamountMin.OptionsColumn.AllowEdit = false;
            this.colamountMin.Visible = true;
            this.colamountMin.VisibleIndex = 2;
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
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDelete1);
            this.groupControl1.Controls.Add(this.btnAdd1);
            this.groupControl1.Controls.Add(this.gcThang);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(568, 358);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Quà thắng";
            // 
            // btnDelete1
            // 
            this.btnDelete1.Image = global::KDQHDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete1.Location = new System.Drawing.Point(540, 53);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(23, 23);
            this.btnDelete1.TabIndex = 5;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.Image = global::KDQHDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd1.Location = new System.Drawing.Point(540, 24);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(23, 23);
            this.btnAdd1.TabIndex = 5;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDelete2);
            this.groupControl2.Controls.Add(this.btnAdd2);
            this.groupControl2.Controls.Add(this.gcThua);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl2.Location = new System.Drawing.Point(576, 40);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(569, 358);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Quà thua";
            // 
            // btnDelete2
            // 
            this.btnDelete2.Image = global::KDQHDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete2.Location = new System.Drawing.Point(540, 53);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(23, 23);
            this.btnDelete2.TabIndex = 5;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = global::KDQHDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd2.Location = new System.Drawing.Point(540, 24);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(23, 23);
            this.btnAdd2.TabIndex = 5;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // gcThua
            // 
            this.gcThua.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcThua.DataSource = this.dbLuanKiemLoseRewardBindingSource;
            this.gcThua.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcThua.Location = new System.Drawing.Point(2, 21);
            this.gcThua.MainView = this.gvThua;
            this.gcThua.Name = "gcThua";
            this.gcThua.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueTypeRewardLose,
            this.lueStaticIDLose});
            this.gcThua.Size = new System.Drawing.Size(532, 335);
            this.gcThua.TabIndex = 4;
            this.gcThua.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvThua});
            // 
            // dbLuanKiemLoseRewardBindingSource
            // 
            this.dbLuanKiemLoseRewardBindingSource.DataSource = typeof(KDQHDesignerTool.dbLuanKiemLoseReward);
            // 
            // gvThua
            // 
            this.gvThua.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid1,
            this.coltypeReward1,
            this.colstaticID1,
            this.colamountMin1,
            this.colamountMax1,
            this.colprocs1});
            this.gvThua.GridControl = this.gcThua;
            this.gvThua.Name = "gvThua";
            this.gvThua.OptionsView.ShowGroupPanel = false;
            this.gvThua.DoubleClick += new System.EventHandler(this.gvThua_DoubleClick);
            // 
            // colid1
            // 
            this.colid1.FieldName = "id";
            this.colid1.Name = "colid1";
            // 
            // coltypeReward1
            // 
            this.coltypeReward1.Caption = "Loại";
            this.coltypeReward1.ColumnEdit = this.lueTypeRewardLose;
            this.coltypeReward1.FieldName = "typeReward";
            this.coltypeReward1.Name = "coltypeReward1";
            this.coltypeReward1.OptionsColumn.AllowEdit = false;
            this.coltypeReward1.Visible = true;
            this.coltypeReward1.VisibleIndex = 0;
            // 
            // lueTypeRewardLose
            // 
            this.lueTypeRewardLose.AutoHeight = false;
            this.lueTypeRewardLose.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeRewardLose.DataSource = this.dbCTAfflictionBindingSource;
            this.lueTypeRewardLose.DisplayMember = "value";
            this.lueTypeRewardLose.Name = "lueTypeRewardLose";
            this.lueTypeRewardLose.ValueMember = "id";
            // 
            // colstaticID1
            // 
            this.colstaticID1.Caption = "Vật phẩm";
            this.colstaticID1.ColumnEdit = this.lueStaticIDLose;
            this.colstaticID1.FieldName = "staticID";
            this.colstaticID1.Name = "colstaticID1";
            this.colstaticID1.OptionsColumn.AllowEdit = false;
            this.colstaticID1.Visible = true;
            this.colstaticID1.VisibleIndex = 1;
            // 
            // lueStaticIDLose
            // 
            this.lueStaticIDLose.AutoHeight = false;
            this.lueStaticIDLose.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStaticIDLose.DataSource = this.dbCTAfflictionBindingSource;
            this.lueStaticIDLose.DisplayMember = "value";
            this.lueStaticIDLose.Name = "lueStaticIDLose";
            this.lueStaticIDLose.ValueMember = "id";
            // 
            // colamountMin1
            // 
            this.colamountMin1.Caption = "S.L Min";
            this.colamountMin1.FieldName = "amountMin";
            this.colamountMin1.Name = "colamountMin1";
            this.colamountMin1.OptionsColumn.AllowEdit = false;
            this.colamountMin1.Visible = true;
            this.colamountMin1.VisibleIndex = 2;
            // 
            // colamountMax1
            // 
            this.colamountMax1.Caption = "S.L Max";
            this.colamountMax1.FieldName = "amountMax";
            this.colamountMax1.Name = "colamountMax1";
            this.colamountMax1.OptionsColumn.AllowEdit = false;
            this.colamountMax1.Visible = true;
            this.colamountMax1.VisibleIndex = 3;
            // 
            // colprocs1
            // 
            this.colprocs1.Caption = "Tỷ lệ";
            this.colprocs1.FieldName = "procs";
            this.colprocs1.Name = "colprocs1";
            this.colprocs1.OptionsColumn.AllowEdit = false;
            this.colprocs1.Visible = true;
            this.colprocs1.VisibleIndex = 4;
            // 
            // frmLuanKiemWinReward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 398);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmLuanKiemWinReward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quà thắng luận kiếm";
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbLuanKiemWinRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcThua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbLuanKiemLoseRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeRewardLose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticIDLose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcThang;
        private DevExpress.XtraGrid.Views.Grid.GridView gvThang;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnDelete1;
        private DevExpress.XtraEditors.SimpleButton btnAdd1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnDelete2;
        private DevExpress.XtraEditors.SimpleButton btnAdd2;
        private DevExpress.XtraGrid.GridControl gcThua;
        private DevExpress.XtraGrid.Views.Grid.GridView gvThua;
        private System.Windows.Forms.BindingSource dbLuanKiemWinRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn coltypeReward;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colstaticID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueStaticID;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMin;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMax;
        private DevExpress.XtraGrid.Columns.GridColumn colprocs;
        private System.Windows.Forms.BindingSource dbLuanKiemLoseRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn coltypeReward1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeRewardLose;
        private DevExpress.XtraGrid.Columns.GridColumn colstaticID1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueStaticIDLose;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMin1;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMax1;
        private DevExpress.XtraGrid.Columns.GridColumn colprocs1;
    }
}