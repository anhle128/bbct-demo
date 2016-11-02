namespace KDQHNPHTool.UserController
{
    partial class ucThongKeTheoLevel
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
            this.btnXemKetQua = new DevExpress.XtraEditors.SimpleButton();
            this.txtLevel = new DevExpress.XtraEditors.TextEdit();
            this.lueChonServer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chartLevel = new DevExpress.XtraCharts.ChartControl();
            this.vChart1730BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.frmSplashScreenManager1 = new KDQHNPHTool.FormLoading.frmSplashScreenManager();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vChart1730BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnXemKetQua);
            this.panelControl1.Controls.Add(this.txtLevel);
            this.panelControl1.Controls.Add(this.lueChonServer);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(910, 52);
            this.panelControl1.TabIndex = 0;
            // 
            // btnXemKetQua
            // 
            this.btnXemKetQua.Location = new System.Drawing.Point(566, 15);
            this.btnXemKetQua.Name = "btnXemKetQua";
            this.btnXemKetQua.Size = new System.Drawing.Size(75, 23);
            this.btnXemKetQua.TabIndex = 3;
            this.btnXemKetQua.Text = "Xem kết quả";
            this.btnXemKetQua.Click += new System.EventHandler(this.btnXemKetQua_Click);
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(410, 17);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(100, 20);
            this.txtLevel.TabIndex = 2;
            // 
            // lueChonServer
            // 
            this.lueChonServer.Location = new System.Drawing.Point(97, 17);
            this.lueChonServer.Name = "lueChonServer";
            this.lueChonServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueChonServer.Properties.View = this.searchLookUpEdit1View;
            this.lueChonServer.Size = new System.Drawing.Size(214, 20);
            this.lueChonServer.TabIndex = 1;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(375, 20);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Level:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn server:";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chartLevel);
            this.panelControl2.Controls.Add(this.frmSplashScreenManager1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 52);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(910, 408);
            this.panelControl2.TabIndex = 0;
            // 
            // chartLevel
            // 
            this.chartLevel.DataSource = this.vChart1730BindingSource;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartLevel.Diagram = xyDiagram1;
            this.chartLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLevel.Location = new System.Drawing.Point(2, 2);
            this.chartLevel.Name = "chartLevel";
            series1.ArgumentDataMember = "date";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            series1.CrosshairLabelPattern = "{V:n0}";
            series1.Name = "Người chơi";
            series1.ValueDataMembersSerializable = "value";
            series2.Name = "Series 2";
            series2.Visible = false;
            this.chartLevel.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartLevel.Size = new System.Drawing.Size(906, 404);
            this.chartLevel.TabIndex = 1;
            // 
            // vChart1730BindingSource
            // 
            this.vChart1730BindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vChart1730);
            // 
            // frmSplashScreenManager1
            // 
            this.frmSplashScreenManager1.Location = new System.Drawing.Point(747, 281);
            this.frmSplashScreenManager1.Name = "frmSplashScreenManager1";
            this.frmSplashScreenManager1.Size = new System.Drawing.Size(150, 150);
            this.frmSplashScreenManager1.TabIndex = 0;
            // 
            // ucThongKeTheoLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucThongKeTheoLevel";
            this.Size = new System.Drawing.Size(910, 460);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueChonServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vChart1730BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit lueChonServer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private FormLoading.frmSplashScreenManager frmSplashScreenManager1;
        private DevExpress.XtraCharts.ChartControl chartLevel;
        private System.Windows.Forms.BindingSource vChart1730BindingSource;
        private DevExpress.XtraEditors.TextEdit txtLevel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnXemKetQua;
    }
}
