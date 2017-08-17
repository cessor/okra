using System.Windows.Media;
using NUnit.Framework;
using Okra.Readability;
using Should.Fluent;

namespace Okra.Tests.Misc
{
    [TestFixture]
    public class ColorTests
    {
        [Test]
        public void ARGB_ConvertColorFromHexValue()
        {
            Assert.AreEqual(Colors.Red, 0xFFFF0000.Argb());
            Color expected = Color.FromArgb(17, 107, 56, 52); // _color: #6b3834, alpha: 11
            Assert.AreEqual(expected, 0x116b3834.Argb());
        }

        [Test]
        public void RGB_ConvertColorFromHexValue()
        {
            Assert.AreEqual(Colors.Red, 0xFF0000.Rgb());
            Assert.AreEqual(Colors.Blue, 0x0000FF.Rgb());
            Color expected = Color.FromRgb(107, 56, 52); // _color: #6b3834
            Assert.AreEqual(expected, 0x6b3834.Rgb());
        }

        [Test]
        public void RGB_ConvertColorToHexValue()
        {
            Colors.Red.Hex().Should().Equal(0xFF0000);
            Colors.Lime.Hex().Should().Equal(0x00FF00);
            Colors.Blue.Hex().Should().Equal(0x0000FF);

            // _color: #6b3834
            Color.FromRgb(107, 56, 52).Hex().Should().Equal(0x6b3834);
        }
    }
}