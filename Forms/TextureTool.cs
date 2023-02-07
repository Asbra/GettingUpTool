using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GettingUpTool
{
    public partial class TextureTool : Form
    {
        public TextureTool()
        {
            InitializeComponent();
        }

        #region Private variables
        private string _gamePath;
        private Texture _texture;
        private Bitmap bmpAlpha, bmpRGB;
        private string _githubUrl = "https://github.com/Asbra/GettingUpTool";
        private string _helpUrl = "https://github.com/Asbra/GettingUpTool/wiki/Replacing-textures-graffiti-in-Marc-Ecko%27s-Getting-Up";
        #endregion

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);
            
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                string filext = file.Extension.ToLower();
                if (filext == ".st") // || filext == ".bir" || filext == ".dds" || filext == ".st2")
                {
                    curNode.Nodes.Add(file.FullName, file.Name);
                }
            }

            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }

        #region Texture functions
        //
        // Load texture from file
        //
        private bool LoadTexture(string path)
        {
            //
            // Reset frontend
            //
            textTextureName.Text = "Name:";
            labelTextureFormat.Text = "Format:";
            labelResolution.Text = "Resolution:";

            textDebugLog.Text = string.Empty;

            picAlpha.Width = 0;
            picAlpha.Height = 0;
            picAlpha.Image = null;
            picRGB.Width = 0;
            picRGB.Height = 0;
            picRGB.Image = null;

            buttonScan.Enabled = true;
            buttonReplaceTexture.Enabled = true;
            buttonExportTexture.Enabled = true;
            
            //
            // Get file information
            //
            // @TODO: Fix this inheritance
            _texture = new Texture(path);

            if (_texture.Type == TextureType.ST)
            {
                _texture = new ST(path);// _texture.Data);
            }
            else if (_texture.Type == TextureType.ST2)
            {
                _texture = new ST2(path);//_texture.Data);
            }
            else if (_texture.Type == TextureType.DDS)
            {
                _texture = new DDS(path);//_texture.Data);
            }
            else
            {
                // Other file extension
                MessageBox.Show("Unknown file format", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Debug output
            if (chkDebug.Checked)
            {
                if (_texture.Type == TextureType.ST)
                {
                    textDebugLog.Text = FileAnalysis.AnalyzeST(_texture.Data);
                }
                else if (_texture.Type == TextureType.ST2)
                {
                    textDebugLog.Text = FileAnalysis.AnalyzeST2(_texture.Data);
                }
                else if (_texture.Type == TextureType.DDS)
                {
                    textDebugLog.Text = FileAnalysis.AnalyzeDDS(_texture.Data);
                }
            }

            // Compile texture format string
            string compression = string.Empty;
            if (_texture.DXT == 1)
            {
                compression = $"DXT{_texture.DXT} (BC1)";
            }
            else if (_texture.DXT == 2 || _texture.DXT == 3)
            {
                compression = $"DXT{_texture.DXT} (BC2)";
            }
            else if (_texture.DXT == 4 || _texture.DXT == 5)
            {
                compression = $"DXT{_texture.DXT} (BC3)";
            }
            else
            {
                compression = "Unknown";
            }

            string textureFormat = $"DDS {compression}";

            linkFile.Text = _texture.Path;
            textTextureName.Text = _texture.Name;
            labelTextureFormat.Text = $"Format: {textureFormat}";
            labelResolution.Text = $"Resolution: {_texture.Width}x{_texture.Height}";

            int controlsOffset = 12;
            labelPicAlpha.Location = new Point(labelPicRGB.Location.X + _texture.Width + controlsOffset, labelPicAlpha.Location.Y);
            picAlpha.Location = new Point(picRGB.Location.X + _texture.Width + controlsOffset, picAlpha.Location.Y);

            panelPixelInfo.Location = new Point(panelPixelInfo.Location.X, picRGB.Location.Y + _texture.Height + controlsOffset / 2);

            return true;
        }
        #endregion

        private void TextureTool_Load(object sender, EventArgs e)
        {
            // Use current system font, rather than WinForms default font
            this.Font = SystemFonts.MessageBoxFont;

            // So we can just do Encoding GetString and not worry about newlines etc.
            Encoding.GetEncoding("Latin1");

            //
            // Try to find the game
            //

            DirectoryInfo path = null;

            // @TODO: Implement a config file

            try
            {
                path = GameFinder.LocateGamePath();
            }
            catch (DirectoryNotFoundException ex)
            {
                DialogResult dresFindGame = MessageBox.Show($"{ex.Message}{Environment.NewLine}Please press OK and choose the game directory.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                if (dresFindGame.Equals(DialogResult.Cancel))
                {
                    // If we can't find the game, there's not much we can do.
                    Application.Exit();
                }
                else if (dresFindGame.Equals(DialogResult.OK))
                {
                    folderBrowser.Description = "Choose the game folder. This should be the folder containing the \"_Bin\" and \"engine\" folders";
                    folderBrowser.ShowNewFolderButton = false;

                    while (path == null)
                    {
                        dresFindGame = folderBrowser.ShowDialog();

                        if (dresFindGame == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                        {
                            DirectoryInfo inpath = new DirectoryInfo(folderBrowser.SelectedPath);

                            if (GameFinder.ValidateGamePath(inpath))
                            {
                                path = inpath;
                                break;
                            }
                            else
                            {
                                this.Focus();
                                MessageBox.Show("Game not found. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (dresFindGame == DialogResult.Cancel)
                            break;
                    }
                }
            }

            try
            {
                if (path != null && path.Exists)
                {
                    _gamePath = path.FullName;
                    openFileDialog.InitialDirectory = _gamePath;

                    BuildTree(path, treeGameFiles.Nodes);
                    if (treeGameFiles.Nodes.Count > 0)
                    {
                        treeGameFiles.Nodes[0].Expand();
                        if (treeGameFiles.Nodes[0].Nodes.Count > 0)
                            treeGameFiles.Nodes[0].Nodes[0].Expand();
                    }
                }
                else throw new DirectoryNotFoundException();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid game folder, please report the following error at {_githubUrl}/issues" + Environment.NewLine + ex.ToString());
            }
        }

        //
        // Update the pictureboxes
        //
        private void UpdatePreviews()
        {
            buttonExportTexture.Enabled = false;
            buttonReplaceTexture.Enabled = false;

            try
            {
                bmpAlpha = new Bitmap(_texture.Width, _texture.Height, PixelFormat.Format32bppArgb);
                bmpRGB = new Bitmap(_texture.Width, _texture.Height, PixelFormat.Format32bppArgb);

                picAlpha.Width = _texture.Width;
                picAlpha.Height = _texture.Height;
                picRGB.Width = _texture.Width;
                picRGB.Height = _texture.Height;

                picAlpha.BackColor = Color.Black;

                if (_texture.DXT > 0)
                {
                    // @TODO: Detect file format
                    byte[] ddsBytes = null;
                    if (_texture.Type == TextureType.ST)
                    {
                        ddsBytes = TextureUtil.STtoDDS(_texture.Data, false);

                        buttonExportTexture.Enabled = true;
                        buttonReplaceTexture.Enabled = true;
                    }
                    else if (_texture.Type == TextureType.ST2)
                    {
                        /*
                        int textureLength = BitConverter.ToInt32(_texture.Data, 0x34);
                        int textureDataOffset = BitConverter.ToInt32(_texture.Data, 0x38);
                        int offset = _texture.Data.Length - textureLength + textureDataOffset;
                        */
                        int offset = 0x4B4;

                        ddsBytes = new byte[_texture.Data.Length - offset];
                        Array.Copy(_texture.Data, offset, ddsBytes, 0, _texture.Data.Length - offset);

                        buttonExportTexture.Enabled = true;
                        buttonReplaceTexture.Enabled = true;
                    }
                    else if (_texture.Type == TextureType.DDS)
                    {
                        ddsBytes = new byte[_texture.Data.Length - TextureUtil.DDS_HEADER_SIZE];
                        Array.Copy(_texture.Data, TextureUtil.DDS_HEADER_SIZE, ddsBytes, 0, _texture.Data.Length - TextureUtil.DDS_HEADER_SIZE);
                    }

                    byte[] bmpBytes = _texture.DXT == 1 ? DxtUtil.DecompressDxt1(ddsBytes, _texture.Width, _texture.Height) : (_texture.DXT >= 4 ? DxtUtil.DecompressDxt5(ddsBytes, _texture.Width, _texture.Height) : DxtUtil.DecompressDxt3(ddsBytes, _texture.Width, _texture.Height));

                    int idx = 0;
                    for (int y = 0; y < _texture.Height; y++)
                    {
                        for (int x = 0; x < _texture.Width; x++)
                        {
                            byte r = bmpBytes[idx + 0];
                            byte g = bmpBytes[idx + 1];
                            byte b = bmpBytes[idx + 2];
                            byte a = bmpBytes[idx + 3];
                            Color color = Color.FromArgb(a, r, g, b);

                            bmpRGB.SetPixel(x, y, color);

                            bmpAlpha.SetPixel(x, y, Color.FromArgb(a, 255, 255, 255));

                            idx += 4;
                        }
                    }
                }

                picAlpha.Image = bmpAlpha;
                picRGB.Image = bmpRGB;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboDXTOverride_SelectedIndexChanged(object sender, EventArgs e)
        {
            object item = ((ComboBox)sender).SelectedItem;
            if (item != null)
            {
                string text = item.ToString();
                _texture.DXT = Int32.Parse(Regex.Match(text, @"\d+").Value);
                UpdatePreviews();
            }
        }

        //////////////////////////////////////////////////
        // This is for use to replace textures in running game process
        // I just used this to test without having to restart game each time
        private void buttonScan_Click(object sender, EventArgs e)
        {
            /*
            textDebugLog.Text = "";
            DebugTools.SetDebugPrivilege();

            byte[] buffer = new byte[(_fileSize - 0x104)];
            Buffer.BlockCopy(_texture.Data, 0x104, buffer, 0, _fileSize - 0x104);

            string mask = new string('x', buffer.Length);

            Process[] procs = Process.GetProcessesByName("GettingUp");

            if (procs.Length <= 0 || procs[0].HasExited)
            {
                MessageBox.Show("Failed to find game process");
                return;
            }

            Text = "[" + procs[0].Id + "] (" + procs[0].Handle.ToString("X8") + ") " + procs[0].ProcessName;

            // 0F9D2C80
            // 1D6B9850
            // 1F860DC0
            DebugTools.MEMORY_BASIC_INFORMATION mbi = new DebugTools.MEMORY_BASIC_INFORMATION();
            uint base_addr = 0x19050000;// 0x0F000000;
            uint addr = base_addr;
            // uint readable = (0x20 | 0x40 | 0x80 | 0x02 | 0x04 | 0x08);

            while (addr < 0x1A000000)
            {
                if (DebugTools.VirtualQuery(ref base_addr, ref mbi, 0x10000000) == 0)
                {
                    MessageBox.Show("VirtualQuery failed!");
                    return;
                }

                addr += (uint)mbi.RegionSize;
                
                if (mbi.State == 0x1000) // MEM_COMMIT
                {
                    SigScan scan = new SigScan(procs[0], new IntPtr(addr), (int)mbi.RegionSize);//0x0D000000);
                    IntPtr address = scan.FindPattern(buffer, mask, (int)addr);

                    if (address == IntPtr.Zero)
                    {
                    }
                    else
                    {
                        textDebugLog.Text += address.ToString("X8") + Environment.NewLine;
                    }
                }
            }
            */
        }

        //
        // Zoom texture
        //
        private void ZoomPictureBox(PictureBox pictureBox, float zoomLevel)
        {
            int sourceWidth = pictureBox.Width;
            int sourceHeight = pictureBox.Height;
            int targetWidth = (int)((float)sourceWidth * zoomLevel);
            int targetHeight = (int)((float)sourceHeight * zoomLevel);
            double aspectRatio;

            pictureBox.Width = targetWidth;
            pictureBox.Height = targetHeight;

            if (sourceWidth > sourceHeight)
            {
                targetWidth = pictureBox.Width;
                aspectRatio = (double)targetWidth / sourceWidth;
                targetHeight = (int)(aspectRatio * sourceHeight);
            }
            else if (sourceWidth < sourceHeight)
            {
                targetHeight = pictureBox.Height;
                aspectRatio = (double)targetHeight / sourceHeight;
                targetWidth = (int)(aspectRatio * sourceWidth);
            }
            else
            {
                targetHeight = pictureBox.Height;
                targetWidth = pictureBox.Width;
            }

            int targetTop = 0;//(preview.Height - targetHeight) / 2;
            int targetLeft = 0;//(preview.Width - targetWidth) / 2;

            Bitmap tempBitmap = new Bitmap(pictureBox.Width, pictureBox.Height, PixelFormat.Format24bppRgb);

            tempBitmap.SetResolution(pictureBox.Image.HorizontalResolution, pictureBox.Image.VerticalResolution);

            Graphics bmGraphics = Graphics.FromImage(tempBitmap);

            bmGraphics.Clear(Color.Transparent);

            bmGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            bmGraphics.DrawImage(pictureBox.Image, new Rectangle(targetLeft, targetTop, targetWidth, targetHeight), new Rectangle(0, 0, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

            bmGraphics.Dispose();

            pictureBox.Width = tempBitmap.Width;
            pictureBox.Height = tempBitmap.Height;
            pictureBox.Image = tempBitmap;
        }

        //
        // Load selected texture when selecting in the tree view
        //
        private void treeGameFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = treeGameFiles.SelectedNode.Name;

            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                try
                {
                    LoadTexture(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                comboDXTOverride.SelectedIndex = -1;
                UpdatePreviews();
            }
        }

        //
        // Open file explorer when clicking on file path
        //
        private void linkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = ((LinkLabel)sender).Text;

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                return;

            Process.Start("explorer.exe", $"/select,\"{path}\"");
        }

        //
        // Get information of hovered pixel
        //
        private void preview_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            if (picBox.Image != null)
            {
                // Create a new image
                picPixelColor.Image = new Bitmap(picPixelColor.Width, picPixelColor.Height, PixelFormat.Format32bppArgb);

                // Fill it with highlit color
                using (Graphics g = Graphics.FromImage(picPixelColor.Image))
                using (SolidBrush brush = new SolidBrush(((Bitmap)picBox.Image).GetPixel(e.X, e.Y)))
                {
                    g.FillRectangle(brush, 0, 0, picPixelColor.Image.Width, picPixelColor.Image.Height);

                    // Show color information
                    Color color = brush.Color;
                    labelPixelinfo.Text = brush.Color.A > 0 ? $"#{color.R:X2}{color.G:X2}{color.B:X2}  {color.R} {color.G} {color.B}" : string.Empty;
                }
            }
        }

        //
        // Replace the game texture with custom imported texture
        //
        private void buttonReplaceTexture_Click(object sender, EventArgs e)
        {
            // Let user choose file to replace with
            openFileDialog.Filter = "DDS|*.dds";
            openFileDialog.Title = "Choose texture to replace with";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // Read the input file
            byte[] fileBytes = null;

            try
            {
                using (Stream fileStream = openFileDialog.OpenFile())
                {
                    FileInfo fi = new FileInfo(openFileDialog.FileName);
                    int fileSize = (int)fi.Length;

                    fileBytes = new byte[fileSize];
                    fileStream.Read(fileBytes, 0, fileSize);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: Could not read file from disk." + Environment.NewLine + "Exception: " + ex.Message);
                return;
            }

            // Backup original texture if user wants to
            DialogResult dresBackup = MessageBox.Show("Create backup of original texture?", "Backup?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dresBackup == DialogResult.Cancel)
            {
                return;
            }
            else if (dresBackup == DialogResult.Yes)
            {
                string filext = ".bak0";

                int n = 0;
                while (File.Exists(_texture.Path + filext))
                {
                    filext = $".bak{++n}";
                }

                File.Move(_texture.Path, _texture.Path + filext);
            }

            // Replace texture data in memory
            for (int i = TextureUtil.DDS_HEADER_SIZE; i < fileBytes.Length; i++)
            {
                _texture.Data[i + TextureUtil.ST_BIR_OFFSET] = fileBytes[i];
            }

            // Save the edited texture to file
            File.WriteAllBytes(_texture.Path, _texture.Data);

            // Reflect changes in the previews
            LoadTexture(_texture.Path);
            UpdatePreviews();
        }

        //
        // Export texture to DDS format
        //
        private void buttonExportTexture_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "DDS|*.dds|PNG|*.png|BMP|*.bmp|JPEG|*.jpg|GIF|*.gif";//|All files|*.*";
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(_texture.Path);
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(_texture.Path);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                switch (saveFileDialog.FilterIndex)
                {
                    case 1: // DDS
                        try
                        {
                            byte[] outBytes = TextureUtil.STtoDDS(_texture.Data);

                            using (Stream fileStream = saveFileDialog.OpenFile())
                            {
                                fileStream.Write(outBytes, 0, outBytes.Length);
                            }

                            // Write metadata to other file
                            // @NOTE: We shouldn't need this anymore
                            // string pathOutMetadata = Path.Combine(Path.GetDirectoryName(_texture.Path), Path.GetFileNameWithoutExtension(_texture.Path) + ".dat");
                            // File.WriteAllBytes(pathOutMetadata, TextureConversion.STmetadata(_texture.Data));
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        break;
                    case 2: // PNG
                        picRGB.Image.Save(saveFileDialog.FileName, ImageFormat.Png);
                        break;
                    case 3: // BMP
                        picRGB.Image.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                        break;
                    case 4: // JPEG
                        picRGB.Image.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                        break;
                    case 5: // GIF
                        picRGB.Image.Save(saveFileDialog.FileName, ImageFormat.Gif);
                        break;
                    default:
                        MessageBox.Show("Unknown output format");
                        break;
                }
            }
        }

        //
        // Show/hide debug information
        //
        private void chkDebug_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            panelDebug.Visible = chk.Checked;
        }

        #region Link control events
        //
        // Handle controls with external links
        //
        private void linkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(_githubUrl);
        }

        private void linkReadme_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(_helpUrl);
        }
        #endregion
    }
}
