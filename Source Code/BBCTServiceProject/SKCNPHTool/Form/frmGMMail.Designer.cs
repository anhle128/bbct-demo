namespace KDQHNPHTool.Form
{
    partial class frmGMMail
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
            this.gcMail = new DevExpress.XtraGrid.GridControl();
            this.vGmMailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvMail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colserver_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueChonServer = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.dbCTStatusSuKienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colusername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcontent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnXemChiTiet = new DevExpress.XtraBars.BarButtonItem();
            this.btnLamMoi = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGmMailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTStatusSuKienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMail
            // 
            this.gcMail.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcMail.DataSource = this.vGmMailBindingSource;
            this.gcMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMail.Location = new System.Drawing.Point(0, 40);
            this.gcMail.MainView = this.gvMail;
            this.gcMail.Name = "gcMail";
            this.gcMail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueChonServer,
            this.lueTrangThai});
            this.gcMail.Size = new System.Drawing.Size(1350, 621);
            this.gcMail.TabIndex = 0;
            this.gcMail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMail});
            // 
            // vGmMailBindingSource
            // 
            this.vGmMailBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vGmMail);
            // 
            // gvMail
            // 
            this.gvMail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colserver_id,
            this.colusername,
            this.coltitle,
            this.colcontent,
            this.colstatus,
            this.colcreateTime,
            this.gridColumn1});
            this.gvMail.GridControl = this.gcMail;
            this.gvMail.Name = "gvMail";
            this.gvMail.OptionsView.ShowGroupPanel = false;
            this.gvMail.DoubleClick += new System.EventHandler(this.gvMail_DoubleClick);
            // 
            // colserver_id
            // 
            this.colserver_id.Caption = "Server";
            this.colserver_id.ColumnEdit = this.lueChonServer;
            this.colserver_id.FieldName = "server_id";
            this.colserver_id.Name = "colserver_id";
            this.colserver_id.OptionsColumn.AllowEdit = false;
            this.colserver_id.Visible = true;
            this.colserver_id.VisibleIndex = 0;
            this.colserver_id.Width = 206;
            // 
            // lueChonServer
            // 
            this.lueChonServer.AutoHeight = false;
            this.lueChonServer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonServer.DataSource = this.dbCTStatusSuKienBindingSource;
            this.lueChonServer.DisplayMember = "value";
            this.lueChonServer.Name = "lueChonServer";
            this.lueChonServer.ValueMember = "id";
            this.lueChonServer.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // dbCTStatusSuKienBindingSource
            // 
            this.dbCTStatusSuKienBindingSource.DataSource = typeof(KDQHNPHTool.dbCTStatusSuKien);
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colusername
            // 
            this.colusername.Caption = "Tên người gửi";
            this.colusername.FieldName = "username";
            this.colusername.Name = "colusername";
            this.colusername.OptionsColumn.AllowEdit = false;
            this.colusername.Visible = true;
            this.colusername.VisibleIndex = 1;
            this.colusername.Width = 206;
            // 
            // coltitle
            // 
            this.coltitle.Caption = "Tiêu đề";
            this.coltitle.FieldName = "title";
            this.coltitle.Name = "coltitle";
            this.coltitle.OptionsColumn.AllowEdit = false;
            this.coltitle.Visible = true;
            this.coltitle.VisibleIndex = 2;
            this.coltitle.Width = 206;
            // 
            // colcontent
            // 
            this.colcontent.Caption = "Nội dung";
            this.colcontent.FieldName = "content";
            this.colcontent.Name = "colcontent";
            this.colcontent.OptionsColumn.AllowEdit = false;
            this.colcontent.Visible = true;
            this.colcontent.VisibleIndex = 3;
            this.colcontent.Width = 419;
            // 
            // colstatus
            // 
            this.colstatus.Caption = "Trạng thái";
            this.colstatus.ColumnEdit = this.lueTrangThai;
            this.colstatus.FieldName = "status";
            this.colstatus.Name = "colstatus";
            this.colstatus.OptionsColumn.AllowEdit = false;
            this.colstatus.Visible = true;
            this.colstatus.VisibleIndex = 5;
            this.colstatus.Width = 106;
            // 
            // lueTrangThai
            // 
            this.lueTrangThai.AutoHeight = false;
            this.lueTrangThai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTrangThai.DataSource = this.dbCTStatusSuKienBindingSource;
            this.lueTrangThai.DisplayMember = "value";
            this.lueTrangThai.Name = "lueTrangThai";
            this.lueTrangThai.ValueMember = "id";
            this.lueTrangThai.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colcreateTime
            // 
            this.colcreateTime.Caption = "Thời gian gửi";
            this.colcreateTime.FieldName = "createTime";
            this.colcreateTime.Name = "colcreateTime";
            this.colcreateTime.OptionsColumn.AllowEdit = false;
            this.colcreateTime.Visible = true;
            this.colcreateTime.VisibleIndex = 4;
            this.colcreateTime.Width = 96;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "idMail";
            this.gridColumn1.FieldName = "idMail";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnXemChiTiet,
            this.btnLamMoi});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXemChiTiet, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLamMoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Caption = "Xem chi tiết";
            this.btnXemChiTiet.Glyph = global::KDQHNPHTool.Properties.Resources.compose32x32;
            this.btnXemChiTiet.Id = 0;
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemChiTiet_ItemClick);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Caption = "Làm mới";
            this.btnLamMoi.Glyph = global::KDQHNPHTool.Properties.Resources.colorwheel32x32;
            this.btnLamMoi.Id = 1;
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLamMoi_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1350, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 661);
            this.barDockControlBottom.Size = new System.Drawing.Size(1350, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 621);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1350, 40);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 621);
            // 
            // frmGMMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 661);
            this.Controls.Add(this.gcMail);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmGMMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thư gửi GM";
            ((System.ComponentModel.ISupportInitialize)(this.gcMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGmMailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTStatusSuKienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMail;
        private System.Windows.Forms.BindingSource vGmMailBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colserver_id;
        private DevExpress.XtraGrid.Columns.GridColumn colusername;
        private DevExpress.XtraGrid.Columns.GridColumn coltitle;
        private DevExpress.XtraGrid.Columns.GridColumn colcontent;
        private DevExpress.XtraGrid.Columns.GridColumn colstatus;
        private DevExpress.XtraGrid.Columns.GridColumn colcreateTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueChonServer;
        private System.Windows.Forms.BindingSource dbCTStatusSuKienBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueTrangThai;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnXemChiTiet;
        private DevExpress.XtraBars.BarButtonItem btnLamMoi;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}