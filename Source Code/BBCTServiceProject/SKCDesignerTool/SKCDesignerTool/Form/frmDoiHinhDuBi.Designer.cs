namespace BBCTDesignerTool.Form
{
    partial class frmDoiHinhDuBi
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
            this.gcConfig = new DevExpress.XtraGrid.GridControl();
            this.dbDoiHinhDuBiRequireBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvConfig = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnumberItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collevels = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbDoiHinhDuBiRequireBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // gcConfig
            // 
            this.gcConfig.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcConfig.DataSource = this.dbDoiHinhDuBiRequireBindingSource;
            this.gcConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcConfig.Location = new System.Drawing.Point(0, 40);
            this.gcConfig.MainView = this.gvConfig;
            this.gcConfig.Name = "gcConfig";
            this.gcConfig.Size = new System.Drawing.Size(300, 323);
            this.gcConfig.TabIndex = 4;
            this.gcConfig.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConfig});
            // 
            // dbDoiHinhDuBiRequireBindingSource
            // 
            this.dbDoiHinhDuBiRequireBindingSource.DataSource = typeof(BBCTDesignerTool.dbDoiHinhDuBiRequire);
            // 
            // gvConfig
            // 
            this.gvConfig.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colnumberItem,
            this.collevels,
            this.colstatus});
            this.gvConfig.GridControl = this.gcConfig;
            this.gvConfig.Name = "gvConfig";
            this.gvConfig.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colnumberItem
            // 
            this.colnumberItem.Caption = "Số lượng Item cần";
            this.colnumberItem.FieldName = "numberItem";
            this.colnumberItem.Name = "colnumberItem";
            this.colnumberItem.Visible = true;
            this.colnumberItem.VisibleIndex = 1;
            // 
            // collevels
            // 
            this.collevels.Caption = "Level";
            this.collevels.FieldName = "levels";
            this.collevels.Name = "collevels";
            this.collevels.Visible = true;
            this.collevels.VisibleIndex = 0;
            // 
            // colstatus
            // 
            this.colstatus.FieldName = "status";
            this.colstatus.Name = "colstatus";
            // 
            // frmDoiHinhDuBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 363);
            this.Controls.Add(this.gcConfig);
            this.Name = "frmDoiHinhDuBi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đội hình dự bị";
            this.Controls.SetChildIndex(this.gcConfig, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbDoiHinhDuBiRequireBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcConfig;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConfig;
        private System.Windows.Forms.BindingSource dbDoiHinhDuBiRequireBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colnumberItem;
        private DevExpress.XtraGrid.Columns.GridColumn collevels;
        private DevExpress.XtraGrid.Columns.GridColumn colstatus;
    }
}