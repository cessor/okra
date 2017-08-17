using System.Windows.Controls;
using System.Windows.Media;
using Seedling.Readability;

namespace Seedling.View.Keyboard
{
    public struct ButtonDesign
    {
        public Brush Border { get; set; }
        public Brush Background { get; set; }

        public static ButtonDesign FromColor(Color color)
        {
            return new ButtonDesign
            {
                Background = new LinearGradientBrush(color, color.Darker(), 90.0),
                Border = new SolidColorBrush(color)
            };
        }

        public void ApplyTo(Button button)
        {
            button.BorderBrush = Border;
            button.Background = Background;
        }

        public static ButtonDesign CloneFrom(Button button)
        {
            return new ButtonDesign
            {
                Border = button.BorderBrush.CloneCurrentValue(),
                Background = button.Background.CloneCurrentValue()
            };
        }
    }
}