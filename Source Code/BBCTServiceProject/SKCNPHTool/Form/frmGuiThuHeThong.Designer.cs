namespace KDQHNPHTool.Form
{
    partial class frmGuiThuHeThong
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtTieuDe = new DevExpress.XtraEditors.TextEdit();
            this.txtNoiDung = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDeleteReward = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddReward = new DevExpress.XtraEditors.SimpleButton();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.vRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidFake = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltype_reward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTTypeRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colstatic_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueReward = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckeServer = new DevExpress.XtraEditors.CheckEdit();
            this.ckeNguoiChoi = new DevExpress.XtraEditors.CheckEdit();
            this.btnChonNguoiChoi = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbChonNguoiChoi = new DevExpress.XtraEditors.LabelControl();
            this.lueServer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.txtTieuDe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTTypeRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckeServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckeNguoiChoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(23, 195);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Tiêu đề:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(16, 239);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Nội dung:";
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Location = new System.Drawing.Point(69, 192);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(345, 20);
            this.txtTieuDe.TabIndex = 5;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(69, 236);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(345, 96);
            this.txtNoiDung.TabIndex = 6;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDeleteReward);
            this.groupControl1.Controls.Add(this.btnAddReward);
            this.groupControl1.Controls.Add(this.gcReward);
            this.groupControl1.Location = new System.Drawing.Point(12, 356);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(437, 254);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Quà";
            // 
            // btnDeleteReward
            // 
            this.btnDeleteReward.Image = global::KDQHNPHTool.Properties.Resources.denied16x16;
            this.btnDeleteReward.Location = new System.Drawing.Point(409, 54);
            this.btnDeleteReward.Name = "btnDeleteReward";
            this.btnDeleteReward.Size = new System.Drawing.Size(23, 23);
            this.btnDeleteReward.TabIndex = 1;
            this.btnDeleteReward.Click += new System.EventHandler(this.btnDeleteReward_Click);
            // 
            // btnAddReward
            // 
            this.btnAddReward.Image = global::KDQHNPHTool.Properties.Resources.compose16x16;
            this.btnAddReward.Location = new System.Drawing.Point(409, 25);
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
            this.lueReward});
            this.gcReward.Size = new System.Drawing.Size(401, 231);
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
            this.colidFake,
            this.coltype_reward,
            this.colstatic_id,
            this.colquantity});
            this.gvReward.GridControl = this.gcReward;
            this.gvReward.Name = "gvReward";
            this.gvReward.OptionsView.ShowGroupPanel = false;
            this.gvReward.DoubleClick += new System.EventHandler(this.gvReward_DoubleClick);
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
            this.coltype_reward.Width = 106;
            // 
            // lueTypeReward
            // 
            this.lueTypeReward.AutoHeight = false;
            this.lueTypeReward.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeReward.DataSource = this.dbCTTypeRewardBindingSource;
            this.lueTypeReward.DisplayMember = "value";
            this.lueTypeReward.Name = "lueTypeReward";
            this.lueTypeReward.ValueMember = "id";
            // 
            // dbCTTypeRewardBindingSource
            // 
            this.dbCTTypeRewardBindingSource.DataSource = typeof(KDQHNPHTool.dbCTTypeReward);
            // 
            // colstatic_id
            // 
            this.colstatic_id.Caption = "Tên";
            this.colstatic_id.ColumnEdit = this.lueReward;
            this.colstatic_id.FieldName = "static_id";
            this.colstatic_id.Name = "colstatic_id";
            this.colstatic_id.OptionsColumn.AllowEdit = false;
            this.colstatic_id.Visible = true;
            this.colstatic_id.VisibleIndex = 1;
            this.colstatic_id.Width = 203;
            // 
            // lueReward
            // 
            this.lueReward.AutoHeight = false;
            this.lueReward.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueReward.DataSource = this.dbCTTypeRewardBindingSource;
            this.lueReward.DisplayMember = "value";
            this.lueReward.Name = "lueReward";
            this.lueReward.ValueMember = "id";
            this.lueReward.View = this.repositoryItemSearchLookUpEdit1View;
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
            this.colquantity.Width = 74;
            // 
            // ckeServer
            // 
            this.ckeServer.Location = new System.Drawing.Point(210, 65);
            this.ckeServer.Name = "ckeServer";
            this.ckeServer.Properties.Caption = "Tất cả server";
            this.ckeServer.Size = new System.Drawing.Size(100, 19);
            this.ckeServer.TabIndex = 9;
            this.ckeServer.CheckedChanged += new System.EventHandler(this.ckeServer_CheckedChanged);
            // 
            // ckeNguoiChoi
            // 
            this.ckeNguoiChoi.Location = new System.Drawing.Point(210, 110);
            this.ckeNguoiChoi.Name = "ckeNguoiChoi";
            this.ckeNguoiChoi.Properties.Caption = "Tất cả người chơi";
            this.ckeNguoiChoi.Size = new System.Drawing.Size(113, 19);
            this.ckeNguoiChoi.TabIndex = 9;
            this.ckeNguoiChoi.CheckedChanged += new System.EventHandler(this.ckeNguoiChoi_CheckedChanged);
            // 
            // btnChonNguoiChoi
            // 
            this.btnChonNguoiChoi.Location = new System.Drawing.Point(68, 108);
            this.btnChonNguoiChoi.Name = "btnChonNguoiChoi";
            this.btnChonNguoiChoi.Size = new System.Drawing.Size(136, 23);
            this.btnChonNguoiChoi.TabIndex = 11;
            this.btnChonNguoiChoi.Text = "Chọn người chơi";
            this.btnChonNguoiChoi.Click += new System.EventHandler(this.btnChonNguoiChoi_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 67);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Server:";
            // 
            // lbChonNguoiChoi
            // 
            this.lbChonNguoiChoi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbChonNguoiChoi.Location = new System.Drawing.Point(68, 155);
            this.lbChonNguoiChoi.Name = "lbChonNguoiChoi";
            this.lbChonNguoiChoi.Size = new System.Drawing.Size(58, 13);
            this.lbChonNguoiChoi.TabIndex = 13;
            this.lbChonNguoiChoi.Text = "Người chơi";
            // 
            // lueServer
            // 
            this.lueServer.Location = new System.Drawing.Point(68, 64);
            this.lueServer.Name = "lueServer";
            this.lueServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueServer.Properties.DataSource = this.dbCTTypeRewardBindingSource;
            this.lueServer.Properties.DisplayMember = "value";
            this.lueServer.Properties.ValueMember = "id";
            this.lueServer.Properties.View = this.searchLookUpEdit1View;
            this.lueServer.Size = new System.Drawing.Size(136, 20);
            this.lueServer.TabIndex = 14;
            this.lueServer.EditValueChanged += new System.EventHandler(this.lueServer_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // frmGuiThuHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 621);
            this.Controls.Add(this.lueServer);
            this.Controls.Add(this.lbChonNguoiChoi);
            this.Controls.Add(this.btnChonNguoiChoi);
            this.Controls.Add(this.ckeNguoiChoi);
            this.Controls.Add(this.ckeServer);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.txtTieuDe);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Name = "frmGuiThuHeThong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thư hệ thống";
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.txtTieuDe, 0);
            this.Controls.SetChildIndex(this.txtNoiDung, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.ckeServer, 0);
            this.Controls.SetChildIndex(this.ckeNguoiChoi, 0);
            this.Controls.SetChildIndex(this.btnChonNguoiChoi, 0);
            this.Controls.SetChildIndex(this.lbChonNguoiChoi, 0);
            this.Controls.SetChildIndex(this.lueServer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtTieuDe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTTypeRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckeServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckeNguoiChoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtTieuDe;
        private DevExpress.XtraEditors.MemoEdit txtNoiDung;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcReward;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private System.Windows.Forms.BindingSource vRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colidFake;
        private DevExpress.XtraGrid.Columns.GridColumn coltype_reward;
        private DevExpress.XtraGrid.Columns.GridColumn colstatic_id;
        private DevExpress.XtraGrid.Columns.GridColumn colquantity;
        private DevExpress.XtraEditors.SimpleButton btnDeleteReward;
        private DevExpress.XtraEditors.SimpleButton btnAddReward;
        private DevExpress.XtraEditors.CheckEdit ckeServer;
        private DevExpress.XtraEditors.CheckEdit ckeNguoiChoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private System.Windows.Forms.BindingSource dbCTTypeRewardBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueReward;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.SimpleButton btnChonNguoiChoi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbChonNguoiChoi;
        private DevExpress.XtraEditors.SearchLookUpEdit lueServer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    }
}