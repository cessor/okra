using System.Threading;
using DateApi;
using NSubstitute;
using NUnit.Framework;
using Okra.Commands.UI;
using Okra.View.Digits;
using Should.Fluent;

namespace Okra.Tests.Commands
{
    [TestFixture, Apartment(ApartmentState.STA)]
    public class SetTimeToDefaultCommandTests
    {
        [Test]
        public void CreateSetTime()
        {
            var command = new SetTime();
            command.Name.Should().Not.Be.NullOrEmpty();
            command.Description.Should().Not.Be.NullOrEmpty();
            command.ShortCuts.Should().Not.Be.Empty();
        }

        [Test]
        public void ShouldTestSomeThing()
        {
            var viewmodel = Substitute.For<IClock>();
            var command = new SetTime {Clock = viewmodel};
            command.Select(25.Seconds().ToString());
            viewmodel.Received().SetTo(25.Seconds());
        }
    }
}