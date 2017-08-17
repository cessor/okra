using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using NUnit.Framework;
using Okra.Commands.Timer;
using Okra.Commands.TimerActions;
using Should.Fluent;

namespace Okra.Tests
{
    

    [TestFixture]
    public class ShortcutParserTests
    {
        [Test]
        public void ShouldTestSomeThing()
        {
            var dsl = @"Toggle
 Enter";
            var lines = dsl.Split('\n');

            var currentCommand = "";

            var bindings = new List<KeyBinding>();
            var validLines = lines.Where(NotEmptyOrComment);
            foreach (var line in validLines)
            {
                if (LineContainsAKeyBinding(line))
                {
                    bindings.Add(MakeBinding(line.Trim(), currentCommand));
                    continue;
                }
                currentCommand = line.Trim();
            }

            bindings.Count.Should().Equal(1);
            bindings.First().Command.Should().Be.OfType(typeof (Toggle));
            bindings.First().Key.Should().Equal(Key.Enter);
        }

        [Test]
        public void ShouldTestSomeOtherThing()
        {
            var dsl = @"DisplayMessage
 Ctrl+Right";
            var lines = dsl.Split('\n');

            var currentCommand = "";

            var bindings = new List<KeyBinding>();
            var validLines = lines.Where(NotEmptyOrComment);
            foreach (var line in validLines)
            {
                if (LineContainsAKeyBinding(line))
                {

                    var keys = line.Split('+');

                    Key k = Key.None;
                    Key.TryParse(keys[1], true, out k);

                    ModifierKeys mods = ModifierKeys.None;
                    var modifier = (keys[0].Trim() == "Ctrl") ?  "Control" : keys[0];
                    ModifierKeys.TryParse(modifier, true, out mods);
                    var binding = new KeyBinding()
                    {
                        Key = k,
                        Modifiers = mods,
                        Command = new DisplayMessage(null)
                    };


                    bindings.Add(binding);
                    continue;
                }
                currentCommand = line.Trim();
            }

            bindings.Count.Should().Equal(1);
            bindings.First().Command.Should().Be.OfType(typeof(DisplayMessage));
            bindings.First().Key.Should().Equal(Key.Right);
            bindings.First().Modifiers.Should().Equal(ModifierKeys.Control);
        }

        private static bool NotEmptyOrComment(string line)
        {
            return !(string.IsNullOrEmpty(line.Trim()) || line.StartsWith("#"));
        }

        private static bool LineContainsAKeyBinding(string line)
        {
            return line.StartsWith(" ") || line.StartsWith("\t");
        }

        private KeyBinding MakeBinding(string line, string command)
        {
            return new KeyBinding()
                {
                    Key = Key.Enter,
                    Command = new Toggle(null)
                };
        }
    }
}