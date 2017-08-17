using Okra.Commands.Power.Win32Api;

namespace Okra.Commands.Power
{
    public class Shutdown : PowerCommand
    {
        public Shutdown(IWindowsFunctions windows) : base(windows)
        {
        }

        public void Execute(object parameter)
        {
            const uint flags = (uint) (ExitWindowsFlags.ShutDown | ExitWindowsFlags.Force);
            Exit(flags);
        }
    }
}