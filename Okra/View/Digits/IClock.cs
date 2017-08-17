using System;
using System.Windows.Media;

namespace Okra.View.Digits
{
    // TODO: This interface is way too big! 05.10.2012
    public interface IClock
    {
        double FontSize { get; set; }
        Brush Color { get; set; }

        TimeSpan Duration { get; }
        bool IsRunning { get; }
        Action Done { get; set; }
        TimeSpan TimeLeft { get; }

        void StartCounter();
        void StopCounter();
        void SetTo(TimeSpan time);
    }
}