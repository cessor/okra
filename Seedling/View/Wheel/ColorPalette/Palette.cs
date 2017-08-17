using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Seedling.View.Wheel.Extensions;

namespace Seedling.View.Wheel.ColorPalette
{
    public static class Palette
    {
        public static readonly IEnumerable<SolidColorBrush> Rainbow = new[]
        {
            "#FF3300",
            "#FF6600",
            "#FFCC00",
            "#CCFF00",
            "#66FF00",
            "#00FF33",
            "#00FF66",
            "#00FFCC",
            "#00CCFF",
            "#0099FF",
            "#0066FF",
            "#0033FF",
            "#6600FF",
            "#CC00FF",
            "#FF00CC",
            "#FF0066"
        }.Select(AsHexColor);

        public static IEnumerable<object> MakeShades(Color baseColor)
        {
            const int slices = 24;
            const int half = slices/2;
            const float perc = (100.0f/half)/100;
            return Enumerable.Range(1, slices)
                .Select(i => (half - i) * perc)
                .Select(j => new SolidColorBrush(baseColor.ChangeColorBrightness(j)));
        }

        public static SolidColorBrush AsHexColor(string hex)
        {
            return (SolidColorBrush) (new BrushConverter().ConvertFrom(hex));
        }
    }
}