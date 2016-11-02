namespace KDQHDesignerTool.Form
{
    partial class frmPlayerDefaultConfig
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
            this.gcPlayer = new DevExpress.XtraGrid.GridControl();
            this.gvPlayer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collevels = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgold = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsilver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstamina = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dbPlayerDefaultConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnQuaTaoNick = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.dbTaoNickRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypeReward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colstaticID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colamountMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colamountMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprocs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lueTypeRewardj = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPlayerDefaultConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuaTaoNick)).BeginInit();
            this.btnQuaTaoNick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTaoNickRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeRewardj)).BeginInit();
            this.SuspendLayout();
            // 
            // gcPlayer
            // 
            this.gcPlayer.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcPlayer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcPlayer.Location = new System.Drawing.Point(0, 40);
            this.gcPlayer.MainView = this.gvPlayer;
            this.gcPlayer.Name = "gcPlayer";
            this.gcPlayer.Size = new System.Drawing.Size(685, 96);
            this.gcPlayer.TabIndex = 4;
            this.gcPlayer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPlayer});
            // 
            // gvPlayer
            // 
            this.gvPlayer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.collevels,
            this.colgold,
            this.colsilver,
            this.colstamina});
            this.gvPlayer.GridControl = this.gcPlayer;
            this.gvPlayer.Name = "gvPlayer";
            this.gvPlayer.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // collevels
            // 
            this.collevels.Caption = "Level";
            this.collevels.FieldName = "levels";
            this.collevels.Name = "collevels";
            this.collevels.Visible = true;
            this.collevels.VisibleIndex = 0;
            // 
            // colgold
            // 
            this.colgold.Caption = "KNB";
            this.colgold.FieldName = "gold";
            this.colgold.Name = "colgold";
            this.colgold.Visible = true;
            this.colgold.VisibleIndex = 1;
            // 
            // colsilver
            // 
            this.colsilver.Caption = "Bạc";
            this.colsilver.FieldName = "silver";
            this.colsilver.Name = "colsilver";
            this.colsilver.Visible = true;
            this.colsilver.VisibleIndex = 2;
            // 
            // colstamina
            // 
            this.colstamina.Caption = "Thể lực";
            this.colstamina.FieldName = "stamina";
            this.colstamina.Name = "colstamina";
            this.colstamina.Visible = true;
            this.colstamina.VisibleIndex = 3;
            // 
            // dbPlayerDefaultConfigBindingSource
            // 
            this.dbPlayerDefaultConfigBindingSource.DataSource = typeof(KDQHDesignerTool.dbPlayerDefaultConfig);
            // 
            // btnQuaTaoNick
            // 
            this.btnQuaTaoNick.Controls.Add(this.btnDelete);
            this.btnQuaTaoNick.Controls.Add(this.btnAdd);
            this.btnQuaTaoNick.Controls.Add(this.gcReward);
            this.btnQuaTaoNick.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnQuaTaoNick.Location = new System.Drawing.Point(0, 151);
            this.btnQuaTaoNick.Name = "btnQuaTaoNick";
            this.btnQuaTaoNick.Size = new System.Drawing.Size(685, 382);
            this.btnQuaTaoNick.TabIndex = 5;
            this.btnQuaTaoNick.Text = "Quà tạo nick";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::KDQHDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete.Location = new System.Drawing.Point(657, 50);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::KDQHDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd.Location = new System.Drawing.Point(657, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gcReward
            // 
            this.gcReward.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcReward.DataSource = this.dbTaoNickRewardBindingSource;
            this.gcReward.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcReward.Location = new System.Drawing.Point(2, 21);
            this.gcReward.MainView = this.gvReward;
            this.gcReward.Name = "gcReward";
            this.gcReward.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.lueTypeRewardj,
            this.lueTypeReward,
            this.lueStaticID});
            this.gcReward.Size = new System.Drawing.Size(649, 359);
            this.gcReward.TabIndex = 0;
            this.gcReward.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReward});
            // 
            // dbTaoNickRewardBindingSource
            // 
            this.dbTaoNickRewardBindingSource.DataSource = typeof(KDQHDesignerTool.dbTaoNickReward);
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
            this.coltypeReward.Width = 147;
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
            this.lueTypeReward.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // dbCTAfflictionBindingSource
            // 
            this.dbCTAfflictionBindingSource.DataSource = typeof(KDQHDesignerTool.dbCTAffliction);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
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
            this.colstaticID.Width = 227;
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
            this.lueStaticID.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // lueTypeRewardj
            // 
            this.lueTypeRewardj.AutoHeight = false;
            this.lueTypeRewardj.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeRewardj.Name = "lueTypeRewardj";
            // 
            // frmPlayerDefaultConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 533);
            this.Controls.Add(this.btnQuaTaoNick);
            this.Controls.Add(this.gcPlayer);
            this.Name = "frmPlayerDefaultConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config thông số người chơi khi tạo nick";
            this.Controls.SetChildIndex(this.gcPlayer, 0);
            this.Controls.SetChildIndex(this.btnQuaTaoNick, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPlayerDefaultConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuaTaoNick)).EndInit();
            this.btnQuaTaoNick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTaoNickRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeRewardj)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcPlayer;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPlayer;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn collevels;
        private DevExpress.XtraGrid.Columns.GridColumn colgold;
        private DevExpress.XtraGrid.Columns.GridColumn colsilver;
        private DevExpress.XtraGrid.Columns.GridColumn colstamina;
        private System.Windows.Forms.BindingSource dbPlayerDefaultConfigBindingSource;
        private DevExpress.XtraEditors.GroupControl btnQuaTaoNick;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl gcReward;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private System.Windows.Forms.BindingSource dbTaoNickRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn coltypeReward;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueTypeReward;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colstaticID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueStaticID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMin;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMax;
        private DevExpress.XtraGrid.Columns.GridColumn colprocs;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeRewardj;
    }
}