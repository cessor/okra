using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Seedling.View.Wheel.Extensions;

namespace Seedling.View.Wheel.Arc
{
    /// <summary>
    ///     A static class that helps with the geometry of a circle, eg. finding points on its circumference given a minute or
    ///     degree value.
    /// </summary>
    public static class Circle
    {
        public static IEnumerable<Point> Segments(int count, int radius)
        {
            return SliceUnitCircle(count).Select(point => point.Scale(radius));
        }

        private static IEnumerable<Point> SliceUnitCircle(int numberOfSlices)
        {
            return Minutes(numberOfSlices).Select(PointAtMinute);
        }

        private static IEnumerable<double> Minutes(int slices)
        {
            double sizeInMinutes = 60/(double) slices;
            return Enumerable.Range(0, slices).Select(segment => segment*sizeInMinutes);
        }

        private static Point PointAtMinute(double minute)
        {
            return PointAt(DegreeAtMinute(Radians(minute)));
        }

        private static Point PointAt(double angleInRadians)
        {
            return new Point(Math.Cos(angleInRadians), Math.Sin(angleInRadians));
        }

        private static double Radians(double angleInDegree)
        {
            return angleInDegree*(Math.PI/180);
        }

        /// <summary>
        ///     Gets the coordinates of a point at the given degrees on a circle with a certain radius.
        /// </summary>
        /// <param name="degree">The angle in degrees on the circle.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <returns></returns>
        public static Point Point(double degree, double radius)
        {
            return PointAt(Radians(degree)).Scale(radius);
        }

        private static double DegreeAtMinute(double minute)
        {
            return minute*6; // 6 Degrees per Minute = 360 / 60
        }

        public static double DistanceToCenter(Point pointOnCircle)
        {
            var center = new Point(0, 0);
            return Math.Sqrt(Math.Pow(pointOnCircle.X - center.X, 2.0) + Math.Pow(pointOnCircle.Y - center.Y, 2.0));
        }
    }
}