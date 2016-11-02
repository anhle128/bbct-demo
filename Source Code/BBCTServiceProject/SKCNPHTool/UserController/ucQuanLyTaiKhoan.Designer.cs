namespace KDQHNPHTool.UserController
{
    partial class ucQuanLyTaiKhoan
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
            this.userInforBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbNumber = new DevExpress.XtraEditors.LabelControl();
            this.lueServer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.serverInMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.serverBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.serverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colusername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnickname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgold = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsilver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstamina = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhash_code_login_time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.userInforBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverInMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // userInforBindingSource
            // 
            this.userInforBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vUserInfor);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.lueServer);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1034, 43);
            this.panelControl1.TabIndex = 5;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.lbNumber);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl3.Location = new System.Drawing.Point(826, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(206, 39);
            this.panelControl3.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(5, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(108, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Tổng số người chơi:";
            // 
            // lbNumber
            // 
            this.lbNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbNumber.Location = new System.Drawing.Point(119, 13);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(7, 13);
            this.lbNumber.TabIndex = 2;
            this.lbNumber.Text = "0";
            // 
            // lueServer
            // 
            this.lueServer.Location = new System.Drawing.Point(60, 12);
            this.lueServer.Name = "lueServer";
            this.lueServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueServer.Properties.DataSource = this.serverInMainBindingSource;
            this.lueServer.Properties.DisplayMember = "nameServer";
            this.lueServer.Properties.ValueMember = "idServer";
            this.lueServer.Properties.View = this.searchLookUpEdit1View;
            this.lueServer.Size = new System.Drawing.Size(294, 20);
            this.lueServer.TabIndex = 1;
            this.lueServer.EditValueChanged += new System.EventHandler(this.lueServer_EditValueChanged);
            // 
            // serverInMainBindingSource
            // 
            this.serverInMainBindingSource.DataSource = typeof(KDQHNPHTool.Model.ServerInMain);
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
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(18, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Sever:";
            // 
            // serverBindingSource1
            // 
            this.serverBindingSource1.DataSource = typeof(KDQHNPHTool.Model.Server);
            // 
            // serverBindingSource
            // 
            this.serverBindingSource.DataSource = typeof(KDQHNPHTool.Model.Server);
            // 
            // gcUser
            // 
            this.gcUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcUser.DataSource = this.userInforBindingSource;
            this.gcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUser.Location = new System.Drawing.Point(2, 2);
            this.gcUser.MainView = this.gvUser;
            this.gcUser.Name = "gcUser";
            this.gcUser.Size = new System.Drawing.Size(1030, 472);
            this.gcUser.TabIndex = 4;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser,
            this.gridView1});
            // 
            // gvUser
            // 
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colusername,
            this.colnickname,
            this.colexp,
            this.colgold,
            this.colsilver,
            this.colstamina,
            this.colvip,
            this.collevel,
            this.colhash_code_login_time,
            this.gridColumn1});
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsView.ShowAutoFilterRow = true;
            this.gvUser.OptionsView.ShowGroupPanel = false;
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
            // colnickname
            // 
            this.colnickname.Caption = "Nick Name";
            this.colnickname.FieldName = "nickname";
            this.colnickname.Name = "colnickname";
            this.colnickname.OptionsColumn.AllowEdit = false;
            this.colnickname.Visible = true;
            this.colnickname.VisibleIndex = 1;
            // 
            // colexp
            // 
            this.colexp.Caption = "EXP";
            this.colexp.FieldName = "exp";
            this.colexp.Name = "colexp";
            this.colexp.OptionsColumn.AllowEdit = false;
            this.colexp.Visible = true;
            this.colexp.VisibleIndex = 6;
            // 
            // colgold
            // 
            this.colgold.Caption = "KNB";
            this.colgold.FieldName = "gold";
            this.colgold.Name = "colgold";
            this.colgold.OptionsColumn.AllowEdit = false;
            this.colgold.Visible = true;
            this.colgold.VisibleIndex = 4;
            // 
            // colsilver
            // 
            this.colsilver.Caption = "Bạc";
            this.colsilver.FieldName = "silver";
            this.colsilver.Name = "colsilver";
            this.colsilver.OptionsColumn.AllowEdit = false;
            this.colsilver.Visible = true;
            this.colsilver.VisibleIndex = 5;
            // 
            // colstamina
            // 
            this.colstamina.Caption = "Thể lực";
            this.colstamina.FieldName = "stamina";
            this.colstamina.Name = "colstamina";
            this.colstamina.OptionsColumn.AllowEdit = false;
            this.colstamina.Visible = true;
            this.colstamina.VisibleIndex = 7;
            // 
            // colvip
            // 
            this.colvip.Caption = "Vip";
            this.colvip.FieldName = "vip";
            this.colvip.Name = "colvip";
            this.colvip.OptionsColumn.AllowEdit = false;
            this.colvip.Visible = true;
            this.colvip.VisibleIndex = 3;
            // 
            // collevel
            // 
            this.collevel.Caption = "Level";
            this.collevel.FieldName = "level";
            this.collevel.Name = "collevel";
            this.collevel.OptionsColumn.AllowEdit = false;
            this.collevel.Visible = true;
            this.collevel.VisibleIndex = 2;
            // 
            // colhash_code_login_time
            // 
            this.colhash_code_login_time.Caption = "Ngày tạo";
            this.colhash_code_login_time.FieldName = "create_at";
            this.colhash_code_login_time.Name = "colhash_code_login_time";
            this.colhash_code_login_time.OptionsColumn.AllowEdit = false;
            this.colhash_code_login_time.Visible = true;
            this.colhash_code_login_time.VisibleIndex = 8;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kim cương";
            this.gridColumn1.FieldName = "gold_lock";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcUser;
            this.gridView1.Name = "gridView1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcUser);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 83);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1034, 476);
            this.panelControl2.TabIndex = 6;
            // 
            // ucQuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucQuanLyTaiKhoan";
            this.Size = new System.Drawing.Size(1034, 559);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.userInforBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverInMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource userInforBindingSource;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraGrid.Columns.GridColumn colusername;
        private DevExpress.XtraGrid.Columns.GridColumn colnickname;
        private DevExpress.XtraGrid.Columns.GridColumn colexp;
        private DevExpress.XtraGrid.Columns.GridColumn colgold;
        private DevExpress.XtraGrid.Columns.GridColumn colsilver;
        private DevExpress.XtraGrid.Columns.GridColumn colstamina;
        private DevExpress.XtraGrid.Columns.GridColumn colvip;
        private DevExpress.XtraGrid.Columns.GridColumn collevel;
        private DevExpress.XtraGrid.Columns.GridColumn colhash_code_login_time;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.BindingSource serverBindingSource;
        private System.Windows.Forms.BindingSource serverBindingSource1;
        private DevExpress.XtraEditors.SearchLookUpEdit lueServer;
        private System.Windows.Forms.BindingSource serverInMainBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.LabelControl lbNumber;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
    }
}
