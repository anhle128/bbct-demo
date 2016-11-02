namespace KDQHNPHTool.UserController
{
    partial class ucChiTietNapTien
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lueChonServer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gcChiTiet = new DevExpress.XtraGrid.GridControl();
            this.vUserTransactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvChiTiet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colusername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueKenhThanhToan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUserTransactionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKenhThanhToan)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueChonServer);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1123, 51);
            this.panelControl1.TabIndex = 0;
            // 
            // lueChonServer
            // 
            this.lueChonServer.Location = new System.Drawing.Point(83, 15);
            this.lueChonServer.Name = "lueChonServer";
            this.lueChonServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonServer.Properties.View = this.searchLookUpEdit1View;
            this.lueChonServer.Size = new System.Drawing.Size(208, 20);
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
            this.labelControl1.Location = new System.Drawing.Point(14, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn server:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcChiTiet);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 51);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1123, 506);
            this.panelControl2.TabIndex = 0;
            // 
            // gcChiTiet
            // 
            this.gcChiTiet.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcChiTiet.DataSource = this.vUserTransactionBindingSource;
            this.gcChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChiTiet.Location = new System.Drawing.Point(2, 2);
            this.gcChiTiet.MainView = this.gvChiTiet;
            this.gcChiTiet.Name = "gcChiTiet";
            this.gcChiTiet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueKenhThanhToan,
            this.lueTrangThai});
            this.gcChiTiet.Size = new System.Drawing.Size(1119, 502);
            this.gcChiTiet.TabIndex = 0;
            this.gcChiTiet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChiTiet});
            // 
            // vUserTransactionBindingSource
            // 
            this.vUserTransactionBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vUserTransaction);
            // 
            // gvChiTiet
            // 
            this.gvChiTiet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colusername,
            this.coltime,
            this.colmoney,
            this.colstatus,
            this.gridColumn1,
            this.gridColumn2});
            this.gvChiTiet.GridControl = this.gcChiTiet;
            this.gvChiTiet.Name = "gvChiTiet";
            this.gvChiTiet.OptionsView.ShowAutoFilterRow = true;
            this.gvChiTiet.OptionsView.ShowFooter = true;
            this.gvChiTiet.OptionsView.ShowGroupPanel = false;
            // 
            // colusername
            // 
            this.colusername.Caption = "Username";
            this.colusername.FieldName = "username";
            this.colusername.Name = "colusername";
            this.colusername.OptionsColumn.AllowEdit = false;
            this.colusername.Visible = true;
            this.colusername.VisibleIndex = 0;
            // 
            // coltime
            // 
            this.coltime.Caption = "Thời gian";
            this.coltime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.coltime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coltime.FieldName = "time";
            this.coltime.Name = "coltime";
            this.coltime.OptionsColumn.AllowEdit = false;
            this.coltime.Visible = true;
            this.coltime.VisibleIndex = 5;
            // 
            // colmoney
            // 
            this.colmoney.Caption = "Tiền VNĐ";
            this.colmoney.DisplayFormat.FormatString = "n0";
            this.colmoney.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colmoney.FieldName = "money";
            this.colmoney.Name = "colmoney";
            this.colmoney.OptionsColumn.AllowEdit = false;
            this.colmoney.Visible = true;
            this.colmoney.VisibleIndex = 2;
            // 
            // colstatus
            // 
            this.colstatus.Caption = "Trạng thái giao dịch";
            this.colstatus.ColumnEdit = this.lueTrangThai;
            this.colstatus.FieldName = "status";
            this.colstatus.Name = "colstatus";
            this.colstatus.OptionsColumn.AllowEdit = false;
            this.colstatus.Visible = true;
            this.colstatus.VisibleIndex = 4;
            // 
            // lueTrangThai
            // 
            this.lueTrangThai.AutoHeight = false;
            this.lueTrangThai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTrangThai.DataSource = this.dbCTAfflictionBindingSource;
            this.lueTrangThai.DisplayMember = "value";
            this.lueTrangThai.Name = "lueTrangThai";
            this.lueTrangThai.ValueMember = "id";
            // 
            // dbCTAfflictionBindingSource
            // 
            this.dbCTAfflictionBindingSource.DataSource = typeof(KDQHNPHTool.dbCTAffliction);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nickname";
            this.gridColumn1.FieldName = "nickname";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ruby";
            this.gridColumn2.DisplayFormat.FormatString = "n0";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "ruby";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // lueKenhThanhToan
            // 
            this.lueKenhThanhToan.AutoHeight = false;
            this.lueKenhThanhToan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueKenhThanhToan.DataSource = this.dbCTAfflictionBindingSource;
            this.lueKenhThanhToan.DisplayMember = "value";
            this.lueKenhThanhToan.Name = "lueKenhThanhToan";
            this.lueKenhThanhToan.ValueMember = "id";
            // 
            // ucChiTietNapTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucChiTietNapTien";
            this.Size = new System.Drawing.Size(1123, 557);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vUserTransactionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKenhThanhToan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit lueChonServer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcChiTiet;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChiTiet;
        private System.Windows.Forms.BindingSource vUserTransactionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colusername;
        private DevExpress.XtraGrid.Columns.GridColumn coltime;
        private DevExpress.XtraGrid.Columns.GridColumn colmoney;
        private DevExpress.XtraGrid.Columns.GridColumn colstatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueKenhThanhToan;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;

    }
}
