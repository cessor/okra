using System;
using DateApi;
using NUnit.Framework;
using Seedling.Model;
using Should.Fluent;

namespace Seedling.Tests.DateAndTime
{
    [TestFixture]
    public class CircularTimespanTests
    {
        [Test]
        public void ShouldDoASetOfOperations()
        {
            // Arange, Act, Assert
            TimeSpan time = new CircularTimeSpan().Add(1).Add(3).Add(0).ToTimeSpan();

            time.Should().Equal(1.Minutes().And(30.Seconds()));
        }
    }
}