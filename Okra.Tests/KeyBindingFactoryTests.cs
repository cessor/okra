using System;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Windows.Input;
using Microsoft.Win32;
using NSubstitute;
using NUnit.Framework;
using Seedling.Commands;
using Seedling.Commands.Timer;
using Should.Core.Exceptions;
using Should.Fluent;

namespace Seedling.Tests
{
    [TestFixture]
    public class KeyBindingFactoryTests
    {
        [Test]
        public void ShouldTestSomeThing()
        {
            // Arrange
            Action @select = () => { };
            var shortCut = ShortCut.None;
            var parameter = new object();
            shortCut.Parameter = parameter;

            // System under Test
            var keyBindingFactory = new KeyBindingFactory();
            
            // Act
            KeyBinding keyBinding = keyBindingFactory.Make(shortCut, @select);

            // Assert
            keyBinding.Key.Should().Equal(shortCut.Button);
            keyBinding.Modifiers.Should().Equal(shortCut.Modifiers);

            keyBinding.CommandParameter.Should().Be.SameAs(parameter);
            var cmd = ((Cmd) keyBinding.Command);
            cmd.Action.Should().Be.SameAs(@select);
        }

        [Test]
        public void ShouldTheCommandFactoryParsesCommands()
        {
            var parameter = new object();
            var shortCut = new ShortCut{Button = Key.C, Modifiers = ModifierKeys.Control, Parameter = parameter};
            Action @select = () => { };
            var command = new KeyBindingFactory().Make(shortCut, @select);
            command.Key.Should().Equal(Key.C);
            command.Modifiers.Should().Equal(ModifierKeys.Control);
            command.CommandParameter.Should().Be.SameAs(parameter);
        }


        [Test]
        public void ShouldCreateACommandThatAcceptsAParameter()
        {
            var shortCut = new ShortCut { 
                Button = Key.C,
                Modifiers = ModifierKeys.Control,
                Parameter =  "Johannes"
            };
            
            
            // System under Test
            var keyBindingFactory = new KeyBindingFactory();

            var keyBinding = keyBindingFactory.Make(shortCut, () => { });

            keyBinding.Command.Execute(null);
            
            
        }
    }
}