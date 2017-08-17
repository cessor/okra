using System;
using System.Windows.Input;

namespace Okra.Commands.Timer
{
    public interface IMakeKeyBindings
    {
        KeyBinding Make(ShortCut shortcut, Action select);
    }

    public class KeyBindingFactory : IMakeKeyBindings
    {
        public KeyBinding Make(ShortCut shortcut, Action select)
        {
            return new KeyBinding
            {
                Key = shortcut.Button,
                Modifiers = shortcut.Modifiers,
                Command = new Cmd(select),
                CommandParameter = shortcut.Parameter
            };
        }
    }
}