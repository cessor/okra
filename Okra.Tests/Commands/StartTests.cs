using NSubstitute;
using NUnit.Framework;
using Seedling.Model;
using Seedling.Commands.Timer;
using Seedling.View.Digits;
using Should.Fluent;

namespace Seedling.Tests.Commands
{
    [TestFixture]
    public class StartTests
    {
        [Test]
        public void CreateStart()
        {
            var start = new Start();
            start.Name.Should().Not.Be.NullOrEmpty();
            start.Description.Should().Not.Be.NullOrEmpty();
            start.ShortCuts.Should().Be.Empty();
        }

        [Test]
        public void ShouldStartTheClockUponSelection()
        {
            // Dependent-On Component
            var viewmodel = Substitute.For<IClock>();

            // System under Test
            var start = new Start { Clock = viewmodel };

            // Act
            start.Select();

            // Assert
            viewmodel.Received().StartCounter();
        }
    }
}