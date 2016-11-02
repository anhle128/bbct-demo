namespace BBCTDesignerTool.Form
{
    partial class frmTips
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
            this.gcTips = new DevExpress.XtraGrid.GridControl();
            this.gvTips = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.dbTipBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colkeywords = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcTips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTipBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTips
            // 
            this.gcTips.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcTips.DataSource = this.dbTipBindingSource;
            this.gcTips.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcTips.Location = new System.Drawing.Point(0, 40);
            this.gcTips.MainView = this.gvTips;
            this.gcTips.Name = "gcTips";
            this.gcTips.Size = new System.Drawing.Size(844, 521);
            this.gcTips.TabIndex = 4;
            this.gcTips.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTips});
            // 
            // gvTips
            // 
            this.gvTips.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colkeywords});
            this.gvTips.GridControl = this.gcTips;
            this.gvTips.Name = "gvTips";
            this.gvTips.OptionsView.ShowGroupPanel = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::BBCTDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd.Location = new System.Drawing.Point(850, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::BBCTDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete.Location = new System.Drawing.Point(849, 69);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dbTipBindingSource
            // 
            this.dbTipBindingSource.DataSource = typeof(BBCTDesignerTool.dbTip);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colkeywords
            // 
            this.colkeywords.Caption = "Tip";
            this.colkeywords.FieldName = "keywords";
            this.colkeywords.Name = "colkeywords";
            this.colkeywords.Visible = true;
            this.colkeywords.VisibleIndex = 0;
            // 
            // frmTips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 561);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gcTips);
            this.Name = "frmTips";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tips";
            this.Controls.SetChildIndex(this.gcTips, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcTips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTipBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTips;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTips;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.BindingSource dbTipBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colkeywords;
    }
}