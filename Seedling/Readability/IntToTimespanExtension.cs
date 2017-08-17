using System;

// This could be replaced with the dateapi, but I would like to keep
// The final assembly a single EXE file without having to compile
// the api into the EXE

namespace Seedling.Readability
{
    internal static class IntToTimespanExtension
    {
        public static DateTime ToTheSecond(this DateTime date)
        {
            return date.AddMilliseconds(-date.Millisecond);
        }

        public static TimeSpan ToTheSecond(this TimeSpan time)
        {
            return TimeSpan.FromTicks(time.Ticks - time.Ticks%TimeSpan.TicksPerSecond);
        }

        public static TimeSpan Minutes(this int minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        public static TimeSpan Second(this int seconds)
        {
            return seconds.Seconds();
        }

        public static TimeSpan Seconds(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }
    }
}