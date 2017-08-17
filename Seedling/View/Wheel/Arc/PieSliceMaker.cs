using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Seedling.View.Wheel.Arc
{
    internal class PieSliceMaker
    {
        /// <summary>
        ///     Creates a new slice of a pie.
        ///     A-------B
        ///     \     )
        ///     \   )
        ///     \ )
        ///     C
        /// </summary>
        /// <param name="center">The center of the slice (A)</param>
        /// <param name="start">The start of the arc (B)</param>
        /// <param name="end">The end of the arc (C)</param>
        /// <returns>A <see cref="Path" /> object that can be drawn on a canvas.</returns>
        public static Path Make(Point center, Point start, Point end)
        {
            double radius = Circle.DistanceToCenter(start);
            PathGeometry slice = Slice(start, end, radius);
            CenterAndRotate(slice, center);
            var path = new Path {Data = slice};
            return path;
        }

        private static PathGeometry Slice(Point start, Point end, double radius)
        {
            var line = new LineSegment
            {
                Point = start
            };
            var curve = new ArcSegment
            {
                IsLargeArc = false,
                Size = new Size(radius, radius),
                SweepDirection = SweepDirection.Clockwise,
                RotationAngle = 0,
                Point = end
            };

            var figure = new PathFigure
            {
                IsClosed = true
            };
            figure.Segments.Add(line);
            figure.Segments.Add(curve);
            var geometry = new PathGeometry();
            geometry.Figures.Add(figure);
            return geometry;
        }

        private static void CenterAndRotate(PathGeometry slice, Point center)
        {
            var transforms = new TransformGroup();
            transforms.Children.Add(new TranslateTransform(center.X, center.Y));
            transforms.Children.Add(new RotateTransform(-90, center.X, center.Y));
            slice.Transform = transforms;
        }
    }
}