namespace BBCTDesignerTool.Form
{
    partial class frmThuGuiGM
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
            this.gcMail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dbGMMailConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmaxMailCanSentPerDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltitleLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcontentLength = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGMMailConfigBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMail
            // 
            this.gcMail.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcMail.DataSource = this.dbGMMailConfigBindingSource;
            this.gcMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMail.Location = new System.Drawing.Point(0, 40);
            this.gcMail.MainView = this.gridView1;
            this.gcMail.Name = "gcMail";
            this.gcMail.Size = new System.Drawing.Size(716, 82);
            this.gcMail.TabIndex = 4;
            this.gcMail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colmaxMailCanSentPerDay,
            this.coltitleLength,
            this.colcontentLength});
            this.gridView1.GridControl = this.gcMail;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // dbGMMailConfigBindingSource
            // 
            this.dbGMMailConfigBindingSource.DataSource = typeof(BBCTDesignerTool.dbGMMailConfig);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colmaxMailCanSentPerDay
            // 
            this.colmaxMailCanSentPerDay.Caption = "Max số mail gửi / ngày";
            this.colmaxMailCanSentPerDay.FieldName = "maxMailCanSentPerDay";
            this.colmaxMailCanSentPerDay.Name = "colmaxMailCanSentPerDay";
            this.colmaxMailCanSentPerDay.Visible = true;
            this.colmaxMailCanSentPerDay.VisibleIndex = 0;
            // 
            // coltitleLength
            // 
            this.coltitleLength.Caption = "Độ dài tiêu đề thư";
            this.coltitleLength.FieldName = "titleLength";
            this.coltitleLength.Name = "coltitleLength";
            this.coltitleLength.Visible = true;
            this.coltitleLength.VisibleIndex = 1;
            // 
            // colcontentLength
            // 
            this.colcontentLength.Caption = "Độ dài nội dung thư";
            this.colcontentLength.FieldName = "contentLength";
            this.colcontentLength.Name = "colcontentLength";
            this.colcontentLength.Visible = true;
            this.colcontentLength.VisibleIndex = 2;
            // 
            // frmThuGuiGM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 122);
            this.Controls.Add(this.gcMail);
            this.Name = "frmThuGuiGM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thư gửi GM";
            this.Controls.SetChildIndex(this.gcMail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGMMailConfigBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource dbGMMailConfigBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colmaxMailCanSentPerDay;
        private DevExpress.XtraGrid.Columns.GridColumn coltitleLength;
        private DevExpress.XtraGrid.Columns.GridColumn colcontentLength;
    }
}