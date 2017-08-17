using System.ComponentModel;
using Seedling.Commands.Power.Win32Api;

namespace Seedling.Commands.Power
{
    [Description("Closes the current user's session")]
    public class LogOff : PowerCommand
    {
        public LogOff(IWindowsFunctions windows) : base(windows)
        {
        }

        public void Execute(object parameter)
        {
            const uint flags = (uint) (ExitWindowsFlags.LogOff | ExitWindowsFlags.Force);
            Exit(flags);
        }
    }
}