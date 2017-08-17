using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Okra.View.Input;
using Okra.View.Wheel.Arc;
using Okra.View.Wheel.Extensions;

namespace Okra.View.TimePicker
{
    public interface ITimePicker
    {
        TimeSpan Time { get; }
        void SetColor(Brush color);
        void ShowDialogAt(CurrentMousePosition position);
    }

    public partial class TimePicker : ITimePicker
    {
        private SegmentArc _arc;
        private Brush _color;
        private Brush _darker;

        public TimePicker()
        {
            InitializeComponent();
        }

        public TimeSpan Time { get; private set; }

        public void SetColor(Brush color)
        {
            _color = color;
            _darker = new SolidColorBrush(((SolidColorBrush) color).Color.Darker());
        }

        public void ShowDialogAt(CurrentMousePosition position)
        {
            SetPosition(position.X, position.Y);
            Draw();
            ShowDialog();
        }

        private void Draw()
        {
            if (_arc != null)
            {
                return;
            }
            IEnumerable<object> data = Enumerable.Range(1, 12).Select(i => (object) (i*5));
            _arc = new SegmentArc(data, this.Center(), Canvas, 125, new Style {Fill = _color, Stroke = Brushes.White});
            _arc.ModifySlice += Reg;
            _arc.Draw();
            _arc.Text("0m");
        }

        private void Reg(Path slice, object data)
        {
            slice.MouseEnter += Hover;
            slice.MouseUp += Select;
        }

        private void Select(object sender, MouseButtonEventArgs e)
        {
            Time = TimeSpan.FromMinutes((int) ((Path) sender).Tag);
            Hide();
        }

        private void Hover(object sender, MouseEventArgs e)
        {
            DisplayValue(sender);
            FillAllSegmentsUpTo(sender);
        }

        private void DisplayValue(object sender)
        {
            _arc.Text(string.Format("{0}m", ((Path) sender).Tag));
        }

        private void FillAllSegmentsUpTo(object sender)
        {
            Brush color = _darker;
            foreach (Path segment in _arc.Segments)
            {
                segment.Fill = color;
                if (Equals(segment, sender))
                {
                    color = _color;
                }
            }
        }

        private void SetPosition(int x, int y)
        {
            Left = x - Width/2;
            Top = y - Height/2;
        }
    }
}