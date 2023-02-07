namespace GettingUpTool
{
    partial class TextureTool
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelName = new System.Windows.Forms.Label();
            this.labelResolution = new System.Windows.Forms.Label();
            this.picAlpha = new System.Windows.Forms.PictureBox();
            this.textDebugLog = new System.Windows.Forms.TextBox();
            this.buttonScan = new System.Windows.Forms.Button();
            this.labelTextureFormat = new System.Windows.Forms.Label();
            this.treeGameFiles = new System.Windows.Forms.TreeView();
            this.picRGB = new System.Windows.Forms.PictureBox();
            this.labelPicAlpha = new System.Windows.Forms.Label();
            this.labelPicRGB = new System.Windows.Forms.Label();
            this.picPixelColor = new System.Windows.Forms.PictureBox();
            this.labelPixelinfo = new System.Windows.Forms.Label();
            this.buttonReplaceTexture = new System.Windows.Forms.Button();
            this.buttonExportTexture = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.linkGithub = new System.Windows.Forms.LinkLabel();
            this.labelPath = new System.Windows.Forms.Label();
            this.panelPixelInfo = new System.Windows.Forms.Panel();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.labelTextureTools = new System.Windows.Forms.Label();
            this.linkReadme = new System.Windows.Forms.LinkLabel();
            this.linkFile = new System.Windows.Forms.LinkLabel();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.panelDebug = new System.Windows.Forms.Panel();
            this.comboDXTOverride = new System.Windows.Forms.ComboBox();
            this.textTextureName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPixelColor)).BeginInit();
            this.panelPixelInfo.SuspendLayout();
            this.panelDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "ST files|*.st|BIR files|*.bir|All files|*.*";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(232, 31);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name:";
            // 
            // labelResolution
            // 
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(232, 75);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(60, 13);
            this.labelResolution.TabIndex = 4;
            this.labelResolution.Text = "Resolution:";
            // 
            // picAlpha
            // 
            this.picAlpha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAlpha.Location = new System.Drawing.Point(502, 224);
            this.picAlpha.Name = "picAlpha";
            this.picAlpha.Size = new System.Drawing.Size(10, 10);
            this.picAlpha.TabIndex = 7;
            this.picAlpha.TabStop = false;
            this.picAlpha.MouseMove += new System.Windows.Forms.MouseEventHandler(this.preview_MouseMove);
            // 
            // textDebugLog
            // 
            this.textDebugLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDebugLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDebugLog.Location = new System.Drawing.Point(3, 32);
            this.textDebugLog.MaxLength = 3276700;
            this.textDebugLog.Multiline = true;
            this.textDebugLog.Name = "textDebugLog";
            this.textDebugLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textDebugLog.Size = new System.Drawing.Size(294, 645);
            this.textDebugLog.TabIndex = 9;
            this.textDebugLog.TabStop = false;
            // 
            // buttonScan
            // 
            this.buttonScan.Enabled = false;
            this.buttonScan.Location = new System.Drawing.Point(3, 3);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(152, 23);
            this.buttonScan.TabIndex = 10;
            this.buttonScan.TabStop = false;
            this.buttonScan.Text = "Find texture in game process";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // labelTextureFormat
            // 
            this.labelTextureFormat.AutoSize = true;
            this.labelTextureFormat.Location = new System.Drawing.Point(232, 53);
            this.labelTextureFormat.Name = "labelTextureFormat";
            this.labelTextureFormat.Size = new System.Drawing.Size(42, 13);
            this.labelTextureFormat.TabIndex = 13;
            this.labelTextureFormat.Text = "Format:";
            // 
            // treeGameFiles
            // 
            this.treeGameFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeGameFiles.Location = new System.Drawing.Point(12, 9);
            this.treeGameFiles.Name = "treeGameFiles";
            this.treeGameFiles.Size = new System.Drawing.Size(214, 720);
            this.treeGameFiles.TabIndex = 14;
            this.treeGameFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeGameFiles_AfterSelect);
            // 
            // picRGB
            // 
            this.picRGB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRGB.Location = new System.Drawing.Point(236, 224);
            this.picRGB.Name = "picRGB";
            this.picRGB.Size = new System.Drawing.Size(10, 10);
            this.picRGB.TabIndex = 15;
            this.picRGB.TabStop = false;
            this.picRGB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.preview_MouseMove);
            // 
            // labelPicAlpha
            // 
            this.labelPicAlpha.AutoSize = true;
            this.labelPicAlpha.Location = new System.Drawing.Point(500, 207);
            this.labelPicAlpha.Name = "labelPicAlpha";
            this.labelPicAlpha.Size = new System.Drawing.Size(75, 13);
            this.labelPicAlpha.TabIndex = 18;
            this.labelPicAlpha.Text = "Alpha channel";
            // 
            // labelPicRGB
            // 
            this.labelPicRGB.AutoSize = true;
            this.labelPicRGB.Location = new System.Drawing.Point(232, 207);
            this.labelPicRGB.Name = "labelPicRGB";
            this.labelPicRGB.Size = new System.Drawing.Size(45, 13);
            this.labelPicRGB.TabIndex = 19;
            this.labelPicRGB.Text = "Preview";
            // 
            // picPixelColor
            // 
            this.picPixelColor.Location = new System.Drawing.Point(0, 0);
            this.picPixelColor.Name = "picPixelColor";
            this.picPixelColor.Size = new System.Drawing.Size(16, 16);
            this.picPixelColor.TabIndex = 28;
            this.picPixelColor.TabStop = false;
            // 
            // labelPixelinfo
            // 
            this.labelPixelinfo.AutoSize = true;
            this.labelPixelinfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPixelinfo.Location = new System.Drawing.Point(20, 1);
            this.labelPixelinfo.Name = "labelPixelinfo";
            this.labelPixelinfo.Size = new System.Drawing.Size(42, 15);
            this.labelPixelinfo.TabIndex = 30;
            this.labelPixelinfo.Text = "R G B";
            // 
            // buttonReplaceTexture
            // 
            this.buttonReplaceTexture.Enabled = false;
            this.buttonReplaceTexture.Location = new System.Drawing.Point(650, 69);
            this.buttonReplaceTexture.Name = "buttonReplaceTexture";
            this.buttonReplaceTexture.Size = new System.Drawing.Size(120, 23);
            this.buttonReplaceTexture.TabIndex = 34;
            this.buttonReplaceTexture.Text = "Replace in-game";
            this.buttonReplaceTexture.UseVisualStyleBackColor = true;
            this.buttonReplaceTexture.Click += new System.EventHandler(this.buttonReplaceTexture_Click);
            // 
            // buttonExportTexture
            // 
            this.buttonExportTexture.Enabled = false;
            this.buttonExportTexture.Location = new System.Drawing.Point(542, 69);
            this.buttonExportTexture.Name = "buttonExportTexture";
            this.buttonExportTexture.Size = new System.Drawing.Size(102, 23);
            this.buttonExportTexture.TabIndex = 35;
            this.buttonExportTexture.Text = "Export";
            this.buttonExportTexture.UseVisualStyleBackColor = true;
            this.buttonExportTexture.Click += new System.EventHandler(this.buttonExportTexture_Click);
            // 
            // linkGithub
            // 
            this.linkGithub.ActiveLinkColor = System.Drawing.Color.DarkRed;
            this.linkGithub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkGithub.AutoSize = true;
            this.linkGithub.Location = new System.Drawing.Point(1044, 715);
            this.linkGithub.Name = "linkGithub";
            this.linkGithub.Size = new System.Drawing.Size(88, 13);
            this.linkGithub.TabIndex = 36;
            this.linkGithub.TabStop = true;
            this.linkGithub.Text = "Follow on GitHub";
            this.linkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGithub_LinkClicked);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(232, 9);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(32, 13);
            this.labelPath.TabIndex = 37;
            this.labelPath.Text = "Path:";
            // 
            // panelPixelInfo
            // 
            this.panelPixelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelPixelInfo.Controls.Add(this.picPixelColor);
            this.panelPixelInfo.Controls.Add(this.labelPixelinfo);
            this.panelPixelInfo.Location = new System.Drawing.Point(236, 713);
            this.panelPixelInfo.Name = "panelPixelInfo";
            this.panelPixelInfo.Size = new System.Drawing.Size(160, 16);
            this.panelPixelInfo.TabIndex = 38;
            // 
            // labelTextureTools
            // 
            this.labelTextureTools.AutoSize = true;
            this.labelTextureTools.Location = new System.Drawing.Point(542, 53);
            this.labelTextureTools.Name = "labelTextureTools";
            this.labelTextureTools.Size = new System.Drawing.Size(33, 13);
            this.labelTextureTools.TabIndex = 39;
            this.labelTextureTools.Text = "Tools";
            // 
            // linkReadme
            // 
            this.linkReadme.AutoSize = true;
            this.linkReadme.Location = new System.Drawing.Point(612, 99);
            this.linkReadme.Name = "linkReadme";
            this.linkReadme.Size = new System.Drawing.Size(94, 13);
            this.linkReadme.TabIndex = 40;
            this.linkReadme.TabStop = true;
            this.linkReadme.Text = "Instructions / Help";
            this.linkReadme.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReadme_LinkClicked);
            // 
            // linkFile
            // 
            this.linkFile.ActiveLinkColor = System.Drawing.Color.Black;
            this.linkFile.AutoSize = true;
            this.linkFile.LinkColor = System.Drawing.Color.Black;
            this.linkFile.Location = new System.Drawing.Point(262, 9);
            this.linkFile.Name = "linkFile";
            this.linkFile.Size = new System.Drawing.Size(0, 13);
            this.linkFile.TabIndex = 41;
            this.linkFile.VisitedLinkColor = System.Drawing.Color.Black;
            this.linkFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFile_LinkClicked);
            // 
            // chkDebug
            // 
            this.chkDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDebug.AutoSize = true;
            this.chkDebug.Location = new System.Drawing.Point(1066, 8);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(58, 17);
            this.chkDebug.TabIndex = 42;
            this.chkDebug.TabStop = false;
            this.chkDebug.Text = "Debug";
            this.chkDebug.UseVisualStyleBackColor = true;
            this.chkDebug.CheckedChanged += new System.EventHandler(this.chkDebug_CheckedChanged);
            // 
            // panelDebug
            // 
            this.panelDebug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDebug.Controls.Add(this.textDebugLog);
            this.panelDebug.Controls.Add(this.buttonScan);
            this.panelDebug.Location = new System.Drawing.Point(824, 23);
            this.panelDebug.Name = "panelDebug";
            this.panelDebug.Size = new System.Drawing.Size(300, 680);
            this.panelDebug.TabIndex = 43;
            this.panelDebug.Visible = false;
            // 
            // comboDXTOverride
            // 
            this.comboDXTOverride.FormattingEnabled = true;
            this.comboDXTOverride.Items.AddRange(new object[] {
            "DXT1",
            "DXT3",
            "DXT5"});
            this.comboDXTOverride.Location = new System.Drawing.Point(371, 50);
            this.comboDXTOverride.Name = "comboDXTOverride";
            this.comboDXTOverride.Size = new System.Drawing.Size(65, 21);
            this.comboDXTOverride.TabIndex = 44;
            this.comboDXTOverride.TabStop = false;
            this.comboDXTOverride.Text = "Override";
            this.comboDXTOverride.SelectedIndexChanged += new System.EventHandler(this.comboDXTOverride_SelectedIndexChanged);
            // 
            // textTextureName
            // 
            this.textTextureName.Location = new System.Drawing.Point(276, 28);
            this.textTextureName.Name = "textTextureName";
            this.textTextureName.ReadOnly = true;
            this.textTextureName.Size = new System.Drawing.Size(200, 20);
            this.textTextureName.TabIndex = 45;
            // 
            // TextureTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 741);
            this.Controls.Add(this.textTextureName);
            this.Controls.Add(this.comboDXTOverride);
            this.Controls.Add(this.panelDebug);
            this.Controls.Add(this.chkDebug);
            this.Controls.Add(this.linkFile);
            this.Controls.Add(this.linkReadme);
            this.Controls.Add(this.labelTextureTools);
            this.Controls.Add(this.panelPixelInfo);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.linkGithub);
            this.Controls.Add(this.buttonExportTexture);
            this.Controls.Add(this.buttonReplaceTexture);
            this.Controls.Add(this.labelPicRGB);
            this.Controls.Add(this.labelPicAlpha);
            this.Controls.Add(this.picRGB);
            this.Controls.Add(this.picAlpha);
            this.Controls.Add(this.labelTextureFormat);
            this.Controls.Add(this.labelResolution);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.treeGameFiles);
            this.Name = "TextureTool";
            this.Text = "Getting Up Mod Tool";
            this.Load += new System.EventHandler(this.TextureTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPixelColor)).EndInit();
            this.panelPixelInfo.ResumeLayout(false);
            this.panelPixelInfo.PerformLayout();
            this.panelDebug.ResumeLayout(false);
            this.panelDebug.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.PictureBox picAlpha;
        private System.Windows.Forms.TextBox textDebugLog;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Label labelTextureFormat;
        private System.Windows.Forms.TreeView treeGameFiles;
        private System.Windows.Forms.PictureBox picRGB;
        private System.Windows.Forms.Label labelPicAlpha;
        private System.Windows.Forms.Label labelPicRGB;
        private System.Windows.Forms.PictureBox picPixelColor;
        private System.Windows.Forms.Label labelPixelinfo;
        private System.Windows.Forms.Button buttonReplaceTexture;
        private System.Windows.Forms.Button buttonExportTexture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.LinkLabel linkGithub;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Panel panelPixelInfo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Label labelTextureTools;
        private System.Windows.Forms.LinkLabel linkReadme;
        private System.Windows.Forms.LinkLabel linkFile;
        private System.Windows.Forms.CheckBox chkDebug;
        private System.Windows.Forms.Panel panelDebug;
        private System.Windows.Forms.ComboBox comboDXTOverride;
        private System.Windows.Forms.TextBox textTextureName;
    }
}

