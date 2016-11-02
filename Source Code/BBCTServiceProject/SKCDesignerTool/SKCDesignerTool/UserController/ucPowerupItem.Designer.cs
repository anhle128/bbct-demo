namespace KDQHDesignerTool.UserController
{
    partial class ucPowerupItem
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete2 = new DevExpress.XtraEditors.SimpleButton();
            this.gcPowerUpAttribute = new DevExpress.XtraGrid.GridControl();
            this.dbPowerUpItemsAttributeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvPowerUpAttribute = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colattribute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueAttribute = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTPromotionCharacterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colmods = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrowthMod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd2 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd1 = new DevExpress.XtraEditors.SimpleButton();
            this.gcPowerUp = new DevExpress.XtraGrid.GridControl();
            this.dbPowerUpItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvPowerUp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidPowerUpItems = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collevelRequire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpromotion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luePromotion = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPowerUpAttribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPowerUpItemsAttributeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPowerUpAttribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAttribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTPromotionCharacterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPowerUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPowerUpItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPowerUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePromotion)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnDelete2);
            this.panelControl1.Controls.Add(this.gcPowerUpAttribute);
            this.panelControl1.Controls.Add(this.btnAdd2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(960, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(406, 503);
            this.panelControl1.TabIndex = 4;
            // 
            // btnDelete2
            // 
            this.btnDelete2.Image = global::KDQHDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete2.Location = new System.Drawing.Point(378, 34);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(23, 23);
            this.btnDelete2.TabIndex = 1;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // gcPowerUpAttribute
            // 
            this.gcPowerUpAttribute.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcPowerUpAttribute.DataSource = this.dbPowerUpItemsAttributeBindingSource;
            this.gcPowerUpAttribute.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcPowerUpAttribute.Location = new System.Drawing.Point(2, 2);
            this.gcPowerUpAttribute.MainView = this.gvPowerUpAttribute;
            this.gcPowerUpAttribute.Name = "gcPowerUpAttribute";
            this.gcPowerUpAttribute.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueAttribute});
            this.gcPowerUpAttribute.Size = new System.Drawing.Size(370, 499);
            this.gcPowerUpAttribute.TabIndex = 0;
            this.gcPowerUpAttribute.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPowerUpAttribute});
            // 
            // dbPowerUpItemsAttributeBindingSource
            // 
            this.dbPowerUpItemsAttributeBindingSource.DataSource = typeof(KDQHDesignerTool.dbPowerUpItemsAttribute);
            // 
            // gvPowerUpAttribute
            // 
            this.gvPowerUpAttribute.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid1,
            this.colattribute,
            this.colmods,
            this.colgrowthMod});
            this.gvPowerUpAttribute.GridControl = this.gcPowerUpAttribute;
            this.gvPowerUpAttribute.Name = "gvPowerUpAttribute";
            this.gvPowerUpAttribute.OptionsView.ShowGroupPanel = false;
            // 
            // colid1
            // 
            this.colid1.FieldName = "id";
            this.colid1.Name = "colid1";
            // 
            // colattribute
            // 
            this.colattribute.Caption = "Attribute";
            this.colattribute.ColumnEdit = this.lueAttribute;
            this.colattribute.FieldName = "attribute";
            this.colattribute.Name = "colattribute";
            this.colattribute.Visible = true;
            this.colattribute.VisibleIndex = 0;
            this.colattribute.Width = 148;
            // 
            // lueAttribute
            // 
            this.lueAttribute.AutoHeight = false;
            this.lueAttribute.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAttribute.DataSource = this.dbCTPromotionCharacterBindingSource;
            this.lueAttribute.DisplayMember = "value";
            this.lueAttribute.DropDownRows = 15;
            this.lueAttribute.Name = "lueAttribute";
            this.lueAttribute.ValueMember = "id";
            // 
            // dbCTPromotionCharacterBindingSource
            // 
            this.dbCTPromotionCharacterBindingSource.DataSource = typeof(KDQHDesignerTool.dbCTPromotionCharacter);
            // 
            // colmods
            // 
            this.colmods.Caption = "Chỉ số";
            this.colmods.FieldName = "mods";
            this.colmods.Name = "colmods";
            this.colmods.Visible = true;
            this.colmods.VisibleIndex = 1;
            this.colmods.Width = 101;
            // 
            // colgrowthMod
            // 
            this.colgrowthMod.Caption = "Chỉ số tăng trưởng";
            this.colgrowthMod.FieldName = "growthMod";
            this.colgrowthMod.Name = "colgrowthMod";
            this.colgrowthMod.Visible = true;
            this.colgrowthMod.VisibleIndex = 2;
            this.colgrowthMod.Width = 103;
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = global::KDQHDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd2.Location = new System.Drawing.Point(378, 5);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(23, 23);
            this.btnAdd2.TabIndex = 1;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnDelete1);
            this.panelControl2.Controls.Add(this.btnAdd1);
            this.panelControl2.Controls.Add(this.gcPowerUp);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 40);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(960, 503);
            this.panelControl2.TabIndex = 4;
            // 
            // btnDelete1
            // 
            this.btnDelete1.Image = global::KDQHDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete1.Location = new System.Drawing.Point(922, 35);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(23, 23);
            this.btnDelete1.TabIndex = 1;
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.Image = global::KDQHDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd1.Location = new System.Drawing.Point(922, 6);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(23, 23);
            this.btnAdd1.TabIndex = 1;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // gcPowerUp
            // 
            this.gcPowerUp.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcPowerUp.DataSource = this.dbPowerUpItemBindingSource;
            this.gcPowerUp.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcPowerUp.Location = new System.Drawing.Point(2, 2);
            this.gcPowerUp.MainView = this.gvPowerUp;
            this.gcPowerUp.Name = "gcPowerUp";
            this.gcPowerUp.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.luePromotion});
            this.gcPowerUp.Size = new System.Drawing.Size(914, 499);
            this.gcPowerUp.TabIndex = 0;
            this.gcPowerUp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPowerUp});
            // 
            // dbPowerUpItemBindingSource
            // 
            this.dbPowerUpItemBindingSource.DataSource = typeof(KDQHDesignerTool.dbPowerUpItem);
            // 
            // gvPowerUp
            // 
            this.gvPowerUp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colidPowerUpItems,
            this.collevelRequire,
            this.colpromotion,
            this.colname,
            this.coldescription});
            this.gvPowerUp.GridControl = this.gcPowerUp;
            this.gvPowerUp.Name = "gvPowerUp";
            this.gvPowerUp.OptionsView.ShowGroupPanel = false;
            this.gvPowerUp.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvPowerUp_FocusedRowChanged);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colidPowerUpItems
            // 
            this.colidPowerUpItems.Caption = "ID";
            this.colidPowerUpItems.FieldName = "idPowerUpItems";
            this.colidPowerUpItems.Name = "colidPowerUpItems";
            this.colidPowerUpItems.Visible = true;
            this.colidPowerUpItems.VisibleIndex = 0;
            this.colidPowerUpItems.Width = 45;
            // 
            // collevelRequire
            // 
            this.collevelRequire.Caption = "Level yêu cầu";
            this.collevelRequire.FieldName = "levelRequire";
            this.collevelRequire.Name = "collevelRequire";
            this.collevelRequire.Visible = true;
            this.collevelRequire.VisibleIndex = 4;
            this.collevelRequire.Width = 147;
            // 
            // colpromotion
            // 
            this.colpromotion.Caption = "Phẩm chất";
            this.colpromotion.ColumnEdit = this.luePromotion;
            this.colpromotion.FieldName = "promotion";
            this.colpromotion.Name = "colpromotion";
            this.colpromotion.Visible = true;
            this.colpromotion.VisibleIndex = 3;
            this.colpromotion.Width = 144;
            // 
            // luePromotion
            // 
            this.luePromotion.AutoHeight = false;
            this.luePromotion.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePromotion.DataSource = this.dbCTPromotionCharacterBindingSource;
            this.luePromotion.DisplayMember = "value";
            this.luePromotion.Name = "luePromotion";
            this.luePromotion.ValueMember = "id";
            // 
            // colname
            // 
            this.colname.Caption = "Tên vật phẩm cường hóa";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 1;
            this.colname.Width = 212;
            // 
            // coldescription
            // 
            this.coldescription.Caption = "Mô tả";
            this.coldescription.FieldName = "description";
            this.coldescription.Name = "coldescription";
            this.coldescription.Visible = true;
            this.coldescription.VisibleIndex = 2;
            this.coldescription.Width = 348;
            // 
            // ucPowerupItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ucPowerupItem";
            this.Size = new System.Drawing.Size(1366, 543);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPowerUpAttribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPowerUpItemsAttributeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPowerUpAttribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueAttribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTPromotionCharacterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPowerUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPowerUpItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPowerUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePromotion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gcPowerUpAttribute;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPowerUpAttribute;
        private DevExpress.XtraGrid.GridControl gcPowerUp;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPowerUp;
        private DevExpress.XtraEditors.SimpleButton btnDelete1;
        private DevExpress.XtraEditors.SimpleButton btnAdd1;
        private DevExpress.XtraEditors.SimpleButton btnDelete2;
        private DevExpress.XtraEditors.SimpleButton btnAdd2;
        private System.Windows.Forms.BindingSource dbPowerUpItemBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colidPowerUpItems;
        private DevExpress.XtraGrid.Columns.GridColumn collevelRequire;
        private DevExpress.XtraGrid.Columns.GridColumn colpromotion;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn coldescription;
        private System.Windows.Forms.BindingSource dbPowerUpItemsAttributeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn colattribute;
        private DevExpress.XtraGrid.Columns.GridColumn colmods;
        private DevExpress.XtraGrid.Columns.GridColumn colgrowthMod;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueAttribute;
        private System.Windows.Forms.BindingSource dbCTPromotionCharacterBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luePromotion;
    }
}
