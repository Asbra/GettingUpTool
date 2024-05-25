using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace GettingUpTool
{
    public enum TextureType
    {
        ST,
        ST2,
        BIR,
        DDS
    }

    public class Texture
    {
        public const int HEADER_SIZE = 0x104;
        public const int DDS_HEADER_SIZE = 128;
        public const int ST_BIR_OFFSET = 0x104;
        public const int ST_TEXTURE_OFFSET = 0x184;

        public byte[] Data;
        public byte[] Pixels;

        public string Path = string.Empty;
        public string FileName = string.Empty;
        public int FileSize = 0;

        public string Name = string.Empty;
        public TextureType Type;
        // public string Type = string.Empty;

        public int DXT = 0;
        public int Width = 0;
        public int Height = 0;
        public int AlphaBitDepth = 0;

        public static T BytesToStructure<T>(byte[] bytes)
        {
            int size = Marshal.SizeOf(typeof(T));
            if (bytes.Length < size)
                throw new ArgumentException("Invalid parameter");

            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(size);

                Marshal.Copy(bytes, 0, ptr, size);

                return (T)Marshal.PtrToStructure(ptr, typeof(T));
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static byte[] StructureToBytes<T>(T structure)
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] bytes = new byte[size];

            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(size);

                // Marshal.StructureToPtr(structure, ptr, false);
                Marshal.Copy(ptr, bytes, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return bytes;
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public unsafe struct DDS_PIXELFORMAT
        {
            public Int32 dwSize;
            public Int32 dwFlags;
            public Int32 dwFourCC;
            public Int32 dwRGBBitCount;
            public Int32 dwRBitMask;
            public Int32 dwGBitMask;
            public Int32 dwBBitMask;
            public Int32 dwABitMask;
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public unsafe struct DDSfile
        {
            public fixed char DDS[4]; // 0000
            public Int32 dwSize; // 0004
            public Int32 dwFlags; // 0008
            public Int32 dwHeight; // 000C
            public Int32 dwWidth; // 0010
            public Int32 dwPitchOrLinearSize; // 0014
            public Int32 dwDepth; // 0018
            public Int32 dwMipMapCount; // 001C
            public fixed Int32 dwReserved[11]; // 0020
            public DDS_PIXELFORMAT PixelFormat; // 0x004C
            public Int32 dwCaps; // 006C
            public Int32 dwCaps2;
            public Int32 dwCaps3;
            public Int32 dwCaps4;
            public Int32 dwReserved2;
            public byte[] Texture; // 0080
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public unsafe struct STfile
        {
            public fixed char ST[4]; // 0000
            public Int32 _0004 { get; set; }
            public Int32 Compression { get; set; } // 0008
            public Int32 Width { get; set; } // 000C
            public Int32 Height { get; set; } // 0010
            public Int32 Width2 { get; set; } // 0014
            public Int32 Height2 { get; set; } // 0018
            public Int32 _001C { get; set; } // 001C
            public Int32 _0020 { get; set; } // 0020
            public Int32 _0024 { get; set; } // 0024
            public Int32 _0028 { get; set; } // 0028
            public Int32 _002C { get; set; } // 002C
            public Int32 _0030 { get; set; } // 0030
            public Int32 DdsSize { get; set; } // 0034
            public Int32 _0038 { get; set; } // 0038
            public Int32 Unknown { get; set; } // 003C
            public fixed char Name[32]; // 0040
            public Int32 _0060 { get; set; } // 0060
            public Int32 _0064 { get; set; } // 0064
            public Int32 _0068 { get; set; } // 0068
            public Int32 _006C { get; set; } // 006C
            public Int32 _0070 { get; set; } // 0070
            public Int32 _0074 { get; set; } // 0074
            public Int32 _0078 { get; set; } // 0078
            public Int32 _007C { get; set; } // 007C
            public Int32 _0080 { get; set; } // 0080
            public Int32 DdsSize2 { get; set; } // 0084
            public Int32 _0088 { get; set; } // 0088
            public Int32 DdsSize3 { get; set; } // 008C
            public Int32 DdsSize4 { get; set; } // 0090
            public Int32 _0094 { get; set; } // 0094
            public Int32 _0098 { get; set; } // 0098
            public Int32 _009C { get; set; } // 009C
            public Int32 _00A0 { get; set; } // 00A0
            public Int32 _00A4 { get; set; } // 00A4
            public Int32 _00A8 { get; set; } // 00A8
            public Int32 _00AC { get; set; } // 00AC
            public Int32 _00B0 { get; set; } // 00B0
            public Int32 _00B4 { get; set; } // 00B4
            public Int32 _00B8 { get; set; } // 00B8
            public Int32 _00BC { get; set; } // 00BC
            public Int32 _00C0 { get; set; } // 00C0
            public Int32 _00C4 { get; set; } // 00C4
            public Int32 _00C8 { get; set; } // 00C8
            public Int32 _00CC { get; set; } // 00CC
            public Int32 _00D0 { get; set; } // 00D0
            public Int32 _00D4 { get; set; } // 00D4
            public Int32 _00D8 { get; set; } // 00D8
            public Int32 _00DC { get; set; } // 00DC
            public Int32 _00E0 { get; set; } // 00E0
            public Int32 _00E4 { get; set; } // 00E4
            public Int32 _00E8 { get; set; } // 00E8
            public Int32 _00EC { get; set; } // 00EC
            public Int32 _00F0 { get; set; } // 00F0
            public Int32 _00F4 { get; set; } // 00F4
            public Int32 _00F8 { get; set; } // 00F8
            public Int32 _00FC { get; set; } // 00FC
            public Int32 _0100 { get; set; } // 0100
            public fixed char BIR[4]; // 0104
            public Int32 _0108 { get; set; } // 0108
            public Int32 _010C { get; set; } // 010C
            public Int32 _0110 { get; set; } // 0110
            public Int32 _0114 { get; set; } // 0114
            public Int32 _0118 { get; set; } // 0118
            public Int32 _011C { get; set; } // 011C
            public Int32 _0120 { get; set; } // 0120
            public Int32 _0124 { get; set; } // 0124
            public Int32 _0128 { get; set; } // 0128
            public Int32 _012C { get; set; } // 012C
            public Int32 _0130 { get; set; } // 0130
            public Int32 _0134 { get; set; } // 0134
            public Int32 _0138 { get; set; } // 0138
            public Int32 _013C { get; set; } // 013C
            public Int32 _0140 { get; set; } // 0140
            public Int32 _0144 { get; set; } // 0144
            public Int32 _0148 { get; set; } // 0148
            public Int32 _014C { get; set; } // 014C
            public Int32 _0150 { get; set; } // 0150
            public Int32 _0154 { get; set; } // 0154
            public Int32 _0158 { get; set; } // 0158
            public Int32 _015C { get; set; } // 015C
            public Int32 _0160 { get; set; } // 0160
            public Int32 _0164 { get; set; } // 0164
            public Int32 _0168 { get; set; } // 0168
            public Int32 _016C { get; set; } // 016C
            public Int32 _0170 { get; set; } // 0170
            public Int32 _0174 { get; set; } // 0174
            public Int32 _0178 { get; set; } // 0178
            public Int32 _017C { get; set; } // 017C
            public Int32 _0180 { get; set; } // 0180
            public byte[] Texture { get; set; } // 0184
        }

        public static DDSfile DdsFromBytes(byte[] bytes)
        {
            int size = Marshal.SizeOf(typeof(DDSfile));
            if (bytes.Length < size)
                throw new ArgumentException("Invalid parameter");

            DDSfile result = new DDSfile();
            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.AllocHGlobal(size);

                Marshal.Copy(bytes, 0, ptr, size);

                var dataSize = bytes.Length - size;
                result.Texture = new byte[dataSize];
                Array.Copy(bytes, size, result.Texture, 0, dataSize);

                return result;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static byte[] DdsToBytes(DDSfile structure)
        {
            int size = Marshal.SizeOf(typeof(DDSfile));
            byte[] bytes = new byte[size + structure.Texture.Length];

            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(size);

                // Marshal.StructureToPtr(structure, ptr, false);
                Marshal.Copy(ptr, bytes, 0, size);

                var dataSize = bytes.Length - size;
                Array.Copy(structure.Texture, 0, bytes, size, structure.Texture.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return bytes;
        }

        public static STfile StFromBytes(byte[] bytes)
        {
            int size = Marshal.SizeOf(typeof(STfile));
            if (bytes.Length < size)
                throw new ArgumentException("Invalid parameter");

            STfile result = new STfile();
            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.AllocHGlobal(size);

                Marshal.Copy(bytes, 0, ptr, size);

                var dataSize = bytes.Length - size;
                result.Texture = new byte[dataSize];
                Array.Copy(bytes, size, result.Texture, 0, dataSize);

                return result;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static byte[] StToBytes(STfile structure)
        {
            int size = Marshal.SizeOf(typeof(STfile));
            byte[] bytes = new byte[size + structure.Texture.Length];

            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(size);

                // Marshal.StructureToPtr(structure, ptr, false);
                Marshal.Copy(ptr, bytes, 0, size);

                var dataSize = bytes.Length - size;
                Array.Copy(structure.Texture, 0, bytes, size, structure.Texture.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return bytes;
        }

        public Texture(string path)
        {
            Path = path;

            FileInfo fi = new FileInfo(path);
            FileSize = (int)fi.Length;
            FileName = fi.Name;

            // Data = new byte[fi.Length];

            Data = File.ReadAllBytes(path);

            Initialize();
        }

        public Texture(byte[] fileBytes)
        {
            Data = new byte[fileBytes.Length];
            Array.Copy(fileBytes, Data, fileBytes.Length);

            Initialize();
        }

        public virtual void Initialize()
        {
            string HeaderString = Encoding.ASCII.GetString(Data, 0, 4);
            HeaderString = HeaderString.TrimEnd().TrimEnd('\0');

            switch (HeaderString)
            {
                case "ST":
                    Type = TextureType.ST;
                    break;
                case "ST2":
                    Type = TextureType.ST2;
                    break;
                case "BIR":
                    Type = TextureType.BIR;
                    break;
                case "DDS":
                    Type = TextureType.DDS;
                    break;
                default: break;
            }
        }
    }

    public class ST : Texture
    {
        public ST(string path) : base(path) { }

        public ST(byte[] fileBytes) : base(fileBytes) { }

        public STfile Struct;

        public override void Initialize()
        {
            base.Initialize();

            for (int i = 0x40; Data[i] != 0; i++)
            {
                Name += (char)Data[i];
            }

            Width = BitConverter.ToInt32(Data, 0x0C); // Data[0xC] | Data[0xD] << 8 | Data[0xE] << 16 | Data[0xF] << 24;
            Height = BitConverter.ToInt32(Data, 0x10); // Data[0x10] | Data[0x11] << 8 | Data[0x12] << 16 | Data[0x13] << 24;

            int textureLength = BitConverter.ToInt32(Data, 0x34);
            int birOffset = Data.Length - textureLength;
            int textureOffset = birOffset + 0x80;
            int pixelsSize = Data.Length - textureOffset;

            Pixels = new byte[pixelsSize];
            Array.Copy(Data, textureOffset, Pixels, 0, pixelsSize);

            Struct = StFromBytes(Data);

            /*
            byte[] fmtNibble = { (byte)((Data[0x3C] & 0xF0) >> 4), (byte)(Data[0x3C] & 0x0F) };
            // Second nibble is 0=DXT1, 1=DXT3?, 2=DXT5
            // First nibble ?? 1 offset image?, 4 used in DXT1, 5/6 used in DXT5

            if (fmtNibble[1] == 0)
            {
                DXT = 1;
            }
            else if (fmtNibble[1] == 1)
            {
                DXT = 3;
            }
            else if (fmtNibble[1] == 2)
            {
                DXT = 5;
            }
            */
            switch (Data[0x08])
            {
                case 3:
                    DXT = 1;
                    break;
                case 4:
                    DXT = 5;
                    break;
                default:
                    DXT = 0;
                    break;
                    // throw new FormatException($"Unknown texture compression {Data[0x08]:X2}");
            }
        }
    }

    public class ST2 : Texture
    {
        public ST2(string path) : base(path) { }

        public ST2(byte[] fileBytes) : base(fileBytes) { }

        public override void Initialize()
        {
            base.Initialize();

            for (int i = 0x40; Data[i] != 0; i++)
            {
                Name += (char)Data[i];
            }

            Width = BitConverter.ToInt32(Data, 0x0C);
            Height = BitConverter.ToInt32(Data, 0x10);

            switch (Data[0x08])
            {
                case 3:
                    DXT = 1;
                    break;
                case 4:
                    DXT = 5;
                    break;
                default:
                    throw new FormatException($"Unknown texture compression {Data[0x08]:X2}");
            }
        }
    }

    public class DDS : Texture
    {
        public DDS(string path) : base(path) { }

        public DDS(byte[] fileBytes) : base(fileBytes) { }

        public DDSfile Struct;

        public override void Initialize()
        {
            base.Initialize();

            Struct = DdsFromBytes(Data);

            /*
            switch (Struct.PixelFormat.dwFourCC)
            {
                case 827611204: // DXT1
                    DXT = 1;
                    break;
                case 861165636: // DXT3
                    DXT = 3;
                    break;
                case 894720068: // DXT5
                    DXT = 5;
                    break;
            }
            */

            if (Data[0x57] == '5') DXT = 5;
            else if (Data[0x57] == '1') DXT = 1;
            else if (Data[0x57] == '3') DXT = 3;

            Width = BitConverter.ToInt32(Data, 0x10);
            Height = BitConverter.ToInt32(Data, 0x0C);
        }
    }

    public class TextureUtil
    {
        #region Constants
        public const int DDS_HEADER_SIZE = 128;
        public const int ST_BIR_OFFSET = 0x104;
        public const int ST_TEXTURE_OFFSET = 0x184;

        // https://github.com/zigox/arturas-kalonline-coding/blob/master/KDE/KDE/XNAGraphics/DDSLib.cs
        private const int DDSD_CAPS = 0x1;                      //Required in every .dds file.	
        private const int DDSD_HEIGHT = 0x2;                    //Required in every .dds file.
        private const int DDSD_WIDTH = 0x4;                     //Required in every .dds file.
        private const int DDSD_PITCH = 0x8;                     //Required when pitch is provided for an uncompressed texture.
        private const int DDSD_PIXELFORMAT = 0x1000;            //Required in every .dds file.
        private const int DDSD_MIPMAPCOUNT = 0x20000;           //Required in a mipmapped texture.
        private const int DDSD_LINEARSIZE = 0x80000;            //Required when pitch is provided for a compressed texture.
        private const int DDSD_DEPTH = 0x800000;                //Required in a depth texture.

        private const int DDPF_ALPHAPIXELS = 0x1;               //Texture contains alpha data; dwRGBAlphaBitMask contains valid data.	
        private const int DDPF_ALPHA = 0x2;	                    //Used in some older DDS files for alpha channel only uncompressed data (dwRGBBitCount contains the alpha channel bitcount; dwABitMask contains valid data)	
        private const int DDPF_FOURCC = 0x4;	                //Texture contains compressed RGB data; dwFourCC contains valid data.	
        private const int DDPF_RGB = 0x40;	                    //Texture contains uncompressed RGB data; dwRGBBitCount and the RGB masks (dwRBitMask, dwRBitMask, dwRBitMask) contain valid data.	
        private const int DDPF_YUV = 0x200;	                    //Used in some older DDS files for YUV uncompressed data (dwRGBBitCount contains the YUV bit count; dwRBitMask contains the Y mask, dwGBitMask contains the U mask, dwBBitMask contains the V mask)	
        private const int DDPF_LUMINANCE = 0x2000;	            //Used in some older DDS files for single channel color uncompressed data (dwRGBBitCount contains the luminance channel bit count; dwRBitMask contains the channel mask). Can be combined with DDPF_ALPHAPIXELS for a two channel DDS file.	
        private const int DDPF_Q8W8V8U8 = 0x00080000;           //Used by Microsoft tools when a Q8W8V8U8 is present, this is not a documeneted flag.

        private const int DDSCAPS_COMPLEX = 0x8;	            //Optional; must be used on any file that contains more than one surface (a mipmap, a cubic environment map, or mipmapped volume texture).	
        private const int DDSCAPS_MIPMAP = 0x400000;            //Optional; should be used for a mipmap.	
        private const int DDSCAPS_TEXTURE = 0x1000;	            //Required	

        private const int DDSCAPS2_CUBEMAP = 0x200;             //Required for a cube map.	
        private const int DDSCAPS2_CUBEMAP_POSITIVEX = 0x400;	//Required when these surfaces are stored in a cube map.	
        private const int DDSCAPS2_CUBEMAP_NEGATIVEX = 0x800;	//Required when these surfaces are stored in a cube map.	
        private const int DDSCAPS2_CUBEMAP_POSITIVEY = 0x1000;	//Required when these surfaces are stored in a cube map.	
        private const int DDSCAPS2_CUBEMAP_NEGATIVEY = 0x2000;	//Required when these surfaces are stored in a cube map.	
        private const int DDSCAPS2_CUBEMAP_POSITIVEZ = 0x4000;	//Required when these surfaces are stored in a cube map.	
        private const int DDSCAPS2_CUBEMAP_NEGATIVEZ = 0x8000;	//Required when these surfaces are stored in a cube map.	
        private const int DDSCAPS2_VOLUME = 0x200000;           //Required for a volume texture.

        private const uint DDS_MAGIC = 0x20534444; // "DDS "
        #endregion

        [StructLayout(LayoutKind.Sequential)]
        public struct PixelData
        {
            // https://en.wikipedia.org/wiki/S3_Texture_Compression
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

        //
        // Convert DDS to ST
        //
        static public byte[] DDStoST(byte[] fileBytes, byte[] metaBytes=null)
        {
            if (fileBytes[0] != 'D' && fileBytes[1] != 'D' && fileBytes[2] != 'S')
            {
                throw new InvalidDataException("Not a DDS file");
            }

            byte _0008 = 0;
            string textureName = string.Empty;
            byte dxt_byte = 0;
            byte _003C = 0;

            if (metaBytes != null)
            {
                textureName = Encoding.ASCII.GetString(metaBytes, 0, 32);
                _0008 = metaBytes[0x20];
                dxt_byte = metaBytes[0x21];
                _003C = metaBytes[0x22];
            }

            int width = fileBytes[0x10] | fileBytes[0x11] << 8 | fileBytes[0x12] << 16 | fileBytes[0x13] << 24;
            int height = fileBytes[0x0C] | fileBytes[0x0D] << 8 | fileBytes[0x0E] << 16 | fileBytes[0x0F] << 24;

            int dxt_version = fileBytes[0x57] == '5' ? 5 : (fileBytes[0x57] == '1' ? 1 : 0);

            PixelData[] pixels = new PixelData[(fileBytes.Length - 0x80) / 16];
            int p = 0;

            for (int i = 0x80; i < fileBytes.Length; i += 16)
            {
                pixels[p++] = new PixelData(fileBytes, i);
            }

            byte[] outBytes = new byte[fileBytes.Length + 0x100]; // each pixel is 16 bytes, 256 ST header size

            byte[] nullBytes = new byte[100];

            using (MemoryStream ms = new MemoryStream())
            {
                // Write ST header
                ms.Write(Encoding.ASCII.GetBytes("ST"), 0, 2);
                ms.Write(BitConverter.GetBytes(0), 0, 2);
                ms.Write(BitConverter.GetBytes(4), 0, 4); // 0004
                ms.Write(BitConverter.GetBytes(_0008), 0, 4); // 0008

                ms.Write(BitConverter.GetBytes(width), 0, 4); // 000C
                ms.Write(BitConverter.GetBytes(height), 0, 4); // 0010
                ms.Write(BitConverter.GetBytes(width), 0, 4); // 0014
                ms.Write(BitConverter.GetBytes(height), 0, 4); // 0018

                ms.Write(BitConverter.GetBytes(dxt_version), 0, 4); // 001C
                ms.Write(BitConverter.GetBytes(0), 0, 4); // 0020
                ms.Write(BitConverter.GetBytes(1), 0, 4); // 0024
                ms.Write(BitConverter.GetBytes(1), 0, 4); // 0028
                ms.Write(BitConverter.GetBytes(0), 0, 4); // 002C
                ms.Write(BitConverter.GetBytes(1), 0, 4); // 0030
                ms.Write(BitConverter.GetBytes(0x00008080), 0, 4); // 0034
                ms.Write(BitConverter.GetBytes(0x80), 0, 4); // 0038
                ms.Write(BitConverter.GetBytes(_003C), 0, 4); // 003C
                
                ms.Write(Encoding.ASCII.GetBytes(textureName), 0, Encoding.ASCII.GetBytes(textureName).Length); // 0040
                ms.Write(nullBytes, 0, 32 - Encoding.ASCII.GetBytes(textureName).Length); // 0040

                ms.Write(BitConverter.GetBytes(0), 0, 4); // 0060
                ms.Write(BitConverter.GetBytes(0), 0, 4); // 0064
                ms.Write(BitConverter.GetBytes(2), 0, 4); // 0068
                ms.Write(BitConverter.GetBytes(10), 0, 4); // 006C
                ms.Write(BitConverter.GetBytes(0), 0, 4); // 0070
                ms.Write(BitConverter.GetBytes(0), 0, 4); // 0074
                ms.Write(BitConverter.GetBytes(0), 0, 4); // 0078
                ms.Write(BitConverter.GetBytes(0), 0, 4); // 007C
                ms.Write(BitConverter.GetBytes(0), 0, 4); // 0080
                ms.Write(BitConverter.GetBytes(0x00008080), 0, 4); // 0084
                ms.Write(BitConverter.GetBytes(0x00000080), 0, 4); // 0088
                ms.Write(BitConverter.GetBytes(0x00008080), 0, 4); // 008C
                ms.Write(BitConverter.GetBytes(0x00008080), 0, 4); // 0090
                ms.Write(nullBytes, 0, 0x70); // 0094

                // Write BIR header
                ms.Write(Encoding.ASCII.GetBytes("BIR"), 0, 3); // 104
                ms.Write(BitConverter.GetBytes(0), 0, 1); // 107
                ms.Write(nullBytes, 0, 0x7C); // 0108

                // Write image pixel data
                // offset 0184
                foreach (PixelData pixel in pixels)
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

                outBytes = ms.ToArray();
                ms.Close();
            }

            return outBytes;
        }

        //
        // Convert ST to DDS
        //
        static public byte[] STtoDDS(byte[] fileBytes, bool header=true)
        {
            if (fileBytes[0] != 'S' && fileBytes[1] != 'T')
            {
                throw new InvalidDataException("Not a ST file");
            }

            int width = fileBytes[0xC] | fileBytes[0xD] << 8 | fileBytes[0xE] << 16 | fileBytes[0xF] << 24;
            int height = fileBytes[0x10] | fileBytes[0x11] << 8 | fileBytes[0x12] << 16 | fileBytes[0x13] << 24;

            int bitCount = fileBytes[0x88];
            int alphaMask = fileBytes[0x1C];

            int dxt_version = 0; // fileBytes[0x1C] > 0 ? 5 : 1;
            switch (fileBytes[0x08])
            {
                case 3:
                    dxt_version = 1;
                    break;
                case 4:
                    dxt_version = 5;
                    break;
                default:
                    // throw new FormatException($"Unknown texture compression {fileBytes[0x08]:X2}");
                    break;
            }

            PixelData[] pixels = new PixelData[(fileBytes.Length - 0x184) / 16];
            int p = 0;

            for (int i = 0x184; i < fileBytes.Length; i += 16)
            {
                pixels[p++] = new PixelData(fileBytes, i);
            }

            p = p * 16;

            byte[] outBytes = new byte[(pixels.Length * 16) + (!header ? 0 : DDS_HEADER_SIZE)]; // each pixel is 16 bytes, 128 DDS header size

            byte[] nullBytes = new byte[100];

            using (MemoryStream ms = new MemoryStream())
            {
                if (header)
                {
                    // DDS_HEADER
                    ms.Write(Encoding.ASCII.GetBytes("DDS "), 0, 4);

                    ms.Write(BitConverter.GetBytes(124), 0, 4); // 0004 dwSize
                    ms.Write(BitConverter.GetBytes(0x081007), 0, 4); // 0008 dwFlags

                    ms.Write(BitConverter.GetBytes(height), 0, 4); // 000C dwHeight
                    ms.Write(BitConverter.GetBytes(width), 0, 4); // 0010 dwWidth

                    ms.Write(BitConverter.GetBytes(width == height ? 0x4000 : 0x2000), 0, 4); // 0014 dwPitchOrLinearSize

                    ms.Write(BitConverter.GetBytes(0), 0, 4); // 0018 dwDepth
                    ms.Write(BitConverter.GetBytes(0), 0, 4); // 001C dwMipMapCount

                    ms.Write(nullBytes, 0, 44); // 0020 dwReserved1[11]

                    // DDS_PIXELFORMAT
                    ms.Write(BitConverter.GetBytes(32), 0, 4); // 004C dwSize

                    if (dxt_version != 0)
                    {
                        ms.Write(BitConverter.GetBytes(DDPF_FOURCC), 0, 4); // 0050 dwFlags
                        ms.Write(Encoding.ASCII.GetBytes("DXT" + dxt_version), 0, 4); // 0054 dwFourCC
                    }
                    else
                    {
                        ms.Write(BitConverter.GetBytes(DDPF_RGB), 0, 4); // 0050 dwFlags
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // 0054 dwFourCC
                    }

                    if (dxt_version != 0)
                    {
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // 0058 dwRGBBitCount
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // 005C dwRBitMask
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // 0060 dwGBitMask
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // 0064 dwBBitMask
                        ms.Write(BitConverter.GetBytes(0), 0, 4); // 0068 dwABitMask
                    }
                    else
                    {
                        ms.Write(BitConverter.GetBytes(bitCount), 0, 4); // 0058 dwRGBBitCount
                        ms.Write(BitConverter.GetBytes(0x00ff0000), 0, 4); // 005C dwRBitMask
                        ms.Write(BitConverter.GetBytes(0x0000ff00), 0, 4); // 0060 dwGBitMask
                        ms.Write(BitConverter.GetBytes(0x000000ff), 0, 4); // 0064 dwBBitMask
                        ms.Write(BitConverter.GetBytes(0xff000000), 0, 4); // 0068 dwABitMask
                    }

                    ms.Write(BitConverter.GetBytes(0x1000), 0, 4); // 006C dwCaps
                    ms.Write(BitConverter.GetBytes(0), 0, 4); // 0070 dwCaps2
                    ms.Write(BitConverter.GetBytes(0), 0, 4); // 0074 dwCaps3
                    ms.Write(BitConverter.GetBytes(0), 0, 4); // 0078 dwCaps4
                    ms.Write(BitConverter.GetBytes(0), 0, 4); // 007C dwReserved2
                }

                // Texture data
                foreach (PixelData pixel in pixels)
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

                outBytes = ms.ToArray();
            }

            return outBytes;
        }

        static public byte[] STtoDDS(string path)
        {
            byte[] fileBytes = File.ReadAllBytes(path);
            return STtoDDS(fileBytes);
        }
    }
}
