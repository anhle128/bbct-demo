namespace KDQHNPHTool.Form
{
    partial class frmGiftCodeCategory
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
            this.btnAddLoai = new DevExpress.XtraEditors.SimpleButton();
            this.gcGifftCodeCategory = new DevExpress.XtraGrid.GridControl();
            this.vGiftCodeCategoryBindingSource = new System.Windows.Forms.BindingSource();
            this.gvGifftCodeCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidServer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueChonServer = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.dbCTTypeRewardBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coltype = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueLoaiGiftCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.serverBindingSource = new System.Windows.Forms.BindingSource();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDeleteReward = new DevExpress.XtraEditors.SimpleButton();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.vRewardBindingSource = new System.Windows.Forms.BindingSource();
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidFakeString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltype_reward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colstatic_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnAddReward = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcGifftCodeCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGiftCodeCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGifftCodeCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTTypeRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiGiftCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnAddLoai);
            this.groupControl1.Controls.Add(this.gcGifftCodeCategory);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(659, 544);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Loại Gift Code";
            // 
            // btnAddLoai
            // 
            this.btnAddLoai.Image = global::KDQHNPHTool.Properties.Resources.compose16x16;
            this.btnAddLoai.Location = new System.Drawing.Point(631, 24);
            this.btnAddLoai.Name = "btnAddLoai";
            this.btnAddLoai.Size = new System.Drawing.Size(23, 23);
            this.btnAddLoai.TabIndex = 1;
            this.btnAddLoai.Click += new System.EventHandler(this.btnAddLoai_Click);
            // 
            // gcGifftCodeCategory
            // 
            this.gcGifftCodeCategory.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcGifftCodeCategory.DataSource = this.vGiftCodeCategoryBindingSource;
            this.gcGifftCodeCategory.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcGifftCodeCategory.Location = new System.Drawing.Point(2, 21);
            this.gcGifftCodeCategory.MainView = this.gvGifftCodeCategory;
            this.gcGifftCodeCategory.Name = "gcGifftCodeCategory";
            this.gcGifftCodeCategory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueLoaiGiftCode,
            this.lueChonServer});
            this.gcGifftCodeCategory.Size = new System.Drawing.Size(623, 521);
            this.gcGifftCodeCategory.TabIndex = 0;
            this.gcGifftCodeCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGifftCodeCategory});
            // 
            // vGiftCodeCategoryBindingSource
            // 
            this.vGiftCodeCategoryBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vGiftCodeCategory);
            // 
            // gvGifftCodeCategory
            // 
            this.gvGifftCodeCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colname,
            this.colidServer,
            this.coltype});
            this.gvGifftCodeCategory.GridControl = this.gcGifftCodeCategory;
            this.gvGifftCodeCategory.Name = "gvGifftCodeCategory";
            this.gvGifftCodeCategory.OptionsView.ShowGroupPanel = false;
            this.gvGifftCodeCategory.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvGifftCodeCategory_FocusedRowChanged);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colname
            // 
            this.colname.Caption = "Tên loại Gift Code";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 0;
            // 
            // colidServer
            // 
            this.colidServer.Caption = "Server";
            this.colidServer.ColumnEdit = this.lueChonServer;
            this.colidServer.FieldName = "idServer";
            this.colidServer.Name = "colidServer";
            this.colidServer.Visible = true;
            this.colidServer.VisibleIndex = 1;
            // 
            // lueChonServer
            // 
            this.lueChonServer.AutoHeight = false;
            this.lueChonServer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonServer.DataSource = this.dbCTTypeRewardBindingSource;
            this.lueChonServer.DisplayMember = "value";
            this.lueChonServer.Name = "lueChonServer";
            this.lueChonServer.ValueMember = "id";
            this.lueChonServer.View = this.gridView1;
            // 
            // dbCTTypeRewardBindingSource
            // 
            this.dbCTTypeRewardBindingSource.DataSource = typeof(KDQHNPHTool.dbCTTypeReward);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // coltype
            // 
            this.coltype.Caption = "Loại";
            this.coltype.ColumnEdit = this.lueLoaiGiftCode;
            this.coltype.FieldName = "type";
            this.coltype.Name = "coltype";
            this.coltype.Visible = true;
            this.coltype.VisibleIndex = 2;
            // 
            // lueLoaiGiftCode
            // 
            this.lueLoaiGiftCode.AutoHeight = false;
            this.lueLoaiGiftCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueLoaiGiftCode.DataSource = this.serverBindingSource;
            this.lueLoaiGiftCode.DisplayMember = "value";
            this.lueLoaiGiftCode.Name = "lueLoaiGiftCode";
            this.lueLoaiGiftCode.ValueMember = "id";
            // 
            // serverBindingSource
            // 
            this.serverBindingSource.DataSource = typeof(KDQHNPHTool.Model.Server);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDeleteReward);
            this.groupControl2.Controls.Add(this.gcReward);
            this.groupControl2.Controls.Add(this.btnAddReward);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl2.Location = new System.Drawing.Point(687, 40);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(522, 544);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Quà của loại Gift Code";
            // 
            // btnDeleteReward
            // 
            this.btnDeleteReward.Image = global::KDQHNPHTool.Properties.Resources.denied16x16;
            this.btnDeleteReward.Location = new System.Drawing.Point(494, 53);
            this.btnDeleteReward.Name = "btnDeleteReward";
            this.btnDeleteReward.Size = new System.Drawing.Size(23, 23);
            this.btnDeleteReward.TabIndex = 1;
            this.btnDeleteReward.Click += new System.EventHandler(this.btnDeleteReward_Click);
            // 
            // gcReward
            // 
            this.gcReward.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcReward.DataSource = this.vRewardBindingSource;
            this.gcReward.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcReward.Location = new System.Drawing.Point(2, 21);
            this.gcReward.MainView = this.gvReward;
            this.gcReward.Name = "gcReward";
            this.gcReward.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.lueTypeReward,
            this.lueStaticID});
            this.gcReward.Size = new System.Drawing.Size(486, 521);
            this.gcReward.TabIndex = 0;
            this.gcReward.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReward});
            // 
            // vRewardBindingSource
            // 
            this.vRewardBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vReward);
            // 
            // gvReward
            // 
            this.gvReward.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidFakeString,
            this.coltype_reward,
            this.colstatic_id,
            this.colquantity});
            this.gvReward.GridControl = this.gcReward;
            this.gvReward.Name = "gvReward";
            this.gvReward.OptionsView.ShowGroupPanel = false;
            this.gvReward.DoubleClick += new System.EventHandler(this.gvReward_DoubleClick);
            // 
            // colidFakeString
            // 
            this.colidFakeString.FieldName = "idFakeString";
            this.colidFakeString.Name = "colidFakeString";
            // 
            // coltype_reward
            // 
            this.coltype_reward.Caption = "Loại";
            this.coltype_reward.ColumnEdit = this.lueTypeReward;
            this.coltype_reward.FieldName = "type_reward";
            this.coltype_reward.Name = "coltype_reward";
            this.coltype_reward.OptionsColumn.AllowEdit = false;
            this.coltype_reward.Visible = true;
            this.coltype_reward.VisibleIndex = 0;
            this.coltype_reward.Width = 142;
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
            // colstatic_id
            // 
            this.colstatic_id.Caption = "Vật phẩm";
            this.colstatic_id.ColumnEdit = this.lueStaticID;
            this.colstatic_id.FieldName = "static_id";
            this.colstatic_id.Name = "colstatic_id";
            this.colstatic_id.OptionsColumn.AllowEdit = false;
            this.colstatic_id.Visible = true;
            this.colstatic_id.VisibleIndex = 1;
            this.colstatic_id.Width = 225;
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
            // colquantity
            // 
            this.colquantity.Caption = "Số lượng";
            this.colquantity.FieldName = "quantity";
            this.colquantity.Name = "colquantity";
            this.colquantity.OptionsColumn.AllowEdit = false;
            this.colquantity.Visible = true;
            this.colquantity.VisibleIndex = 2;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // btnAddReward
            // 
            this.btnAddReward.Image = global::KDQHNPHTool.Properties.Resources.compose16x16;
            this.btnAddReward.Location = new System.Drawing.Point(494, 24);
            this.btnAddReward.Name = "btnAddReward";
            this.btnAddReward.Size = new System.Drawing.Size(23, 23);
            this.btnAddReward.TabIndex = 1;
            this.btnAddReward.Click += new System.EventHandler(this.btnAddReward_Click);
            // 
            // frmGiftCodeCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 584);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmGiftCodeCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loại gift code";
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcGifftCodeCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGiftCodeCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGifftCodeCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTTypeRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiGiftCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gcGifftCodeCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGifftCodeCategory;
        private DevExpress.XtraGrid.GridControl gcReward;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private DevExpress.XtraEditors.SimpleButton btnAddLoai;
        private DevExpress.XtraEditors.SimpleButton btnDeleteReward;
        private DevExpress.XtraEditors.SimpleButton btnAddReward;
        private System.Windows.Forms.BindingSource vRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colidFakeString;
        private DevExpress.XtraGrid.Columns.GridColumn coltype_reward;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private System.Windows.Forms.BindingSource dbCTTypeRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colstatic_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueStaticID;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colquantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource vGiftCodeCategoryBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn colidServer;
        private DevExpress.XtraGrid.Columns.GridColumn coltype;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueChonServer;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueLoaiGiftCode;
        private System.Windows.Forms.BindingSource serverBindingSource;
    }
}