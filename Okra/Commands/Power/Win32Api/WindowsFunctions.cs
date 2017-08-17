using System.Runtime.InteropServices;

namespace Okra.Commands.Power.Win32Api
{
    internal class WindowsFunctions : IWindowsFunctions
    {
        #region IWindowsFunctions Members

        public bool ExitWindows(uint uFlags, uint dwReason)
        {
            return ExitWindowsEx(uFlags, dwReason);
        }

        public bool LockComputer()
        {
            return LockWorkStation();
        }

        public bool Suspend(bool hibernate, bool forceCritical, bool disableWakeEvent)
        {
            return SetSuspendState(hibernate, forceCritical, disableWakeEvent);
        }

        #endregion

        // http://pinvoke.net/default.aspx/user32.ExitWindowsEx

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool LockWorkStation();

        [DllImport("Powrprof.dll", SetLastError = true)]
        private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);
    }
}