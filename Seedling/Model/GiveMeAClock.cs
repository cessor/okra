using Seedling.Readability;
using Seedling.Model.Time;
using Seedling.View.Digits;

namespace Seedling.Model
{
    internal static class GiveMeAClock
    {
        public static IClock ForTheCurrentConfig()
        {
#if DEBUG
            return Debug();
#endif
#pragma warning disable 162 // Disable Warning
            return Release();
#pragma warning restore 162
        }

        private static IClock Release()
        {
            return new Clock(new Countdown(), new Wristwatch(), 25.Minutes())
            {
                Color = 0x00DB00.Rgb().Brush(),
                FontSize = 100d
            };
        }

        private static IClock Debug()
        {
            return new Clock(new Countdown(), new Wristwatch(), 1.Second())
            {
                Color = 0xFF00FF.Rgb().Brush(),
                FontSize = 100d
            };
        }
    }
}