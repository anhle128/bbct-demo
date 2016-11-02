namespace KDQHNPHTool.Form
{
    partial class frmQuanLyNguoiDung
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.gcNguoiDung = new DevExpress.XtraGrid.GridControl();
            this.dbUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvNguoiDung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypeUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueQuyen = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNguoiDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNguoiDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTrangThai)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(867, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 532);
            this.barDockControlBottom.Size = new System.Drawing.Size(867, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 532);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(867, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 532);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Glyph = global::KDQHNPHTool.Properties.Resources.upload32x32;
            this.btnLuu.Id = 0;
            this.btnLuu.Name = "btnLuu";
            // 
            // gcNguoiDung
            // 
            this.gcNguoiDung.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcNguoiDung.DataSource = this.dbUserBindingSource;
            this.gcNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNguoiDung.Location = new System.Drawing.Point(0, 40);
            this.gcNguoiDung.MainView = this.gvNguoiDung;
            this.gcNguoiDung.MenuManager = this.barManager1;
            this.gcNguoiDung.Name = "gcNguoiDung";
            this.gcNguoiDung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueQuyen,
            this.lueTrangThai});
            this.gcNguoiDung.Size = new System.Drawing.Size(867, 492);
            this.gcNguoiDung.TabIndex = 8;
            this.gcNguoiDung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNguoiDung});
            // 
            // dbUserBindingSource
            // 
            this.dbUserBindingSource.DataSource = typeof(KDQHNPHTool.dbUser);
            // 
            // gvNguoiDung
            // 
            this.gvNguoiDung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colname,
            this.coltypeUser,
            this.colstatus});
            this.gvNguoiDung.GridControl = this.gcNguoiDung;
            this.gvNguoiDung.Name = "gvNguoiDung";
            this.gvNguoiDung.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colname
            // 
            this.colname.Caption = "Tên người dùng";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 0;
            // 
            // coltypeUser
            // 
            this.coltypeUser.Caption = "Quyền";
            this.coltypeUser.ColumnEdit = this.lueQuyen;
            this.coltypeUser.FieldName = "typeUser";
            this.coltypeUser.Name = "coltypeUser";
            this.coltypeUser.Visible = true;
            this.coltypeUser.VisibleIndex = 1;
            // 
            // lueQuyen
            // 
            this.lueQuyen.AutoHeight = false;
            this.lueQuyen.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueQuyen.DataSource = this.dbCTAfflictionBindingSource;
            this.lueQuyen.DisplayMember = "value";
            this.lueQuyen.Name = "lueQuyen";
            this.lueQuyen.ValueMember = "id";
            // 
            // dbCTAfflictionBindingSource
            // 
            this.dbCTAfflictionBindingSource.DataSource = typeof(KDQHNPHTool.dbCTAffliction);
            // 
            // colstatus
            // 
            this.colstatus.Caption = "Trạng thái";
            this.colstatus.ColumnEdit = this.lueTrangThai;
            this.colstatus.FieldName = "status";
            this.colstatus.Name = "colstatus";
            this.colstatus.Visible = true;
            this.colstatus.VisibleIndex = 2;
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
            // frmQuanLyNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 532);
            this.Controls.Add(this.gcNguoiDung);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmQuanLyNguoiDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý người dùng";
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.gcNguoiDung, 0);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNguoiDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNguoiDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTrangThai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraGrid.GridControl gcNguoiDung;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNguoiDung;
        private System.Windows.Forms.BindingSource dbUserBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn coltypeUser;
        private DevExpress.XtraGrid.Columns.GridColumn colstatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueQuyen;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTrangThai;
    }
}