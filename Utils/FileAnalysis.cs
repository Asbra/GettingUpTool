using System;
using System.Text;
using static GettingUpTool.Texture;

namespace GettingUpTool
{
    class FileAnalysis
    {
        private static string StringFromByteArray(byte[] array, int index, int length)
        {
            return Encoding.ASCII.GetString(array, index, length).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?');
        }

        private static string HexLine(ref Int32 offset, ArraySegment<byte> bytes, Type type, string comment="", bool show_bytes=true)
        {
            string str = $"{offset:X4}";

            if (show_bytes == true)
                str += $"\t{bytes.Array[bytes.Offset + 0]:X2} {bytes.Array[bytes.Offset + 1]:X2} {bytes.Array[bytes.Offset + 2]:X2} {bytes.Array[bytes.Offset + 3]:X2}";

            if (type.FullName == "System.String")
                str += $"\t{StringFromByteArray(bytes.Array, bytes.Offset, bytes.Count)}";
            else if (type.FullName == "System.Int32")
                str += $"\t{BitConverter.ToInt32(bytes.Array, bytes.Offset)}";
            else
                str += "\t\t";

            if (comment != "")
                str += $"\t{comment}";
            
            str += Environment.NewLine;
            
            offset += bytes.Count;
            
            return str;
        }

        public static string AnalyzeST(byte[] fileBytes)
        {
            string debugLog = string.Empty;
            int i = 0;

            // var fileStruct = BytesToStructure<STfile>(fileBytes);

            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(string), "header ----------");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Compression");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Width");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Height");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Width2");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Height2");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Alpha bit depth");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "0");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "1 / 8");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "1 / 4");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "??");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "1");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "DDS size");
            int birOffset = 0x84 + fileBytes[i];
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Texture data offset?");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Tiling?");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 32), typeof(string), "", false);
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "2");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "10");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "DDS size 2");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Bit output?");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "DDS size 3");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "DDS size 4");
            while (i < birOffset)
                debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(string), "header ----------");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += $". Texture data {fileBytes.Length - i} bytes";

            return debugLog;
        }

        public static string AnalyzeST2(byte[] fileBytes)
        {
            string debugLog = string.Empty;
            int i = 0;

            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(string), "header ----------");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Compression");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Width");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Height");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Width2");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Height2");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Alpha bit depth");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "0");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "1");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "1");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "??");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "1");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "DDS size");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Texture data offset?");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Tiling?");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 32), typeof(string), "", false);
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "2");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "10");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "DDS size 2");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "Bit output?");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "DDS size 3");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "DDS size 4");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(string), "header ----------");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32));
            debugLog += $". Texture data {fileBytes.Length - i} bytes";

            return debugLog;
        }

        public static string AnalyzeDDS(byte[] fileBytes)
        {
            string debugLog = string.Empty;
            int i = 0;

            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(string), "Header");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwSize");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwFlags");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwHeight");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwWidth");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwPitchOrLinearSize");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwDepth");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwMipMapCount");

            for (int n = 0; n < 0x2C; n += 4)
            {
                debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), $"dwReserved[{n / 4}]");
            }

            debugLog += $". DDS_PIXELFORMAT" + Environment.NewLine;
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwSize");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwFlags");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(string), "dwFourCC");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwRGBBitCount");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwRBitMask");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwGBitMask");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwBBitMask");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwABitMask");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwCaps");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwCaps2");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwCaps3");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwCaps4");
            debugLog += HexLine(ref i, new ArraySegment<byte>(fileBytes, i, 4), typeof(Int32), "dwReserved2");
            debugLog += $". Texture data {fileBytes.Length - i} bytes";

            return debugLog;
        }
    }
}
