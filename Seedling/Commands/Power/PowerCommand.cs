using Seedling.Commands.Power.Win32Api;

namespace Seedling.Commands.Power
{
    public abstract class PowerCommand
    {
        protected readonly IWindowsFunctions Windows;

        protected internal PowerCommand(IWindowsFunctions windows)
        {
            Windows = windows;
        }

        protected void Exit(uint flags)
        {
            Windows.ExitWindows(flags, Planned());
        }

        private static uint Planned()
        {
            return (uint) (ShutdownReason.MajorApplication | ShutdownReason.MinorOther | ShutdownReason.Planned);
        }
    }
}