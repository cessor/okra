using System.Windows.Media;

namespace Okra.Readability
{
    internal static class ColorToBrushExtension
    {
        // It is probably not smart to create a new brush and the application resources should be used instead.
        public static Brush Brush(this Color color)
        {
            return new SolidColorBrush(color);
        }
    }
}