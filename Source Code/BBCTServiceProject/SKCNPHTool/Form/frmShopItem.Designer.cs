namespace KDQHNPHTool.Form
{
    partial class frmShopItem
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
            this.gcVip = new DevExpress.XtraGrid.GridControl();
            this.vRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gVip = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidFakeString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatic_id1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDeleteItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
            this.gcVatPham = new DevExpress.XtraGrid.GridControl();
            this.gvVatPham = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidFake = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatic_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.dbCTStatusSuKienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colprice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStatusSuKien = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeRewardMain = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueTypeReward1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.lueTypeReward2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbAttributeItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcVip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gVip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcVatPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVatPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTStatusSuKienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStatusSuKien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeRewardMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAttributeItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueChonServer);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(989, 54);
            this.panelControl1.TabIndex = 4;
            // 
            // lueChonServer
            // 
            this.lueChonServer.Location = new System.Drawing.Point(94, 18);
            this.lueChonServer.Name = "lueChonServer";
            this.lueChonServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonServer.Properties.View = this.searchLookUpEdit1View;
            this.lueChonServer.Size = new System.Drawing.Size(240, 20);
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
            this.labelControl1.Location = new System.Drawing.Point(25, 21);
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
            this.panelControl2.Location = new System.Drawing.Point(0, 94);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(989, 567);
            this.panelControl2.TabIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gcVip);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl2.Location = new System.Drawing.Point(766, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(221, 563);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Số lượng mua theo Vip";
            // 
            // gcVip
            // 
            this.gcVip.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcVip.DataSource = this.vRewardBindingSource;
            this.gcVip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcVip.Location = new System.Drawing.Point(2, 21);
            this.gcVip.MainView = this.gVip;
            this.gcVip.Name = "gcVip";
            this.gcVip.Size = new System.Drawing.Size(217, 540);
            this.gcVip.TabIndex = 0;
            this.gcVip.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gVip});
            // 
            // vRewardBindingSource
            // 
            this.vRewardBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vReward);
            // 
            // gVip
            // 
            this.gVip.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidFakeString,
            this.colstatic_id1,
            this.colquantity});
            this.gVip.GridControl = this.gcVip;
            this.gVip.Name = "gVip";
            this.gVip.OptionsView.ShowGroupPanel = false;
            // 
            // colidFakeString
            // 
            this.colidFakeString.FieldName = "idFakeString";
            this.colidFakeString.Name = "colidFakeString";
            // 
            // colstatic_id1
            // 
            this.colstatic_id1.Caption = "Vip";
            this.colstatic_id1.FieldName = "static_id";
            this.colstatic_id1.Name = "colstatic_id1";
            this.colstatic_id1.OptionsColumn.AllowEdit = false;
            this.colstatic_id1.Visible = true;
            this.colstatic_id1.VisibleIndex = 0;
            // 
            // colquantity
            // 
            this.colquantity.Caption = "Số lượng";
            this.colquantity.FieldName = "quantity";
            this.colquantity.Name = "colquantity";
            this.colquantity.Visible = true;
            this.colquantity.VisibleIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDeleteItem);
            this.groupControl1.Controls.Add(this.btnAddItem);
            this.groupControl1.Controls.Add(this.gcVatPham);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(733, 563);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Vật phẩm";
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Image = global::KDQHNPHTool.Properties.Resources.denied16x16;
            this.btnDeleteItem.Location = new System.Drawing.Point(705, 53);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(23, 23);
            this.btnDeleteItem.TabIndex = 1;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Image = global::KDQHNPHTool.Properties.Resources.compose16x16;
            this.btnAddItem.Location = new System.Drawing.Point(705, 24);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(23, 23);
            this.btnAddItem.TabIndex = 1;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // gcVatPham
            // 
            this.gcVatPham.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcVatPham.DataSource = this.vRewardBindingSource;
            this.gcVatPham.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcVatPham.Location = new System.Drawing.Point(2, 21);
            this.gcVatPham.MainView = this.gvVatPham;
            this.gcVatPham.Name = "gcVatPham";
            this.gcVatPham.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueStatusSuKien,
            this.lueTypeReward1,
            this.lueStaticID,
            this.repositoryItemImageEdit1,
            this.lueTypeReward2,
            this.lueTypeReward,
            this.lueTypeRewardMain});
            this.gcVatPham.Size = new System.Drawing.Size(697, 540);
            this.gcVatPham.TabIndex = 0;
            this.gcVatPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvVatPham});
            // 
            // gvVatPham
            // 
            this.gvVatPham.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidFake,
            this.colstatic_id,
            this.colprice,
            this.colstatus,
            this.gridColumn1,
            this.gridColumn2});
            this.gvVatPham.GridControl = this.gcVatPham;
            this.gvVatPham.Name = "gvVatPham";
            this.gvVatPham.OptionsView.ShowGroupPanel = false;
            this.gvVatPham.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvVatPham_FocusedRowChanged);
            this.gvVatPham.DoubleClick += new System.EventHandler(this.gvVatPham_DoubleClick);
            // 
            // colidFake
            // 
            this.colidFake.FieldName = "idFakeString";
            this.colidFake.Name = "colidFake";
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
            this.colstatic_id.Width = 228;
            // 
            // lueStaticID
            // 
            this.lueStaticID.AutoHeight = false;
            this.lueStaticID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStaticID.DataSource = this.dbCTStatusSuKienBindingSource;
            this.lueStaticID.DisplayMember = "value";
            this.lueStaticID.Name = "lueStaticID";
            this.lueStaticID.ValueMember = "id";
            this.lueStaticID.View = this.gridView2;
            // 
            // dbCTStatusSuKienBindingSource
            // 
            this.dbCTStatusSuKienBindingSource.DataSource = typeof(KDQHNPHTool.dbCTStatusSuKien);
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colprice
            // 
            this.colprice.Caption = "Giá";
            this.colprice.FieldName = "price";
            this.colprice.Name = "colprice";
            this.colprice.OptionsColumn.AllowEdit = false;
            this.colprice.Visible = true;
            this.colprice.VisibleIndex = 3;
            this.colprice.Width = 101;
            // 
            // colstatus
            // 
            this.colstatus.Caption = "Trạng thái";
            this.colstatus.ColumnEdit = this.lueStatusSuKien;
            this.colstatus.FieldName = "status";
            this.colstatus.Name = "colstatus";
            this.colstatus.Visible = true;
            this.colstatus.VisibleIndex = 4;
            this.colstatus.Width = 113;
            // 
            // lueStatusSuKien
            // 
            this.lueStatusSuKien.AutoHeight = false;
            this.lueStatusSuKien.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueStatusSuKien.DataSource = this.dbCTStatusSuKienBindingSource;
            this.lueStatusSuKien.DisplayMember = "value";
            this.lueStatusSuKien.Name = "lueStatusSuKien";
            this.lueStatusSuKien.ValueMember = "id";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số lượng";
            this.gridColumn1.FieldName = "quantity";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 104;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Loại";
            this.gridColumn2.ColumnEdit = this.lueTypeRewardMain;
            this.gridColumn2.FieldName = "type_reward";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 135;
            // 
            // lueTypeRewardMain
            // 
            this.lueTypeRewardMain.AutoHeight = false;
            this.lueTypeRewardMain.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeRewardMain.DataSource = this.dbCTStatusSuKienBindingSource;
            this.lueTypeRewardMain.DisplayMember = "value";
            this.lueTypeRewardMain.DropDownRows = 10;
            this.lueTypeRewardMain.Name = "lueTypeRewardMain";
            this.lueTypeRewardMain.ValueMember = "id";
            // 
            // lueTypeReward1
            // 
            this.lueTypeReward1.AutoHeight = false;
            this.lueTypeReward1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeReward1.DataSource = this.dbCTStatusSuKienBindingSource;
            this.lueTypeReward1.DisplayMember = "value";
            this.lueTypeReward1.Name = "lueTypeReward1";
            this.lueTypeReward1.ValueMember = "id";
            this.lueTypeReward1.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // lueTypeReward2
            // 
            this.lueTypeReward2.AutoHeight = false;
            this.lueTypeReward2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeReward2.Name = "lueTypeReward2";
            // 
            // lueTypeReward
            // 
            this.lueTypeReward.AutoHeight = false;
            this.lueTypeReward.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeReward.DataSource = this.dbCTStatusSuKienBindingSource;
            this.lueTypeReward.DisplayMember = "value";
            this.lueTypeReward.DropDownRows = 10;
            this.lueTypeReward.Name = "lueTypeReward";
            this.lueTypeReward.ValueMember = "id";
            // 
            // dbAttributeItemBindingSource
            // 
            this.dbAttributeItemBindingSource.DataSource = typeof(KDQHNPHTool.dbItemAttribute);
            // 
            // frmShopItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 661);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmShopItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop Items";
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
            ((System.ComponentModel.ISupportInitialize)(this.gcVip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gVip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcVatPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvVatPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTStatusSuKienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStatusSuKien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeRewardMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbAttributeItemBindingSource)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcVip;
        private DevExpress.XtraGrid.Views.Grid.GridView gVip;
        private DevExpress.XtraGrid.GridControl gcVatPham;
        private DevExpress.XtraGrid.Views.Grid.GridView gvVatPham;
        private DevExpress.XtraEditors.SimpleButton btnDeleteItem;
        private DevExpress.XtraEditors.SimpleButton btnAddItem;
        private System.Windows.Forms.BindingSource dbAttributeItemBindingSource;
        private System.Windows.Forms.BindingSource vRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colidFake;
        private DevExpress.XtraGrid.Columns.GridColumn colstatic_id;
        private DevExpress.XtraGrid.Columns.GridColumn colprice;
        private DevExpress.XtraGrid.Columns.GridColumn colstatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueStatusSuKien;
        private System.Windows.Forms.BindingSource dbCTStatusSuKienBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueTypeReward1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueStaticID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colidFakeString;
        private DevExpress.XtraGrid.Columns.GridColumn colstatic_id1;
        private DevExpress.XtraGrid.Columns.GridColumn colquantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeRewardMain;
    }
}