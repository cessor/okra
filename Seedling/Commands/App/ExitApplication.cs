using System.Windows;
using Seedling.Readability;
using Seedling.Commands.Timer;

namespace Seedling.Commands.App
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