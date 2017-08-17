using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Okra.Model;
using Okra.Readability;

namespace Okra.View.Digits
{
    public partial class Display
    {
        private readonly CircularTimeSpan _circularTimeSpan;
        private readonly IClock _viewmodel;

        public Display(IClock viewmodel, IEnumerable<KeyBinding> keybindings)
        {
            _viewmodel = viewmodel;
            DataContext = _viewmodel;
            InitializeComponent();
            InputBindings.AddRange(keybindings.ToList());
            _circularTimeSpan = new CircularTimeSpan();
        }

        private void WhenTheMouseIsDownOnTheLabel(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.Dispatch(DragMove);
            }
        }

        // TODO: Can this become a command of some kind? - JH, Ages Ago.  17.12.2012
        // TODO: Can this become a command of some kind? - JH, Ages Ago.  17.08.2017
        private void WhenAKeyWasPressed(object sender, KeyEventArgs pressed)
        {
            if (pressed.Key.IsDigit())
            { 
                AppendToTheTimeLeft(pressed.Key.Digit());
            }
        }

        private void AppendToTheTimeLeft(byte digit)
        {
            _circularTimeSpan.Add(digit);
            _viewmodel.SetTo(_circularTimeSpan.ToTimeSpan());
        }
    }
}