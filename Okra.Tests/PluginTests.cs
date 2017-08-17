using System;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using Okra.Commands;
using Okra.Commands.Timer;
using Should.Fluent;

namespace Okra.Tests
{
    [TestFixture]
    public class PluginTests
    {
        private class TestablePlugin : Plugin
        {
        }

        private class NamedPlugin : Plugin
        {
            public NamedPlugin(string name)
            {
                Name = name;
            }
        }

        public class PluginWithShortCuts : Plugin
        {
            public PluginWithShortCuts(IMakeKeyBindings keybindingFactory, IParseKeys parser)
                : base(keybindingFactory, parser)
            {
            }
        }

        [Test]
        public void ShouldAddAShortCutWithoutAParameter()
        {
            // Arrange
            var shortCut = new ShortCut 
            {
                Button = Key.C, 
                Modifiers = ModifierKeys.Control
            };

            // Dependent-On Components
            var keybindingFactory = Substitute.For<IMakeKeyBindings>();
            var parser = Substitute.For<IParseKeys>();
            var binding = new KeyBinding();

            // System under Test
            var plugin = new PluginWithShortCuts(keybindingFactory, parser);

            keybindingFactory.Make(shortCut, plugin.Select).Returns(binding);

            // Act 
            plugin.AddShortCut(shortCut);

            // Assert
            plugin.ShortCuts.Should().Contain.One(binding);
            binding.CommandParameter.Should().Be.Null();
        }

        [Test]
        public void ShouldAddAShortCutFromString()
        {
            // Arrange
            var shortCut = new ShortCut {Button = Key.C, Modifiers = ModifierKeys.Control};
            var binding = new KeyBinding();
            const string keyCombination = "Ctrl+C";

            // Dependent-On Components
            var keybindingFactory = Substitute.For<IMakeKeyBindings>();
            var parser = Substitute.For<IParseKeys>();

            // System under Test
            var plugin = new PluginWithShortCuts(keybindingFactory, parser);

            parser.Parse(keyCombination).Returns(shortCut);
            keybindingFactory.Make(shortCut, plugin.Select).Returns(binding);

            // Act 
            plugin.AddShortCut(keyCombination);

            // Assert
            plugin.ShortCuts.Should().Contain.One(binding);
        }

        [Test]
        public void ShouldAddAShortCutFromStringWithParameter()
        {
            // Arrange
            var shortCut = new ShortCut { Button = Key.C, Modifiers = ModifierKeys.Control };
            var changedShortcut = new ShortCut { Button = Key.C, Modifiers = ModifierKeys.Control, Parameter = "Hello" };
            var binding = new KeyBinding();
            const string keyCombination = "Ctrl+C";

            // Dependent-On Components
            var keybindingFactory = Substitute.For<IMakeKeyBindings>();
            var parser = Substitute.For<IParseKeys>();

            // System under Test
            var plugin = new PluginWithShortCuts(keybindingFactory, parser);
            parser.Parse(keyCombination).Returns(shortCut);
            
            // Act 
            plugin.AddShortCut(keyCombination, "Hello");
            
            // Assert
            parser.Received().Parse(keyCombination);
            keybindingFactory.Received().Make(changedShortcut, plugin.Select);
        }
   
        [Test]
        public void ShouldCreateAPlugin()
        {
            var plugin = new TestablePlugin();
            plugin.ShortCuts.Should().Be.Empty();
        }

        [Test]
        public void ShouldIfNoNameIsProvidedAPluginShouldBeNamedAfterItsType()
        {
            var plugin = new TestablePlugin();
            plugin.Name.Should().Equal("TestablePlugin");
        }

        [Test]
        public void ShouldNotHaveShortCutsByDefault()
        {
            var parser = Substitute.For<IParseKeys>();
            var keybindingFactory = Substitute.For<IMakeKeyBindings>();
            var plugin = new PluginWithShortCuts(keybindingFactory, parser);
            plugin.ShortCuts.Should().Not.Be.Null();
            plugin.ShortCuts.Should().Be.Empty();
        }

        [Test]
        public void ShouldSetAName()
        {
            var plugin = new NamedPlugin("Name");
            plugin.Name.Should().Equal("Name");
        }

        [Test, Apartment(ApartmentState.STA)]
        public void ShouldMakeAMenuItem()
        {
            var plugin = new NamedPlugin("Name");
            var cmd = new Cmd(plugin.Select);
            plugin.MenuItem.Header.Should().Equal("Name");
            true.Should().Be.False();
            // Check Command here!!
        }
    }
}