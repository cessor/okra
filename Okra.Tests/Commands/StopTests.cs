using NSubstitute;
using NUnit.Framework;
using Seedling.Commands.Timer;
using Seedling.View.Digits;
using Should.Fluent;

namespace Seedling.Tests.Commands
{
    [TestFixture]
    public class StopTests
    {
        [Test]
        public void CreateStop()
        {
            var stop = new Stop();
            stop.Name.Should().Not.Be.NullOrEmpty();
            stop.Description.Should().Not.Be.NullOrEmpty();
            stop.ShortCuts.Should().Be.Empty();
        }

        [Test]
        public void ShouldStopTheClockUponSelection()
        {
            // Dependent-On Component
            var viewmodel = Substitute.For<IClock>();

            // System under Test
            var stop = new Stop { Clock = viewmodel };

            // Act
            stop.Select();

            // Assert
            viewmodel.Received().StopCounter();
        }
    }
}