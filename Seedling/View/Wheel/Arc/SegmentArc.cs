using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Seedling.View.Wheel.Arc
{
    /// <summary>
    ///     This is a circular arc, that shows individual segments.
    ///     The overall arc is circle shaped and has a plate in the middle.
    ///     It can also display some (short) text in its center.
    /// </summary>
    public class SegmentArc
    {
        /// <summary>
        ///     Creates a segmented circular arc.
        ///     The number of segments is determined by the number of elements in the <see cref="data" /> collection passed.
        ///     Each slice can be modified depending on its data by using the <see cref="ModifySlice" /> events.
        /// </summary>
        /// <param name="data">
        ///     A collection of objects. The size of the collection (the number of elements in it) will determine how many segments
        ///     you get.
        ///     Each object will be attached to a corresponding slice.
        ///     You can decide what the slice should do with the data by registring a function to the <see cref="ModifySlice" />
        ///     event.
        /// </param>
        /// <param name="center">The center location of the circle on the canvas.</param>
        /// <param name="canvas">The canvas that this arc will be drawn to</param>
        /// <param name="radius">The radius of the complete circle</param>
        /// <param name="style">
        ///     A <see cref="Style" /> object containing the colors of the path segments and the plate (Fill and
        ///     Stroke, StrokeThickness)
        /// </param>
        public SegmentArc(IEnumerable<object> data, Point center, Canvas canvas, int radius, Style style)
        {
            Center = center;
            Canvas = canvas;
            Radius = radius;
            Style = style;
            Data = data;

            Plate = new Path();
            Label = new Label();
        }

        public int Radius { get; private set; }
        public Style Style { get; private set; }
        public Canvas Canvas { get; private set; }
        public Path Plate { get; private set; }
        public Point Center { get; private set; }
        public Label Label { get; private set; }
        public IEnumerable<object> Data { get; private set; }
        public List<Path> Segments { get; private set; }

        /// <summary>
        ///     This event is fired whenever a slice (segment) of the arc is being created, allowing you to access its path and
        ///     corresponding data,
        ///     so that you can modify its design and behavior.
        /// </summary>
        public event Action<Path, object> ModifySlice;

        private void OnModifySlice(Path slicePath)
        {
            Action<Path, object> handler = ModifySlice;
            if (handler != null) handler(slicePath, slicePath.Tag);
        }

        /// <summary>
        ///     Draws the circle to the specified canvas.
        /// </summary>
        public void Draw()
        {
            DrawSlices();
            DrawPlate();
        }

        private void DrawSlices()
        {
            Segments = CreateSlices(Center, Radius, Data, Style).ToList();
            foreach (Path segment in Segments)
            {
                Canvas.Children.Add(segment);
            }
        }

        private IEnumerable<Path> CreateSlices(Point center, int radius, IEnumerable<object> items, Style style)
        {
            // Although this could be done with map & zip, 
            // I found it easier to simultaneously access three lists at once using this simple for loop.
            // You can give it a shot, if you want. - JH, 18.12.2013
            object[] data = items.ToArray();
            int numberOfSegments = data.Length;
            List<Point> points = Circle.Segments(numberOfSegments, radius).ToList();
            points.Add(points.First());
            for (int i = 0; i < numberOfSegments; i++)
            {
                Point start = points[i];
                Point end = points[i + 1];
                Path slice = PieSliceMaker.Make(center, start, end);
                slice.Tag = data[i];
                style.ApplyTo(slice);
                OnModifySlice(slice);
                yield return slice;
            }
        }

        private void DrawPlate()
        {
            var plate = new Plate(Center, Radius, Style);
            Plate = plate.Disk;
            Label = plate.Label;
            Canvas.Children.Add(Plate);
            Canvas.Children.Add(Label);
        }

        /// <summary>
        ///     Redraw the circle with new <see cref="data" />.
        /// </summary>
        /// <param name="data">The items to determine the amount of segments, as well as the item attached to each of them.</param>
        public void Update(IEnumerable<object> data)
        {
            Canvas.Children.Clear();
            Data = data;
            Draw();
        }

        /// <summary>
        ///     Changes the text to display in the center plate of the arc.
        /// </summary>
        /// <param name="message">The text to display</param>
        public void Text(string message)
        {
            Label.Content = message;
        }
    }
}