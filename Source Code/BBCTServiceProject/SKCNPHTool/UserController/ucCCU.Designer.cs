namespace KDQHNPHTool.UserController
{
    partial class ucCCU
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
            this.chartCCU = new DevExpress.XtraCharts.ChartControl();
            this.vChartCCUBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartCCU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vChartCCUBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chartCCU
            // 
            this.chartCCU.DataSource = this.vChartCCUBindingSource;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartCCU.Diagram = xyDiagram1;
            this.chartCCU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCCU.Location = new System.Drawing.Point(0, 40);
            this.chartCCU.Name = "chartCCU";
            series1.ArgumentDataMember = "nameServer";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            series1.CrosshairLabelPattern = "{V:n0}";
            series1.Name = "Người chơi";
            series1.ValueDataMembersSerializable = "value";
            series2.Name = "Series 2";
            series2.Visible = false;
            this.chartCCU.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartCCU.Size = new System.Drawing.Size(1118, 393);
            this.chartCCU.TabIndex = 4;
            // 
            // vChartCCUBindingSource
            // 
            this.vChartCCUBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vChartCCU);
            // 
            // ucCCU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartCCU);
            this.Name = "ucCCU";
            this.Size = new System.Drawing.Size(1118, 433);
            this.Controls.SetChildIndex(this.chartCCU, 0);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCCU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vChartCCUBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartCCU;
        private System.Windows.Forms.BindingSource vChartCCUBindingSource;
    }
}
