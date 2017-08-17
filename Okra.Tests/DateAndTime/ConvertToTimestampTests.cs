using System;
using DateApi;
using NUnit.Framework;
using Seedling.Model;

namespace Seedling.Tests.DateAndTime
{
    [TestFixture]
    public class ConvertToTimestampTests
    {
        [Test]
        public void ListWith4Elements()
        {
            // Arrange
            var digits = new byte[] {1, 5, 0, 5};
            TimeSpan expected = 15.Minutes().And(5.Seconds());

            // Act
            TimeSpan actual = CircularTimeSpan.ToTimeSpan(digits);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ListWithUnevenElements()
        {
            // Arrange
            var digits = new byte[] {1, 3, 0};
            TimeSpan expected = 1.Minutes().And(30.Seconds());

            // Act
            TimeSpan actual = CircularTimeSpan.ToTimeSpan(digits);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WithLeadingZeros()
        {
            // Arrange
            var digits = new byte[] {0, 0, 1, 5, 0, 5};
            TimeSpan expected = 15.Minutes().And(5.Seconds());

            // Act
            TimeSpan actual = CircularTimeSpan.ToTimeSpan(digits);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}