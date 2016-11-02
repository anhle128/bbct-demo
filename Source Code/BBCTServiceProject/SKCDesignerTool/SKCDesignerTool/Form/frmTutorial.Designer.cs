namespace BBCTDesignerTool.Form
{
    partial class frmTutorial
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
            this.gcTuto = new DevExpress.XtraGrid.GridControl();
            this.dbTutorialConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnormalCharReward = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colspecialCharReward = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcTuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTutorialConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTuto
            // 
            this.gcTuto.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcTuto.DataSource = this.dbTutorialConfigBindingSource;
            this.gcTuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTuto.Location = new System.Drawing.Point(0, 40);
            this.gcTuto.MainView = this.gridView1;
            this.gcTuto.Name = "gcTuto";
            this.gcTuto.Size = new System.Drawing.Size(717, 75);
            this.gcTuto.TabIndex = 4;
            this.gcTuto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dbTutorialConfigBindingSource
            // 
            this.dbTutorialConfigBindingSource.DataSource = typeof(BBCTDesignerTool.dbTutorialConfig);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colnormalCharReward,
            this.colspecialCharReward});
            this.gridView1.GridControl = this.gcTuto;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colnormalCharReward
            // 
            this.colnormalCharReward.Caption = "Lần quay bình thường";
            this.colnormalCharReward.FieldName = "normalCharReward";
            this.colnormalCharReward.Name = "colnormalCharReward";
            this.colnormalCharReward.Visible = true;
            this.colnormalCharReward.VisibleIndex = 0;
            // 
            // colspecialCharReward
            // 
            this.colspecialCharReward.Caption = "Lần quay đặc biệt";
            this.colspecialCharReward.FieldName = "specialCharReward";
            this.colspecialCharReward.Name = "colspecialCharReward";
            this.colspecialCharReward.Visible = true;
            this.colspecialCharReward.VisibleIndex = 1;
            // 
            // frmTutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 115);
            this.Controls.Add(this.gcTuto);
            this.Name = "frmTutorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tutorial ";
            this.Controls.SetChildIndex(this.gcTuto, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcTuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTutorialConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTuto;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource dbTutorialConfigBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colnormalCharReward;
        private DevExpress.XtraGrid.Columns.GridColumn colspecialCharReward;
    }
}