using System.Windows;
using Seedling.Commands.Timer;

namespace Seedling.Commands.UI
{
    internal class FullScreen : Plugin
    {
        public FullScreen()
        {
            Name = "Fullscreen";
            Description = "Make it BIG!";
            AddShortCut("F11");
        }

        public override void Select()
        {
            double numberOfCharacters = (SystemParameters.PrimaryScreenWidth/3);
            double fontsize = (numberOfCharacters*72)/96;
            Clock.FontSize = fontsize;
        }
    }
}