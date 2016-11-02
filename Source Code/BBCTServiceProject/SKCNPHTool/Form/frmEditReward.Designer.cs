namespace KDQHNPHTool.Form
{
    partial class frmEditReward
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
            this.txtQuantity = new DevExpress.XtraEditors.TextEdit();
            this.lueTypeReward = new DevExpress.XtraEditors.LookUpEdit();
            this.dbCTBorderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lueReward = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lab = new DevExpress.XtraEditors.LabelControl();
            this.lbQuan = new DevExpress.XtraEditors.LabelControl();
            this.txtProc = new DevExpress.XtraEditors.TextEdit();
            this.lbProc = new DevExpress.XtraEditors.LabelControl();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.lbPrice = new DevExpress.XtraEditors.LabelControl();
            this.lbMin = new DevExpress.XtraEditors.LabelControl();
            this.lbMax = new DevExpress.XtraEditors.LabelControl();
            this.lbRuongBau = new DevExpress.XtraEditors.LabelControl();
            this.lueRuongBau = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTBorderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueReward.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueRuongBau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(86, 183);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(85, 20);
            this.txtQuantity.TabIndex = 0;
            // 
            // lueTypeReward
            // 
            this.lueTypeReward.Location = new System.Drawing.Point(86, 51);
            this.lueTypeReward.Name = "lueTypeReward";
            this.lueTypeReward.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeReward.Properties.DataSource = this.dbCTBorderBindingSource;
            this.lueTypeReward.Properties.DisplayMember = "value";
            this.lueTypeReward.Properties.DropDownRows = 11;
            this.lueTypeReward.Properties.ValueMember = "id";
            this.lueTypeReward.Size = new System.Drawing.Size(197, 20);
            this.lueTypeReward.TabIndex = 1;
            this.lueTypeReward.EditValueChanged += new System.EventHandler(this.lueTypeReward_EditValueChanged);
            // 
            // lueReward
            // 
            this.lueReward.Location = new System.Drawing.Point(86, 105);
            this.lueReward.Name = "lueReward";
            this.lueReward.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueReward.Properties.DataSource = this.dbCTBorderBindingSource;
            this.lueReward.Properties.DisplayMember = "value";
            this.lueReward.Properties.ValueMember = "id";
            this.lueReward.Properties.View = this.searchLookUpEdit1View;
            this.lueReward.Size = new System.Drawing.Size(197, 20);
            this.lueReward.TabIndex = 2;
            this.lueReward.EditValueChanged += new System.EventHandler(this.lueReward_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(57, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Loại:";
            // 
            // lab
            // 
            this.lab.Location = new System.Drawing.Point(34, 108);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(49, 13);
            this.lab.TabIndex = 3;
            this.lab.Text = "Vật phẩm:";
            // 
            // lbQuan
            // 
            this.lbQuan.Location = new System.Drawing.Point(34, 186);
            this.lbQuan.Name = "lbQuan";
            this.lbQuan.Size = new System.Drawing.Size(46, 13);
            this.lbQuan.TabIndex = 3;
            this.lbQuan.Text = "Số lượng:";
            // 
            // txtProc
            // 
            this.txtProc.Location = new System.Drawing.Point(86, 228);
            this.txtProc.Name = "txtProc";
            this.txtProc.Size = new System.Drawing.Size(85, 20);
            this.txtProc.TabIndex = 0;
            // 
            // lbProc
            // 
            this.lbProc.Location = new System.Drawing.Point(53, 231);
            this.lbProc.Name = "lbProc";
            this.lbProc.Size = new System.Drawing.Size(27, 13);
            this.lbProc.TabIndex = 3;
            this.lbProc.Text = "Tỷ lệ:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(86, 273);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(85, 20);
            this.txtPrice.TabIndex = 0;
            // 
            // lbPrice
            // 
            this.lbPrice.Location = new System.Drawing.Point(53, 276);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(27, 13);
            this.lbPrice.TabIndex = 3;
            this.lbPrice.Text = "Price:";
            // 
            // lbMin
            // 
            this.lbMin.Location = new System.Drawing.Point(42, 186);
            this.lbMin.Name = "lbMin";
            this.lbMin.Size = new System.Drawing.Size(38, 13);
            this.lbMin.TabIndex = 3;
            this.lbMin.Text = "S.L Min:";
            // 
            // lbMax
            // 
            this.lbMax.Location = new System.Drawing.Point(38, 276);
            this.lbMax.Name = "lbMax";
            this.lbMax.Size = new System.Drawing.Size(42, 13);
            this.lbMax.TabIndex = 3;
            this.lbMax.Text = "S.L Max:";
            // 
            // lbRuongBau
            // 
            this.lbRuongBau.Location = new System.Drawing.Point(23, 145);
            this.lbRuongBau.Name = "lbRuongBau";
            this.lbRuongBau.Size = new System.Drawing.Size(57, 13);
            this.lbRuongBau.TabIndex = 4;
            this.lbRuongBau.Text = "Rương báu:";
            // 
            // lueRuongBau
            // 
            this.lueRuongBau.Location = new System.Drawing.Point(86, 142);
            this.lueRuongBau.Name = "lueRuongBau";
            this.lueRuongBau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueRuongBau.Properties.View = this.gridView1;
            this.lueRuongBau.Size = new System.Drawing.Size(197, 20);
            this.lueRuongBau.TabIndex = 5;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // frmEditReward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 320);
            this.Controls.Add(this.lueRuongBau);
            this.Controls.Add(this.lbRuongBau);
            this.Controls.Add(this.lbMax);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbProc);
            this.Controls.Add(this.lbMin);
            this.Controls.Add(this.lbQuan);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lueReward);
            this.Controls.Add(this.lueTypeReward);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtProc);
            this.Controls.Add(this.txtQuantity);
            this.Name = "frmEditReward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin vật phẩm";
            this.Controls.SetChildIndex(this.txtQuantity, 0);
            this.Controls.SetChildIndex(this.txtProc, 0);
            this.Controls.SetChildIndex(this.txtPrice, 0);
            this.Controls.SetChildIndex(this.lueTypeReward, 0);
            this.Controls.SetChildIndex(this.lueReward, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.lab, 0);
            this.Controls.SetChildIndex(this.lbQuan, 0);
            this.Controls.SetChildIndex(this.lbMin, 0);
            this.Controls.SetChildIndex(this.lbProc, 0);
            this.Controls.SetChildIndex(this.lbPrice, 0);
            this.Controls.SetChildIndex(this.lbMax, 0);
            this.Controls.SetChildIndex(this.lbRuongBau, 0);
            this.Controls.SetChildIndex(this.lueRuongBau, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTBorderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueReward.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueRuongBau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtQuantity;
        private DevExpress.XtraEditors.LookUpEdit lueTypeReward;
        private DevExpress.XtraEditors.SearchLookUpEdit lueReward;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lab;
        private DevExpress.XtraEditors.LabelControl lbQuan;
        private System.Windows.Forms.BindingSource dbCTBorderBindingSource;
        private DevExpress.XtraEditors.TextEdit txtProc;
        private DevExpress.XtraEditors.LabelControl lbProc;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.LabelControl lbPrice;
        private DevExpress.XtraEditors.LabelControl lbMin;
        private DevExpress.XtraEditors.LabelControl lbMax;
        private DevExpress.XtraEditors.LabelControl lbRuongBau;
        private DevExpress.XtraEditors.SearchLookUpEdit lueRuongBau;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}