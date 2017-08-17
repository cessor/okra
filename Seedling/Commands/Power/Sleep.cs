using Seedling.Commands.Power.Win32Api;

namespace Seedling.Commands.Power
{
    public class Sleep : PowerCommand
    {
        public Sleep(IWindowsFunctions windows) : base(windows)
        {
        }

        public void Execute(object parameter)
        {
            Windows.Suspend(false, false, false);
        }
    }
}