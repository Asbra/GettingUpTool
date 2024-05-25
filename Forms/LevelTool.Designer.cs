
namespace GettingUpTool.Forms
{
    partial class LevelTool
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
            this.treeGameFiles = new System.Windows.Forms.TreeView();
            this.textDebugLog = new System.Windows.Forms.TextBox();
            this.textDebugLog2 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.textMeshes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTextures = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeGameFiles
            // 
            this.treeGameFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeGameFiles.Location = new System.Drawing.Point(12, 12);
            this.treeGameFiles.Name = "treeGameFiles";
            this.treeGameFiles.Size = new System.Drawing.Size(240, 612);
            this.treeGameFiles.TabIndex = 15;
            this.treeGameFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeGameFiles_AfterSelect);
            // 
            // textDebugLog
            // 
            this.textDebugLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDebugLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDebugLog.Location = new System.Drawing.Point(3, 3);
            this.textDebugLog.MaxLength = 3276700;
            this.textDebugLog.Multiline = true;
            this.textDebugLog.Name = "textDebugLog";
            this.textDebugLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textDebugLog.Size = new System.Drawing.Size(344, 423);
            this.textDebugLog.TabIndex = 16;
            this.textDebugLog.WordWrap = false;
            // 
            // textDebugLog2
            // 
            this.textDebugLog2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDebugLog2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDebugLog2.Location = new System.Drawing.Point(3, 3);
            this.textDebugLog2.MaxLength = 3276700;
            this.textDebugLog2.Multiline = true;
            this.textDebugLog2.Name = "textDebugLog2";
            this.textDebugLog2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textDebugLog2.Size = new System.Drawing.Size(344, 419);
            this.textDebugLog2.TabIndex = 17;
            this.textDebugLog2.TabStop = false;
            this.textDebugLog2.WordWrap = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(614, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textDebugLog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textDebugLog2);
            this.splitContainer1.Size = new System.Drawing.Size(350, 858);
            this.splitContainer1.SplitterDistance = 429;
            this.splitContainer1.TabIndex = 18;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(258, 12);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.textMeshes);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.textTextures);
            this.splitContainer2.Size = new System.Drawing.Size(350, 858);
            this.splitContainer2.SplitterDistance = 429;
            this.splitContainer2.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Meshes used in level";
            // 
            // textMeshes
            // 
            this.textMeshes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textMeshes.Location = new System.Drawing.Point(0, 23);
            this.textMeshes.MaxLength = 3276700;
            this.textMeshes.Multiline = true;
            this.textMeshes.Name = "textMeshes";
            this.textMeshes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textMeshes.Size = new System.Drawing.Size(350, 406);
            this.textMeshes.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Textures used in level";
            // 
            // textTextures
            // 
            this.textTextures.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textTextures.Location = new System.Drawing.Point(0, 19);
            this.textTextures.MaxLength = 3276700;
            this.textTextures.Multiline = true;
            this.textTextures.Name = "textTextures";
            this.textTextures.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textTextures.Size = new System.Drawing.Size(350, 406);
            this.textTextures.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 630);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 240);
            this.panel1.TabIndex = 20;
            // 
            // LevelTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 881);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.treeGameFiles);
            this.Name = "LevelTool";
            this.Text = "Level Tool";
            this.Load += new System.EventHandler(this.LevelTool_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeGameFiles;
        private System.Windows.Forms.TextBox textDebugLog;
        private System.Windows.Forms.TextBox textDebugLog2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textMeshes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTextures;
        private System.Windows.Forms.Panel panel1;
    }
}