using System.Windows.Media;

namespace Okra.View.Wheel.Extensions
{
    public static class ColorBrightnessExtension
    {
        public static Color Dark(this Color color)
        {
            return color.ChangeColorBrightness(-0.1f);
        }

        public static Color Darker(this Color color)
        {
            return color.ChangeColorBrightness(-0.5f);
        }

        public static Color Bright(this Color color)
        {
            return color.ChangeColorBrightness(+0.1f);
        }

        public static Color Brighter(this Color color)
        {
            return color.ChangeColorBrightness(+0.5f);
        }

        /// <summary>
        ///     Creates color with corrected brightness.
        /// </summary>
        /// <param name="color">_color to correct.</param>
        /// <param name="correctionFactor">
        ///     The brightness correction factor. Must be between -1 and 1.
        ///     Negative values produce darker colors.
        /// </param>
        /// <returns>
        ///     Corrected <see cref="Color" /> structure.
        ///     Source: http://www.pvladov.com/2012/09/make-color-lighter-or-darker.html
        /// </returns>
        public static Color ChangeColorBrightness(this Color color, float correctionFactor)
        {
            float red = color.R;
            float green = color.G;
            float blue = color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red)*correctionFactor + red;
                green = (255 - green)*correctionFactor + green;
                blue = (255 - blue)*correctionFactor + blue;
            }
            return Color.FromArgb(color.A, (byte) red, (byte) green, (byte) blue);
        }
    }
}