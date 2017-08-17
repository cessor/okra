using System.Runtime.InteropServices;

namespace Okra.View.Input
{
    public class CurrentMousePosition
    {
        internal CurrentMousePosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public CurrentMousePosition()
        {
            Pt pt;
            GetCursorPos(out pt);
            X = pt.x;
            Y = pt.y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Pt lpPoint);

        #region Nested type: Pt

        [StructLayout(LayoutKind.Sequential)]
        private struct Pt
        {
            internal readonly int x;
            internal readonly int y;
        }

        #endregion
    }
}