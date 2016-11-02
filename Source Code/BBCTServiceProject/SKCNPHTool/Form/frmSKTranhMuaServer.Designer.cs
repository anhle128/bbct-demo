namespace KDQHNPHTool.Form
{
    partial class frmSKTranhMuaServer
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddReward = new DevExpress.XtraEditors.SimpleButton();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.vRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidFake1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltype_reward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colstatic_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmax_buy_time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcNgay = new DevExpress.XtraGrid.GridControl();
            this.gvNgay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidFakeString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidFake = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTrangThai = new DevExpress.XtraEditors.LookUpEdit();
            this.dteToDate = new DevExpress.XtraEditors.DateEdit();
            this.dteFromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTrangThai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFromDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueChonServer);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1132, 51);
            this.panelControl1.TabIndex = 4;
            // 
            // lueChonServer
            // 
            this.lueChonServer.Location = new System.Drawing.Point(111, 15);
            this.lueChonServer.Name = "lueChonServer";
            this.lueChonServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonServer.Properties.View = this.searchLookUpEdit1View;
            this.lueChonServer.Size = new System.Drawing.Size(239, 20);
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
            this.labelControl1.Location = new System.Drawing.Point(42, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn server:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Controls.Add(this.lueTrangThai);
            this.panelControl2.Controls.Add(this.dteToDate);
            this.panelControl2.Controls.Add(this.dteFromDate);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 91);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1132, 407);
            this.panelControl2.TabIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.simpleButton1);
            this.groupControl2.Controls.Add(this.btnAddReward);
            this.groupControl2.Controls.Add(this.gcReward);
            this.groupControl2.Location = new System.Drawing.Point(227, 62);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(893, 324);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Vật phẩm";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::KDQHNPHTool.Properties.Resources.denied16x16;
            this.simpleButton1.Location = new System.Drawing.Point(865, 53);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(23, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnAddReward
            // 
            this.btnAddReward.Image = global::KDQHNPHTool.Properties.Resources.compose16x16;
            this.btnAddReward.Location = new System.Drawing.Point(865, 24);
            this.btnAddReward.Name = "btnAddReward";
            this.btnAddReward.Size = new System.Drawing.Size(23, 23);
            this.btnAddReward.TabIndex = 1;
            this.btnAddReward.Click += new System.EventHandler(this.btnAddReward_Click);
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
            this.lueTypeReward,
            this.lueStaticID});
            this.gcReward.Size = new System.Drawing.Size(857, 301);
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
            this.colidFake1,
            this.coltype_reward,
            this.colstatic_id,
            this.colquantity,
            this.colstatus,
            this.colprice,
            this.colmax_buy_time});
            this.gvReward.GridControl = this.gcReward;
            this.gvReward.Name = "gvReward";
            this.gvReward.OptionsView.ShowGroupPanel = false;
            this.gvReward.DoubleClick += new System.EventHandler(this.gvReward_DoubleClick);
            // 
            // colidFake1
            // 
            this.colidFake1.FieldName = "idFake";
            this.colidFake1.Name = "colidFake1";
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
            this.coltype_reward.Width = 119;
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
            this.dbCTAfflictionBindingSource.DataSource = typeof(KDQHNPHTool.dbCTAffliction);
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
            this.colstatic_id.Width = 202;
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
            // colquantity
            // 
            this.colquantity.Caption = "Số lượng";
            this.colquantity.FieldName = "quantity";
            this.colquantity.Name = "colquantity";
            this.colquantity.OptionsColumn.AllowEdit = false;
            this.colquantity.Visible = true;
            this.colquantity.VisibleIndex = 2;
            this.colquantity.Width = 102;
            // 
            // colstatus
            // 
            this.colstatus.Caption = "Số lượng ngoài";
            this.colstatus.FieldName = "status";
            this.colstatus.Name = "colstatus";
            this.colstatus.Visible = true;
            this.colstatus.VisibleIndex = 4;
            this.colstatus.Width = 102;
            // 
            // colprice
            // 
            this.colprice.Caption = "Giá";
            this.colprice.FieldName = "price";
            this.colprice.Name = "colprice";
            this.colprice.Visible = true;
            this.colprice.VisibleIndex = 3;
            this.colprice.Width = 82;
            // 
            // colmax_buy_time
            // 
            this.colmax_buy_time.Caption = "Max SL mua/ người";
            this.colmax_buy_time.FieldName = "max_buy_time";
            this.colmax_buy_time.Name = "colmax_buy_time";
            this.colmax_buy_time.Visible = true;
            this.colmax_buy_time.VisibleIndex = 5;
            this.colmax_buy_time.Width = 131;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcNgay);
            this.groupControl1.Location = new System.Drawing.Point(21, 62);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(200, 324);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Ngày";
            // 
            // gcNgay
            // 
            this.gcNgay.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcNgay.DataSource = this.vRewardBindingSource;
            this.gcNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNgay.Location = new System.Drawing.Point(2, 21);
            this.gcNgay.MainView = this.gvNgay;
            this.gcNgay.Name = "gcNgay";
            this.gcNgay.Size = new System.Drawing.Size(196, 301);
            this.gcNgay.TabIndex = 0;
            this.gcNgay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNgay});
            // 
            // gvNgay
            // 
            this.gvNgay.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidFakeString,
            this.colidFake});
            this.gvNgay.GridControl = this.gcNgay;
            this.gvNgay.Name = "gvNgay";
            this.gvNgay.OptionsView.ShowGroupPanel = false;
            this.gvNgay.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvNgay_FocusedRowChanged);
            // 
            // colidFakeString
            // 
            this.colidFakeString.Caption = "Ngày";
            this.colidFakeString.FieldName = "idFakeString";
            this.colidFakeString.Name = "colidFakeString";
            this.colidFakeString.OptionsColumn.AllowEdit = false;
            this.colidFakeString.Visible = true;
            this.colidFakeString.VisibleIndex = 0;
            // 
            // colidFake
            // 
            this.colidFake.Caption = "id";
            this.colidFake.FieldName = "idFake";
            this.colidFake.Name = "colidFake";
            // 
            // lueTrangThai
            // 
            this.lueTrangThai.Location = new System.Drawing.Point(779, 17);
            this.lueTrangThai.Name = "lueTrangThai";
            this.lueTrangThai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTrangThai.Properties.DataSource = this.dbCTAfflictionBindingSource;
            this.lueTrangThai.Properties.DisplayMember = "value";
            this.lueTrangThai.Properties.ValueMember = "id";
            this.lueTrangThai.Size = new System.Drawing.Size(100, 20);
            this.lueTrangThai.TabIndex = 2;
            // 
            // dteToDate
            // 
            this.dteToDate.EditValue = null;
            this.dteToDate.Enabled = false;
            this.dteToDate.Location = new System.Drawing.Point(451, 17);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteToDate.Properties.DisplayFormat.FormatString = "g";
            this.dteToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteToDate.Size = new System.Drawing.Size(202, 20);
            this.dteToDate.TabIndex = 1;
            // 
            // dteFromDate
            // 
            this.dteFromDate.EditValue = null;
            this.dteFromDate.Location = new System.Drawing.Point(96, 17);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteFromDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dteFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteFromDate.Properties.DisplayFormat.FormatString = "g";
            this.dteFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteFromDate.Size = new System.Drawing.Size(202, 20);
            this.dteFromDate.TabIndex = 1;
            this.dteFromDate.EditValueChanged += new System.EventHandler(this.dteFromDate_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(720, 20);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(53, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Trạng thái:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(374, 20);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Ngày kết thúc:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 20);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Ngày bắt đầu:";
            // 
            // frmSKTranhMuaServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 498);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmSKTranhMuaServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tranh mua server";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTrangThai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFromDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit lueChonServer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueTrangThai;
        private DevExpress.XtraEditors.DateEdit dteToDate;
        private DevExpress.XtraEditors.DateEdit dteFromDate;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcReward;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private DevExpress.XtraGrid.GridControl gcNgay;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNgay;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnAddReward;
        private System.Windows.Forms.BindingSource vRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colidFake1;
        private DevExpress.XtraGrid.Columns.GridColumn coltype_reward;
        private DevExpress.XtraGrid.Columns.GridColumn colstatic_id;
        private DevExpress.XtraGrid.Columns.GridColumn colquantity;
        private DevExpress.XtraGrid.Columns.GridColumn colstatus;
        private DevExpress.XtraGrid.Columns.GridColumn colprice;
        private DevExpress.XtraGrid.Columns.GridColumn colmax_buy_time;
        private DevExpress.XtraGrid.Columns.GridColumn colidFakeString;
        private DevExpress.XtraGrid.Columns.GridColumn colidFake;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueStaticID;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
    }
}