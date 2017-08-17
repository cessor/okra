using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Okra.View.Input;
using Okra.View.Wheel.Arc;
using Okra.View.Wheel.ColorPalette;
using Okra.View.Wheel.Extensions;

namespace Okra.View.Clock
{
    public interface IClock
    {
        Brush Color { get; }
        void ShowDialogAt(CurrentMousePosition position);
    }

    public partial class Clock : IClock
    { 
    
        public Clock()
        {
            InitializeComponent();
        }

        public Brush Color { get; private set; }
        
        public void ShowDialogAt(CurrentMousePosition position)
        {
            SetPosition(position.X, position.Y);
            Draw();

            ShowDialog();
        }

        private void SetPosition(int x, int y)
        {
            Left = x - Width/2;
            Top = y - Height/2;
        }

        private void SelectColor(object sender, MouseEventArgs e)
        {
            Color = ((Path) sender).Fill;
            Hide();
        }

        private void Draw()
        {
            var arc = new SegmentArc(Palette.Rainbow, this.Center(), Canvas, 125, new Style {Stroke = Brushes.White});

            Action<Path, object> modifySlice = (slice, data) =>
            {
                var color = (SolidColorBrush) data;
                slice.Fill = color;
                slice.Tag = data;
                slice.MouseUp += SelectColor;
                slice.MouseEnter += (s, e) => arc.Plate.Fill = slice.Fill;
            };

            arc.ModifySlice += modifySlice;
            arc.Draw();
            arc.Plate.MouseUp += SelectColor;
        }
    }
}