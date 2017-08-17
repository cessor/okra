using Okra.Commands.Timer;
using Okra.View.Keyboard;

namespace Okra.Commands.App
{
    public class ShowKeymap : Plugin
    {
        public ShowKeymap()
        {
            Name = "Keyboard";
            Description = "Displays an overview of all keyboard shortcuts.";
        }

        public override void Select()
        {
            new Keyboard(Clock.Color).Show();
        }
    }
}