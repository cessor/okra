using System.ComponentModel;
using Seedling.Commands.Power.Win32Api;

namespace Seedling.Commands.Power
{
    [Description("Locks your workstation. You are still logged on and all programs will be running")]
    public class Lock : PowerCommand
    {
        public Lock(IWindowsFunctions windows) : base(windows)
        {
        }

        public void Execute(object parameter)
        {
            Windows.LockComputer();
        }
    }
}