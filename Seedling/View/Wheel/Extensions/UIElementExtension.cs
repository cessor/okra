using System;
using System.Windows;

namespace Seedling.View.Wheel.Extensions
{
    public static class UIElementExtension
    {
        public static Point Center(this FrameworkElement element)
        {
            double width = Math.Max(element.ActualWidth, element.Width);
            double height = Math.Max(element.ActualHeight, element.Height);
            return new Point(width/2.0, height/2.0);
        }
    }
}