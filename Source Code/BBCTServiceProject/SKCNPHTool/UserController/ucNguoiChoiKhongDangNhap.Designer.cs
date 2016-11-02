namespace KDQHNPHTool.UserController
{
    partial class ucNguoiChoiKhongDangNhap
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnXemKetQua = new DevExpress.XtraEditors.SimpleButton();
            this.dteMocThoiGian = new DevExpress.XtraEditors.DateEdit();
            this.lueChonServer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chartNoLogin = new DevExpress.XtraCharts.ChartControl();
            this.vChartOnlineTime510152030BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteMocThoiGian.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteMocThoiGian.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNoLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vChartOnlineTime510152030BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnExport);
            this.panelControl1.Controls.Add(this.btnXemKetQua);
            this.panelControl1.Controls.Add(this.dteMocThoiGian);
            this.panelControl1.Controls.Add(this.lueChonServer);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1366, 53);
            this.panelControl1.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(453, 20);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Mốc thời gian:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(146, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Chọn server:";
            // 
            // btnExport
            // 
            this.btnExport.Image = global::KDQHNPHTool.Properties.Resources.excel32x32;
            this.btnExport.Location = new System.Drawing.Point(5, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(40, 40);
            this.btnExport.TabIndex = 2;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnXemKetQua
            // 
            this.btnXemKetQua.Location = new System.Drawing.Point(751, 15);
            this.btnXemKetQua.Name = "btnXemKetQua";
            this.btnXemKetQua.Size = new System.Drawing.Size(75, 23);
            this.btnXemKetQua.TabIndex = 2;
            this.btnXemKetQua.Text = "Xem kết quả";
            this.btnXemKetQua.Click += new System.EventHandler(this.btnXemKetQua_Click);
            // 
            // dteMocThoiGian
            // 
            this.dteMocThoiGian.EditValue = null;
            this.dteMocThoiGian.Location = new System.Drawing.Point(526, 17);
            this.dteMocThoiGian.Name = "dteMocThoiGian";
            this.dteMocThoiGian.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteMocThoiGian.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dteMocThoiGian.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteMocThoiGian.Properties.DisplayFormat.FormatString = "g";
            this.dteMocThoiGian.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteMocThoiGian.Size = new System.Drawing.Size(190, 20);
            this.dteMocThoiGian.TabIndex = 1;
            // 
            // lueChonServer
            // 
            this.lueChonServer.Location = new System.Drawing.Point(215, 17);
            this.lueChonServer.Name = "lueChonServer";
            this.lueChonServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonServer.Properties.View = this.searchLookUpEdit1View;
            this.lueChonServer.Size = new System.Drawing.Size(190, 20);
            this.lueChonServer.TabIndex = 0;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chartNoLogin);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 53);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1366, 547);
            this.panelControl2.TabIndex = 4;
            // 
            // chartNoLogin
            // 
            this.chartNoLogin.DataSource = this.vChartOnlineTime510152030BindingSource;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartNoLogin.Diagram = xyDiagram1;
            this.chartNoLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartNoLogin.Location = new System.Drawing.Point(2, 2);
            this.chartNoLogin.Name = "chartNoLogin";
            series1.ArgumentDataMember = "time";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            series1.CrosshairLabelPattern = "{V:n0}";
            series1.Name = "Người chơi";
            series1.ValueDataMembersSerializable = "value";
            series2.Name = "Series 2";
            series2.Visible = false;
            this.chartNoLogin.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartNoLogin.Size = new System.Drawing.Size(1362, 543);
            this.chartNoLogin.TabIndex = 0;
            // 
            // vChartOnlineTime510152030BindingSource
            // 
            this.vChartOnlineTime510152030BindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vChartOnlineTime510152030);
            // 
            // ucNguoiChoiKhongDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucNguoiChoiKhongDangNhap";
            this.Size = new System.Drawing.Size(1366, 600);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteMocThoiGian.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteMocThoiGian.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNoLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vChartOnlineTime510152030BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit lueChonServer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnXemKetQua;
        private DevExpress.XtraEditors.DateEdit dteMocThoiGian;
        private DevExpress.XtraCharts.ChartControl chartNoLogin;
        private System.Windows.Forms.BindingSource vChartOnlineTime510152030BindingSource;
    }
}
