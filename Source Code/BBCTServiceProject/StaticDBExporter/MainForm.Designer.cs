namespace StaticDBExporter
{
    partial class MainForm
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
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExportSerializer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoadBinary = new System.Windows.Forms.Button();
            this.jsonViewer1 = new EPocalipse.Json.Viewer.JsonViewer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(6, 19);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(138, 23);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "Load JSON";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(150, 19);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(149, 23);
            this.btnSaveData.TabIndex = 1;
            this.btnSaveData.Text = "Export JSON";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(121, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(110, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export Binary";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExportSerializer
            // 
            this.btnExportSerializer.Location = new System.Drawing.Point(237, 19);
            this.btnExportSerializer.Name = "btnExportSerializer";
            this.btnExportSerializer.Size = new System.Drawing.Size(224, 23);
            this.btnExportSerializer.TabIndex = 3;
            this.btnExportSerializer.Text = "Export Serializer For Unity";
            this.btnExportSerializer.UseVisualStyleBackColor = true;
            this.btnExportSerializer.Click += new System.EventHandler(this.btnExportSerializer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLoadData);
            this.groupBox1.Controls.Add(this.btnSaveData);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 58);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "JSON";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLoadBinary);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.btnExportSerializer);
            this.groupBox2.Location = new System.Drawing.Point(323, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 58);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Binary";
            // 
            // btnLoadBinary
            // 
            this.btnLoadBinary.Location = new System.Drawing.Point(7, 19);
            this.btnLoadBinary.Name = "btnLoadBinary";
            this.btnLoadBinary.Size = new System.Drawing.Size(108, 23);
            this.btnLoadBinary.TabIndex = 3;
            this.btnLoadBinary.Text = "Load Binary";
            this.btnLoadBinary.UseVisualStyleBackColor = true;
            this.btnLoadBinary.Click += new System.EventHandler(this.btnLoadBinary_Click);
            // 
            // jsonViewer1
            // 
            this.jsonViewer1.Json = null;
            this.jsonViewer1.Location = new System.Drawing.Point(12, 76);
            this.jsonViewer1.Name = "jsonViewer1";
            this.jsonViewer1.Size = new System.Drawing.Size(792, 604);
            this.jsonViewer1.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 689);
            this.Controls.Add(this.jsonViewer1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExportSerializer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLoadBinary;
        private EPocalipse.Json.Viewer.JsonViewer jsonViewer1;
    }
}