using System;
using NSubstitute;
using NUnit.Framework;
using Okra.Commands.Actions;
using Okra.View.Digits;
using Should.Fluent;

namespace Okra.Tests.Commands
{
    class ClearActionsTests
    {
        [Test]
        public void ShouldTestSomeThing()
        {
            var command = new ClearActions();
            command.Name.Should().Not.Be.NullOrEmpty();
            command.Description.Should().Not.Be.NullOrEmpty();
            command.ShortCuts.Should().Be.Empty();
        }

        [Test]
        public void ShouldRemoveAllActionsFromTheViewModel()
        {
            var viewmodel = Substitute.For<IClock>();
            var command = new ClearActions {Clock = viewmodel};

            command.Select();

            viewmodel.Received().Done = Arg.Any<Action>();
        }
    }
}
