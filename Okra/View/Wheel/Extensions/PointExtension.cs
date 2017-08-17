using System.Windows;

namespace Okra.View.Wheel.Extensions
{
    public static class PointExtension
    {
        public static Point Scale(this Point point, double scale)
        {
            return Multiply(point, scale);
        }

        public static Point Scale(this Point point, int scale)
        {
            return Multiply(point, scale);
        }

        private static Point Multiply(Point p, double scale)
        {
            return new Point(p.X*scale, p.Y*scale);
        }
    }
}