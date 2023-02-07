using System;
using System.Text;

namespace GettingUpTool
{
    class FileAnalysis
    {
        private static string StringFromByteArray(byte[] array, int index, int length)
        {
            return Encoding.ASCII.GetString(array, index, length).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?');
        }

        public static string AnalyzeST(byte[] fileBytes)
        {
            string debugLog = string.Empty;
            int i = 0;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{StringFromByteArray(fileBytes, i, 4)}";
            // debugLog += $"\t{Convert.ToChar(fileBytes[0])}";
            // debugLog += $"{Convert.ToChar(fileBytes[1])}";
            // debugLog += $"{Convert.ToChar(fileBytes[2])}";
            // debugLog += $"{Convert.ToChar(fileBytes[3])}";
            debugLog += $"\tST header";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tWidth";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tHeight";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tWidth";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tHeight";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tAlpha?";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t0";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t1";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t1";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t1";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tDDS size";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tTexture data offset?";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tCompression?";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 32).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            // debugLog += $"\tFilename";
            debugLog += Environment.NewLine;
            i += 32;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t2";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t0x0A";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tDDS size";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tBit output?";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tDDS size 2";
            debugLog += Environment.NewLine;
            i += 4;

            for (int n = 0; n < 0x70; n += 4)
            {
                debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
                debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
                debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
                // debugLog += $"\t{Convert.ToChar(fileBytes[i + 0])}{Convert.ToChar(fileBytes[i + 1])}{Convert.ToChar(fileBytes[i + 2])}{Convert.ToChar(fileBytes[i + 3])}";
                debugLog += Environment.NewLine;
                i += 4; // 0x70;
            }

            // 0104
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            // debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tBIR header";
            debugLog += Environment.NewLine;
            i += 4;

            for (int n = 0; n < 0x7C; n += 4)
            {
                debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
                debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
                debugLog += Environment.NewLine;
                i += 4;
            }

            // 0184
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\tTexture data {fileBytes.Length - i} bytes";
            debugLog += Environment.NewLine;
            i += 4;

            return debugLog;
        }

        public static string AnalyzeST2(byte[] fileBytes)
        {
            string debugLog = string.Empty;
            int i = 0;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{StringFromByteArray(fileBytes, i, 4)}";
            // debugLog += $"\t{Convert.ToChar(fileBytes[0])}";
            // debugLog += $"{Convert.ToChar(fileBytes[1])}";
            // debugLog += $"{Convert.ToChar(fileBytes[2])}";
            // debugLog += $"{Convert.ToChar(fileBytes[3])}";
            debugLog += $"\tHeader";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tWidth";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tHeight";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tWidth";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tHeight";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tAlpha?";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t0";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t1";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t1";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t0";
            debugLog += Environment.NewLine;
            i += 4;

            // 0030
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t1";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tDDS size";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tTexture data offset?";
            debugLog += Environment.NewLine;
            i += 4;

            // 003C
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            // 0040 Filename
            debugLog += $"{i:X4}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 32).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += Environment.NewLine;
            i += 32;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t2";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t10";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tDDS size";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tBit output?";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tBIR size";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tDDS size 2";
            debugLog += Environment.NewLine;
            i += 4;

            // 0094
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += Environment.NewLine;
            i += 4;

            // 00A4 BIR header
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += $"\tBIR/DDS header";
            debugLog += Environment.NewLine;
            i += 4;
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += Environment.NewLine;
            i += 4;
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += Environment.NewLine;
            i += 4;
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t{Encoding.ASCII.GetString(fileBytes, i, 4).Replace('\0', ' ').Replace('\t', '?').Replace('\r', '?').Replace('\n', '?')}";
            debugLog += Environment.NewLine;
            i += 4;

            // 00B4
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\tTexture data {fileBytes.Length - i} bytes";
            debugLog += Environment.NewLine;
            i += 4;

            return debugLog;
        }

        public static string AnalyzeDDS(byte[] fileBytes)
        {
            string debugLog = string.Empty;
            int i = 0;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{StringFromByteArray(fileBytes, i, 4)}";
            debugLog += $"\tHeader";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwSize";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwFlags";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwHeight";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwWidth";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwPitchOrLinearSize";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwDepth";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwMipMapCount";
            debugLog += Environment.NewLine;
            i += 4;

            // 0020
            for (int n = 0; n < 0x2C; n += 4)
            {
                debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
                debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
                debugLog += $"\tdwReserved1[{n / 4}]";
                debugLog += Environment.NewLine;
                i += 4;
            }

            // 004C
            debugLog += $". DDS_PIXELFORMAT" + Environment.NewLine;

            debugLog += $"| {i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwSize";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"| {i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwFlags";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"| {i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            // debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\t{StringFromByteArray(fileBytes, i, 4)}";
            debugLog += $"\tdwFourCC";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"| {i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwRGBBitCount";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"| {i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwRBitMask";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"| {i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwGBitMask";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"| {i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwBBitMask";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $"' {i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwABitMask";
            debugLog += Environment.NewLine;
            i += 4;

            // 006C
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwCaps";
            debugLog += Environment.NewLine;
            i += 4;
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwCaps2";
            debugLog += Environment.NewLine;
            i += 4;
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwCaps3";
            debugLog += Environment.NewLine;
            i += 4;
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwCaps4";
            debugLog += Environment.NewLine;
            i += 4;

            // 007C
            debugLog += $"{i:X4}\t{fileBytes[i + 0]:X2} {fileBytes[i + 1]:X2} {fileBytes[i + 2]:X2} {fileBytes[i + 3]:X2}";
            debugLog += $"\t{BitConverter.ToInt32(fileBytes, i)}";
            debugLog += $"\tdwReserved2";
            debugLog += Environment.NewLine;
            i += 4;

            debugLog += $". Texture data {fileBytes.Length - i} bytes";

            return debugLog;
        }
    }
}
