namespace Okra.Commands.Power.Win32Api
{
    public interface IWindowsFunctions
    {
        bool ExitWindows(uint uFlags, uint dwReason);
        bool LockComputer();
        bool Suspend(bool hibernate, bool forceCritical, bool disableWakeEvent);
    }
}