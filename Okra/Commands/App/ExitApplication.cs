using System.Windows;
using Okra.Commands.Timer;
using Okra.Readability;

namespace Okra.Commands.App
{
    internal class ExitApplication : Plugin
    {
        public ExitApplication()
        {
            Name = "Exit";
            Description = "Closes the Application";
            AddShortCut("Escape");
            AddShortCut("Control+X");
        }

        public override void Select()
        {
            Application.Current.Dispatch(Application.Current.Shutdown);
        }
    }
}