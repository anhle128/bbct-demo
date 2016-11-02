namespace KDQHDesignerTool.Form
{
    partial class frmInviteFacebook
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd1 = new DevExpress.XtraEditors.SimpleButton();
            this.gcMoc = new DevExpress.XtraGrid.GridControl();
            this.dbInviteFriendConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvMoc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrequire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete2 = new DevExpress.XtraEditors.SimpleButton();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.dbInviteFriendRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypeReward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colstaticID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueVatPham = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colamountMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colamountMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprocs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnAdd2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbInviteFriendConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbInviteFriendRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueVatPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDelete1);
            this.groupControl1.Controls.Add(this.btnAdd1);
            this.groupControl1.Controls.Add(this.gcMoc);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(183, 571);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Mốc phần thưởng";
            // 
            // btnDelete1
            // 
            this.btnDelete1.Image = global::KDQHDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete1.Location = new System.Drawing.Point(155, 50);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(23, 23);
            this.btnDelete1.TabIndex = 1;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.Image = global::KDQHDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd1.Location = new System.Drawing.Point(155, 21);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(23, 23);
            this.btnAdd1.TabIndex = 1;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // gcMoc
            // 
            this.gcMoc.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcMoc.DataSource = this.dbInviteFriendConfigBindingSource;
            this.gcMoc.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcMoc.Location = new System.Drawing.Point(2, 21);
            this.gcMoc.MainView = this.gvMoc;
            this.gcMoc.Name = "gcMoc";
            this.gcMoc.Size = new System.Drawing.Size(147, 548);
            this.gcMoc.TabIndex = 0;
            this.gcMoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMoc});
            // 
            // dbInviteFriendConfigBindingSource
            // 
            this.dbInviteFriendConfigBindingSource.DataSource = typeof(KDQHDesignerTool.dbInviteFriendConfig);
            // 
            // gvMoc
            // 
            this.gvMoc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colrequire});
            this.gvMoc.GridControl = this.gcMoc;
            this.gvMoc.Name = "gvMoc";
            this.gvMoc.OptionsView.ShowGroupPanel = false;
            this.gvMoc.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMoc_FocusedRowChanged);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colrequire
            // 
            this.colrequire.Caption = "Số người";
            this.colrequire.FieldName = "require";
            this.colrequire.Name = "colrequire";
            this.colrequire.Visible = true;
            this.colrequire.VisibleIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDelete2);
            this.groupControl2.Controls.Add(this.gcReward);
            this.groupControl2.Controls.Add(this.btnAdd2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl2.Location = new System.Drawing.Point(204, 40);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(634, 571);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Phần thưởng mốc";
            // 
            // btnDelete2
            // 
            this.btnDelete2.Image = global::KDQHDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete2.Location = new System.Drawing.Point(606, 50);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(23, 23);
            this.btnDelete2.TabIndex = 1;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // gcReward
            // 
            this.gcReward.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcReward.DataSource = this.dbInviteFriendRewardBindingSource;
            this.gcReward.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcReward.Location = new System.Drawing.Point(2, 21);
            this.gcReward.MainView = this.gvReward;
            this.gcReward.Name = "gcReward";
            this.gcReward.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueTypeReward,
            this.repositoryItemMarqueeProgressBar1,
            this.lueStaticID,
            this.lueVatPham});
            this.gcReward.Size = new System.Drawing.Size(598, 548);
            this.gcReward.TabIndex = 0;
            this.gcReward.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReward});
            // 
            // dbInviteFriendRewardBindingSource
            // 
            this.dbInviteFriendRewardBindingSource.DataSource = typeof(KDQHDesignerTool.dbInviteFriendReward);
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
            this.coltypeReward.Width = 133;
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
            this.colstaticID.ColumnEdit = this.lueVatPham;
            this.colstaticID.FieldName = "staticID";
            this.colstaticID.Name = "colstaticID";
            this.colstaticID.OptionsColumn.AllowEdit = false;
            this.colstaticID.Visible = true;
            this.colstaticID.VisibleIndex = 1;
            this.colstaticID.Width = 248;
            // 
            // lueVatPham
            // 
            this.lueVatPham.AutoHeight = false;
            this.lueVatPham.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueVatPham.DataSource = this.dbCTAfflictionBindingSource;
            this.lueVatPham.DisplayMember = "value";
            this.lueVatPham.Name = "lueVatPham";
            this.lueVatPham.ValueMember = "id";
            // 
            // colamountMin
            // 
            this.colamountMin.Caption = "S.L Min";
            this.colamountMin.FieldName = "amountMin";
            this.colamountMin.Name = "colamountMin";
            this.colamountMin.OptionsColumn.AllowEdit = false;
            this.colamountMin.Visible = true;
            this.colamountMin.VisibleIndex = 2;
            this.colamountMin.Width = 64;
            // 
            // colamountMax
            // 
            this.colamountMax.Caption = "S.L Max";
            this.colamountMax.FieldName = "amountMax";
            this.colamountMax.Name = "colamountMax";
            this.colamountMax.OptionsColumn.AllowEdit = false;
            this.colamountMax.Visible = true;
            this.colamountMax.VisibleIndex = 3;
            this.colamountMax.Width = 68;
            // 
            // colprocs
            // 
            this.colprocs.Caption = "Tỷ lệ";
            this.colprocs.FieldName = "procs";
            this.colprocs.Name = "colprocs";
            this.colprocs.OptionsColumn.AllowEdit = false;
            this.colprocs.Visible = true;
            this.colprocs.VisibleIndex = 4;
            this.colprocs.Width = 69;
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            // 
            // lueStaticID
            // 
            this.lueStaticID.AutoHeight = false;
            this.lueStaticID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStaticID.Name = "lueStaticID";
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = global::KDQHDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd2.Location = new System.Drawing.Point(606, 21);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(23, 23);
            this.btnAdd2.TabIndex = 1;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // frmInviteFacebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 611);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmInviteFacebook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invite Facebook";
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbInviteFriendConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbInviteFriendRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueVatPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnDelete1;
        private DevExpress.XtraEditors.SimpleButton btnAdd1;
        private DevExpress.XtraGrid.GridControl gcMoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMoc;
        private DevExpress.XtraEditors.SimpleButton btnDelete2;
        private DevExpress.XtraGrid.GridControl gcReward;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private DevExpress.XtraEditors.SimpleButton btnAdd2;
        private System.Windows.Forms.BindingSource dbInviteFriendConfigBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colrequire;
        private System.Windows.Forms.BindingSource dbInviteFriendRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn coltypeReward;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colstaticID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueVatPham;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMin;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMax;
        private DevExpress.XtraGrid.Columns.GridColumn colprocs;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueStaticID;
    }
}