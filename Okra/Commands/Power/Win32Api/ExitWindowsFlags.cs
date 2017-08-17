using System;

namespace Okra.Commands.Power.Win32Api
{
    [Flags]
    internal enum ExitWindowsFlags : uint
    {
        LogOff = 0x00,
        ShutDown = 0x01,
        Reboot = 0x02,
        Force = 0x04,
        PowerOff = 0x08,

        ForceIfHung = 0x10,
        RestartApps = 0x40,
    }
}