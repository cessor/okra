using DateApi;
using NUnit.Framework;
using Seedling.Model;
using Should.Fluent;

namespace Seedling.Tests
{
    [TestFixture]
    public class GiveMeAClockTests
    {
        [Test]
        public void ShouldGenerateAViewModel()
        {
            var clock = GiveMeAClock.ForTheCurrentConfig();
            clock.Color.Should().Not.Be.Null();
            //clock.FontSize.Should().Not.Be.Null();
#if DEBUG
            clock.TimeLeft.Should().Equal(1.Second());            
#else
            clock.TimeLeft.Should().Equal(25.Minutes());
#endif

        } 
    }
}