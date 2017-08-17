using NUnit.Framework;
using Seedling.View.Keyboard;
using Should.Fluent;

namespace Seedling.Tests.Actions
{
    [System.ComponentModel.Description("Description")]
    internal class ClassWithDescription
    {
    }

    internal class ClassWithoutDescription
    {
    }

    [TestFixture]
    public class KeymapTests
    {
        [Test]
        public void ShouldDescribeAType()
        {
            new KeyMap().Describe(typeof (ClassWithDescription)).Should().Equal("Description");
        }

        [Test]
        public void ShouldNotShowADescriptionIfTheTypeWasNotDescribed()
        {
            new KeyMap().Describe(typeof (ClassWithoutDescription)).Should().Equal(string.Empty);
        }
    }
}