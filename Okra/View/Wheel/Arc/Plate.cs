using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Okra.View.Wheel.Arc
{
    internal class Plate
    {
        public Plate(Point center, double radius, Style style)
        {
            Label = PlateLabel.Make(center, radius, style);
            Disk = PlateDisk.Make(center, radius/2.0, style);
        }

        public Label Label { get; private set; }
        public Path Disk { get; private set; }

        private static class PlateDisk
        {
            public static Path Make(Point center, double radius, Style style)
            {
                var path = new Path
                {
                    Fill = style.Fill,
                    Stroke = style.Stroke,
                    StrokeThickness = style.StrokeThickness,
                    Data = new EllipseGeometry(center, radius, radius)
                };
                return path;
            }
        }

        private static class PlateLabel
        {
            public static Label Make(Point center, double radius, Style style)
            {
                Label label = Create(style);
                PositionAt(center, radius, label);
                return label;
            }

            private static Label Create(Style style)
            {
                var label = new Label
                {
                    FontFamily = new FontFamily("Cambria"),
                    Foreground = style.Stroke,
                    FontSize = 48.0,
                    FontStyle = FontStyles.Italic,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };
                return label;
            }

            private static void PositionAt(Point center, double radius, FrameworkElement label)
            {
                Point dimensions = Circle.Point(40, radius);
                label.Height = dimensions.Y;
                label.Width = dimensions.X;
                label.SetValue(Canvas.TopProperty, center.Y - label.Height/2.0);
                label.SetValue(Canvas.LeftProperty, center.X - label.Width/2.0);
                label.SetValue(Panel.ZIndexProperty, 1000);
            }
        }
    }
}