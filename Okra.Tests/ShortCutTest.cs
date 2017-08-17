using System.Windows.Input;
using NUnit.Framework;
using Seedling.Commands;
using Should.Fluent;

namespace Seedling.Tests
{
    [TestFixture]
    public class ShortCutTest
    {
        [Test]
        public void CreateAnEmptyShortcut()
        {
            var shortcut = new ShortCut();
            shortcut.Button.Should().Equal(Key.None);
            shortcut.Modifiers.Should().Equal(ModifierKeys.None);
            shortcut.Parameter.Should().Be.Null();
        }

        [Test]
        public void CreateAnNoneShortcut()
        {
            var shortcut = ShortCut.None;
            shortcut.Button.Should().Equal(Key.None);
            shortcut.Modifiers.Should().Equal(ModifierKeys.None);
            shortcut.Parameter.Should().Not.Be.Null();
        }

        [Test]
        public void ShortcutCanCarryAParameter()
        {
            var shortcut = new ShortCut {Parameter = "Hello"};
            shortcut.Parameter.ToString().Should().Equal("Hello");
        }

        [Test]
        public void ShouldDescribeAMoreComplexShortCut()
        {
            new ShortCut {Button = Key.N, Modifiers = ModifierKeys.Control}
                .ToString()
                .Should()
                .Equal("Ctrl + N");
        }

        [Test]
        public void ShouldDescribeAMoreComplexShortCutWithAlternative()
        {
            new ShortCut {Button = Key.N, Modifiers = ModifierKeys.Shift}
                .ToString()
                .Should()
                .Equal("Shift + N");
        }

        [Test]
        public void ShouldDescribeAMoreComplexShortCutWithShift()
        {
            new ShortCut {Button = Key.N, Modifiers = ModifierKeys.Alt}
                .ToString()
                .Should()
                .Equal("Alt + N");
        }

        [Test]
        public void ShouldDescribeASimpleShortCut()
        {
            new ShortCut {Button = Key.N}
                .ToString()
                .Should()
                .Equal("N");
        }
    }
}