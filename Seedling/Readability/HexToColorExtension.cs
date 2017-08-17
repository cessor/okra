using System.Windows.Media;

namespace Seedling.Readability
{
    /// <summary>
    ///     Converts an integer into A System.Windows.Media._color Value.
    ///     If you format the integer like as a hex number you can increase the readability of your code!
    /// </summary>
    internal static class HexToColorExtension
    {
        public static Color Rgb(this int hex)
        {
            return Color.FromRgb((byte) (hex >> 16), (byte) (hex >> 8), (byte) (hex >> 0));
        }

        public static Color Argb(this uint hex)
        {
            // 0x FF 00 AA DD -- Alpha, Red, Green, Blue
            // The alpha value defines transparency
            return Color.FromArgb((byte) (hex >> 24), (byte) (hex >> 16), (byte) (hex >> 8), (byte) (hex >> 0));
        }

        public static Color Argb(this int hex)
        {
            // 0x FF 00 AA DD -- Alpha, Red, Green, Blue
            // The alpha value defines transparency
            return Color.FromArgb((byte) (hex >> 24), (byte) (hex >> 16), (byte) (hex >> 8), (byte) (hex >> 0));
        }

        public static int Hex(this Color color)
        {
            return (color.R << 16) | (color.G << 8) | (color.B << 0);
        }
    }
}