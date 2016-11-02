namespace BBCTDesignerTool.Form
{
    partial class frmNhiemVuChinhTuyen
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
            this.btnDelete1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd1 = new DevExpress.XtraEditors.SimpleButton();
            this.gcNhiemVu = new DevExpress.XtraGrid.GridControl();
            this.dbNhiemVuChinhTuyenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvNhiemVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidNhiemVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeNhiemVu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstepUpNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnumberRequire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete2 = new DevExpress.XtraEditors.SimpleButton();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.dbNhiemVuChinhTuyenRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypeReward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colstaticID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstepUpQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd2 = new DevExpress.XtraEditors.SimpleButton();
            this.dbNhiemVuChinhTuyenConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNhiemVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbNhiemVuChinhTuyenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhiemVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeNhiemVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbNhiemVuChinhTuyenRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbNhiemVuChinhTuyenConfigBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDelete1);
            this.groupControl1.Controls.Add(this.btnAdd1);
            this.groupControl1.Controls.Add(this.gcNhiemVu);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 40);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(829, 533);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Nhiệm vụ chính tuyến";
            // 
            // btnDelete1
            // 
            this.btnDelete1.Image = global::BBCTDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete1.Location = new System.Drawing.Point(801, 53);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(23, 23);
            this.btnDelete1.TabIndex = 1;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.Image = global::BBCTDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd1.Location = new System.Drawing.Point(801, 24);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(23, 23);
            this.btnAdd1.TabIndex = 1;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // gcNhiemVu
            // 
            this.gcNhiemVu.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcNhiemVu.DataSource = this.dbNhiemVuChinhTuyenBindingSource;
            this.gcNhiemVu.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcNhiemVu.Location = new System.Drawing.Point(2, 21);
            this.gcNhiemVu.MainView = this.gvNhiemVu;
            this.gcNhiemVu.Name = "gcNhiemVu";
            this.gcNhiemVu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueTypeNhiemVu});
            this.gcNhiemVu.Size = new System.Drawing.Size(793, 510);
            this.gcNhiemVu.TabIndex = 0;
            this.gcNhiemVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNhiemVu});
            // 
            // dbNhiemVuChinhTuyenBindingSource
            // 
            this.dbNhiemVuChinhTuyenBindingSource.DataSource = typeof(BBCTDesignerTool.dbNhiemVuChinhTuyen);
            // 
            // gvNhiemVu
            // 
            this.gvNhiemVu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colidNhiemVu,
            this.coltypes,
            this.colname,
            this.coldes,
            this.colnumber,
            this.colstepUpNumber,
            this.colnumberRequire});
            this.gvNhiemVu.GridControl = this.gcNhiemVu;
            this.gvNhiemVu.Name = "gvNhiemVu";
            this.gvNhiemVu.OptionsView.ShowGroupPanel = false;
            this.gvNhiemVu.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvNhiemVu_FocusedRowChanged);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colidNhiemVu
            // 
            this.colidNhiemVu.Caption = "ID";
            this.colidNhiemVu.FieldName = "idNhiemVu";
            this.colidNhiemVu.Name = "colidNhiemVu";
            this.colidNhiemVu.Visible = true;
            this.colidNhiemVu.VisibleIndex = 0;
            this.colidNhiemVu.Width = 59;
            // 
            // coltypes
            // 
            this.coltypes.Caption = "Loại";
            this.coltypes.ColumnEdit = this.lueTypeNhiemVu;
            this.coltypes.FieldName = "types";
            this.coltypes.Name = "coltypes";
            this.coltypes.Visible = true;
            this.coltypes.VisibleIndex = 1;
            this.coltypes.Width = 118;
            // 
            // lueTypeNhiemVu
            // 
            this.lueTypeNhiemVu.AutoHeight = false;
            this.lueTypeNhiemVu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeNhiemVu.DataSource = this.dbCTAfflictionBindingSource;
            this.lueTypeNhiemVu.DisplayMember = "value";
            this.lueTypeNhiemVu.Name = "lueTypeNhiemVu";
            this.lueTypeNhiemVu.ValueMember = "id";
            // 
            // dbCTAfflictionBindingSource
            // 
            this.dbCTAfflictionBindingSource.DataSource = typeof(BBCTDesignerTool.dbCTAffliction);
            // 
            // colname
            // 
            this.colname.Caption = "Tên nhiệm vụ";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 2;
            this.colname.Width = 140;
            // 
            // coldes
            // 
            this.coldes.Caption = "Mô tả";
            this.coldes.FieldName = "des";
            this.coldes.Name = "coldes";
            this.coldes.Visible = true;
            this.coldes.VisibleIndex = 3;
            this.coldes.Width = 228;
            // 
            // colnumber
            // 
            this.colnumber.Caption = "Số lượng";
            this.colnumber.FieldName = "number";
            this.colnumber.Name = "colnumber";
            this.colnumber.Visible = true;
            this.colnumber.VisibleIndex = 4;
            this.colnumber.Width = 63;
            // 
            // colstepUpNumber
            // 
            this.colstepUpNumber.Caption = "Tăng thêm";
            this.colstepUpNumber.FieldName = "stepUpNumber";
            this.colstepUpNumber.Name = "colstepUpNumber";
            this.colstepUpNumber.Visible = true;
            this.colstepUpNumber.VisibleIndex = 5;
            this.colstepUpNumber.Width = 70;
            // 
            // colnumberRequire
            // 
            this.colnumberRequire.Caption = "Số lượng yêu cầu";
            this.colnumberRequire.FieldName = "numberRequire";
            this.colnumberRequire.Name = "colnumberRequire";
            this.colnumberRequire.Visible = true;
            this.colnumberRequire.VisibleIndex = 6;
            this.colnumberRequire.Width = 99;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDelete2);
            this.groupControl2.Controls.Add(this.gcReward);
            this.groupControl2.Controls.Add(this.btnAdd2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl2.Location = new System.Drawing.Point(835, 40);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(515, 533);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Vật phẩm hoàn thành nhiệm vụ";
            // 
            // btnDelete2
            // 
            this.btnDelete2.Image = global::BBCTDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete2.Location = new System.Drawing.Point(487, 53);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(23, 23);
            this.btnDelete2.TabIndex = 1;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // gcReward
            // 
            this.gcReward.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcReward.DataSource = this.dbNhiemVuChinhTuyenRewardBindingSource;
            this.gcReward.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcReward.Location = new System.Drawing.Point(2, 21);
            this.gcReward.MainView = this.gvReward;
            this.gcReward.Name = "gcReward";
            this.gcReward.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueTypeReward,
            this.lueStaticID});
            this.gcReward.Size = new System.Drawing.Size(479, 510);
            this.gcReward.TabIndex = 0;
            this.gcReward.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReward});
            // 
            // dbNhiemVuChinhTuyenRewardBindingSource
            // 
            this.dbNhiemVuChinhTuyenRewardBindingSource.DataSource = typeof(BBCTDesignerTool.dbNhiemVuChinhTuyenReward);
            // 
            // gvReward
            // 
            this.gvReward.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid1,
            this.coltypeReward,
            this.colstaticID,
            this.colquantity,
            this.colstepUpQuantity});
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
            this.coltypeReward.Width = 105;
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
            // colstaticID
            // 
            this.colstaticID.Caption = "Vật phẩm";
            this.colstaticID.ColumnEdit = this.lueStaticID;
            this.colstaticID.FieldName = "staticID";
            this.colstaticID.Name = "colstaticID";
            this.colstaticID.OptionsColumn.AllowEdit = false;
            this.colstaticID.Visible = true;
            this.colstaticID.VisibleIndex = 1;
            this.colstaticID.Width = 185;
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
            this.colquantity.Width = 61;
            // 
            // colstepUpQuantity
            // 
            this.colstepUpQuantity.Caption = "Bước tăng số lượng";
            this.colstepUpQuantity.FieldName = "stepUpQuantity";
            this.colstepUpQuantity.Name = "colstepUpQuantity";
            this.colstepUpQuantity.OptionsColumn.AllowEdit = false;
            this.colstepUpQuantity.Visible = true;
            this.colstepUpQuantity.VisibleIndex = 3;
            this.colstepUpQuantity.Width = 112;
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = global::BBCTDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd2.Location = new System.Drawing.Point(487, 24);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(23, 23);
            this.btnAdd2.TabIndex = 1;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // dbNhiemVuChinhTuyenConfigBindingSource
            // 
            this.dbNhiemVuChinhTuyenConfigBindingSource.DataSource = typeof(BBCTDesignerTool.dbNhiemVuChinhTuyenConfig);
            // 
            // frmNhiemVuChinhTuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 573);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmNhiemVuChinhTuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhiệm vụ chính tuyến";
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNhiemVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbNhiemVuChinhTuyenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhiemVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeNhiemVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbNhiemVuChinhTuyenRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbNhiemVuChinhTuyenConfigBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcNhiemVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNhiemVu;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gcReward;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private DevExpress.XtraEditors.SimpleButton btnDelete1;
        private DevExpress.XtraEditors.SimpleButton btnAdd1;
        private DevExpress.XtraEditors.SimpleButton btnDelete2;
        private DevExpress.XtraEditors.SimpleButton btnAdd2;
        private System.Windows.Forms.BindingSource dbNhiemVuChinhTuyenBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colidNhiemVu;
        private DevExpress.XtraGrid.Columns.GridColumn coltypes;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn coldes;
        private DevExpress.XtraGrid.Columns.GridColumn colnumber;
        private DevExpress.XtraGrid.Columns.GridColumn colstepUpNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colnumberRequire;
        private System.Windows.Forms.BindingSource dbNhiemVuChinhTuyenConfigBindingSource;
        private System.Windows.Forms.BindingSource dbNhiemVuChinhTuyenRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn coltypeReward;
        private DevExpress.XtraGrid.Columns.GridColumn colstaticID;
        private DevExpress.XtraGrid.Columns.GridColumn colquantity;
        private DevExpress.XtraGrid.Columns.GridColumn colstepUpQuantity;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueStaticID;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeNhiemVu;
    }
}