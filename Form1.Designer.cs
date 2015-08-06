namespace GettingUpTool
{
    partial class Form1
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
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.textFileInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.preview = new System.Windows.Forms.PictureBox();
            this.checkLog = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonScan = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.button2x = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.preview2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.trackOffset = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.color = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonSaveTexture = new System.Windows.Forms.Button();
            this.buttonExportDDS = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preview2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color)).BeginInit();
            this.SuspendLayout();
            // 
            // ofd
            // 
            this.ofd.Filter = "ST files|*.st|BIR files|*.bir|All files|*.*";
            this.ofd.RestoreDirectory = true;
            // 
            // textFileInput
            // 
            this.textFileInput.Location = new System.Drawing.Point(55, 6);
            this.textFileInput.Name = "textFileInput";
            this.textFileInput.Size = new System.Drawing.Size(521, 20);
            this.textFileInput.TabIndex = 0;
            this.textFileInput.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ST file";
            this.label1.Visible = false;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(582, 4);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Visible = false;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Resolution:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(480, 55);
            this.textBox1.MaxLength = 3276700;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(327, 195);
            this.textBox1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Pixel count:";
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(200, 280);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(10, 10);
            this.preview.TabIndex = 7;
            this.preview.TabStop = false;
            // 
            // checkLog
            // 
            this.checkLog.AutoSize = true;
            this.checkLog.Location = new System.Drawing.Point(480, 32);
            this.checkLog.Name = "checkLog";
            this.checkLog.Size = new System.Drawing.Size(86, 17);
            this.checkLog.TabIndex = 8;
            this.checkLog.Text = "Output bytes";
            this.checkLog.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(830, 41);
            this.textBox2.MaxLength = 3276700;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(273, 137);
            this.textBox2.TabIndex = 9;
            this.textBox2.Visible = false;
            // 
            // buttonScan
            // 
            this.buttonScan.Enabled = false;
            this.buttonScan.Location = new System.Drawing.Point(930, 12);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(173, 23);
            this.buttonScan.TabIndex = 10;
            this.buttonScan.Text = "Find texture in game process";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Visible = false;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(201, 128);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(83, 23);
            this.buttonEdit.TabIndex = 11;
            this.buttonEdit.Text = "Edit texture";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // button2x
            // 
            this.button2x.Enabled = false;
            this.button2x.Location = new System.Drawing.Point(290, 128);
            this.button2x.Name = "button2x";
            this.button2x.Size = new System.Drawing.Size(34, 23);
            this.button2x.TabIndex = 12;
            this.button2x.Text = "2x";
            this.button2x.UseVisualStyleBackColor = true;
            this.button2x.Click += new System.EventHandler(this.button2x_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Type:";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(12, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(180, 726);
            this.treeView1.TabIndex = 14;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // preview2
            // 
            this.preview2.Location = new System.Drawing.Point(800, 280);
            this.preview2.Name = "preview2";
            this.preview2.Size = new System.Drawing.Size(10, 10);
            this.preview2.TabIndex = 15;
            this.preview2.TabStop = false;
            this.preview2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.preview2_MouseMove);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Alpha";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(797, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "RGB";
            // 
            // trackOffset
            // 
            this.trackOffset.LargeChange = 1;
            this.trackOffset.Location = new System.Drawing.Point(370, 205);
            this.trackOffset.Maximum = 13;
            this.trackOffset.Minimum = 1;
            this.trackOffset.Name = "trackOffset";
            this.trackOffset.Size = new System.Drawing.Size(104, 45);
            this.trackOffset.TabIndex = 22;
            this.trackOffset.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackOffset.Value = 9;
            this.trackOffset.Visible = false;
            this.trackOffset.Scroll += new System.EventHandler(this.trackOffset_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(384, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Color offset (9)";
            this.label8.Visible = false;
            // 
            // color
            // 
            this.color.Location = new System.Drawing.Point(198, 212);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(20, 20);
            this.color.TabIndex = 28;
            this.color.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(224, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Hovered color";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(224, 224);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "R G B";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(197, 237);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Bytes";
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(830, 50);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(102, 23);
            this.buttonImport.TabIndex = 33;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonSaveTexture
            // 
            this.buttonSaveTexture.Enabled = false;
            this.buttonSaveTexture.Location = new System.Drawing.Point(938, 50);
            this.buttonSaveTexture.Name = "buttonSaveTexture";
            this.buttonSaveTexture.Size = new System.Drawing.Size(102, 23);
            this.buttonSaveTexture.TabIndex = 34;
            this.buttonSaveTexture.Text = "Replace texture";
            this.buttonSaveTexture.UseVisualStyleBackColor = true;
            this.buttonSaveTexture.Click += new System.EventHandler(this.buttonSaveTexture_Click);
            // 
            // buttonExportDDS
            // 
            this.buttonExportDDS.Enabled = false;
            this.buttonExportDDS.Location = new System.Drawing.Point(1046, 50);
            this.buttonExportDDS.Name = "buttonExportDDS";
            this.buttonExportDDS.Size = new System.Drawing.Size(102, 23);
            this.buttonExportDDS.TabIndex = 35;
            this.buttonExportDDS.Text = "Export DDS";
            this.buttonExportDDS.UseVisualStyleBackColor = true;
            this.buttonExportDDS.Click += new System.EventHandler(this.buttonExportDDS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 742);
            this.Controls.Add(this.buttonExportDDS);
            this.Controls.Add(this.buttonSaveTexture);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.color);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.preview2);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2x);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.checkLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textFileInput);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.trackOffset);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preview2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.TextBox textFileInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox preview;
        private System.Windows.Forms.CheckBox checkLog;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button button2x;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox preview2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trackOffset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox color;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonSaveTexture;
        private System.Windows.Forms.Button buttonExportDDS;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}

