using System.ComponentModel;
using Seedling.Commands.Power.Win32Api;

namespace Seedling.Commands.Power
{
    [Description("Reboots the computer")]
    public class Restart : PowerCommand
    {
        public Restart(IWindowsFunctions windows) : base(windows)
        {
        }

        public void Execute(object parameter)
        {
            const uint flags = (uint) (ExitWindowsFlags.Reboot | ExitWindowsFlags.Force);
            Exit(flags);
        }
    }
}