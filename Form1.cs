using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

[StructLayout(LayoutKind.Sequential)]
public struct PixelData
{
    public byte alpha;
    public byte unk01;
    public byte unk02;
    public byte unk03;
    public byte unk04;
    public byte unk05;
    public byte unk06;
    public byte unk07;
    public byte unk08; // c0
    public byte unk09; // c0
    public byte unk0A; // c1
    public byte unk0B; // c1
    public byte unk0C; // Color indexes
    public byte unk0D; // ^
    public byte unk0E; // ^
    public byte unk0F; // ^

    public PixelData(byte[] buffer, int index)
    {
        alpha = buffer[index + 0];
        unk01 = buffer[index + 1];
        unk02 = buffer[index + 2];
        unk03 = buffer[index + 3];
        unk04 = buffer[index + 4];
        unk05 = buffer[index + 5];
        unk06 = buffer[index + 6];
        unk07 = buffer[index + 7];
        unk08 = buffer[index + 8];
        unk09 = buffer[index + 9];
        unk0A = buffer[index + 10];
        unk0B = buffer[index + 11];
        unk0C = buffer[index + 12];
        unk0D = buffer[index + 13];
        unk0E = buffer[index + 14];
        unk0F = buffer[index + 15];
    }
}

namespace GettingUpTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string _gamePath;
        private PixelData[] _pixels;
        private byte[] _fileBytes;
        private string _path;
        private string _textureName;
        private int _width;
        private int _height;
        private int _fileSize;
        private string _fileName;
        private Bitmap bmp, bmp2;

        public static int Clamp(int val, int min, int max)
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);
            
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                if (file.Extension == ".st" || file.Extension == ".bir")
                {
                    curNode.Nodes.Add(file.FullName, file.Name);
                }
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////
            // Try to find the game path
            RegistryKey rk = Registry.ClassesRoot;
            RegistryKey sk1 = rk.OpenSubKey("TheCollective.Slayer\\DefaultIcon");

            if (sk1 == null)
            {
                MessageBox.Show("Failed to auto-detect game path!");
            }
            else
            {
                try
                {
                    _gamePath = Path.GetDirectoryName(Path.GetDirectoryName((string)sk1.GetValue(""))) + @"\engine";
                    ofd.InitialDirectory = _gamePath;

                    DirectoryInfo directoryInfo = new DirectoryInfo(_gamePath);
                    if (directoryInfo.Exists)
                    {
                        BuildTree(directoryInfo, treeView1.Nodes);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception encountered while reading the registry" + Environment.NewLine + ex.ToString());
                }
            }
        }

        //////////////////////////////////////////////////
        // Function to load a texture from file
        private bool LoadTexture(Stream fileStream, string path)
        {
            if (fileStream == null)
            {
                fileStream = File.OpenRead(path);
            }

            //////////////////////////////////////////////////
            // Reset frontend
            label2.Text = "Name: -";
            label3.Text = "Resolution: -";
            label4.Text = "Pixel count: -";
            textFileInput.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            preview.Width = 0;
            preview.Height = 0;
            preview.Image = null;
            buttonScan.Enabled = true;
            buttonEdit.Enabled = true;
            button2x.Enabled = true;
            buttonSaveTexture.Enabled = true;
            buttonExportDDS.Enabled = true;

            _path = path;
            FileInfo fi = new FileInfo(_path);
            _fileSize = (int)fi.Length;
            _fileName = fi.Name;

            _fileBytes = new byte[fi.Length];
            fileStream.Read(_fileBytes, 0, _fileSize);

            fileStream.Close();

            //////////////////////////////////////////////////
            // Parse ST texture files
            if (_fileBytes[0] == 'S' && _fileBytes[1] == 'T')
            {
                _textureName = "";
                for (int i = 0x40; _fileBytes[i] != 0; i++)
                {
                    _textureName += (char)_fileBytes[i];
                }
                label2.Text = "Name: " + _textureName;

                string type = _textureName.Split('_')[0];

                // Get the texture type from the file name
                switch (type)
                {
                    case "AM":
                        label5.Text = "Type: Mural";
                        break;
                    case "AT":
                        label5.Text = "Type: Throw-up";
                        break;
                    case "AW":
                        label5.Text = "Type: Wildstyle";
                        break;
                    case "CA":
                        label5.Text = "Type: Roll-up";
                        break;
                    case "CR":
                        label5.Text = "Type: Roll-up";
                        break;
                    case "CW":
                        label5.Text = "Type: Roll-up";
                        break;
                    case "FF":
                        label5.Text = "Type: Freeform";
                        break;
                    case "RU":
                        label5.Text = "Type: Roll-up";
                        break;
                    case "WP":
                        label5.Text = "Type: Wheat paste";
                        break;
                    default:
                        label5.Text = "Type: ?";
                        break;
                }

                _width = _fileBytes[0xC] | _fileBytes[0xD] << 8 | _fileBytes[0xE] << 16 | _fileBytes[0xF] << 24;
                _height = _fileBytes[0x10] | _fileBytes[0x11] << 8 | _fileBytes[0x12] << 16 | _fileBytes[0x13] << 24;
                
                Text = _fileBytes[0x36].ToString("X2");

                _pixels = new PixelData[(_fileSize - 0x184) / 16];
                string tmpString = "";
                int p = 0;

                for (int i = 0x184; i < _fileSize; i += 16)
                {
                    _pixels[p++] = new PixelData(_fileBytes, i);

                    if (checkLog.Checked)
                    {
                        for (int n = 0; n < 16; n++)
                        {
                            tmpString += _fileBytes[i + n].ToString("X2") + " ";
                        }
                        tmpString += Environment.NewLine;
                    }
                }

                p = p * 16;
                label4.Text = "Pixel count: " + p;
                label3.Text = "Dimensions: " + _width + "x" + _height;

                UpdatePreviews();

                textBox1.Text = tmpString;
            }
            else if (_fileBytes[0] == 'B' && _fileBytes[1] == 'I' && _fileBytes[2] == 'R')
            {
                //////////////////////////////////////////////////
                // BIR parser
                MessageBox.Show("No BIR support yet!");
                return false;
            }
            else
            {
                //////////////////////////////////////////////////
                // Other file extension
            }

            return true;
        }

        private void UpdatePreviews()
        {
            bmp = new Bitmap(_width, _height, PixelFormat.Format32bppArgb);
            bmp2 = new Bitmap(_width, _height, PixelFormat.Format32bppArgb);

            preview.BackColor = Color.Black;

            bool done = false;
            int y;
            for (y = 0; y < _height; y += 4)
            {
                for (int x = 0; x < _width; x += 4)
                {   
                    if (x + _width * y >= _pixels.Length*16)
                    {
                        label3.Text = "Dimensions: " + _width + "x" + _height;//y;
                        done = true;
                        break;
                    }

                    PixelData pixel = _pixels[x/4 + _width/4 * (y/4)];

                    int[] alphan = new int[8];
                    alphan[0] = pixel.alpha;
                    alphan[1] = pixel.unk01;
                    if (alphan[0] > alphan[1])
                    {
                        alphan[2] = (6 * alphan[0] + alphan[1]) / 7; alphan[3] = (5 * alphan[0] + 2 * alphan[1]) / 7; alphan[4] = (4 * alphan[0] + 3 * alphan[1]) / 7; alphan[5] = (3 * alphan[0] + 4 * alphan[1]) / 7; alphan[6] = (2 * alphan[0] + 5 * alphan[1]) / 7; alphan[7] = (alphan[0] + 6 * alphan[1]) / 7;
                    }
                    else
                    {
                        alphan[2] = (4 * alphan[0] + alphan[1]) / 5; alphan[3] = (3 * alphan[0] + 2 * alphan[1]) / 5; alphan[4] = (2 * alphan[0] + 3 * alphan[1]) / 5; alphan[5] = (alphan[0] + 4 * alphan[1]) / 5; alphan[6] = 0; alphan[7] = 255;
                    }

                    int a = 255;//pixel.alpha;
                    ulong alphatable = (ulong)(pixel.unk02 | (pixel.unk03 << 8) | (pixel.unk04 << 16) | (pixel.unk05 << 24) | (pixel.unk06 << 32) | (pixel.unk07 << 40));

                    int r = 255, g = 255, b = 255;
                    Color[] c = new Color[4];
                    byte b1, b2;

                    b1 = pixel.unk08;
                    b2 = pixel.unk09;

                    r = (b2 & 0xF8) >> 3;
                    g = ((b1 & 0xE0) >> 5) | ((b2 & 0x7) << 3);
                    b = b1 & 0x1F;

                    r = (r * 255) / 31;
                    g = (g * 255) / 63;
                    b = (b * 255) / 31;

                    c[0] = Color.FromArgb(a, r, g, b);
                    int c0_s = c[0].R+c[0].G+c[0].B;//b1 | (b2 << 8);

                    b1 = pixel.unk0A;
                    b2 = pixel.unk0B;

                    r = (b2 & 0xF8) >> 3;
                    g = ((b1 & 0xE0) >> 5) | ((b2 & 0x7) << 3);
                    b = b1 & 0x1F;

                    r = (r * 255) / 31;
                    g = (g * 255) / 63;
                    b = (b * 255) / 31;

                    c[1] = Color.FromArgb(a, r, g, b);
                    int c1_s = c[1].R + c[1].G + c[1].B;//b1 | (b2 << 8);

                    //if (c0_s > c1_s)
                    //{
                        c[2] = Color.FromArgb(a, (2 * c[0].R + c[1].R) / 3, (2 * c[0].G + c[1].G) / 3, (2 * c[0].B + c[1].B) / 3);
                        c[3] = Color.FromArgb(a, (c[0].R + 2 * c[1].R) / 3, (c[0].G + 2 * c[1].G) / 3, (c[0].B + 2 * c[1].B) / 3);
                    /*}
                    else
                    {
                        c[2] = Color.FromArgb(a, (c[0].R + c[1].R) / 2, (c[0].G + c[1].G) / 2, (c[0].B + c[1].B) / 2);
                        c[3] = Color.FromArgb(0, 0, 0, 0);
                    }*/

                    ulong indexes = (ulong)(pixel.unk0C | (pixel.unk0D << 8) | (pixel.unk0E << 16) | (pixel.unk0F << 24));

                    r = g = b = 0;

                    int[] alphas = new int[16];
                    for (int i = 0; i < 16; i++)
                    {
                        ulong index = alphatable & 7;
                        alphatable = alphatable >> 3;
                        alphas[i] = alphan[index];
                    }

                    // while (indexes > 0)
                    for(int i = 0; i < 16; i++)
                    {
                        ulong index = indexes & 3;
                        indexes = indexes >> 2; //shift two bytes right (same as indexes = indexes >> 2)

                        bmp2.SetPixel(x + i % 4, y + i / 4, Color.FromArgb(alphas[i], c[index].R, c[index].G, c[index].B));

                        // Alpha
                        bmp.SetPixel(x + i % 4, y + i / 4, Color.FromArgb(alphas[i], alphas[i], alphas[i], alphas[i]));
                    }
                }

                if (done != false)
                {
                    break;
                }
            }
             //_height = y;
            //numericHeight.Value = _height;

            if (preview.Width != _width)
            {
                preview.Width = _width;
                preview2.Width = _width;
            }
            if (preview.Height != _height)
            {
                preview.Height = _height;
                preview2.Height = _height;
            }

            preview.Image = bmp;
            preview2.Image = bmp2;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Stream fileStream = ofd.OpenFile())
                    {
                        textFileInput.Text = ofd.FileName;
                        LoadTexture(fileStream, ofd.FileName);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Error: Could not read file from disk." + Environment.NewLine + "Exception: " + ex.Message);
                }
            }
        }

        private void trackOffset_Scroll(object sender, EventArgs e)
        {
            label8.Text = "Color offset(" + trackOffset.Value + ")";

            UpdatePreviews();
        }

        //////////////////////////////////////////////////
        // This is for use to replace textures in running game process
        // I just used this to test without having to restart game each time ;P
        private void buttonScan_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            DebugTools.SetDebugPrivilege();

            byte[] buffer = new byte[(_fileSize - 0x104)];
            Buffer.BlockCopy(_fileBytes, 0x104, buffer, 0, _fileSize - 0x104);

            string mask = new string('x', buffer.Length);

            Process[] procs = Process.GetProcessesByName("GettingUp");

            if (procs.Length <= 0 || procs[0].HasExited)
            {
                MessageBox.Show("Failed to find game, is it even running?!");
                return;
            }

            Text = "[" + procs[0].Id + "] (" + procs[0].Handle.ToString("X8") + ") " + procs[0].ProcessName;

            // 0F9D2C80
            // 1D6B9850
            // 1F860DC0
            DebugTools.MEMORY_BASIC_INFORMATION mbi = new DebugTools.MEMORY_BASIC_INFORMATION();
            uint base_addr = 0x19050000;// 0x0F000000;
            uint addr = base_addr;
            uint readable = (0x20 | 0x40 | 0x80 | 0x02 | 0x04 | 0x08);

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
                    // textBox2.Text += "addr " + addr.ToString("X8") + Environment.NewLine;

                    SigScan scan = new SigScan(procs[0], new IntPtr(addr), (int)mbi.RegionSize);//0x0D000000);
                    IntPtr address = scan.FindPattern(buffer, mask, (int)addr);

                    if (address == IntPtr.Zero)
                    {
                        // textBox2.Text += "Not found" + Environment.NewLine;
                    }
                    else
                    {
                        textBox2.Text += address.ToString("X8") + Environment.NewLine;
                    }
                }

                /*
                textBox2.Text += "mbi.AllocationBase " + mbi.AllocationBase.ToUInt32().ToString("X8") + Environment.NewLine;
                textBox2.Text += "mbi.BaseAddress " + mbi.BaseAddress.ToUInt32().ToString("X8") + Environment.NewLine;

                switch (mbi.AllocationProtect)
                {
                    case 0x01:
                        textBox2.Text += "mbi.AllocationProtect PAGE_NOACCESS" + Environment.NewLine;
                        break;
                    case 0x02:
                        textBox2.Text += "mbi.AllocationProtect PAGE_READONLY" + Environment.NewLine;
                        break;
                    case 0x03:
                        textBox2.Text += "mbi.AllocationProtect PAGE_READWRITE" + Environment.NewLine;
                        break;
                    case 0x04:
                        textBox2.Text += "mbi.AllocationProtect PAGE_WRITECOPY" + Environment.NewLine;
                        break;
                    default:
                        textBox2.Text += "mbi.AllocationProtect " + mbi.AllocationProtect + Environment.NewLine;
                        break;
                }

                textBox2.Text += "mbi.Protect " + mbi.Protect + Environment.NewLine;
                textBox2.Text += "mbi.RegionSize " + mbi.RegionSize + Environment.NewLine;
                */
            }
        }

        //////////////////////////////////////////////////
        // Zoom texture
        private void button2x_Click(object sender, EventArgs e)
        {
            int sourceWidth = preview.Width;
            int sourceHeight = preview.Height;
            int targetWidth = sourceWidth * 2;
            int targetHeight = sourceHeight * 2;
            double ratio;

            preview.Width = targetWidth;
            preview.Height = targetHeight;

            if (sourceWidth > sourceHeight)
            {
                targetWidth = preview.Width;
                ratio = (double)targetWidth / sourceWidth;
                targetHeight = (int)(ratio * sourceHeight);
            }
            else if (sourceWidth < sourceHeight)
            {
                targetHeight = preview.Height;
                ratio = (double)targetHeight / sourceHeight;
                targetWidth = (int)(ratio * sourceWidth);
            }
            else
            {
                targetHeight = preview.Height;
                targetWidth = preview.Width;
            }

            int targetTop = 0;//(preview.Height - targetHeight) / 2;
            int targetLeft = 0;//(preview.Width - targetWidth) / 2;

            Bitmap tempBitmap = new Bitmap(preview.Width, preview.Height, PixelFormat.Format24bppRgb);

            tempBitmap.SetResolution(preview.Image.HorizontalResolution, preview.Image.VerticalResolution);

            Graphics bmGraphics = Graphics.FromImage(tempBitmap);

            bmGraphics.Clear(Color.Transparent);

            bmGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            bmGraphics.DrawImage(preview.Image, new Rectangle(targetLeft, targetTop, targetWidth, targetHeight), new Rectangle(0, 0, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

            bmGraphics.Dispose();

            preview.Width = tempBitmap.Width;
            preview.Height = tempBitmap.Height;
            preview.Image = tempBitmap;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = treeView1.SelectedNode.Name;
            Text = path;

            if (path != "")
            {
                LoadTexture(null, path);
            }
        }

        private void preview2_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            if (preview2.Image != null)
            {
                color.Image = new Bitmap(20, 20, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(color.Image))
                using (SolidBrush brush = new SolidBrush(((Bitmap)preview2.Image).GetPixel(e.X, e.Y)))
                {
                    g.FillRectangle(brush, 0, 0, color.Image.Width, color.Image.Height);
                }

                label14.Text = ((Bitmap)preview2.Image).GetPixel(e.X, e.Y).ToString();
                label15.Text = _pixels[e.X + e.Y * _width].alpha.ToString("X2") + " " + _pixels[e.X + e.Y * _width].unk01.ToString("X2") + " " +
                               _pixels[e.X + e.Y * _width].unk02.ToString("X2") + " " + _pixels[e.X + e.Y * _width].unk03.ToString("X2") + " " +
                               _pixels[e.X + e.Y * _width].unk04.ToString("X2") + " " + _pixels[e.X + e.Y * _width].unk05.ToString("X2") + " " +
                               _pixels[e.X + e.Y * _width].unk06.ToString("X2") + " " + _pixels[e.X + e.Y * _width].unk07.ToString("X2") + " " +
                               _pixels[e.X + e.Y * _width].unk08.ToString("X2") + " " + _pixels[e.X + e.Y * _width].unk09.ToString("X2") + " " +
                               _pixels[e.X + e.Y * _width].unk0A.ToString("X2") + " " + _pixels[e.X + e.Y * _width].unk0B.ToString("X2") + " " +
                               _pixels[e.X + e.Y * _width].unk0C.ToString("X2") + " " + _pixels[e.X + e.Y * _width].unk0D.ToString("X2") + " " +
                               _pixels[e.X + e.Y * _width].unk0E.ToString("X2") + " " + _pixels[e.X + e.Y * _width].unk0F.ToString("X2");
            }
            */
        }

        //////////////////////////////////////////////////
        // Import texture from file
        private void buttonImport_Click(object sender, EventArgs e)
        {
            ofd.Filter = "DDS files|*.dds";//|PNG files|*.png|All files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    switch (Path.GetExtension(ofd.FileName).ToLower())
                    {
                        case ".dds":
                            using (Stream fileStream = ofd.OpenFile())
                            {
                                FileInfo fi = new FileInfo(ofd.FileName);
                                int fileSize = (int) fi.Length;

                                byte[] fileBytes = new byte[fi.Length];
                                fileStream.Read(fileBytes, 0, fileSize);

                                fileStream.Close();

                                _pixels = new PixelData[(fileSize - 0x80)/16];
                                int p = 0;

                                for (int i = 0x80; i < fileSize; i += 16)
                                {
                                    _pixels[p++] = new PixelData(fileBytes, i);
                                }

                                UpdatePreviews();
                            }
                            break;
                        case ".png":
                            // @TODO: PNG to DDS (DXT) conversion
                            Bitmap bmp = new Bitmap(ofd.FileName);

                            bmp.Save("temp.bmp", ImageFormat.Bmp);
                            /*
                            using (MemoryStream stream = new MemoryStream())
                            {
                                bmp.Save(stream, ImageFormat.Bmp);
                            }
                            */
                            break;
                        case ".bmp":
                            // @TODO: BMP to DDS (DXT) conversion
                            // Bitmap bmp = new Bitmap(ofd.FileName);
                            break;
                        default:
                            MessageBox.Show("Unknown file format " + Path.GetExtension(ofd.FileName));
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Error: Could not read file from disk." + Environment.NewLine + "Exception: " + ex.Message);
                }
            }
        }

        //////////////////////////////////////////////////
        // Save/replace the game texture with custom imported texture
        private void buttonSaveTexture_Click(object sender, EventArgs e)
        {
            // Backup original texture
            File.Move(_path, _path + ".bak");

            // Update the bytes
            int index = 0;
            foreach (PixelData pixel in _pixels)
            {
                _fileBytes[0x184 + index + 0] = pixel.alpha;
                _fileBytes[0x184 + index + 1] = pixel.unk01;
                _fileBytes[0x184 + index + 2] = pixel.unk02;
                _fileBytes[0x184 + index + 3] = pixel.unk03;
                _fileBytes[0x184 + index + 4] = pixel.unk04;
                _fileBytes[0x184 + index + 5] = pixel.unk05;
                _fileBytes[0x184 + index + 6] = pixel.unk06;
                _fileBytes[0x184 + index + 7] = pixel.unk07;
                _fileBytes[0x184 + index + 8] = pixel.unk08;
                _fileBytes[0x184 + index + 9] = pixel.unk09;
                _fileBytes[0x184 + index + 10] = pixel.unk0A;
                _fileBytes[0x184 + index + 11] = pixel.unk0B;
                _fileBytes[0x184 + index + 12] = pixel.unk0C;
                _fileBytes[0x184 + index + 13] = pixel.unk0D;
                _fileBytes[0x184 + index + 14] = pixel.unk0E;
                _fileBytes[0x184 + index + 15] = pixel.unk0F;
                index += 16;
            }

            // Save new texture
            Stream fileStream = File.OpenWrite(_path);
            fileStream.Write(_fileBytes, 0, _fileBytes.Length);
            fileStream.Close();

            UpdatePreviews();
        }

        //////////////////////////////////////////////////
        // Export texture to DDS format
        private void buttonExportDDS_Click(object sender, EventArgs e)
        {
            sfd.Filter = "DDS files|*.dds";
            sfd.FileName = Path.GetFileNameWithoutExtension(_fileName);

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // DXT5
                    byte[] ddsBytes = new byte[(_pixels.Length * 16) + 128]; // each pixel is 16 bytes, 128 DDS header size

                    byte[] nullBytes = new byte[100];

                    using (MemoryStream ms = new MemoryStream())
                    {
                        // DDS_HEADER
                        ms.Write(Encoding.ASCII.GetBytes("DDS "), 0, 4);

                        ms.Write(BitConverter.GetBytes(124), 0, 4); // dwSize
                        ms.Write(BitConverter.GetBytes(0x081007), 0, 4); // dwFlags

                        ms.Write(BitConverter.GetBytes(_height), 0, 4); // dwHeight
                        ms.Write(BitConverter.GetBytes(_width), 0, 4); // dwWidth

                        ms.Write(BitConverter.GetBytes(_width == _height ? 0x4000 : 0x2000), 0, 4); // dwPitchOrLinearSize

                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwDepth
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwMipMapCount

                        // dwReserved1[11]
                        ms.Write(nullBytes, 0, 11);

                        // DDS_PIXELFORMAT
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwSize
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwFlags
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwFourCC
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwRGBBitCount
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwRBitMask
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwGBitMask
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwBBitMask
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwABitMask

                        ms.WriteByte(0); // ?
                        ms.Write(BitConverter.GetBytes(0x20), 0, 4); // ?
                        ms.Write(BitConverter.GetBytes(0x04), 0, 4); // ?

                        ms.Write(Encoding.ASCII.GetBytes("DXT5"), 0, 4);
                        ms.Write(nullBytes, 0, 20);

                        ms.Write(BitConverter.GetBytes(0x1000), 0, 4); // dwCaps
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwCaps2
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwCaps3
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwCaps4
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // dwReserved2

                        foreach (PixelData pixel in _pixels)
                        {
                            ms.WriteByte(pixel.alpha);
                            ms.WriteByte(pixel.unk01);
                            ms.WriteByte(pixel.unk02);
                            ms.WriteByte(pixel.unk03);
                            ms.WriteByte(pixel.unk04);
                            ms.WriteByte(pixel.unk05);
                            ms.WriteByte(pixel.unk06);
                            ms.WriteByte(pixel.unk07);
                            ms.WriteByte(pixel.unk08);
                            ms.WriteByte(pixel.unk09);
                            ms.WriteByte(pixel.unk0A);
                            ms.WriteByte(pixel.unk0B);
                            ms.WriteByte(pixel.unk0C);
                            ms.WriteByte(pixel.unk0D);
                            ms.WriteByte(pixel.unk0E);
                            ms.WriteByte(pixel.unk0F);
                        }

                        // That should be 0x80 bytes total

                        ddsBytes = ms.ToArray();
                        ms.Close();
                    }

                    using (Stream fileStream = sfd.OpenFile())
                    {
                        fileStream.Write(ddsBytes, 0, ddsBytes.Length);
                        fileStream.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
