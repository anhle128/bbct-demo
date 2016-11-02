namespace BBCTDesignerTool.Form
{
    partial class frmBadWord
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
            this.gcTuNguCam = new DevExpress.XtraGrid.GridControl();
            this.dbBadWordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvTuNguCam = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colkeys = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcTuNguCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBadWordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTuNguCam)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTuNguCam
            // 
            this.gcTuNguCam.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcTuNguCam.DataSource = this.dbBadWordBindingSource;
            this.gcTuNguCam.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcTuNguCam.Location = new System.Drawing.Point(0, 40);
            this.gcTuNguCam.MainView = this.gvTuNguCam;
            this.gcTuNguCam.Name = "gcTuNguCam";
            this.gcTuNguCam.Size = new System.Drawing.Size(343, 621);
            this.gcTuNguCam.TabIndex = 4;
            this.gcTuNguCam.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTuNguCam});
            // 
            // dbBadWordBindingSource
            // 
            this.dbBadWordBindingSource.DataSource = typeof(BBCTDesignerTool.dbBadWord);
            // 
            // gvTuNguCam
            // 
            this.gvTuNguCam.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colkeys});
            this.gvTuNguCam.GridControl = this.gcTuNguCam;
            this.gvTuNguCam.Name = "gvTuNguCam";
            this.gvTuNguCam.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colkeys
            // 
            this.colkeys.Caption = "Từ khóa";
            this.colkeys.FieldName = "keys";
            this.colkeys.Name = "colkeys";
            this.colkeys.Visible = true;
            this.colkeys.VisibleIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::BBCTDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd.Location = new System.Drawing.Point(349, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::BBCTDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete.Location = new System.Drawing.Point(349, 69);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmBadWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 661);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gcTuNguCam);
            this.Name = "frmBadWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Từ ngữ  cấm trong game";
            this.Controls.SetChildIndex(this.gcTuNguCam, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcTuNguCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBadWordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTuNguCam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTuNguCam;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTuNguCam;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.BindingSource dbBadWordBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colkeys;
    }
}