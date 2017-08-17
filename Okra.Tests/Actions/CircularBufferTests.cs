using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okra.Model;

namespace Okra.Tests.Actions
{
    [TestClass]
    public class CircularBufferTests
    {
        [TestMethod]
        public void ShouldThrowOutTheOldestElement()
        {
            // Arrange
            const int capacity = 2;

            // System under Test
            var buffer = new CircularBuffer<int>(capacity) {1, 2};

            // Assert
            Assert.AreEqual(2, buffer.Capacity);

            // Assert over capacity
            Assert.AreEqual(1, buffer[0]);
            Assert.AreEqual(2, buffer[1]);

            buffer.Add(3);
            Assert.AreEqual(2, buffer[0]);
            Assert.AreEqual(3, buffer[1]);

            buffer.Add(4);
            Assert.AreEqual(3, buffer[0]);
            Assert.AreEqual(4, buffer[1]);

            // Kept the capacity
            Assert.AreEqual(2, buffer.Capacity);
        }
    }
}