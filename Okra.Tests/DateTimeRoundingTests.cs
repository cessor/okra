using System;
using DateApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Okra.Tests.Actions
{
    [TestClass]
    public class DateTimeRoundingTests
    {
        [TestMethod]
        public void ShouldStripMilisecondsFromATimespan()
        {           
            var someMiliseconds = TimeSpan.FromTicks((long) (2.000234*TimeSpan.TicksPerMillisecond));
            var anUnevenValue = 3.Second() - someMiliseconds;

            // Act
            anUnevenValue = anUnevenValue.ToTheSecond();

            // Assert
            Assert.AreEqual(2.Seconds(), anUnevenValue);
        }
    }
}