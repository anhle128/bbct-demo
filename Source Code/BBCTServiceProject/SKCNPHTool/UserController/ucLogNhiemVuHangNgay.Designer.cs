namespace KDQHNPHTool.UserController
{
    partial class ucLogNhiemVuHangNgay
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
            this.dteFromDate = new DevExpress.XtraEditors.DateEdit();
            this.btnXemKetQua = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lueChonServer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.serverInMainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chartNhiemVuHangNgay = new DevExpress.XtraCharts.ChartControl();
            this.vChartGoldSilverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverInMainBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhiemVuHangNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vChartGoldSilverBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dteFromDate);
            this.panelControl1.Controls.Add(this.btnXemKetQua);
            this.panelControl1.Controls.Add(this.btnExport);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lueChonServer);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1260, 52);
            this.panelControl1.TabIndex = 0;
            // 
            // dteFromDate
            // 
            this.dteFromDate.EditValue = null;
            this.dteFromDate.Location = new System.Drawing.Point(545, 16);
            this.dteFromDate.Name = "dteFromDate";
            this.dteFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteFromDate.Size = new System.Drawing.Size(246, 20);
            this.dteFromDate.TabIndex = 3;
            // 
            // btnXemKetQua
            // 
            this.btnXemKetQua.Location = new System.Drawing.Point(865, 15);
            this.btnXemKetQua.Name = "btnXemKetQua";
            this.btnXemKetQua.Size = new System.Drawing.Size(75, 23);
            this.btnXemKetQua.TabIndex = 2;
            this.btnXemKetQua.Text = "Xem kết quả";
            this.btnXemKetQua.Click += new System.EventHandler(this.btnXemKetQua_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::KDQHNPHTool.Properties.Resources.excel32x32;
            this.btnExport.Location = new System.Drawing.Point(5, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(40, 40);
            this.btnExport.TabIndex = 2;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(483, 20);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Chọn ngày:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(111, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Chọn server:";
            // 
            // lueChonServer
            // 
            this.lueChonServer.Location = new System.Drawing.Point(180, 17);
            this.lueChonServer.Name = "lueChonServer";
            this.lueChonServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonServer.Properties.DataSource = this.serverInMainBindingSource;
            this.lueChonServer.Properties.DisplayMember = "nameServer";
            this.lueChonServer.Properties.ValueMember = "idServer";
            this.lueChonServer.Properties.View = this.searchLookUpEdit1View;
            this.lueChonServer.Size = new System.Drawing.Size(220, 20);
            this.lueChonServer.TabIndex = 0;
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
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chartNhiemVuHangNgay);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 52);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1260, 498);
            this.panelControl2.TabIndex = 0;
            // 
            // chartNhiemVuHangNgay
            // 
            this.chartNhiemVuHangNgay.DataSource = this.vChartGoldSilverBindingSource;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartNhiemVuHangNgay.Diagram = xyDiagram1;
            this.chartNhiemVuHangNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartNhiemVuHangNgay.Location = new System.Drawing.Point(2, 2);
            this.chartNhiemVuHangNgay.Name = "chartNhiemVuHangNgay";
            series1.ArgumentDataMember = "type";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            series1.CrosshairLabelPattern = "{V:n0}";
            series1.Name = "Người chơi";
            series1.ValueDataMembersSerializable = "daTieu";
            series2.Name = "Series 2";
            series2.Visible = false;
            this.chartNhiemVuHangNgay.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartNhiemVuHangNgay.Size = new System.Drawing.Size(1256, 494);
            this.chartNhiemVuHangNgay.TabIndex = 0;
            // 
            // vChartGoldSilverBindingSource
            // 
            this.vChartGoldSilverBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vChartGoldSilver);
            // 
            // ucLogNhiemVuHangNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucLogNhiemVuHangNgay";
            this.Size = new System.Drawing.Size(1260, 550);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverInMainBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhiemVuHangNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vChartGoldSilverBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.DateEdit dteFromDate;
        private DevExpress.XtraEditors.SimpleButton btnXemKetQua;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit lueChonServer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraCharts.ChartControl chartNhiemVuHangNgay;
        private System.Windows.Forms.BindingSource serverInMainBindingSource;
        private System.Windows.Forms.BindingSource vChartGoldSilverBindingSource;
    }
}
