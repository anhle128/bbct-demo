namespace KDQHDesignerTool.Form
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lueTypeReward = new DevExpress.XtraEditors.LookUpEdit();
            this.txtAmountMin = new DevExpress.XtraEditors.TextEdit();
            this.txtAmountMax = new DevExpress.XtraEditors.TextEdit();
            this.txtProc = new DevExpress.XtraEditors.TextEdit();
            this.slueTypeReward = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.totalRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slueTypeReward.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(57, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Loại:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 100);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Vật phẩm:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(42, 143);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "S.L Min:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(39, 181);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "S.L Max:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(53, 222);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(27, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Tỷ lệ:";
            // 
            // lueTypeReward
            // 
            this.lueTypeReward.Location = new System.Drawing.Point(86, 54);
            this.lueTypeReward.Name = "lueTypeReward";
            this.lueTypeReward.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTypeReward.Properties.DropDownRows = 12;
            this.lueTypeReward.Size = new System.Drawing.Size(177, 20);
            this.lueTypeReward.TabIndex = 5;
            this.lueTypeReward.EditValueChanged += new System.EventHandler(this.lueTypeReward_EditValueChanged);
            // 
            // txtAmountMin
            // 
            this.txtAmountMin.Location = new System.Drawing.Point(87, 140);
            this.txtAmountMin.Name = "txtAmountMin";
            this.txtAmountMin.Size = new System.Drawing.Size(83, 20);
            this.txtAmountMin.TabIndex = 7;
            // 
            // txtAmountMax
            // 
            this.txtAmountMax.Location = new System.Drawing.Point(87, 178);
            this.txtAmountMax.Name = "txtAmountMax";
            this.txtAmountMax.Size = new System.Drawing.Size(83, 20);
            this.txtAmountMax.TabIndex = 7;
            // 
            // txtProc
            // 
            this.txtProc.Location = new System.Drawing.Point(87, 219);
            this.txtProc.Name = "txtProc";
            this.txtProc.Size = new System.Drawing.Size(83, 20);
            this.txtProc.TabIndex = 7;
            // 
            // slueTypeReward
            // 
            this.slueTypeReward.Location = new System.Drawing.Point(86, 97);
            this.slueTypeReward.Name = "slueTypeReward";
            this.slueTypeReward.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slueTypeReward.Properties.DataSource = this.totalRewardBindingSource;
            this.slueTypeReward.Properties.DisplayMember = "value";
            this.slueTypeReward.Properties.ValueMember = "id";
            this.slueTypeReward.Properties.View = this.searchLookUpEdit1View;
            this.slueTypeReward.Size = new System.Drawing.Size(177, 20);
            this.slueTypeReward.TabIndex = 8;
            // 
            // totalRewardBindingSource
            // 
            this.totalRewardBindingSource.DataSource = typeof(KDQHDesignerTool.Models.TotalReward);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // frmEditReward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 254);
            this.Controls.Add(this.slueTypeReward);
            this.Controls.Add(this.txtProc);
            this.Controls.Add(this.txtAmountMax);
            this.Controls.Add(this.txtAmountMin);
            this.Controls.Add(this.lueTypeReward);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmEditReward";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉnh sửa vật phẩm";
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.labelControl4, 0);
            this.Controls.SetChildIndex(this.labelControl5, 0);
            this.Controls.SetChildIndex(this.lueTypeReward, 0);
            this.Controls.SetChildIndex(this.txtAmountMin, 0);
            this.Controls.SetChildIndex(this.txtAmountMax, 0);
            this.Controls.SetChildIndex(this.txtProc, 0);
            this.Controls.SetChildIndex(this.slueTypeReward, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lueTypeReward.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmountMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slueTypeReward.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lueTypeReward;
        private DevExpress.XtraEditors.TextEdit txtAmountMin;
        private DevExpress.XtraEditors.TextEdit txtAmountMax;
        private DevExpress.XtraEditors.TextEdit txtProc;
        private DevExpress.XtraEditors.SearchLookUpEdit slueTypeReward;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private System.Windows.Forms.BindingSource totalRewardBindingSource;
    }
}