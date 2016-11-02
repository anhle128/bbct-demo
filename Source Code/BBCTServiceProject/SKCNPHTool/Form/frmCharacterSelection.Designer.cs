namespace KDQHNPHTool.Form
{
    partial class frmCharacterSelection
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
            this.gcCharacter = new DevExpress.XtraGrid.GridControl();
            this.vCharacterSelectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvCharacter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colusername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnickname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colchoose = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vCharacterSelectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCharacter)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCharacter
            // 
            this.gcCharacter.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcCharacter.DataSource = this.vCharacterSelectionBindingSource;
            this.gcCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCharacter.Location = new System.Drawing.Point(0, 40);
            this.gcCharacter.MainView = this.gvCharacter;
            this.gcCharacter.Name = "gcCharacter";
            this.gcCharacter.Size = new System.Drawing.Size(579, 661);
            this.gcCharacter.TabIndex = 4;
            this.gcCharacter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCharacter});
            // 
            // vCharacterSelectionBindingSource
            // 
            this.vCharacterSelectionBindingSource.DataSource = typeof(KDQHNPHTool.Model_View.vCharacterSelection);
            // 
            // gvCharacter
            // 
            this.gvCharacter.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colusername,
            this.colnickname,
            this.colchoose});
            this.gvCharacter.GridControl = this.gcCharacter;
            this.gvCharacter.Name = "gvCharacter";
            this.gvCharacter.OptionsView.ShowAutoFilterRow = true;
            this.gvCharacter.OptionsView.ShowGroupPanel = false;
            // 
            // colusername
            // 
            this.colusername.Caption = "Username";
            this.colusername.FieldName = "username";
            this.colusername.Name = "colusername";
            this.colusername.OptionsColumn.AllowEdit = false;
            this.colusername.Visible = true;
            this.colusername.VisibleIndex = 0;
            this.colusername.Width = 241;
            // 
            // colnickname
            // 
            this.colnickname.Caption = "Nickname";
            this.colnickname.FieldName = "nickname";
            this.colnickname.Name = "colnickname";
            this.colnickname.OptionsColumn.AllowEdit = false;
            this.colnickname.Visible = true;
            this.colnickname.VisibleIndex = 1;
            this.colnickname.Width = 265;
            // 
            // colchoose
            // 
            this.colchoose.AppearanceHeader.Options.UseTextOptions = true;
            this.colchoose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colchoose.Caption = "Lựa chọn";
            this.colchoose.FieldName = "choose";
            this.colchoose.Name = "colchoose";
            this.colchoose.Visible = true;
            this.colchoose.VisibleIndex = 2;
            this.colchoose.Width = 74;
            // 
            // frmCharacterSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 701);
            this.Controls.Add(this.gcCharacter);
            this.Name = "frmCharacterSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn người chơi";
            this.Controls.SetChildIndex(this.gcCharacter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vCharacterSelectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCharacter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcCharacter;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCharacter;
        private System.Windows.Forms.BindingSource vCharacterSelectionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colusername;
        private DevExpress.XtraGrid.Columns.GridColumn colnickname;
        private DevExpress.XtraGrid.Columns.GridColumn colchoose;
    }
}