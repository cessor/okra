using System.Windows.Media;
using System.Windows.Shapes;

namespace Okra.View.Wheel.Arc
{
    public class Style
    {
        public Style()
        {
            Stroke = Brushes.LightGray;
            Fill = Brushes.DarkGray;
            StrokeThickness = 4.0;
        }

        public Brush Fill { get; set; }
        public Brush Stroke { get; set; }
        public double StrokeThickness { get; set; }

        public Path ApplyTo(Path path)
        {
            path.Fill = Fill;
            path.Stroke = Stroke;
            path.StrokeThickness = StrokeThickness;
            return path;
        }
    }
}