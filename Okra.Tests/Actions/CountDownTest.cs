using System;
using DateApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Okra.Tests.Actions
{
    [TestClass]
    public class CountDownTest
    {
        [TestMethod]
        public void ShouldDoASetOfOperations()
        {
            DateTime start = 23.February(2011).AtNoon();
            TimeSpan duration = 25.Minutes();

            DateTime now = 23.February(2011).AtNoon() + 15.Minutes();

            TimeSpan timeleft = TimeLeft(start, duration, now);

            Assert.AreEqual(10.Minutes(), timeleft);

            //var timeLeft = _duration - (_clock.Now - _start);
            //return timeLeft - TimeSpan.FromMilliseconds((timeLeft.Ticks % TimeSpan.TicksPerMillisecond));
        }

        [TestMethod]
        public void ShouldDoASetOfOperations2()
        {
            DateTime start = 23.February(2011).AtNoon();
            TimeSpan duration = 25.Minutes();

            DateTime now = 23.February(2011).AtNoon() + 15.Minutes() + TimeSpan.FromMilliseconds(345);

            TimeSpan timeleft = TimeLeft(start, duration, now);

            Assert.AreEqual(9.Minutes().And(59.Seconds()), timeleft);
        }

        [TestMethod]
        public void ShouldShit()
        {
            TimeSpan x = 1.Minute() + TimeSpan.FromMilliseconds(56);
            Assert.AreEqual(56, x.Milliseconds);
            Console.WriteLine(x.Milliseconds%TimeSpan.TicksPerMillisecond);
        }

        // TODO: Proper TDD, you lazy piece of *
        private TimeSpan TimeLeft(DateTime start, TimeSpan duration, DateTime now)
        {
            TimeSpan timeLeft = duration - (now - start);
            return TimeSpan.FromTicks(timeLeft.Ticks - (timeLeft.Ticks%TimeSpan.TicksPerSecond));
        }
    }
}