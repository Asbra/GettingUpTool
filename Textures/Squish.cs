using System.Runtime.InteropServices;

namespace GettingUpTool.Textures
{
    internal class Squish
    {
        [DllImport("libsquish.dll", EntryPoint = "CompressImage")]
        public static extern void CompressImage([MarshalAs(UnmanagedType.LPArray)] byte[] rgba, uint width, uint height, [MarshalAs(UnmanagedType.LPArray)] byte[] blocks, int flags);

        public enum Flags
        {
            DXT1 = 1 << 0,
            DXT3 = 1 << 1,
            DXT5 = 1 << 2,

            ColourIterativeClusterFit = 1 << 8,
            ColourClusterFit = 1 << 3,              // Default
            ColourRangeFit = 1 << 4,

            ColourMetricPerceptual = 1 << 5,        // Default
            ColourMetricUniform = 1 << 6,

            WeightColourByAlpha = 1 << 7,           // Disabled by Default
        }
    }
}