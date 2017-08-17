using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using System.Windows.Input;
using Okra.View.Digits;

namespace Okra.Commands.Timer
{
    [InheritedExport(typeof (IPlugIn))]
    public abstract class Plugin : IPlugIn
    {
        private readonly IParseKeys _keyParser;
        private readonly IMakeKeyBindings _keybindingFactory;
        private MenuItem _menuItem;
        private string _name;

        protected Plugin(IMakeKeyBindings keybindingFactory, IParseKeys keyParser)
        {
            _keybindingFactory = keybindingFactory;
            _keyParser = keyParser;
            ShortCuts = new List<KeyBinding>();
        }

        protected Plugin() : this(new KeyBindingFactory(), new KeyParser())
        {
        }

        [Import(typeof (IClock))]
        public IClock Clock { get; protected internal set; }

        public string Description { get; protected set; }
        public List<KeyBinding> ShortCuts { get; protected set; }

        public string Name
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_name))
                    return GetType().Name;
                return _name;
            }
            protected set { _name = value; }
        }

        public MenuItem MenuItem
        {
            get
            {
                if (_menuItem == null)
                {
                    _menuItem = new MenuItem
                    {
                        Header = Name,
                        Command = new Cmd(Select)
                    };
                }
                return _menuItem;
            }
            protected set { _menuItem = value; }
        }

        public virtual void Select(object parameter)
        {
        }

        public virtual void Select()
        {
        }

        protected internal void AddShortCut(string keys)
        {
            AddShortCut(keys, null);
        }

        protected internal void AddShortCut(string keys, object parameter)
        {
            ShortCut shortcut = _keyParser.Parse(keys);
            shortcut.Parameter = parameter;
            AddShortCut(shortcut);
        }

        protected internal void AddShortCut(ShortCut shortcut)
        {
            Action action = () => { };
            if (shortcut.Parameter == null)
            {
                action = Select;
            }
            else
            {
                action = () => Select(shortcut.Parameter);
            }
            KeyBinding binding = _keybindingFactory.Make(shortcut, action);
            ShortCuts.Add(binding);
        }
    }
}