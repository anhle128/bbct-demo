namespace KDQHDesignerTool.UserController
{
    partial class ucQuanLyItem
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
            this.btnAdd2 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gcAttribute = new DevExpress.XtraGrid.GridControl();
            this.dbItemAttributeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvAttribute = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete2 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.gcItem = new DevExpress.XtraGrid.GridControl();
            this.dbItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvItem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colidItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescriptions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsellPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltypes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lueCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dbCTAfflictionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colborder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luePromotion = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAttribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbItemAttributeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttribute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePromotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = global::KDQHDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd2.Location = new System.Drawing.Point(176, 3);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(23, 23);
            this.btnAdd2.TabIndex = 6;
            this.btnAdd2.Text = "simpleButton1";
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.gcAttribute);
            this.panelControl2.Controls.Add(this.btnDelete2);
            this.panelControl2.Controls.Add(this.btnAdd2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(1162, 40);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(204, 530);
            this.panelControl2.TabIndex = 8;
            // 
            // gcAttribute
            // 
            this.gcAttribute.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcAttribute.DataSource = this.dbItemAttributeBindingSource;
            this.gcAttribute.Location = new System.Drawing.Point(6, 0);
            this.gcAttribute.MainView = this.gvAttribute;
            this.gcAttribute.Name = "gcAttribute";
            this.gcAttribute.Size = new System.Drawing.Size(164, 297);
            this.gcAttribute.TabIndex = 7;
            this.gcAttribute.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAttribute});
            // 
            // dbItemAttributeBindingSource
            // 
            this.dbItemAttributeBindingSource.DataSource = typeof(KDQHDesignerTool.dbItemAttribute);
            // 
            // gvAttribute
            // 
            this.gvAttribute.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid1,
            this.colvalue});
            this.gvAttribute.GridControl = this.gcAttribute;
            this.gvAttribute.Name = "gvAttribute";
            this.gvAttribute.OptionsView.ShowGroupPanel = false;
            // 
            // colid1
            // 
            this.colid1.FieldName = "id";
            this.colid1.Name = "colid1";
            // 
            // colvalue
            // 
            this.colvalue.Caption = "Giá trị";
            this.colvalue.FieldName = "value";
            this.colvalue.Name = "colvalue";
            this.colvalue.Visible = true;
            this.colvalue.VisibleIndex = 0;
            // 
            // btnDelete2
            // 
            this.btnDelete2.Image = global::KDQHDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete2.Location = new System.Drawing.Point(176, 32);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(23, 23);
            this.btnDelete2.TabIndex = 6;
            this.btnDelete2.Text = "simpleButton1";
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.panelControl4);
            this.panelControl3.Controls.Add(this.panelControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 40);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1162, 530);
            this.panelControl3.TabIndex = 9;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.gcItem);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(1127, 530);
            this.panelControl4.TabIndex = 1;
            // 
            // gcItem
            // 
            this.gcItem.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcItem.DataSource = this.dbItemBindingSource;
            this.gcItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcItem.Location = new System.Drawing.Point(0, 0);
            this.gcItem.MainView = this.gvItem;
            this.gcItem.Name = "gcItem";
            this.gcItem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lueCategory,
            this.luePromotion});
            this.gcItem.Size = new System.Drawing.Size(1127, 530);
            this.gcItem.TabIndex = 0;
            this.gcItem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvItem});
            // 
            // dbItemBindingSource
            // 
            this.dbItemBindingSource.DataSource = typeof(KDQHDesignerTool.dbItem);
            // 
            // gvItem
            // 
            this.gvItem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colidItem,
            this.colname,
            this.coldescriptions,
            this.colsellPrice,
            this.coltypes,
            this.colborder});
            this.gvItem.GridControl = this.gcItem;
            this.gvItem.Name = "gvItem";
            this.gvItem.OptionsView.ShowGroupPanel = false;
            this.gvItem.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvItem_FocusedRowChanged);
            // 
            // colid
            // 
            this.colid.Caption = "id";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colidItem
            // 
            this.colidItem.Caption = "ID";
            this.colidItem.FieldName = "idItem";
            this.colidItem.Name = "colidItem";
            this.colidItem.OptionsColumn.AllowEdit = false;
            this.colidItem.Visible = true;
            this.colidItem.VisibleIndex = 0;
            this.colidItem.Width = 56;
            // 
            // colname
            // 
            this.colname.Caption = "Tên vật phẩm";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 1;
            this.colname.Width = 209;
            // 
            // coldescriptions
            // 
            this.coldescriptions.Caption = "Mô tả";
            this.coldescriptions.FieldName = "descriptions";
            this.coldescriptions.Name = "coldescriptions";
            this.coldescriptions.Visible = true;
            this.coldescriptions.VisibleIndex = 2;
            this.coldescriptions.Width = 272;
            // 
            // colsellPrice
            // 
            this.colsellPrice.Caption = "Giá bán";
            this.colsellPrice.FieldName = "sellPrice";
            this.colsellPrice.Name = "colsellPrice";
            this.colsellPrice.Visible = true;
            this.colsellPrice.VisibleIndex = 3;
            this.colsellPrice.Width = 188;
            // 
            // coltypes
            // 
            this.coltypes.Caption = "Loại";
            this.coltypes.ColumnEdit = this.lueCategory;
            this.coltypes.FieldName = "types";
            this.coltypes.Name = "coltypes";
            this.coltypes.Visible = true;
            this.coltypes.VisibleIndex = 4;
            this.coltypes.Width = 188;
            // 
            // lueCategory
            // 
            this.lueCategory.AutoHeight = false;
            this.lueCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCategory.DataSource = this.dbCTAfflictionBindingSource;
            this.lueCategory.DisplayMember = "value";
            this.lueCategory.DropDownRows = 25;
            this.lueCategory.Name = "lueCategory";
            this.lueCategory.ValueMember = "id";
            // 
            // dbCTAfflictionBindingSource
            // 
            this.dbCTAfflictionBindingSource.DataSource = typeof(KDQHDesignerTool.dbCTAffliction);
            // 
            // colborder
            // 
            this.colborder.Caption = "Phẩm chất";
            this.colborder.ColumnEdit = this.luePromotion;
            this.colborder.FieldName = "border";
            this.colborder.Name = "colborder";
            this.colborder.Visible = true;
            this.colborder.VisibleIndex = 5;
            this.colborder.Width = 196;
            // 
            // luePromotion
            // 
            this.luePromotion.AutoHeight = false;
            this.luePromotion.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePromotion.DataSource = this.dbCTAfflictionBindingSource;
            this.luePromotion.DisplayMember = "value";
            this.luePromotion.Name = "luePromotion";
            this.luePromotion.ValueMember = "id";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnAdd1);
            this.panelControl1.Controls.Add(this.btnDelete1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(1127, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(35, 530);
            this.panelControl1.TabIndex = 0;
            // 
            // btnAdd1
            // 
            this.btnAdd1.Image = global::KDQHDesignerTool.Properties.Resources.compose16x16;
            this.btnAdd1.Location = new System.Drawing.Point(6, 3);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(23, 23);
            this.btnAdd1.TabIndex = 6;
            this.btnAdd1.Text = "simpleButton1";
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // btnDelete1
            // 
            this.btnDelete1.Image = global::KDQHDesignerTool.Properties.Resources.denied16x16;
            this.btnDelete1.Location = new System.Drawing.Point(6, 32);
            this.btnDelete1.Name = "btnDelete1";
            this.btnDelete1.Size = new System.Drawing.Size(23, 23);
            this.btnDelete1.TabIndex = 6;
            this.btnDelete1.Text = "simpleButton1";
            this.btnDelete1.Click += new System.EventHandler(this.btnDelete1_Click);
            // 
            // ucQuanLyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Name = "ucQuanLyItem";
            this.Size = new System.Drawing.Size(1366, 570);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.Controls.SetChildIndex(this.panelControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAttribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbItemAttributeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttribute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTAfflictionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luePromotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAdd2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gcAttribute;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAttribute;
        private DevExpress.XtraEditors.SimpleButton btnDelete2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraGrid.GridControl gcItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvItem;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdd1;
        private DevExpress.XtraEditors.SimpleButton btnDelete1;
        private System.Windows.Forms.BindingSource dbItemBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colidItem;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn coldescriptions;
        private DevExpress.XtraGrid.Columns.GridColumn colsellPrice;
        private DevExpress.XtraGrid.Columns.GridColumn coltypes;
        private DevExpress.XtraGrid.Columns.GridColumn colborder;
        private System.Windows.Forms.BindingSource dbItemAttributeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn colvalue;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lueCategory;
        private System.Windows.Forms.BindingSource dbCTAfflictionBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luePromotion;
    }
}
