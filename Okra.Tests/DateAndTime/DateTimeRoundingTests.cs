using System;
using NUnit.Framework;
using Okra.Readability;

namespace Okra.Tests.DateAndTime
{
    [TestFixture]
    public class DateTimeRoundingTests
    {
        [Test]
        public void ShouldStripMilisecondsFromADateTime()
        {
            const int someMiliseconds = 354;
            var d = new DateTime(2004, 4, 14, 1, 32, 32, someMiliseconds);
            d = d.ToTheSecond();

            Assert.AreEqual(0, d.Millisecond);
        }
    }
}