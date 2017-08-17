using System;
using System.Windows.Input;
using NSubstitute;
using NUnit.Framework;
using Okra.Commands.Actions;
using Okra.Commands.TimerActions;
using Okra.View.Clock;

namespace Okra.Tests
{
    [TestFixture]
    public class RegisterTimeoutEventTest
    {
        [Test]
        public void RegisterAShutdownAction()
        {
            // Arrange
            var viewmodel = Substitute.For<IClock>();
            var actionToBeSelected = Substitute.For<ICommand>();

            // System under Test
            var register = new RegisterTimeoutEvent(viewmodel);

            // Act
            register.Execute(actionToBeSelected);

            // Assert
            viewmodel.Received().Done = Arg.Any<Action>();
        }

        [Test]
        public void WhenAShutdownActionIsSelectedItActivatesAnAction()
        {
            // Arrange
            var viewmodel = Substitute.For<IClock>();
            ICanBeSelected actionToBeSelected = Substitute.For<ICanBeSelected, ICommand>();

            // System under Test
            var register = new RegisterTimeoutEvent(viewmodel);

            // Act
            register.Execute(actionToBeSelected);

            // Assert
            actionToBeSelected.Received().Select();
        }
    }
}