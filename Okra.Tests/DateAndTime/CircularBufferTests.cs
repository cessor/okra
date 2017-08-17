using NUnit.Framework;
using Seedling.Model;
using Should.Fluent;

namespace Seedling.Tests.DateAndTime
{
    [TestFixture]
    public class CircularBufferTests
    {
        [Test]
        public void ShouldThrowOutTheOldestElement()
        {
            // Arrange
            const int capacity = 2;

            // System under Host
            var buffer = new CircularBuffer<int>(capacity) {1, 2};

            // Assert
            buffer.Capacity.Should().Equal(2);

            // Assert over capacity
            buffer[0].Should().Equal(1);
            buffer[1].Should().Equal(2);

            buffer.Add(3);
            buffer[0].Should().Equal(2);
            buffer[1].Should().Equal(3);

            buffer.Add(4);
            buffer[0].Should().Equal(3);
            buffer[1].Should().Equal(4);

            // Kept the capacity
            buffer.Capacity.Should().Equal(2);
        }
    }
}