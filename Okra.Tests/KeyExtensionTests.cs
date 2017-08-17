using System.Windows.Input;
using NUnit.Framework;
using Seedling.Readability;

namespace Seedling.Tests
{
    [TestFixture]
    public class KeyExtensionTests
    {
        [Test]
        public void CharacterKeysAreNotDigits()
        {
            Assert.IsFalse(Key.A.IsDigit());
        }

        [Test]
        public void NumberKeysAreDigits()
        {
            Assert.IsTrue(Key.D0.IsDigit());
        }

        [Test]
        public void TheFirstNumpadKeyShouldBeADigit()
        {
            Assert.IsTrue(Key.NumPad0.IsDigit());
        }

        [Test]
        public void TheKeysShouldGiveTheAppropriateNumbers()
        {
            Assert.AreEqual(0, Key.D0.Digit());
            Assert.AreEqual(1, Key.D1.Digit());
            Assert.AreEqual(2, Key.D2.Digit());
            Assert.AreEqual(3, Key.D3.Digit());
            Assert.AreEqual(4, Key.D4.Digit());
            Assert.AreEqual(5, Key.D5.Digit());
            Assert.AreEqual(6, Key.D6.Digit());
            Assert.AreEqual(7, Key.D7.Digit());
            Assert.AreEqual(8, Key.D8.Digit());
            Assert.AreEqual(9, Key.D9.Digit());
        }

        [Test]
        public void TheLastNumpadKeyShouldAlsoBeADigit()
        {
            Assert.IsTrue(Key.NumPad9.IsDigit());
        }

        [Test]
        public void TheNumpadKeysShouldGiveTheAppropriateNumbers()
        {
            Assert.AreEqual(0, Key.NumPad0.Digit());
            Assert.AreEqual(1, Key.NumPad1.Digit());
            Assert.AreEqual(2, Key.NumPad2.Digit());
            Assert.AreEqual(3, Key.NumPad3.Digit());
            Assert.AreEqual(4, Key.NumPad4.Digit());
            Assert.AreEqual(5, Key.NumPad5.Digit());
            Assert.AreEqual(6, Key.NumPad6.Digit());
            Assert.AreEqual(7, Key.NumPad7.Digit());
            Assert.AreEqual(8, Key.NumPad8.Digit());
            Assert.AreEqual(9, Key.NumPad9.Digit());
        }
    }
}