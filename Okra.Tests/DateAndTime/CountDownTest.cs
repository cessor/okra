using System;
using DateApi;
using NUnit.Framework;
using Should.Fluent;

namespace Okra.Tests.DateAndTime
{
    // TODO: Check whether this is actually still used - JH, 23.12.2012
    [TestFixture]
    public class CountDownTest
    {
        private TimeSpan TimeLeft(DateTime start, TimeSpan duration, DateTime now)
        {
            TimeSpan timeLeft = duration - (now - start);
            return TimeSpan.FromTicks(timeLeft.Ticks - (timeLeft.Ticks%TimeSpan.TicksPerSecond));
        }

        [Test]
        public void ShouldDoASetOfOperations()
        {
            DateTime start = 23.February(2011).AtNoon();
            TimeSpan duration = 25.Minutes();
            DateTime now = 23.February(2011).AtNoon() + 15.Minutes();
            TimeSpan timeleft = TimeLeft(start, duration, now);
            timeleft.Should().Equal(10.Minutes());
        }

        [Test]
        public void ShouldDoASetOfOperations2()
        {
            DateTime start = 23.February(2011).AtNoon();
            TimeSpan duration = 25.Minutes();
            DateTime now = 23.February(2011).AtNoon() + 15.Minutes() + TimeSpan.FromMilliseconds(345);
            TimeSpan timeleft = TimeLeft(start, duration, now);
            timeleft.Should().Equal(9.Minutes().And(59.Seconds()));
        }
    }
}