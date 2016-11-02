namespace KDQHNPHTool.Form
{
    partial class frmVipConfig
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lueChonServer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDeleteReward = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddReward = new DevExpress.XtraEditors.SimpleButton();
            this.gcQuaVip = new DevExpress.XtraGrid.GridControl();
            this.vRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvQuaVip = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidFake = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltype_reward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTBorderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colstatic_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcVip = new DevExpress.XtraGrid.GridControl();
            this.dbAttributeItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvVip = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcQuaVip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuaVip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTBorderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcVip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAttributeItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVip)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueChonServer);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(740, 53);
            this.panelControl1.TabIndex = 4;
            // 
            // lueChonServer
            // 
            this.lueChonServer.Location = new System.Drawing.Point(82, 15);
            this.lueChonServer.Name = "lueChonServer";
            this.lueChonServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonServer.Properties.View = this.searchLookUpEdit1View;
            this.lueChonServer.Size = new System.Drawing.Size(245, 20);
            this.lueChonServer.TabIndex = 1;
            this.lueChonServer.EditValueChanged += new System.EventHandler(this.lueChonServer_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn server:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 93);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(740, 485);
            this.panelControl2.TabIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDeleteReward);
            this.groupControl2.Controls.Add(this.btnAddReward);
            this.groupControl2.Controls.Add(this.gcQuaVip);
            this.groupControl2.Location = new System.Drawing.Point(211, 6);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(524, 467);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Quà Vip";
            // 
            // btnDeleteReward
            // 
            this.btnDeleteReward.Image = global::KDQHNPHTool.Properties.Resources.denied16x16;
            this.btnDeleteReward.Location = new System.Drawing.Point(496, 53);
            this.btnDeleteReward.Name = "btnDeleteReward";
            this.btnDeleteReward.Size = new System.Drawing.Size(23, 23);
            this.btnDeleteReward.TabIndex = 1;
            this.btnDeleteReward.Click += new System.EventHandler(this.btnDeleteReward_Click);
            // 
            // btnAddReward
            // 
            this.btnAddReward.Image = global::KDQHNPHTool.Properties.Resources.compose16x16;
            this.btnAddReward.Location = new System.Drawing.Point(496, 24);
            this.btnAddReward.Name = "btnAddReward";
            this.btnAddReward.Size = new System.Drawing.Size(23, 23);
            this.btnAddReward.TabIndex = 1;
            this.btnAddReward.Click += new System.EventHandler(this.btnAddReward_Click);
            // 
            // gcQuaVip
            // 
            this.gcQuaVip.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcQuaVip.DataSource = this.vRewardBindingSource;
            this.gcQuaVip.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcQuaVip.Location = new System.Drawing.Point(2, 21);
            this.gcQuaVip.MainView = this.gvQuaVip;
            this.gcQuaVip.Name = "gcQuaVip";
            this.gcQuaVip.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueTypeReward,
            this.lueStaticID});
            this.gcQuaVip.Size = new System.Drawing.Size(488, 444);
            this.gcQuaVip.TabIndex = 0;
            this.gcQuaVip.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvQuaVip});
            // 
            // vRewardBindingSource
            // 
            this.vRewardBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vReward);
            // 
            // gvQuaVip
            // 
            this.gvQuaVip.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidFake,
            this.coltype_reward,
            this.colstatic_id,
            this.colquantity});
            this.gvQuaVip.GridControl = this.gcQuaVip;
            this.gvQuaVip.Name = "gvQuaVip";
            this.gvQuaVip.OptionsView.ShowGroupPanel = false;
            this.gvQuaVip.DoubleClick += new System.EventHandler(this.gvQuaVip_DoubleClick);
            // 
            // colidFake
            // 
            this.colidFake.FieldName = "idFake";
            this.colidFake.Name = "colidFake";
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
            this.coltype_reward.Width = 122;
            // 
            // lueTypeReward
            // 
            this.lueTypeReward.AutoHeight = false;
            this.lueTypeReward.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeReward.DataSource = this.dbCTBorderBindingSource;
            this.lueTypeReward.DisplayMember = "value";
            this.lueTypeReward.DropDownRows = 10;
            this.lueTypeReward.Name = "lueTypeReward";
            this.lueTypeReward.ValueMember = "id";
            // 
            // dbCTBorderBindingSource
            // 
            this.dbCTBorderBindingSource.DataSource = typeof(KDQHNPHTool.dbCTAffliction);
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
            this.colstatic_id.Width = 211;
            // 
            // lueStaticID
            // 
            this.lueStaticID.AutoHeight = false;
            this.lueStaticID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStaticID.DataSource = this.dbCTBorderBindingSource;
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcVip);
            this.groupControl1.Location = new System.Drawing.Point(5, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(200, 467);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Vip";
            // 
            // gcVip
            // 
            this.gcVip.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcVip.DataSource = this.dbAttributeItemBindingSource;
            this.gcVip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcVip.Location = new System.Drawing.Point(2, 21);
            this.gcVip.MainView = this.gvVip;
            this.gcVip.Name = "gcVip";
            this.gcVip.Size = new System.Drawing.Size(196, 444);
            this.gcVip.TabIndex = 0;
            this.gcVip.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVip});
            // 
            // dbAttributeItemBindingSource
            // 
            this.dbAttributeItemBindingSource.DataSource = typeof(KDQHNPHTool.dbItemAttribute);
            // 
            // gvVip
            // 
            this.gvVip.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colvalue});
            this.gvVip.GridControl = this.gcVip;
            this.gvVip.Name = "gvVip";
            this.gvVip.OptionsView.ShowGroupPanel = false;
            this.gvVip.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvVip_FocusedRowChanged);
            // 
            // colid
            // 
            this.colid.Caption = "Vip";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.AllowEdit = false;
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            // 
            // colvalue
            // 
            this.colvalue.Caption = "Vip";
            this.colvalue.FieldName = "value";
            this.colvalue.Name = "colvalue";
            // 
            // frmVipConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 578);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmVipConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vip";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcQuaVip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuaVip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTBorderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcVip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAttributeItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit lueChonServer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcQuaVip;
        private DevExpress.XtraGrid.Views.Grid.GridView gvQuaVip;
        private DevExpress.XtraGrid.GridControl gcVip;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVip;
        private DevExpress.XtraEditors.SimpleButton btnDeleteReward;
        private DevExpress.XtraEditors.SimpleButton btnAddReward;
        private System.Windows.Forms.BindingSource vRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colidFake;
        private DevExpress.XtraGrid.Columns.GridColumn coltype_reward;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private System.Windows.Forms.BindingSource dbCTBorderBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colstatic_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueStaticID;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colquantity;
        private System.Windows.Forms.BindingSource dbAttributeItemBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colvalue;
    }
}