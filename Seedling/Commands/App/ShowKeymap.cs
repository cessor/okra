using Seedling.Commands.Timer;
using Seedling.View.Keyboard;

namespace Seedling.Commands.App
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