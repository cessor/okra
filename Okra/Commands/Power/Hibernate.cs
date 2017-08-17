using System.ComponentModel;
using Okra.Commands.Power.Win32Api;

namespace Okra.Commands.Power
{
    [Description("Sends the computer to hibernation (Suspend to Disc).")]
    public class Hibernate : PowerCommand
    {
        public Hibernate(IWindowsFunctions windows) : base(windows)
        {
        }

        public void Execute(object parameter)
        {
            const bool hibernate = true;
            const bool forceCritical = false;
            const bool disableWakeEvent = false;
            Windows.Suspend(hibernate, forceCritical, disableWakeEvent);
        }
    }
}