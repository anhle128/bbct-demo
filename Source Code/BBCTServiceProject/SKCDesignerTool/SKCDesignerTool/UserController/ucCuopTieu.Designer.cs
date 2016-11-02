namespace KDQHDesignerTool.UserController
{
    partial class ucCuopTieu
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
            this.gcCuopTieu = new DevExpress.XtraGrid.GridControl();
            this.gvCuopTieu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dbCuopTieuConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmaxTimesCuopTieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmaxTimesVehicleBiCuop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprocLoseSilver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprocGetSilver = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcCuopTieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCuopTieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCuopTieuConfigBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCuopTieu
            // 
            this.gcCuopTieu.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcCuopTieu.DataSource = this.dbCuopTieuConfigBindingSource;
            this.gcCuopTieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCuopTieu.Location = new System.Drawing.Point(0, 40);
            this.gcCuopTieu.MainView = this.gvCuopTieu;
            this.gcCuopTieu.Name = "gcCuopTieu";
            this.gcCuopTieu.Size = new System.Drawing.Size(1366, 369);
            this.gcCuopTieu.TabIndex = 4;
            this.gcCuopTieu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCuopTieu});
            // 
            // gvCuopTieu
            // 
            this.gvCuopTieu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colmaxTimesCuopTieu,
            this.colmaxTimesVehicleBiCuop,
            this.colprocLoseSilver,
            this.colprocGetSilver});
            this.gvCuopTieu.GridControl = this.gcCuopTieu;
            this.gvCuopTieu.Name = "gvCuopTieu";
            this.gvCuopTieu.OptionsView.ShowGroupPanel = false;
            // 
            // dbCuopTieuConfigBindingSource
            // 
            this.dbCuopTieuConfigBindingSource.DataSource = typeof(KDQHDesignerTool.dbCuopTieuConfig);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colmaxTimesCuopTieu
            // 
            this.colmaxTimesCuopTieu.Caption = "Max Time Cướp tiêu";
            this.colmaxTimesCuopTieu.FieldName = "maxTimesCuopTieu";
            this.colmaxTimesCuopTieu.Name = "colmaxTimesCuopTieu";
            this.colmaxTimesCuopTieu.Visible = true;
            this.colmaxTimesCuopTieu.VisibleIndex = 0;
            // 
            // colmaxTimesVehicleBiCuop
            // 
            this.colmaxTimesVehicleBiCuop.Caption = "Max Time Vehicle";
            this.colmaxTimesVehicleBiCuop.FieldName = "maxTimesVehicleBiCuop";
            this.colmaxTimesVehicleBiCuop.Name = "colmaxTimesVehicleBiCuop";
            this.colmaxTimesVehicleBiCuop.Visible = true;
            this.colmaxTimesVehicleBiCuop.VisibleIndex = 1;
            // 
            // colprocLoseSilver
            // 
            this.colprocLoseSilver.Caption = "Proc Lose Silver";
            this.colprocLoseSilver.FieldName = "procLoseSilver";
            this.colprocLoseSilver.Name = "colprocLoseSilver";
            this.colprocLoseSilver.Visible = true;
            this.colprocLoseSilver.VisibleIndex = 2;
            // 
            // colprocGetSilver
            // 
            this.colprocGetSilver.Caption = "Proc Get Silver";
            this.colprocGetSilver.FieldName = "procGetSilver";
            this.colprocGetSilver.Name = "colprocGetSilver";
            this.colprocGetSilver.Visible = true;
            this.colprocGetSilver.VisibleIndex = 3;
            // 
            // ucCuopTieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcCuopTieu);
            this.Name = "ucCuopTieu";
            this.Size = new System.Drawing.Size(1366, 409);
            this.Controls.SetChildIndex(this.gcCuopTieu, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcCuopTieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCuopTieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCuopTieuConfigBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcCuopTieu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCuopTieu;
        private System.Windows.Forms.BindingSource dbCuopTieuConfigBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colmaxTimesCuopTieu;
        private DevExpress.XtraGrid.Columns.GridColumn colmaxTimesVehicleBiCuop;
        private DevExpress.XtraGrid.Columns.GridColumn colprocLoseSilver;
        private DevExpress.XtraGrid.Columns.GridColumn colprocGetSilver;
    }
}
