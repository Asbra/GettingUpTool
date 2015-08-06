namespace GettingUpTool.Textures
{
    public enum TextureType
    {
        DXT1,
        DXT3,
        DXT5,
        A8R8G8B8,
    }

    internal enum D3DFormat
    {
        DXT1 = 0x31545844,
        DXT3 = 0x33545844,
        DXT5 = 0x35545844,
        A8R8G8B8 = 0x15,
    }
}
