using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okra.Readability;

namespace Okra.Tests.Actions
{
    [TestClass]
    public class ColorTests
    {
        [TestMethod]
        public void RGB_ConvertColorFromHexValue()
        {
            Assert.AreEqual(Colors.Red, 0xFF0000.Rgb());
            Assert.AreEqual(Colors.Blue, 0x0000FF.Rgb());
            Color expected = Color.FromRgb(107, 56, 52); // Color: #6b3834
            Assert.AreEqual(expected, 0x6b3834.Rgb());
        }

        [TestMethod]
        public void ARGB_ConvertColorFromHexValue()
        {
            Assert.AreEqual(Colors.Red, 0xFFFF0000.Argb());
            Color expected = Color.FromArgb(17, 107, 56, 52); // Color: #6b3834, alpha: 11
            Assert.AreEqual(expected, 0x116b3834.Argb());
        }

        #region Nested type: ConvertToTimestampTestsImpl

        private class ConvertToTimestampTestsImpl : ConvertToTimestampTests
        {
        }

        #endregion
    }
}