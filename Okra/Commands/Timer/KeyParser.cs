using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Okra.Commands.Timer
{
    public interface IParseKeys
    {
        ShortCut Parse(string command);
    }

    public class KeyParser : IParseKeys
    {
        private readonly Dictionary<string, Key> _keyMap = new Dictionary<string, Key>
        {
            {"Esc", Key.Escape},
        };

        private readonly Dictionary<string, ModifierKeys> _modifierKeyMap = new Dictionary<string, ModifierKeys>
        {
            {"Win", ModifierKeys.Windows},
            {"Ctrl", ModifierKeys.Control}
        };

        public ShortCut Parse(string command)
        {
            var key = Key.None;
            if (command.Contains("+"))
            {
                string[] keys = command.Split('+').Select(s => s.Trim()).ToArray();
                ModifierKeys modifier = ParseModifier(keys.First());
                key = ParseKey(keys.Last());
                return new ShortCut {Button = key, Modifiers = modifier};
            }

            key = ParseKey(command);
            return new ShortCut {Button = key};
        }

        public Key ParseKey(string key)
        {
            if (key.Length == 1)
            {
                key = key.ToUpper();
            }
            if (_keyMap.ContainsKey(key))
            {
                return _keyMap[key];
            }
            return (Key) Enum.Parse(typeof (Key), key);
        }

        public ModifierKeys ParseModifier(string modifierKey)
        {
            modifierKey = modifierKey.Trim();
            if (_modifierKeyMap.ContainsKey(modifierKey))
            {
                return _modifierKeyMap[modifierKey];
            }
            return (ModifierKeys) Enum.Parse(typeof (ModifierKeys), modifierKey);
        }
    }
}