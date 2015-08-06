namespace GettingUpTool.Textures
{
    internal static class DXTEncoder
    {
        public static byte[] EncodeDXT1(byte[] data, int width, int height)
        {
            var dataSize = (width / 4) * (height / 4) * 8;
            var outData = new byte[dataSize];
            Squish.CompressImage(data, (uint)width, (uint)height, outData, (int)Squish.Flags.DXT1);

            return outData;
        }

        public static byte[] EncodeDXT3(byte[] data, int width, int height)
        {
            var dataSize = (width / 4) * (height / 4) * 16;
            var outData = new byte[dataSize];
            Squish.CompressImage(data, (uint)width, (uint)height, outData, (int)Squish.Flags.DXT3);

            return outData;
        }

        public static byte[] EncodeDXT5(byte[] data, int width, int height)
        {
            var dataSize = (width / 4) * (height / 4) * 16;
            var outData = new byte[dataSize];
            Squish.CompressImage(data, (uint)width, (uint)height, outData, (int)Squish.Flags.DXT5);

            return outData;
        }
    }
}
