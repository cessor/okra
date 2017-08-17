using System.Windows;
using Seedling.Commands.Timer;
using Seedling.View;

namespace Seedling.Commands.TimerActions
{
    internal class DisplayMessage : Plugin
    {
        private string _message;

        public DisplayMessage()
        {
            Name = "Display message";
            Description = "Display a custom message after the timer elapsed.";
            AddShortCut("m");
        }

        public override void Select()
        {
            var messageBox = new AskForAMessage
            {
                Foreground = Clock.Color
            };

            if (messageBox.ShowDialog() ?? false)
            {
                _message = messageBox.Message;
            }
            Clock.Done = Done;
        }


        public void Done()
        {
            MessageBox.Show(_message, "Tick!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}