namespace KDQHNPHTool.Form
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
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lueChonServer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete2 = new DevExpress.XtraEditors.SimpleButton();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.vRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidFakeString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidFake = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltype_reward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeReward = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colstatic_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueStaticID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colquantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd2 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd1 = new DevExpress.XtraEditors.SimpleButton();
            this.gcRuong = new DevExpress.XtraGrid.GridControl();
            this.vRuongBauBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvRuong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidRuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldes = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRuongBauBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRuong)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueChonServer);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1202, 50);
            this.panelControl1.TabIndex = 4;
            // 
            // lueChonServer
            // 
            this.lueChonServer.Location = new System.Drawing.Point(96, 15);
            this.lueChonServer.Name = "lueChonServer";
            this.lueChonServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonServer.Properties.View = this.searchLookUpEdit1View;
            this.lueChonServer.Size = new System.Drawing.Size(314, 20);
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
            this.labelControl1.Location = new System.Drawing.Point(27, 18);
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
            this.panelControl2.Location = new System.Drawing.Point(0, 90);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1202, 416);
            this.panelControl2.TabIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnDelete2);
            this.groupControl2.Controls.Add(this.gcReward);
            this.groupControl2.Controls.Add(this.btnAdd2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl2.Location = new System.Drawing.Point(606, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(594, 412);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Vật phẩm trong rương";
            // 
            // btnDelete2
            // 
            this.btnDelete2.Image = global::KDQHNPHTool.Properties.Resources.denied16x16;
            this.btnDelete2.Location = new System.Drawing.Point(566, 53);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(23, 23);
            this.btnDelete2.TabIndex = 1;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
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
            this.gcReward.Size = new System.Drawing.Size(558, 389);
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
            this.colidFakeString,
            this.colidFake,
            this.coltype_reward,
            this.colstatic_id,
            this.colquantity});
            this.gvReward.GridControl = this.gcReward;
            this.gvReward.Name = "gvReward";
            this.gvReward.OptionsView.ShowGroupPanel = false;
            this.gvReward.DoubleClick += new System.EventHandler(this.gvReward_DoubleClick);
            // 
            // colidFakeString
            // 
            this.colidFakeString.Caption = "idRuong";
            this.colidFakeString.FieldName = "idFakeString";
            this.colidFakeString.Name = "colidFakeString";
            // 
            // colidFake
            // 
            this.colidFake.Caption = "id";
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
            this.coltype_reward.Width = 164;
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
            this.colstatic_id.Width = 260;
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
            // colquantity
            // 
            this.colquantity.Caption = "Số lượng";
            this.colquantity.FieldName = "quantity";
            this.colquantity.Name = "colquantity";
            this.colquantity.OptionsColumn.AllowEdit = false;
            this.colquantity.Visible = true;
            this.colquantity.VisibleIndex = 2;
            this.colquantity.Width = 118;
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = global::KDQHNPHTool.Properties.Resources.compose16x16;
            this.btnAdd2.Location = new System.Drawing.Point(566, 24);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(23, 23);
            this.btnAdd2.TabIndex = 1;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDelete1);
            this.groupControl1.Controls.Add(this.btnAdd1);
            this.groupControl1.Controls.Add(this.gcRuong);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(598, 412);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Rương";
            // 
            // btnDelete1
            // 
            this.btnDelete1.Image = global::KDQHNPHTool.Properties.Resources.denied16x16;
            this.btnDelete1.Location = new System.Drawing.Point(570, 53);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(23, 23);
            this.btnDelete1.TabIndex = 1;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.Image = global::KDQHNPHTool.Properties.Resources.compose16x16;
            this.btnAdd1.Location = new System.Drawing.Point(570, 24);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(23, 23);
            this.btnAdd1.TabIndex = 1;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // gcRuong
            // 
            this.gcRuong.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcRuong.DataSource = this.vRuongBauBindingSource;
            this.gcRuong.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcRuong.Location = new System.Drawing.Point(2, 21);
            this.gcRuong.MainView = this.gvRuong;
            this.gcRuong.Name = "gcRuong";
            this.gcRuong.Size = new System.Drawing.Size(562, 389);
            this.gcRuong.TabIndex = 0;
            this.gcRuong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRuong});
            // 
            // vRuongBauBindingSource
            // 
            this.vRuongBauBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vRuongBau);
            // 
            // gvRuong
            // 
            this.gvRuong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidRuong,
            this.colname,
            this.coldes});
            this.gvRuong.GridControl = this.gcRuong;
            this.gvRuong.Name = "gvRuong";
            this.gvRuong.OptionsView.ShowGroupPanel = false;
            this.gvRuong.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvRuong_FocusedRowChanged);
            // 
            // colidRuong
            // 
            this.colidRuong.FieldName = "idRuong";
            this.colidRuong.Name = "colidRuong";
            // 
            // colname
            // 
            this.colname.Caption = "Tên rương";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 0;
            this.colname.Width = 196;
            // 
            // coldes
            // 
            this.coldes.Caption = "Mô tả";
            this.coldes.FieldName = "des";
            this.coldes.Name = "coldes";
            this.coldes.Visible = true;
            this.coldes.VisibleIndex = 1;
            this.coldes.Width = 350;
            // 
            // frmRuongBau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 506);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmRuongBau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rương báu";
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
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueStaticID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRuongBauBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRuong)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcReward;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private DevExpress.XtraGrid.GridControl gcRuong;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRuong;
        private DevExpress.XtraEditors.SimpleButton btnDelete2;
        private DevExpress.XtraEditors.SimpleButton btnAdd2;
        private DevExpress.XtraEditors.SimpleButton btnDelete1;
        private DevExpress.XtraEditors.SimpleButton btnAdd1;
        private System.Windows.Forms.BindingSource vRuongBauBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colidRuong;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn coldes;
        private System.Windows.Forms.BindingSource vRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colidFakeString;
        private DevExpress.XtraGrid.Columns.GridColumn colidFake;
        private DevExpress.XtraGrid.Columns.GridColumn coltype_reward;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeReward;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colstatic_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueStaticID;
        private DevExpress.XtraGrid.Columns.GridColumn colquantity;
    }
}