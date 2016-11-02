namespace KDQHDesignerTool.UserController
{
    partial class ucQuanLyNhanVat
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
            this.gcCharacter = new DevExpress.XtraGrid.GridControl();
            this.dbCharacterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvCharacter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidCharacter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescriptions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTCategoryCharacterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colpromotion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luePromotion = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colclassCharacter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueClassCharacter = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colisMain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueMainCharacter = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colorders = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCharacterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTCategoryCharacterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePromotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueClassCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMainCharacter)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCharacter
            // 
            this.gcCharacter.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcCharacter.DataSource = this.dbCharacterBindingSource;
            this.gcCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCharacter.Location = new System.Drawing.Point(0, 40);
            this.gcCharacter.MainView = this.gvCharacter;
            this.gcCharacter.Name = "gcCharacter";
            this.gcCharacter.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueCategory,
            this.luePromotion,
            this.lueClassCharacter,
            this.lueMainCharacter});
            this.gcCharacter.Size = new System.Drawing.Size(693, 325);
            this.gcCharacter.TabIndex = 4;
            this.gcCharacter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCharacter});
            // 
            // dbCharacterBindingSource
            // 
            this.dbCharacterBindingSource.DataSource = typeof(KDQHDesignerTool.dbCharacter);
            // 
            // gvCharacter
            // 
            this.gvCharacter.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colidCharacter,
            this.colname,
            this.coldescriptions,
            this.colcategory,
            this.colpromotion,
            this.colclassCharacter,
            this.colisMain,
            this.colorders});
            this.gvCharacter.GridControl = this.gcCharacter;
            this.gvCharacter.Name = "gvCharacter";
            this.gvCharacter.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colidCharacter
            // 
            this.colidCharacter.Caption = "ID";
            this.colidCharacter.FieldName = "idCharacter";
            this.colidCharacter.Name = "colidCharacter";
            this.colidCharacter.OptionsColumn.AllowEdit = false;
            this.colidCharacter.Visible = true;
            this.colidCharacter.VisibleIndex = 0;
            this.colidCharacter.Width = 34;
            // 
            // colname
            // 
            this.colname.Caption = "Tên";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.OptionsColumn.AllowEdit = false;
            this.colname.Visible = true;
            this.colname.VisibleIndex = 2;
            this.colname.Width = 106;
            // 
            // coldescriptions
            // 
            this.coldescriptions.Caption = "Mô tả";
            this.coldescriptions.FieldName = "descriptions";
            this.coldescriptions.Name = "coldescriptions";
            this.coldescriptions.OptionsColumn.AllowEdit = false;
            this.coldescriptions.Visible = true;
            this.coldescriptions.VisibleIndex = 3;
            this.coldescriptions.Width = 175;
            // 
            // colcategory
            // 
            this.colcategory.Caption = "Loại";
            this.colcategory.ColumnEdit = this.lueCategory;
            this.colcategory.FieldName = "category";
            this.colcategory.Name = "colcategory";
            this.colcategory.OptionsColumn.AllowEdit = false;
            this.colcategory.Visible = true;
            this.colcategory.VisibleIndex = 4;
            this.colcategory.Width = 69;
            // 
            // lueCategory
            // 
            this.lueCategory.AutoHeight = false;
            this.lueCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCategory.DataSource = this.dbCTCategoryCharacterBindingSource;
            this.lueCategory.DisplayMember = "value";
            this.lueCategory.Name = "lueCategory";
            this.lueCategory.ValueMember = "id";
            // 
            // dbCTCategoryCharacterBindingSource
            // 
            this.dbCTCategoryCharacterBindingSource.DataSource = typeof(KDQHDesignerTool.dbCTCategoryCharacter);
            // 
            // colpromotion
            // 
            this.colpromotion.Caption = "Phẩm chất";
            this.colpromotion.ColumnEdit = this.luePromotion;
            this.colpromotion.FieldName = "promotion";
            this.colpromotion.Name = "colpromotion";
            this.colpromotion.OptionsColumn.AllowEdit = false;
            this.colpromotion.Visible = true;
            this.colpromotion.VisibleIndex = 5;
            this.colpromotion.Width = 69;
            // 
            // luePromotion
            // 
            this.luePromotion.AutoHeight = false;
            this.luePromotion.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePromotion.DataSource = this.dbCTCategoryCharacterBindingSource;
            this.luePromotion.DisplayMember = "value";
            this.luePromotion.Name = "luePromotion";
            this.luePromotion.ValueMember = "id";
            // 
            // colclassCharacter
            // 
            this.colclassCharacter.Caption = "Class";
            this.colclassCharacter.ColumnEdit = this.lueClassCharacter;
            this.colclassCharacter.FieldName = "classCharacter";
            this.colclassCharacter.Name = "colclassCharacter";
            this.colclassCharacter.OptionsColumn.AllowEdit = false;
            this.colclassCharacter.Visible = true;
            this.colclassCharacter.VisibleIndex = 6;
            this.colclassCharacter.Width = 69;
            // 
            // lueClassCharacter
            // 
            this.lueClassCharacter.AutoHeight = false;
            this.lueClassCharacter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueClassCharacter.DataSource = this.dbCTCategoryCharacterBindingSource;
            this.lueClassCharacter.DisplayMember = "value";
            this.lueClassCharacter.Name = "lueClassCharacter";
            this.lueClassCharacter.ValueMember = "id";
            // 
            // colisMain
            // 
            this.colisMain.Caption = "Nhân vật";
            this.colisMain.ColumnEdit = this.lueMainCharacter;
            this.colisMain.FieldName = "isMain";
            this.colisMain.Name = "colisMain";
            this.colisMain.OptionsColumn.AllowEdit = false;
            this.colisMain.Visible = true;
            this.colisMain.VisibleIndex = 1;
            this.colisMain.Width = 69;
            // 
            // lueMainCharacter
            // 
            this.lueMainCharacter.AutoHeight = false;
            this.lueMainCharacter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMainCharacter.DataSource = this.dbCTCategoryCharacterBindingSource;
            this.lueMainCharacter.DisplayMember = "value";
            this.lueMainCharacter.Name = "lueMainCharacter";
            this.lueMainCharacter.ValueMember = "id";
            // 
            // colorders
            // 
            this.colorders.Caption = "Sắp xếp";
            this.colorders.FieldName = "orders";
            this.colorders.Name = "colorders";
            this.colorders.OptionsColumn.AllowEdit = false;
            this.colorders.Visible = true;
            this.colorders.VisibleIndex = 7;
            this.colorders.Width = 84;
            // 
            // ucQuanLyNhanVat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcCharacter);
            this.Name = "ucQuanLyNhanVat";
            this.Size = new System.Drawing.Size(693, 365);
            this.Controls.SetChildIndex(this.gcCharacter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCharacterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTCategoryCharacterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePromotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueClassCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMainCharacter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcCharacter;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCharacter;
        private System.Windows.Forms.BindingSource dbCharacterBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colidCharacter;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn coldescriptions;
        private DevExpress.XtraGrid.Columns.GridColumn colcategory;
        private DevExpress.XtraGrid.Columns.GridColumn colpromotion;
        private DevExpress.XtraGrid.Columns.GridColumn colclassCharacter;
        private DevExpress.XtraGrid.Columns.GridColumn colisMain;
        private DevExpress.XtraGrid.Columns.GridColumn colorders;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueCategory;
        private System.Windows.Forms.BindingSource dbCTCategoryCharacterBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luePromotion;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueClassCharacter;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueMainCharacter;
    }
}
