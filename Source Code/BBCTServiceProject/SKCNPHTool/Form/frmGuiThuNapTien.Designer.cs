namespace KDQHNPHTool.Form
{
    partial class frmGuiThuNapTien
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
            this.lbThongBao = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnChonNguoiChoi = new DevExpress.XtraEditors.SimpleButton();
            this.dbCTBorderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtKNB = new DevExpress.XtraEditors.TextEdit();
            this.lueServer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lueLoaiNTraoBu = new DevExpress.XtraEditors.LookUpEdit();
            this.dbCTCategoryCharacterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dbCTBorderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKNB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiNTraoBu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTCategoryCharacterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 139);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn server:";
            // 
            // lbThongBao
            // 
            this.lbThongBao.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbThongBao.Location = new System.Drawing.Point(86, 231);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(58, 13);
            this.lbThongBao.TabIndex = 0;
            this.lbThongBao.Text = "Người chơi";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(51, 273);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(29, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Ruby:";
            // 
            // btnChonNguoiChoi
            // 
            this.btnChonNguoiChoi.Location = new System.Drawing.Point(86, 182);
            this.btnChonNguoiChoi.Name = "btnChonNguoiChoi";
            this.btnChonNguoiChoi.Size = new System.Drawing.Size(154, 23);
            this.btnChonNguoiChoi.TabIndex = 4;
            this.btnChonNguoiChoi.Text = "Chọn người chơi";
            this.btnChonNguoiChoi.Click += new System.EventHandler(this.btnChonNguoiChoi_Click);
            // 
            // txtKNB
            // 
            this.txtKNB.Location = new System.Drawing.Point(86, 270);
            this.txtKNB.Name = "txtKNB";
            this.txtKNB.Size = new System.Drawing.Size(100, 20);
            this.txtKNB.TabIndex = 6;
            // 
            // lueServer
            // 
            this.lueServer.Location = new System.Drawing.Point(86, 136);
            this.lueServer.Name = "lueServer";
            this.lueServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueServer.Properties.DataSource = this.dbCTBorderBindingSource;
            this.lueServer.Properties.DisplayMember = "value";
            this.lueServer.Properties.ValueMember = "id";
            this.lueServer.Properties.View = this.searchLookUpEdit1View;
            this.lueServer.Size = new System.Drawing.Size(154, 20);
            this.lueServer.TabIndex = 7;
            this.lueServer.EditValueChanged += new System.EventHandler(this.lueServer_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(57, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Loại:";
            // 
            // lueLoaiNTraoBu
            // 
            this.lueLoaiNTraoBu.Location = new System.Drawing.Point(86, 90);
            this.lueLoaiNTraoBu.Name = "lueLoaiNTraoBu";
            this.lueLoaiNTraoBu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueLoaiNTraoBu.Properties.DataSource = this.dbCTCategoryCharacterBindingSource;
            this.lueLoaiNTraoBu.Properties.DisplayMember = "value";
            this.lueLoaiNTraoBu.Properties.ValueMember = "id";
            this.lueLoaiNTraoBu.Size = new System.Drawing.Size(154, 20);
            this.lueLoaiNTraoBu.TabIndex = 8;
            // 
            // dbCTCategoryCharacterBindingSource
            // 
            this.dbCTCategoryCharacterBindingSource.DataSource = typeof(KDQHNPHTool.dbCTCategoryCharacter);
            // 
            // frmGuiThuNapTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 319);
            this.Controls.Add(this.lueLoaiNTraoBu);
            this.Controls.Add(this.lueServer);
            this.Controls.Add(this.txtKNB);
            this.Controls.Add(this.btnChonNguoiChoi);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lbThongBao);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmGuiThuNapTien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trao bù KNB";
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.lbThongBao, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.btnChonNguoiChoi, 0);
            this.Controls.SetChildIndex(this.txtKNB, 0);
            this.Controls.SetChildIndex(this.lueServer, 0);
            this.Controls.SetChildIndex(this.lueLoaiNTraoBu, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dbCTBorderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKNB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueLoaiNTraoBu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbCTCategoryCharacterBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbThongBao;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnChonNguoiChoi;
        private DevExpress.XtraEditors.TextEdit txtKNB;
        private System.Windows.Forms.BindingSource dbCTBorderBindingSource;
        private DevExpress.XtraEditors.SearchLookUpEdit lueServer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueLoaiNTraoBu;
        private System.Windows.Forms.BindingSource dbCTCategoryCharacterBindingSource;
    }
}