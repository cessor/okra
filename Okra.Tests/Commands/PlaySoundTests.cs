using System;
using NSubstitute;
using NSubstitute.Exceptions;
using NUnit.Framework;
using Seedling.Commands.TimerActions;
using Seedling.View.Digits;
using Should.Fluent;

namespace Seedling.Tests.Commands
{
    [TestFixture]
    public class PlaySoundTests
    {
        [Test]
        public void ShouldTestSomeThing()
        {
            var playSound = new PlaySound();
            playSound.Name.Should().Not.Be.NullOrEmpty();
            playSound.Description.Should().Not.Be.NullOrEmpty();
            playSound.ShortCuts.Should().Be.Empty();
        }

        [Test]
        public void ShouldRegisterPlayingASoundForLaterUponSelection()
        {
            var viewmodel = Substitute.For<IClock>();
            var playSound = new PlaySound {Clock = viewmodel};

            playSound.Select();
            viewmodel.Received().Done = Arg.Any<Action>();
        }
    }
}