using NSubstitute;
using NUnit.Framework;
using Okra.Commands.Timer;
using Okra.Model;
using Okra.View.Digits;
using Should.Fluent;

namespace Okra.Tests.Commands
{
    [TestFixture]
    public class ToggleTests
    {
        [Test]
        public void CreateToggle()
        {
            var toggle = new Toggle();
            toggle.Name.Should().Not.Be.NullOrEmpty();
            toggle.Description.Should().Not.Be.NullOrEmpty();
            toggle.ShortCuts.Should().Not.Be.Empty();
        }

        [Test]
        public void ShouldStartTheClockIfItIsNotRunning()
        {
            // Dependent-On Component
            var viewmodel = Substitute.For<IClock>();
            viewmodel.IsRunning.Returns(false);
            
            var toggle = new Toggle {Clock = viewmodel};
            
            toggle.Select();

            viewmodel.Received().StartCounter();
        }

        [Test]
        public void ShouldStopTheClockIfItIsNotRunning()
        {
            // Dependent-On Component
            var viewmodel = Substitute.For<IClock>();
            viewmodel.IsRunning.Returns(true);

            var toggle = new Toggle { Clock = viewmodel };

            toggle.Select();

            viewmodel.Received().StopCounter();
        }
    }
}