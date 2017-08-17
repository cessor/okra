using System;
using NUnit.Framework;
using Seedling.Commands.Timer;
using Should.Fluent;

namespace Seedling.Tests
{
    [TestFixture]
    public class CmdTests
    {
        [Test]
        public void CreateCmd()
        {
            Action nothing = () => { };
            var cmd = new Cmd(nothing);
            cmd.Action.Should().Be.SameAs(nothing);
        }

        [Test]
        public void ByDefaultACmdCanExecute()
        {
            Action nothing = () => { };
            var cmd = new Cmd(nothing);
            cmd.CanExecute(new object()).Should().Be.True();
        }

        [Test]
        public void ExecutingTheICommandExecuteFunctionRunsTheInsertedCommand()
        {
            var wasCalled = false;
            Action nothing = () => { wasCalled = true; };
            var cmd = new Cmd(nothing);
            cmd.Execute(null);
            wasCalled.Should().Be.True();
        }
    }
}