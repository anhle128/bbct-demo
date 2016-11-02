namespace KDQHNPHTool
{
    partial class frmGiftCode
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
            this.gcGiftCode = new DevExpress.XtraGrid.GridControl();
            this.vGiftCodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvGiftCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueType = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colusername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueTypeGiftCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gcGiftCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGiftCodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGiftCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeGiftCode)).BeginInit();
            this.SuspendLayout();
            // 
            // gcGiftCode
            // 
            this.gcGiftCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcGiftCode.DataSource = this.vGiftCodeBindingSource;
            this.gcGiftCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGiftCode.Location = new System.Drawing.Point(0, 40);
            this.gcGiftCode.MainView = this.gvGiftCode;
            this.gcGiftCode.Name = "gcGiftCode";
            this.gcGiftCode.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueTypeGiftCode,
            this.lueType});
            this.gcGiftCode.Size = new System.Drawing.Size(502, 621);
            this.gcGiftCode.TabIndex = 4;
            this.gcGiftCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGiftCode});
            // 
            // vGiftCodeBindingSource
            // 
            this.vGiftCodeBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vGiftCode);
            // 
            // gvGiftCode
            // 
            this.gvGiftCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcategory,
            this.colcode,
            this.colusername});
            this.gvGiftCode.GridControl = this.gcGiftCode;
            this.gvGiftCode.Name = "gvGiftCode";
            this.gvGiftCode.OptionsView.ShowAutoFilterRow = true;
            this.gvGiftCode.OptionsView.ShowGroupPanel = false;
            // 
            // colcategory
            // 
            this.colcategory.Caption = "Loại Gift Code";
            this.colcategory.ColumnEdit = this.lueType;
            this.colcategory.FieldName = "category";
            this.colcategory.Name = "colcategory";
            this.colcategory.OptionsColumn.AllowEdit = false;
            this.colcategory.Visible = true;
            this.colcategory.VisibleIndex = 0;
            // 
            // lueType
            // 
            this.lueType.AutoHeight = false;
            this.lueType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueType.DataSource = this.vGiftCodeBindingSource;
            this.lueType.DisplayMember = "code";
            this.lueType.Name = "lueType";
            this.lueType.ValueMember = "category";
            this.lueType.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colcode
            // 
            this.colcode.Caption = "Code";
            this.colcode.FieldName = "code";
            this.colcode.Name = "colcode";
            this.colcode.OptionsColumn.AllowEdit = false;
            this.colcode.Visible = true;
            this.colcode.VisibleIndex = 1;
            // 
            // colusername
            // 
            this.colusername.Caption = "Loại";
            this.colusername.FieldName = "username";
            this.colusername.Name = "colusername";
            // 
            // lueTypeGiftCode
            // 
            this.lueTypeGiftCode.AutoHeight = false;
            this.lueTypeGiftCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeGiftCode.DataSource = this.vGiftCodeBindingSource;
            this.lueTypeGiftCode.DisplayMember = "code";
            this.lueTypeGiftCode.Name = "lueTypeGiftCode";
            this.lueTypeGiftCode.ValueMember = "category";
            // 
            // frmGiftCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 661);
            this.Controls.Add(this.gcGiftCode);
            this.Name = "frmGiftCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gift Code";
            this.Controls.SetChildIndex(this.gcGiftCode, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcGiftCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGiftCodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGiftCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeGiftCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcGiftCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGiftCode;
        private System.Windows.Forms.BindingSource vGiftCodeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colcategory;
        private DevExpress.XtraGrid.Columns.GridColumn colcode;
        private DevExpress.XtraGrid.Columns.GridColumn colusername;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueTypeGiftCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit lueType;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}