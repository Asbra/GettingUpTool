
namespace GettingUpTool.Forms
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.btnRun = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.textureToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbLevelSelect = new System.Windows.Forms.ComboBox();
            this.lblLevelSelect = new System.Windows.Forms.Label();
            this.chkClearAssetCache = new System.Windows.Forms.CheckBox();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.lblArgs = new System.Windows.Forms.Label();
            this.txtCmdLine = new System.Windows.Forms.TextBox();
            this.lblCmdLine = new System.Windows.Forms.Label();
            this.lblCharSelect = new System.Windows.Forms.Label();
            this.cmbCharSelect = new System.Windows.Forms.ComboBox();
            this.lblGameRoot = new System.Windows.Forms.Label();
            this.cmbRootSelect = new System.Windows.Forms.ComboBox();
            this.lblGamePath = new System.Windows.Forms.Label();
            this.txtGamePath = new System.Windows.Forms.TextBox();
            this.btnGamePathBrowse = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(12, 415);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(287, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textureToolStripMenuItem1,
            this.levelToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(311, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // textureToolStripMenuItem1
            // 
            this.textureToolStripMenuItem1.Name = "textureToolStripMenuItem1";
            this.textureToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.textureToolStripMenuItem1.Text = "Texture tool";
            this.textureToolStripMenuItem1.Click += new System.EventHandler(this.textureToolStripMenuItem1_Click);
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.levelToolStripMenuItem.Text = "Level tool";
            this.levelToolStripMenuItem.Click += new System.EventHandler(this.levelToolStripMenuItem_Click);
            // 
            // pakToolStripMenuItem
            // 
            this.pakToolStripMenuItem.Name = "pakToolStripMenuItem";
            this.pakToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.pakToolStripMenuItem.Text = "PAK tool";
            this.pakToolStripMenuItem.Click += new System.EventHandler(this.pakToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // cmbLevelSelect
            // 
            this.cmbLevelSelect.FormattingEnabled = true;
            this.cmbLevelSelect.Location = new System.Drawing.Point(12, 196);
            this.cmbLevelSelect.Name = "cmbLevelSelect";
            this.cmbLevelSelect.Size = new System.Drawing.Size(170, 21);
            this.cmbLevelSelect.TabIndex = 2;
            this.cmbLevelSelect.SelectionChangeCommitted += new System.EventHandler(this.comboBox_CmdArg_SelectionChangeCommitted);
            // 
            // lblLevelSelect
            // 
            this.lblLevelSelect.AutoSize = true;
            this.lblLevelSelect.Location = new System.Drawing.Point(12, 180);
            this.lblLevelSelect.Name = "lblLevelSelect";
            this.lblLevelSelect.Size = new System.Drawing.Size(64, 13);
            this.lblLevelSelect.TabIndex = 3;
            this.lblLevelSelect.Text = "Level select";
            // 
            // chkClearAssetCache
            // 
            this.chkClearAssetCache.AutoSize = true;
            this.chkClearAssetCache.Checked = true;
            this.chkClearAssetCache.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClearAssetCache.Location = new System.Drawing.Point(188, 198);
            this.chkClearAssetCache.Name = "chkClearAssetCache";
            this.chkClearAssetCache.Size = new System.Drawing.Size(111, 17);
            this.chkClearAssetCache.TabIndex = 0;
            this.chkClearAssetCache.Text = "Clear asset cache";
            this.chkClearAssetCache.UseVisualStyleBackColor = true;
            // 
            // txtArgs
            // 
            this.txtArgs.Location = new System.Drawing.Point(12, 313);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.Size = new System.Drawing.Size(287, 20);
            this.txtArgs.TabIndex = 5;
            // 
            // lblArgs
            // 
            this.lblArgs.AutoSize = true;
            this.lblArgs.Location = new System.Drawing.Point(12, 297);
            this.lblArgs.Name = "lblArgs";
            this.lblArgs.Size = new System.Drawing.Size(105, 13);
            this.lblArgs.TabIndex = 6;
            this.lblArgs.Text = "Additional arguments";
            // 
            // txtCmdLine
            // 
            this.txtCmdLine.Location = new System.Drawing.Point(12, 352);
            this.txtCmdLine.Multiline = true;
            this.txtCmdLine.Name = "txtCmdLine";
            this.txtCmdLine.ReadOnly = true;
            this.txtCmdLine.Size = new System.Drawing.Size(287, 48);
            this.txtCmdLine.TabIndex = 7;
            // 
            // lblCmdLine
            // 
            this.lblCmdLine.AutoSize = true;
            this.lblCmdLine.Location = new System.Drawing.Point(12, 336);
            this.lblCmdLine.Name = "lblCmdLine";
            this.lblCmdLine.Size = new System.Drawing.Size(73, 13);
            this.lblCmdLine.TabIndex = 8;
            this.lblCmdLine.Text = "Command-line";
            // 
            // lblCharSelect
            // 
            this.lblCharSelect.AutoSize = true;
            this.lblCharSelect.Location = new System.Drawing.Point(12, 131);
            this.lblCharSelect.Name = "lblCharSelect";
            this.lblCharSelect.Size = new System.Drawing.Size(84, 13);
            this.lblCharSelect.TabIndex = 10;
            this.lblCharSelect.Text = "Character select";
            // 
            // cmbCharSelect
            // 
            this.cmbCharSelect.FormattingEnabled = true;
            this.cmbCharSelect.Items.AddRange(new object[] {
            "Trane",
            "ConWorker",
            "Cope2",
            "Dip",
            "Dog",
            "Gabe",
            "ManfredsArmy",
            "Kry1",
            "MeatWorker",
            "OrangeGuardHeavy",
            "OrangeGuardLight",
            "PoliceChief",
            "SecurityGuard",
            "ShannaRay",
            "SilverGuardHeavy",
            "SilverGuardLight",
            "Spleen",
            "Stake",
            "VandalSquad",
            "VandalSquadBoss",
            "VanR",
            "VanRHeavy",
            "Welder",
            "WhiteMike",
            "WorkBum",
            "WWAHeavy"});
            this.cmbCharSelect.Location = new System.Drawing.Point(12, 147);
            this.cmbCharSelect.Name = "cmbCharSelect";
            this.cmbCharSelect.Size = new System.Drawing.Size(139, 21);
            this.cmbCharSelect.TabIndex = 9;
            this.cmbCharSelect.SelectionChangeCommitted += new System.EventHandler(this.comboBox_CmdArg_SelectionChangeCommitted);
            // 
            // lblGameRoot
            // 
            this.lblGameRoot.AutoSize = true;
            this.lblGameRoot.Location = new System.Drawing.Point(12, 82);
            this.lblGameRoot.Name = "lblGameRoot";
            this.lblGameRoot.Size = new System.Drawing.Size(56, 13);
            this.lblGameRoot.TabIndex = 12;
            this.lblGameRoot.Text = "Game root";
            // 
            // cmbRootSelect
            // 
            this.cmbRootSelect.FormattingEnabled = true;
            this.cmbRootSelect.Items.AddRange(new object[] {
            "engine",
            "beta"});
            this.cmbRootSelect.Location = new System.Drawing.Point(12, 98);
            this.cmbRootSelect.Name = "cmbRootSelect";
            this.cmbRootSelect.Size = new System.Drawing.Size(139, 21);
            this.cmbRootSelect.TabIndex = 11;
            this.cmbRootSelect.SelectionChangeCommitted += new System.EventHandler(this.cmbRootSelect_SelectionChangeCommitted);
            // 
            // lblGamePath
            // 
            this.lblGamePath.AutoSize = true;
            this.lblGamePath.Location = new System.Drawing.Point(12, 33);
            this.lblGamePath.Name = "lblGamePath";
            this.lblGamePath.Size = new System.Drawing.Size(59, 13);
            this.lblGamePath.TabIndex = 14;
            this.lblGamePath.Text = "Game path";
            // 
            // txtGamePath
            // 
            this.txtGamePath.Location = new System.Drawing.Point(12, 49);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.Size = new System.Drawing.Size(215, 20);
            this.txtGamePath.TabIndex = 13;
            // 
            // btnGamePathBrowse
            // 
            this.btnGamePathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGamePathBrowse.Location = new System.Drawing.Point(233, 48);
            this.btnGamePathBrowse.Name = "btnGamePathBrowse";
            this.btnGamePathBrowse.Size = new System.Drawing.Size(66, 22);
            this.btnGamePathBrowse.TabIndex = 15;
            this.btnGamePathBrowse.Text = "Browse";
            this.btnGamePathBrowse.UseVisualStyleBackColor = true;
            this.btnGamePathBrowse.Click += new System.EventHandler(this.btnGamePathBrowse_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 450);
            this.Controls.Add(this.btnGamePathBrowse);
            this.Controls.Add(this.lblGamePath);
            this.Controls.Add(this.txtGamePath);
            this.Controls.Add(this.lblGameRoot);
            this.Controls.Add(this.cmbRootSelect);
            this.Controls.Add(this.lblCharSelect);
            this.Controls.Add(this.cmbCharSelect);
            this.Controls.Add(this.lblCmdLine);
            this.Controls.Add(this.txtCmdLine);
            this.Controls.Add(this.lblArgs);
            this.Controls.Add(this.lblLevelSelect);
            this.Controls.Add(this.chkClearAssetCache);
            this.Controls.Add(this.cmbLevelSelect);
            this.Controls.Add(this.txtArgs);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MEGU Launcher";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem textureToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pakToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbLevelSelect;
        private System.Windows.Forms.Label lblLevelSelect;
        private System.Windows.Forms.CheckBox chkClearAssetCache;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.Label lblArgs;
        private System.Windows.Forms.TextBox txtCmdLine;
        private System.Windows.Forms.Label lblCmdLine;
        private System.Windows.Forms.Label lblCharSelect;
        private System.Windows.Forms.ComboBox cmbCharSelect;
        private System.Windows.Forms.Label lblGameRoot;
        private System.Windows.Forms.ComboBox cmbRootSelect;
        private System.Windows.Forms.Label lblGamePath;
        private System.Windows.Forms.TextBox txtGamePath;
        private System.Windows.Forms.Button btnGamePathBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
    }
}