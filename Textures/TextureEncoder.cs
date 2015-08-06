using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
/*
namespace GettingUpTool.Textures
{
    internal class TextureEncoder
    {
        internal static void Encode(Texture texture, Image image, int level)
        {
            var width = texture.GetWidth(level);
            var height = texture.GetHeight(level);
            var data = new byte[width * height * 4];  // R G B A

            var bitmap = new Bitmap((int)width, (int)height);

            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImage(image, 0, 0, (int)width, (int)height);
            g.Dispose();

            var rect = new Rectangle(0, 0, (int)width, (int)height);
            BitmapData bmpdata = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            if (texture.TextureType == TextureType.A8R8G8B8)
            {
                Marshal.Copy(bmpdata.Scan0, data, 0, (int)width * (int)height * 4);
            }
            else
            {
                // Convert from the B G R A format stored by GDI+ to R G B A
                unsafe
                {
                    var p = (byte*)bmpdata.Scan0;
                    for (var y = 0; y < bitmap.Height; y++)
                    {
                        for (var x = 0; x < bitmap.Width; x++)
                        {
                            var offset = y * bmpdata.Stride + x * 4;
                            var dataOffset = y * width * 4 + x * 4;
                            data[dataOffset + 0] = p[offset + 2];       // R
                            data[dataOffset + 1] = p[offset + 1];       // G
                            data[dataOffset + 2] = p[offset + 0];       // B
                            data[dataOffset + 3] = p[offset + 3];       // A
                        }
                    }
                }
            }

            bitmap.UnlockBits(bmpdata);

            bitmap.Dispose();

            switch (texture.TextureType)
            {
                case TextureType.DXT1:
                    data = DXTEncoder.EncodeDXT1(data, (int)width, (int)height);
                    break;
                case TextureType.DXT3:
                    data = DXTEncoder.EncodeDXT3(data, (int)width, (int)height);
                    break;
                case TextureType.DXT5:
                    data = DXTEncoder.EncodeDXT5(data, (int)width, (int)height);
                    break;
                case TextureType.A8R8G8B8:
                    // Nothing to do
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            texture.SetTextureData(level, data);
        }
    }
}
*/