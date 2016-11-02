namespace BBCTDesignerTool.Form
{
    partial class frmLinkExportStaticDB
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
            this.gcChoose = new DevExpress.XtraGrid.GridControl();
            this.mChooseLinkStaticDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvChoose = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collink = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcChoose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mChooseLinkStaticDBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChoose)).BeginInit();
            this.SuspendLayout();
            // 
            // gcChoose
            // 
            this.gcChoose.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcChoose.DataSource = this.mChooseLinkStaticDBBindingSource;
            this.gcChoose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChoose.Location = new System.Drawing.Point(0, 40);
            this.gcChoose.MainView = this.gvChoose;
            this.gcChoose.Name = "gcChoose";
            this.gcChoose.Size = new System.Drawing.Size(811, 463);
            this.gcChoose.TabIndex = 0;
            this.gcChoose.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChoose});
            // 
            // mChooseLinkStaticDBBindingSource
            // 
            this.mChooseLinkStaticDBBindingSource.DataSource = typeof(BBCTDesignerTool.Models.MChooseLinkStaticDB);
            // 
            // gvChoose
            // 
            this.gvChoose.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colname,
            this.collink,
            this.colchoose,
            this.gridColumn1});
            this.gvChoose.GridControl = this.gcChoose;
            this.gvChoose.Name = "gvChoose";
            this.gvChoose.OptionsView.ShowGroupPanel = false;
            // 
            // colname
            // 
            this.colname.Caption = "Tên Server";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 0;
            this.colname.Width = 168;
            // 
            // collink
            // 
            this.collink.FieldName = "link";
            this.collink.Name = "collink";
            // 
            // colchoose
            // 
            this.colchoose.AppearanceCell.Options.UseTextOptions = true;
            this.colchoose.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colchoose.AppearanceHeader.Options.UseTextOptions = true;
            this.colchoose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colchoose.Caption = "Chọn";
            this.colchoose.FieldName = "choose";
            this.colchoose.Name = "colchoose";
            this.colchoose.Visible = true;
            this.colchoose.VisibleIndex = 2;
            this.colchoose.Width = 86;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Đường dẫn";
            this.gridColumn1.FieldName = "link";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 462;
            // 
            // frmLinkExportStaticDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 503);
            this.Controls.Add(this.gcChoose);
            this.Name = "frmLinkExportStaticDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn server upload StaticID";
            this.Controls.SetChildIndex(this.gcChoose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcChoose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mChooseLinkStaticDBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChoose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcChoose;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChoose;
        private System.Windows.Forms.BindingSource mChooseLinkStaticDBBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn collink;
        private DevExpress.XtraGrid.Columns.GridColumn colchoose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}