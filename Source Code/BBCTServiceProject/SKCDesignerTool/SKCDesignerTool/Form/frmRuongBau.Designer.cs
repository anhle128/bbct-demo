﻿namespace BBCTDesignerTool.Form
{
    partial class frmRuongBau
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
            this.btnDelete1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd1 = new DevExpress.XtraEditors.SimpleButton();
            this.gcRuong = new DevExpress.XtraGrid.GridControl();
            this.dbRuongBauConfigBindingSource = new System.Windows.Forms.BindingSource();
            this.gvRuong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidRuongBau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete2 = new DevExpress.XtraEditors.SimpleButton();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.dbRuongBauRewardBindingSource = new System.Windows.Forms.BindingSource();
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypeReward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource();
            this.colstaticID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colamountMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colamountMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprocs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd2 = new DevExpress.XtraEditors.SimpleButton();
            this.lueRuong = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dbItemBindingSource = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbRuongBauConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbRuongBauRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueRuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDelete1);
            this.groupControl1.Controls.Add(this.btnAdd1);
            this.groupControl1.Controls.Add(this.gcRuong);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(356, 467);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Rương";
            // 
            // btnDelete1
            // 
            this.btnDelete1.Image = global::BBCTDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete1.Location = new System.Drawing.Point(328, 53);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(23, 23);
            this.btnDelete1.TabIndex = 1;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.Image = global::BBCTDesignerTool.Properties.Resources.compose16x161;
            this.btnAdd1.Location = new System.Drawing.Point(328, 24);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(23, 23);
            this.btnAdd1.TabIndex = 1;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // gcRuong
            // 
            this.gcRuong.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcRuong.DataSource = this.dbRuongBauConfigBindingSource;
            this.gcRuong.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcRuong.Location = new System.Drawing.Point(2, 21);
            this.gcRuong.MainView = this.gvRuong;
            this.gcRuong.Name = "gcRuong";
            this.gcRuong.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueRuong});
            this.gcRuong.Size = new System.Drawing.Size(320, 444);
            this.gcRuong.TabIndex = 0;
            this.gcRuong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRuong});
            // 
            // dbRuongBauConfigBindingSource
            // 
            this.dbRuongBauConfigBindingSource.DataSource = typeof(BBCTDesignerTool.dbRuongBauConfig);
            // 
            // gvRuong
            // 
            this.gvRuong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colidRuongBau,
            this.colname,
            this.colstatus});
            this.gvRuong.GridControl = this.gcRuong;
            this.gvRuong.Name = "gvRuong";
            this.gvRuong.OptionsView.ShowGroupPanel = false;
            this.gvRuong.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvRuong_FocusedRowChanged);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colidRuongBau
            // 
            this.colidRuongBau.Caption = "Rương";
            this.colidRuongBau.ColumnEdit = this.lueRuong;
            this.colidRuongBau.FieldName = "idRuongBau";
            this.colidRuongBau.Name = "colidRuongBau";
            this.colidRuongBau.Visible = true;
            this.colidRuongBau.VisibleIndex = 0;
            this.colidRuongBau.Width = 135;
            // 
            // colname
            // 
            this.colname.Caption = "Tên rương";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Width = 169;
            // 
            // colstatus
            // 
            this.colstatus.FieldName = "status";
            this.colstatus.Name = "colstatus";
            this.colstatus.OptionsColumn.AllowEdit = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDelete2);
            this.groupControl2.Controls.Add(this.gcReward);
            this.groupControl2.Controls.Add(this.btnAdd2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl2.Location = new System.Drawing.Point(362, 40);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(630, 467);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Vật phẩm trong rương";
            // 
            // btnDelete2
            // 
            this.btnDelete2.Image = global::BBCTDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete2.Location = new System.Drawing.Point(602, 53);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(23, 23);
            this.btnDelete2.TabIndex = 1;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // gcReward
            // 
            this.gcReward.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcReward.DataSource = this.dbRuongBauRewardBindingSource;
            this.gcReward.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcReward.Location = new System.Drawing.Point(2, 21);
            this.gcReward.MainView = this.gvReward;
            this.gcReward.Name = "gcReward";
            this.gcReward.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueTypeReward,
            this.lueStaticID});
            this.gcReward.Size = new System.Drawing.Size(594, 444);
            this.gcReward.TabIndex = 0;
            this.gcReward.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReward});
            // 
            // dbRuongBauRewardBindingSource
            // 
            this.dbRuongBauRewardBindingSource.DataSource = typeof(BBCTDesignerTool.dbRuongBauReward);
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
            this.coltypeReward.Width = 138;
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
            this.dbCTAfflictionBindingSource.DataSource = typeof(BBCTDesignerTool.dbCTAffliction);
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
            this.colstaticID.Width = 229;
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
            this.colamountMin.Caption = "SL Min";
            this.colamountMin.FieldName = "amountMin";
            this.colamountMin.Name = "colamountMin";
            this.colamountMin.OptionsColumn.AllowEdit = false;
            this.colamountMin.Visible = true;
            this.colamountMin.VisibleIndex = 2;
            this.colamountMin.Width = 68;
            // 
            // colamountMax
            // 
            this.colamountMax.Caption = "SL Max";
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
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = global::BBCTDesignerTool.Properties.Resources.compose16x161;
            this.btnAdd2.Location = new System.Drawing.Point(602, 24);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(23, 23);
            this.btnAdd2.TabIndex = 1;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // lueRuong
            // 
            this.lueRuong.AutoHeight = false;
            this.lueRuong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueRuong.DataSource = this.dbItemBindingSource;
            this.lueRuong.DisplayMember = "name";
            this.lueRuong.Name = "lueRuong";
            this.lueRuong.ValueMember = "idItem";
            this.lueRuong.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // dbItemBindingSource
            // 
            this.dbItemBindingSource.DataSource = typeof(BBCTDesignerTool.dbItem);
            // 
            // frmRuongBau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 507);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmRuongBau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rương báu";
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbRuongBauConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbRuongBauRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueRuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnDelete1;
        private DevExpress.XtraEditors.SimpleButton btnAdd1;
        private DevExpress.XtraGrid.GridControl gcRuong;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRuong;
        private DevExpress.XtraEditors.SimpleButton btnDelete2;
        private DevExpress.XtraGrid.GridControl gcReward;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private DevExpress.XtraEditors.SimpleButton btnAdd2;
        private System.Windows.Forms.BindingSource dbRuongBauConfigBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colidRuongBau;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn colstatus;
        private System.Windows.Forms.BindingSource dbRuongBauRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn coltypeReward;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colstaticID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueStaticID;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMin;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMax;
        private DevExpress.XtraGrid.Columns.GridColumn colprocs;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueRuong;
        private System.Windows.Forms.BindingSource dbItemBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
    }
}