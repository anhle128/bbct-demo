﻿namespace BBCTDesignerTool.Form
{
    partial class frmPhucLoiThang
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
            this.gcConfig = new DevExpress.XtraGrid.GridControl();
            this.dbPucLoiThangConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgoldRequire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colngay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.dbPucLoiThangRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypeReward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colstaticID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colamountMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colamountMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprocs = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPucLoiThangConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPucLoiThangRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcConfig);
            this.groupControl1.Location = new System.Drawing.Point(12, 46);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(672, 82);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Thông số";
            // 
            // gcConfig
            // 
            this.gcConfig.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcConfig.DataSource = this.dbPucLoiThangConfigBindingSource;
            this.gcConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcConfig.Location = new System.Drawing.Point(2, 21);
            this.gcConfig.MainView = this.gridView1;
            this.gcConfig.Name = "gcConfig";
            this.gcConfig.Size = new System.Drawing.Size(668, 59);
            this.gcConfig.TabIndex = 0;
            this.gcConfig.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dbPucLoiThangConfigBindingSource
            // 
            this.dbPucLoiThangConfigBindingSource.DataSource = typeof(BBCTDesignerTool.dbPucLoiThangConfig);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colgoldRequire,
            this.colngay});
            this.gridView1.GridControl = this.gcConfig;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colgoldRequire
            // 
            this.colgoldRequire.Caption = "Kim cương yêu cầu";
            this.colgoldRequire.FieldName = "goldRequire";
            this.colgoldRequire.Name = "colgoldRequire";
            this.colgoldRequire.Visible = true;
            this.colgoldRequire.VisibleIndex = 1;
            // 
            // colngay
            // 
            this.colngay.Caption = "Ngày trong tháng diễn ra";
            this.colngay.FieldName = "ngay";
            this.colngay.Name = "colngay";
            this.colngay.Visible = true;
            this.colngay.VisibleIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDelete);
            this.groupControl2.Controls.Add(this.btnAdd);
            this.groupControl2.Controls.Add(this.gcReward);
            this.groupControl2.Location = new System.Drawing.Point(12, 147);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(672, 315);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Vật phẩm nhận được";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::BBCTDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete.Location = new System.Drawing.Point(644, 53);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::BBCTDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd.Location = new System.Drawing.Point(644, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gcReward
            // 
            this.gcReward.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcReward.DataSource = this.dbPucLoiThangRewardBindingSource;
            this.gcReward.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcReward.Location = new System.Drawing.Point(2, 21);
            this.gcReward.MainView = this.gvReward;
            this.gcReward.Name = "gcReward";
            this.gcReward.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueTypeReward,
            this.lueStaticID});
            this.gcReward.Size = new System.Drawing.Size(636, 292);
            this.gcReward.TabIndex = 0;
            this.gcReward.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReward});
            // 
            // dbPucLoiThangRewardBindingSource
            // 
            this.dbPucLoiThangRewardBindingSource.DataSource = typeof(BBCTDesignerTool.dbPucLoiThangReward);
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
            this.coltypeReward.Width = 123;
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
            this.colstaticID.Width = 255;
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
            // colamountMin
            // 
            this.colamountMin.Caption = "SL Min";
            this.colamountMin.FieldName = "amountMin";
            this.colamountMin.Name = "colamountMin";
            this.colamountMin.OptionsColumn.AllowEdit = false;
            this.colamountMin.Visible = true;
            this.colamountMin.VisibleIndex = 2;
            this.colamountMin.Width = 78;
            // 
            // colamountMax
            // 
            this.colamountMax.Caption = "SL Max";
            this.colamountMax.FieldName = "amountMax";
            this.colamountMax.Name = "colamountMax";
            this.colamountMax.OptionsColumn.AllowEdit = false;
            this.colamountMax.Visible = true;
            this.colamountMax.VisibleIndex = 3;
            this.colamountMax.Width = 78;
            // 
            // colprocs
            // 
            this.colprocs.Caption = "Tỷ lệ";
            this.colprocs.FieldName = "procs";
            this.colprocs.Name = "colprocs";
            this.colprocs.OptionsColumn.AllowEdit = false;
            this.colprocs.Visible = true;
            this.colprocs.VisibleIndex = 4;
            this.colprocs.Width = 84;
            // 
            // frmPhucLoiThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 474);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmPhucLoiThang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phúc lợi tháng";
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPucLoiThangConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPucLoiThangRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gcConfig;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gcReward;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.BindingSource dbPucLoiThangConfigBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colgoldRequire;
        private DevExpress.XtraGrid.Columns.GridColumn colngay;
        private System.Windows.Forms.BindingSource dbPucLoiThangRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn coltypeReward;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colstaticID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueStaticID;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMin;
        private DevExpress.XtraGrid.Columns.GridColumn colamountMax;
        private DevExpress.XtraGrid.Columns.GridColumn colprocs;

    }
}