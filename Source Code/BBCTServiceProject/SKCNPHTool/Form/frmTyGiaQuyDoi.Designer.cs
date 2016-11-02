namespace KDQHNPHTool.Form
{
    partial class frmTyGiaQuyDoi
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
            this.gcTyGia = new DevExpress.XtraGrid.GridControl();
            this.vRewardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvTyGia = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidFake = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltype_reward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatic_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcTyGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTyGia)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTyGia
            // 
            this.gcTyGia.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcTyGia.DataSource = this.vRewardBindingSource;
            this.gcTyGia.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcTyGia.Location = new System.Drawing.Point(0, 80);
            this.gcTyGia.MainView = this.gvTyGia;
            this.gcTyGia.Name = "gcTyGia";
            this.gcTyGia.Size = new System.Drawing.Size(280, 444);
            this.gcTyGia.TabIndex = 4;
            this.gcTyGia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTyGia});
            // 
            // vRewardBindingSource
            // 
            this.vRewardBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vReward);
            // 
            // gvTyGia
            // 
            this.gvTyGia.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidFake,
            this.coltype_reward,
            this.colstatic_id});
            this.gvTyGia.GridControl = this.gcTyGia;
            this.gvTyGia.Name = "gvTyGia";
            this.gvTyGia.OptionsView.ShowGroupPanel = false;
            // 
            // colidFake
            // 
            this.colidFake.Caption = "Ruby";
            this.colidFake.DisplayFormat.FormatString = "n0";
            this.colidFake.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colidFake.FieldName = "idFake";
            this.colidFake.Name = "colidFake";
            this.colidFake.Visible = true;
            this.colidFake.VisibleIndex = 0;
            // 
            // coltype_reward
            // 
            this.coltype_reward.Caption = "VNĐ";
            this.coltype_reward.DisplayFormat.FormatString = "n0";
            this.coltype_reward.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coltype_reward.FieldName = "type_reward";
            this.coltype_reward.Name = "coltype_reward";
            this.coltype_reward.Visible = true;
            this.coltype_reward.VisibleIndex = 1;
            // 
            // colstatic_id
            // 
            this.colstatic_id.Caption = "ID Fake";
            this.colstatic_id.FieldName = "idFakeString";
            this.colstatic_id.Name = "colstatic_id";
            // 
            // btnAdd1
            // 
            this.btnAdd1.Image = global::KDQHNPHTool.Properties.Resources.compose16x16;
            this.btnAdd1.Location = new System.Drawing.Point(286, 40);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(23, 23);
            this.btnAdd1.TabIndex = 5;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = global::KDQHNPHTool.Properties.Resources.denied16x16;
            this.btnAdd2.Location = new System.Drawing.Point(286, 69);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(23, 23);
            this.btnAdd2.TabIndex = 5;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // frmTyGiaQuyDoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 524);
            this.Controls.Add(this.btnAdd2);
            this.Controls.Add(this.btnAdd1);
            this.Controls.Add(this.gcTyGia);
            this.Name = "frmTyGiaQuyDoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tỷ giá quy đổi";
            this.Controls.SetChildIndex(this.gcTyGia, 0);
            this.Controls.SetChildIndex(this.btnAdd1, 0);
            this.Controls.SetChildIndex(this.btnAdd2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcTyGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vRewardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTyGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTyGia;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTyGia;
        private DevExpress.XtraEditors.SimpleButton btnAdd1;
        private DevExpress.XtraEditors.SimpleButton btnAdd2;
        private System.Windows.Forms.BindingSource vRewardBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colidFake;
        private DevExpress.XtraGrid.Columns.GridColumn coltype_reward;
        private DevExpress.XtraGrid.Columns.GridColumn colstatic_id;
    }
}