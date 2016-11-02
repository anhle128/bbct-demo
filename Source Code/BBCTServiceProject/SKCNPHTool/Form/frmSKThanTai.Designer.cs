namespace KDQHNPHTool.Form
{
    partial class frmSKThanTai
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lueChonServer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.serverInMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lueTrangThai = new DevExpress.XtraEditors.LookUpEdit();
            this.dbCTBorderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dteFromDate = new DevExpress.XtraEditors.DateEdit();
            this.dteToDate = new DevExpress.XtraEditors.DateEdit();
            this.gcReward = new DevExpress.XtraGrid.GridControl();
            this.vThanTaiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvReward = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colgoldRequire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgoldMin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgoldMax = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverInMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTrangThai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTBorderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vThanTaiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Chọn server:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 99);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Từ ngày:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(341, 99);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Đến ngày:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(339, 57);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(53, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Trạng thái:";
            // 
            // lueChonServer
            // 
            this.lueChonServer.Location = new System.Drawing.Point(81, 54);
            this.lueChonServer.Name = "lueChonServer";
            this.lueChonServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonServer.Properties.DataSource = this.serverInMainBindingSource;
            this.lueChonServer.Properties.DisplayMember = "nameServer";
            this.lueChonServer.Properties.ValueMember = "idServer";
            this.lueChonServer.Properties.View = this.searchLookUpEdit1View;
            this.lueChonServer.Size = new System.Drawing.Size(230, 20);
            this.lueChonServer.TabIndex = 5;
            this.lueChonServer.EditValueChanged += new System.EventHandler(this.lueChonServer_EditValueChanged);
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
            // lueTrangThai
            // 
            this.lueTrangThai.Location = new System.Drawing.Point(398, 54);
            this.lueTrangThai.Name = "lueTrangThai";
            this.lueTrangThai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTrangThai.Properties.DataSource = this.dbCTBorderBindingSource;
            this.lueTrangThai.Properties.DisplayMember = "value";
            this.lueTrangThai.Properties.ValueMember = "id";
            this.lueTrangThai.Size = new System.Drawing.Size(100, 20);
            this.lueTrangThai.TabIndex = 6;
            // 
            // dbCTBorderBindingSource
            // 
            this.dbCTBorderBindingSource.DataSource = typeof(KDQHNPHTool.dbCTAffliction);
            // 
            // dteFromDate
            // 
            this.dteFromDate.EditValue = null;
            this.dteFromDate.Location = new System.Drawing.Point(81, 96);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteFromDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dteFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteFromDate.Properties.DisplayFormat.FormatString = "g";
            this.dteFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteFromDate.Size = new System.Drawing.Size(171, 20);
            this.dteFromDate.TabIndex = 7;
            // 
            // dteToDate
            // 
            this.dteToDate.EditValue = null;
            this.dteToDate.Location = new System.Drawing.Point(398, 96);
            this.dteToDate.Name = "dteToDate";
            this.dteToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteToDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dteToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteToDate.Properties.DisplayFormat.FormatString = "g";
            this.dteToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteToDate.Size = new System.Drawing.Size(171, 20);
            this.dteToDate.TabIndex = 7;
            // 
            // gcReward
            // 
            this.gcReward.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcReward.DataSource = this.vThanTaiBindingSource;
            this.gcReward.Location = new System.Drawing.Point(12, 154);
            this.gcReward.MainView = this.gvReward;
            this.gcReward.Name = "gcReward";
            this.gcReward.Size = new System.Drawing.Size(557, 330);
            this.gcReward.TabIndex = 8;
            this.gcReward.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReward});
            // 
            // vThanTaiBindingSource
            // 
            this.vThanTaiBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vThanTai);
            // 
            // gvReward
            // 
            this.gvReward.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colgoldRequire,
            this.colgoldMin,
            this.colgoldMax});
            this.gvReward.GridControl = this.gcReward;
            this.gvReward.Name = "gvReward";
            this.gvReward.OptionsView.ShowGroupPanel = false;
            // 
            // colgoldRequire
            // 
            this.colgoldRequire.Caption = "KNB cần";
            this.colgoldRequire.FieldName = "goldRequire";
            this.colgoldRequire.Name = "colgoldRequire";
            this.colgoldRequire.Visible = true;
            this.colgoldRequire.VisibleIndex = 0;
            // 
            // colgoldMin
            // 
            this.colgoldMin.Caption = "Số KNB Min nhận lại";
            this.colgoldMin.FieldName = "goldMin";
            this.colgoldMin.Name = "colgoldMin";
            this.colgoldMin.Visible = true;
            this.colgoldMin.VisibleIndex = 1;
            // 
            // colgoldMax
            // 
            this.colgoldMax.Caption = "Số KNB Max nhận lại";
            this.colgoldMax.FieldName = "goldMax";
            this.colgoldMax.Name = "colgoldMax";
            this.colgoldMax.Visible = true;
            this.colgoldMax.VisibleIndex = 2;
            // 
            // frmSKThanTai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 496);
            this.Controls.Add(this.gcReward);
            this.Controls.Add(this.dteToDate);
            this.Controls.Add(this.dteFromDate);
            this.Controls.Add(this.lueTrangThai);
            this.Controls.Add(this.lueChonServer);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmSKThanTai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thần tài";
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.lueChonServer, 0);
            this.Controls.SetChildIndex(this.lueTrangThai, 0);
            this.Controls.SetChildIndex(this.dteFromDate, 0);
            this.Controls.SetChildIndex(this.dteToDate, 0);
            this.Controls.SetChildIndex(this.gcReward, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverInMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTrangThai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTBorderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vThanTaiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReward)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SearchLookUpEdit lueChonServer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LookUpEdit lueTrangThai;
        private DevExpress.XtraEditors.DateEdit dteFromDate;
        private DevExpress.XtraEditors.DateEdit dteToDate;
        private DevExpress.XtraGrid.GridControl gcReward;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReward;
        private System.Windows.Forms.BindingSource vThanTaiBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colgoldRequire;
        private DevExpress.XtraGrid.Columns.GridColumn colgoldMin;
        private DevExpress.XtraGrid.Columns.GridColumn colgoldMax;
        private System.Windows.Forms.BindingSource serverInMainBindingSource;
        private System.Windows.Forms.BindingSource dbCTBorderBindingSource;
    }
}