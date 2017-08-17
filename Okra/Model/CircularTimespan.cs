using System;
using System.Collections.Generic;
using System.Linq;
using Okra.Readability;

namespace Okra.Model
{
    internal class CircularTimeSpan
    {
        private readonly CircularBuffer<byte> _buffer;

        public CircularTimeSpan()
        {
            const byte digitsInATimespan = 6;
            _buffer = new CircularBuffer<byte>(digitsInATimespan);
        }

        public CircularTimeSpan Add(byte value)
        {
            _buffer.Add(value);
            return this;
        }

        public TimeSpan ToTimeSpan()
        {
            return ToTimeSpan(_buffer);
        }

        internal static TimeSpan ToTimeSpan(IEnumerable<byte> digits)
        {
            var secondsPerUnit = new[] {1, 10, 60, 600, 3600, 36000};
            return digits.Reverse().Zip(secondsPerUnit, (digit, unit) => digit*unit).Sum().Seconds();
        }
    }
}