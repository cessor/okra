using System.Collections.Generic;
using System.Windows.Input;

namespace Seedling.Commands
{
    public struct ShortCut
    {
        private static readonly Dictionary<ModifierKeys, string> ClearNames = new Dictionary<ModifierKeys, string>
        {
            {ModifierKeys.Control, "Ctrl"},
            {ModifierKeys.None, string.Empty},
        };

        public Key Button { get; set; }
        public ModifierKeys Modifiers { get; set; }
        public object Parameter { get; set; }

        public static ShortCut None
        {
            get
            {
                return new ShortCut
                {
                    Button = Key.None,
                    Modifiers = ModifierKeys.None,
                    Parameter = new object()
                };
            }
        }

        public override string ToString()
        {
            string modifier = GetModifierName(Modifiers);
            return
                string.IsNullOrEmpty(modifier)
                    ? Button.ToString()
                    : string.Join(" + ", modifier, Button);
        }

        private string GetModifierName(ModifierKeys m)
        {
            return ClearNames.ContainsKey(m)
                ? ClearNames[m]
                : m.ToString();
        }
    }
}