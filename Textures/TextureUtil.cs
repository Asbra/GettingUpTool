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

        public string Path = string.Empty;
        public string FileName = string.Empty;
        public int FileSize = 0;

        public string Name = string.Empty;
        public TextureType Type;
        // public string Type = string.Empty;

        public int DXT = 0;
        public int Width = 0;
        public int Height = 0;

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

            /*
            if (HeaderString == "ST2") // fileBytes[0] == 'S' && fileBytes[1] == 'T' && fileBytes[2] == '2')
            {
                Type = TextureType.ST2;
            }
            else if (fileBytes[0] == 'S' && fileBytes[1] == 'T')
            {
                Type = TextureType.ST;
            }
            else if (fileBytes[0] == 'B' && fileBytes[1] == 'I' && fileBytes[2] == 'R')
            {
                Type = TextureType.BIR;
            }
            else if (fileBytes[0] == 'D' && fileBytes[1] == 'D' && fileBytes[2] == 'S')
            {
                Type = TextureType.DDS;
            }
            */
        }
    }

    public class ST : Texture
    {
        public ST(string path) : base(path) { }

        public ST(byte[] fileBytes) : base(fileBytes) { }

        public override void Initialize()
        {
            base.Initialize();

            for (int i = 0x40; Data[i] != 0; i++)
            {
                Name += (char)Data[i];
            }

            Width = Data[0xC] | Data[0xD] << 8 | Data[0xE] << 16 | Data[0xF] << 24;
            Height = Data[0x10] | Data[0x11] << 8 | Data[0x12] << 16 | Data[0x13] << 24;

            // DXT = Data[0x1C] > 0 ? 5 : 1;
            // DXT = Data[0x1C] == 0 ? 1 : Data[0x1C];

            byte[] fmtNibble = { (byte)((Data[0x3C] & 0xF0) >> 4), (byte)(Data[0x3C] & 0x0F) };
            // Second nibble is 0=DXT1, 1=DXT3?, 2=DXT5
            // First nibble ?? 1 offset image, 4 used in DXT1, 5/6 used in DXT5

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
            else
            {
                throw new FormatException($"Unknown texture compression {Data[0x3C]:X2}");
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

            byte[] fmtNibble = { (byte)((Data[0x38] & 0xF0) >> 4), (byte)(Data[0x38] & 0x0F) };
            // Second nibble is 0=DXT1, 1=DXT3?, 2=DXT5
            // First nibble ?? 1 offset image, 4 used in DXT1, 5/6 used in DXT5

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
            else
            {
                throw new FormatException($"Unknown texture compression {Data[0x38]:X2} ({fmtNibble[0]:X} {fmtNibble[1]:X})");
            }
        }
    }

    public class DDS : Texture
    {
        public DDS(string path) : base(path) { }

        public DDS(byte[] fileBytes) : base(fileBytes) { }

        public override void Initialize()
        {
            base.Initialize();

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
        // Get "metadata" bytes from ST file
        //
        static public byte[] STmetadata(byte[] fileBytes)
        {
            byte[] metaBytes = new byte[0x22];

            string textureName = "";
            for (int i = 0x40; fileBytes[i] != 0; i++)
            {
                textureName += (char)fileBytes[i];
            }

            byte[] extraBytes = {
                    fileBytes[0x08],
                    fileBytes[0x1C],
                    fileBytes[0x3C] };

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(Encoding.ASCII.GetBytes(textureName), 0, Encoding.ASCII.GetBytes(textureName).Length);
                ms.Write(new byte[32 - Encoding.ASCII.GetBytes(textureName).Length], 0, 32 - Encoding.ASCII.GetBytes(textureName).Length);
                ms.Write(extraBytes, 0, extraBytes.Length);
                metaBytes = ms.ToArray();
            }

            return metaBytes;
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

            int dxt_version = fileBytes[0x1C] > 0 ? 5 : 1;

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

                    ms.Write(BitConverter.GetBytes(124), 0, 4); // dwSize
                    ms.Write(BitConverter.GetBytes(0x081007), 0, 4); // dwFlags

                    ms.Write(BitConverter.GetBytes(height), 0, 4); // dwHeight
                    ms.Write(BitConverter.GetBytes(width), 0, 4); // dwWidth

                    ms.Write(BitConverter.GetBytes(width == height ? 0x4000 : 0x2000), 0, 4); // dwPitchOrLinearSize

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

                    ms.Write(Encoding.ASCII.GetBytes("DXT" + dxt_version), 0, 4);
                    ms.Write(nullBytes, 0, 20);

                    ms.Write(BitConverter.GetBytes(0x1000), 0, 4); // dwCaps
                    ms.Write(BitConverter.GetBytes(0), 0, 4); // dwCaps2
                    ms.Write(BitConverter.GetBytes(0), 0, 4); // dwCaps3
                    ms.Write(BitConverter.GetBytes(0), 0, 4); // dwCaps4
                    ms.Write(BitConverter.GetBytes(0), 0, 4); // dwReserved2
                }

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
