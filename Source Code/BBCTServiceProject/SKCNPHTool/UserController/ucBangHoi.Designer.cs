namespace KDQHNPHTool.UserController
{
    partial class ucBangHoi
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcBang = new DevExpress.XtraGrid.GridControl();
            this.vGuildBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvBang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colusername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcontribution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnotice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcMember = new DevExpress.XtraGrid.GridControl();
            this.vGuildMemberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvMember = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_id1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcontribution1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colusername1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mGuildBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGuildBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGuildMemberBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGuildBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lueChonServer);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1366, 53);
            this.panelControl1.TabIndex = 0;
            // 
            // lueChonServer
            // 
            this.lueChonServer.Location = new System.Drawing.Point(84, 20);
            this.lueChonServer.Name = "lueChonServer";
            this.lueChonServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonServer.Properties.View = this.searchLookUpEdit1View;
            this.lueChonServer.Size = new System.Drawing.Size(227, 20);
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
            this.labelControl1.Location = new System.Drawing.Point(15, 23);
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
            this.panelControl2.Location = new System.Drawing.Point(0, 93);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1366, 507);
            this.panelControl2.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gcBang);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(927, 503);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Thông tin Bang";
            // 
            // gcBang
            // 
            this.gcBang.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcBang.DataSource = this.vGuildBindingSource;
            this.gcBang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBang.Location = new System.Drawing.Point(2, 21);
            this.gcBang.MainView = this.gvBang;
            this.gcBang.Name = "gcBang";
            this.gcBang.Size = new System.Drawing.Size(923, 480);
            this.gcBang.TabIndex = 0;
            this.gcBang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBang});
            // 
            // vGuildBindingSource
            // 
            this.vGuildBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vGuild);
            // 
            // gvBang
            // 
            this.gvBang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_id,
            this.colname,
            this.colusername,
            this.colcontribution,
            this.colnotice,
            this.collevel});
            this.gvBang.GridControl = this.gcBang;
            this.gvBang.Name = "gvBang";
            this.gvBang.OptionsView.ShowGroupPanel = false;
            this.gvBang.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvBang_FocusedRowChanged);
            // 
            // col_id
            // 
            this.col_id.FieldName = "_id";
            this.col_id.Name = "col_id";
            // 
            // colname
            // 
            this.colname.Caption = "Tên bang";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 0;
            this.colname.Width = 245;
            // 
            // colusername
            // 
            this.colusername.Caption = "Bang chủ";
            this.colusername.FieldName = "username";
            this.colusername.Name = "colusername";
            this.colusername.OptionsColumn.AllowEdit = false;
            this.colusername.Visible = true;
            this.colusername.VisibleIndex = 4;
            this.colusername.Width = 182;
            // 
            // colcontribution
            // 
            this.colcontribution.Caption = "Điểm cống hiến";
            this.colcontribution.FieldName = "contribution";
            this.colcontribution.Name = "colcontribution";
            this.colcontribution.Visible = true;
            this.colcontribution.VisibleIndex = 1;
            this.colcontribution.Width = 134;
            // 
            // colnotice
            // 
            this.colnotice.Caption = "Thông báo";
            this.colnotice.FieldName = "notice";
            this.colnotice.Name = "colnotice";
            this.colnotice.Visible = true;
            this.colnotice.VisibleIndex = 2;
            this.colnotice.Width = 320;
            // 
            // collevel
            // 
            this.collevel.Caption = "Level";
            this.collevel.FieldName = "level";
            this.collevel.Name = "collevel";
            this.collevel.Visible = true;
            this.collevel.VisibleIndex = 3;
            this.collevel.Width = 79;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcMember);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(929, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(435, 503);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thành viên Bang";
            // 
            // gcMember
            // 
            this.gcMember.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcMember.DataSource = this.vGuildMemberBindingSource;
            this.gcMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMember.Location = new System.Drawing.Point(2, 21);
            this.gcMember.MainView = this.gvMember;
            this.gcMember.Name = "gcMember";
            this.gcMember.Size = new System.Drawing.Size(431, 480);
            this.gcMember.TabIndex = 0;
            this.gcMember.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMember});
            // 
            // vGuildMemberBindingSource
            // 
            this.vGuildMemberBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vGuildMember);
            // 
            // gvMember
            // 
            this.gvMember.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_id1,
            this.colcontribution1,
            this.colusername1});
            this.gvMember.GridControl = this.gcMember;
            this.gvMember.Name = "gvMember";
            this.gvMember.OptionsView.ShowGroupPanel = false;
            // 
            // col_id1
            // 
            this.col_id1.FieldName = "_id";
            this.col_id1.Name = "col_id1";
            // 
            // colcontribution1
            // 
            this.colcontribution1.Caption = "Điểm cống hiến";
            this.colcontribution1.FieldName = "contribution";
            this.colcontribution1.Name = "colcontribution1";
            this.colcontribution1.Visible = true;
            this.colcontribution1.VisibleIndex = 1;
            this.colcontribution1.Width = 145;
            // 
            // colusername1
            // 
            this.colusername1.Caption = "Thành viên";
            this.colusername1.FieldName = "username";
            this.colusername1.Name = "colusername1";
            this.colusername1.OptionsColumn.AllowEdit = false;
            this.colusername1.Visible = true;
            this.colusername1.VisibleIndex = 0;
            this.colusername1.Width = 213;
            // 
            // mGuildBindingSource
            // 
            this.mGuildBindingSource.DataSource = typeof(MongoDBModel.SubDatabaseModels.MGuild);
            // 
            // ucBangHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucBangHoi";
            this.Size = new System.Drawing.Size(1366, 600);
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
            ((System.ComponentModel.ISupportInitialize)(this.gcBang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGuildBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGuildMemberBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mGuildBindingSource)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcBang;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBang;
        private DevExpress.XtraGrid.GridControl gcMember;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMember;
        private System.Windows.Forms.BindingSource mGuildBindingSource;
        private System.Windows.Forms.BindingSource vGuildBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn col_id;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn colusername;
        private DevExpress.XtraGrid.Columns.GridColumn colcontribution;
        private DevExpress.XtraGrid.Columns.GridColumn colnotice;
        private DevExpress.XtraGrid.Columns.GridColumn collevel;
        private System.Windows.Forms.BindingSource vGuildMemberBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn col_id1;
        private DevExpress.XtraGrid.Columns.GridColumn colcontribution1;
        private DevExpress.XtraGrid.Columns.GridColumn colusername1;
    }
}
