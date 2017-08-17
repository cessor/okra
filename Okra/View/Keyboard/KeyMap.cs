using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace Okra.View.Keyboard
{
    public class KeyMap
    {
        private readonly List<ShortCut> _shortcuts = new List<ShortCut>();

        public List<ShortCut> Shortcuts
        {
            get { return _shortcuts; }
        }

        public KeyMap Key(Button key, string description)
        {
            return Key(new NoButton(), key, description);
        }

        public KeyMap Key(Button key, Type command)
        {
            return Key(new NoButton(), key, command);
        }

        public KeyMap Key(Button modifier, Button key, string description)
        {
            var shortCut = new ShortCut {Button = key, Modifier = modifier, Description = description};
            _shortcuts.Add(shortCut);
            return this;
        }

        public KeyMap Key(Button modifier, Button key, Type command)
        {
            string description = Describe(command);
            return Key(modifier, key, description);
        }

        public string Describe(Type type)
        {
            var descriptionAttribute = FindAttribute<DescriptionAttribute>(type);
            return descriptionAttribute == null
                ? string.Empty
                : descriptionAttribute.Description;
        }

        private static TAttribute FindAttribute<TAttribute>(Type type) where TAttribute : new()
        {
            return type
                .GetCustomAttributes(typeof (TAttribute), false)
                .Select(attribute => (TAttribute) attribute)
                .FirstOrDefault();
        }
    }
}