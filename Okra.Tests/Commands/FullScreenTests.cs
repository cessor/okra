using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using Okra.Commands.UI;
using Okra.View.Digits;
using Should.Fluent;

namespace Okra.Tests.Commands
{
    [TestFixture]
    public class FullScreenTests
    {
        [Test]
        public void CreateFullscreen()
        {
            var command = new FullScreen();
            command.Name.Should().Not.Be.NullOrEmpty();
            command.Description.Should().Not.Be.NullOrEmpty();
            command.ShortCuts.Should().Not.Be.Empty();
        }

        [Test]
        public void ShouldSetTheFontsize()
        {
            var viewmodel = Substitute.For<IClock>();
            var command = new FullScreen{Clock = viewmodel};
            command.Select();
            viewmodel.Received().FontSize = Arg.Any<double>();
        }
    }
}