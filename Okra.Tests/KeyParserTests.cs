using System.Windows.Input;
using NUnit.Framework;
using Seedling.Commands.Timer;
using Should.Fluent;

namespace Seedling.Tests
{
    [TestFixture]
    public class KeyParserTests
    {
        [Test]
        public void ShouldParseASimpleCharacter()
        {
            const string commandString = "c";
            var shortcut = new KeyParser().Parse(commandString);
            shortcut.Button.Should().Equal(Key.C);
        }

        [Test]
        public void ItDoesntMatterWhetherYouUseCapitalsOrNot()
        {
            const string commandString = "C";
            var shortcut = new KeyParser().Parse(commandString);
            shortcut.Button.Should().Equal(Key.C);
        }

        [Test]
        public void ShouldParseACombinedCommand()
        {
            const string commandString = "Control+C";
            var shortcut = new KeyParser().Parse(commandString);
            shortcut.Button.Should().Equal(Key.C);
            shortcut.Modifiers.Should().Equal(ModifierKeys.Control);
        }

        [Test]
        public void ShouldParseWithSpacing()
        {
            const string commandString = "Control + C";
            var shortcut = new KeyParser().Parse(commandString);
            shortcut.Button.Should().Equal(Key.C);
            shortcut.Modifiers.Should().Equal(ModifierKeys.Control);
        }

        [Test]
        public void ShouldParseACombinedCommandWithAnAbbreviatedModifierKey()
        {
            const string commandString = "Ctrl + C";
            var shortcut = new KeyParser().Parse(commandString);
            shortcut.Button.Should().Equal(Key.C);
            shortcut.Modifiers.Should().Equal(ModifierKeys.Control);
        }

        [Test, Sequential]
        public void ShouldParseModifierKey(
            [Values("Ctrl","Alt","Shift","Win")] string keyString, 
            [Values(ModifierKeys.Control,ModifierKeys.Alt, ModifierKeys.Shift, ModifierKeys.Windows)] ModifierKeys modifierKey)
        {
            new KeyParser().ParseModifier(keyString).Should().Equal(modifierKey);
        }

        [Test, Sequential]
        public void ParsingModifiersAlsoWorksWithSpacing(
            [Values("Ctrl", " Alt", "Shift ", " Win ")] string keyString,
            [Values(ModifierKeys.Control, ModifierKeys.Alt, ModifierKeys.Shift, ModifierKeys.Windows)] ModifierKeys modifierKey)
        {
            new KeyParser().ParseModifier(keyString).Should().Equal(modifierKey);
        }

        [Test, Sequential]
        public void ShouldParseNormalKeys()
        {
            new KeyParser().ParseKey("X").Should().Equal(Key.X);
        }

        [Test, Sequential]
        public void ShouldParseSpecialKeys(
            [Values("Enter", "Space", "Return ", "Escape", "Esc")] string keyString,
            [Values(Key.Enter, Key.Space, Key.Return, Key.Escape, Key.Escape)] Key key)
            
        {
            new KeyParser().ParseKey(keyString).Should().Equal(key);
        }

        [Test, Sequential]
        public void ParsingModifiersAlsoWorksWithSpacing(
            [Values("Enter", "Space ", " Return", " Escape ")] string keyString,
            [Values(Key.Enter, Key.Space, Key.Return, Key.Escape)] Key key)
        {
            new KeyParser().ParseKey(keyString).Should().Equal(key);
        }
    }
}