using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GettingUpTool.Forms
{
    public partial class LevelTool : Form
    {
        #region Public variables
        #endregion

        #region Private variables
        private DirectoryInfo _gamePath;
        private string _gameRoot = "engine";
        private string[] _targetFileExtensions = { ".slp" };

        private Properties.Settings _settings = Properties.Settings.Default;

        private SLP slp;
        private SLS sls;
        #endregion

        #region Constructor
        public LevelTool()
        {
            InitializeComponent();
        }
        #endregion

        private static string StringFromByteArray(byte[] array, int index, int length)
        {
            return Encoding.ASCII.GetString(array, index, length).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?');
        }

        private static string HexLine(ref Int32 offset, ArraySegment<byte> bytes, Type type = null, string comment = "", bool show_bytes = true, bool show_chars = true)
        {
            string str = $"{offset:X4}";

            if (show_bytes == true)
            {
                str += $"\t";
                List<string> bstr = new List<string>();
                for (int i = 0; i < bytes.Count; i++)
                    bstr.Add($"{bytes.Array[bytes.Offset + i]:X2}");
                str += string.Join(" ", bstr.ToArray()).PadRight(11);
            }

            if (show_chars == true && (type == null || type.FullName != "System.String"))
            {
                str += $"\t";
                // List<string> bstr = new List<string>();
                for (int i = 0; i < bytes.Count; i++)
                {
                    if (bytes.Offset + i >= bytes.Array.Length - 1) continue;
                    char chr = BitConverter.ToChar(bytes.Array, bytes.Offset + i);
                    if (chr < 0x20 || chr > 0x7E) chr = '.';
                    str += chr;
                    // bstr.Add($"{bytes.Array[bytes.Offset + i]}");
                }
                // str += string.Join(" ", bstr.ToArray()).PadRight(11);
            }

            if (type == null)
                str += $"\t{BitConverter.ToInt32(bytes.Array, bytes.Offset),12}\t{BitConverter.ToSingle(bytes.Array, bytes.Offset),12}";
            else if (type.FullName == "System.String")
                str += $"\t{StringFromByteArray(bytes.Array, bytes.Offset, bytes.Count)}";
            else if (type.FullName == "System.Char")
                str += $"\t{BitConverter.ToChar(bytes.Array, bytes.Offset)}";
            else if (type.FullName == "System.Int16")
                str += $"\t{BitConverter.ToInt16(bytes.Array, bytes.Offset)}";
            else if (type.FullName == "System.Int32")
                str += $"\t{BitConverter.ToInt32(bytes.Array, bytes.Offset)}";
            else if (type.FullName == "System.UInt16")
                str += $"\t{BitConverter.ToUInt16(bytes.Array, bytes.Offset)}";
            else if (type.FullName == "System.UInt32")
                str += $"\t{BitConverter.ToUInt32(bytes.Array, bytes.Offset)}";
            else if (type.FullName == "System.Single")
                str += $"\t{BitConverter.ToSingle(bytes.Array, bytes.Offset)}";

            if (comment != "")
                str += $"\t{comment}";

            str += Environment.NewLine;

            offset += bytes.Count;

            return str;
        }

        private class Level
        {
            public bool Valid = false;

            public string Path = string.Empty;
            public string FileName = string.Empty;
            public int FileSize = 0;

            public byte[] Data;

            public string Name = string.Empty;
            public Int32 Offset = 0;

            [Serializable]
            [StructLayout(LayoutKind.Sequential, Pack = 0)]
            private unsafe struct LevelFile
            {
                // Offsets based on m02_hoo_subway_2.slp
                public Int32 Version; // 0000
                public string Header; // 0004 3DF!
                public Int16 _0008; // 0008
                public Int16 _000A; // 000A
                public Int32 NameLength; // 000C
                public string Name; // 0010
                public UInt32 Checksum; // Checksum?
                public Int32 _0048; // 1
                public Int32 _004C; // 0
                public Int32 _0050; // 1
                public Int32 _0054;
                public Int32 _0058;
                public Int32 _005C;
                public Int32 _0060;
            }
            private LevelFile Struct;

            private Int16 DataReadInt16(int index)
            {
                byte[] bytes = new byte[2];
                Buffer.BlockCopy(Data, index, bytes, 0, 2);
                return BitConverter.ToInt16(bytes, 0);
            }

            private Int32 DataReadInt32(int index)
            {
                byte[] bytes = new byte[4];
                Buffer.BlockCopy(Data, index, bytes, 0, 4);
                return BitConverter.ToInt32(bytes, 0);
            }

            private UInt32 DataReadUInt32(int index)
            {
                byte[] bytes = new byte[4];
                Buffer.BlockCopy(Data, index, bytes, 0, 4);
                return BitConverter.ToUInt32(bytes, 0);
            }

            public Level(string path)
            {
                Path = path;

                if (!File.Exists(path))
                    return;

                Valid = true;

                FileInfo fi = new FileInfo(path);
                FileSize = (int)fi.Length;
                FileName = fi.Name;

                Data = File.ReadAllBytes(path);

                Struct.Version = DataReadInt32(0x00); // 4

                Struct.Header = Encoding.ASCII.GetString(Data, 0x04, 4); // 3DF!

                Struct._0008 = DataReadInt16(0x08);
                Struct._000A = DataReadInt16(0x0A);

                Struct.NameLength = DataReadInt32(0x0C);

                Name = StringFromByteArray(Data, 0x10, Struct.NameLength);

                Offset = 0x10 + Struct.NameLength;

                Struct.Checksum = DataReadUInt32(Offset + 0x00);
                Struct._0048 = DataReadInt32(Offset + 0x04);
                Struct._004C = DataReadInt32(Offset + 0x08);
                Struct._0050 = DataReadInt32(Offset + 0x0C);
            }

            private static bool Equals(byte[] source, byte[] separator, int index)
            {
                for (int i = 0; i < separator.Length; ++i)
                    if (index + i >= source.Length || source[index + i] != separator[i])
                        return false;
                return true;
            }

            private static byte[][] Separate(byte[] source, byte[] separator)
            {
                var Parts = new List<byte[]>();
                var Index = 0;
                byte[] Part;

                for (var I = 0; I < source.Length; ++I)
                {
                    if (Equals(source, separator, I))
                    {
                        Part = new byte[I - Index];
                        Array.Copy(source, Index, Part, 0, Part.Length);
                        Parts.Add(Part);
                        Index = I + separator.Length;
                        I += separator.Length - 1;
                    }
                }

                Part = new byte[source.Length - Index];
                Array.Copy(source, Index, Part, 0, Part.Length);
                Parts.Add(Part);

                return Parts.ToArray();
            }

            public string Analyze()
            {
                if (!Valid)
                    return string.Empty;

                string output = string.Empty;
                int offset = 0;

                output += $"File\t{FileName}" + Environment.NewLine;
                output += $"FSize\t{FileSize} / {FileSize.ToString("X")}" + Environment.NewLine;

                output += $"Version\t{Struct.Version}" + Environment.NewLine;
                output += $"Header\t{Struct.Header}" + Environment.NewLine;
                output += $"Name\t{Name}" + Environment.NewLine;

                output += Environment.NewLine;

                output += $"{Offset:X4}\t{Struct.Checksum:X4}\t{Struct.Checksum}" + Environment.NewLine;

                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                for (offset = Offset + 4; offset < FileSize / 4;)
                {
                    if (FileSize - offset < 4)
                        break;
                    else
                        output += HexLine(ref offset, new ArraySegment<byte>(Data, offset, 4));
                }
                sw.Stop();
                output += Environment.NewLine + $"{sw.Elapsed.TotalSeconds}";

                output += Environment.NewLine;

                return output;
                ///////////////////////////////////////////////////////////////

                // TODO: Read the entire file and split by 0xFFFF
                // ArraySegment<byte>(Data, offset, 4);
                byte[] splitter = { 0xFF, 0xFF };
                var segments = Separate(Data, splitter);

                output += $"Segs.\t{segments.Length}" + Environment.NewLine;

                offset = Offset;
                for (int n = 1; n < segments.Length; n++)
                {
                    output += $"{offset:X4}";
                    output += $"\t";

                    List<string> bstr = new List<string>();

                    int i = 0;
                    for (i = 0; i < segments[n].Length; i++)
                        bstr.Add($"{segments[n][i]:X2}");
                    offset += segments[n].Length;

                    output += string.Join(" ", bstr.ToArray()).PadRight(11);

                    output += Environment.NewLine;
                }

                return output;
            }
        }

        private class SLS : Level
        {
            public SLS(string path) : base(path) { }
        }

        private class SLP : Level
        {
            public SLP(string path) : base(path) { }
        }

        private void LevelTool_Load(object sender, EventArgs e)
        {
            // Use current system font, rather than WinForms default font
            this.Font = SystemFonts.MessageBoxFont;

            // So we can just do Encoding GetString and not worry about newlines etc.
            Encoding.GetEncoding("Latin1");

            if (!string.IsNullOrWhiteSpace(_settings.GamePath))
            {
                _gamePath = new DirectoryInfo(_settings.GamePath);
            }

            if (!string.IsNullOrWhiteSpace(_settings.GameRoot))
            {
                _gameRoot = _settings.GameRoot;
            }

            DirectoryInfo levelsDir = new DirectoryInfo(Path.Combine(_gamePath.FullName, $@"{_gameRoot}\Levels"));

            treeGameFiles.SuspendLayout();
            treeGameFiles.Nodes.Clear();
            foreach (FileInfo file in levelsDir.GetFiles("*.slp", SearchOption.AllDirectories))
            {
                treeGameFiles.Nodes.Add(file.FullName, file.FullName.Replace(levelsDir.FullName, ""));
            }
            treeGameFiles.SelectedNode = null;
            treeGameFiles.ResumeLayout();
        }

        //
        // Load level from file
        //
        private bool LoadLevel(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            string pathNoExt = Path.Combine(fileInfo.DirectoryName, fileInfo.Name);

            slp = new SLP(path);
            sls = new SLS(Path.ChangeExtension(path, ".sls"));

            textDebugLog.Text = slp.Analyze();
            // textDebugLog2.Text = sls.Analyze();

            textMeshes.Text = "";
            textTextures.Text = "";

            return true;
        }

        //
        // Load selected file when selecting in the tree view
        //
        bool firstRun = true;
        private void treeGameFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (firstRun)
            {
                firstRun = false;
                return;
            }

            string path = treeGameFiles.SelectedNode.Name;

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                return;

            LoadLevel(path);
        }
    }
}
