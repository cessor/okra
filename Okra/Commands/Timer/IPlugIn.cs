using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace Okra.Commands.Timer
{
    public interface ISelect
    {
        void Select();
        void Select(object parameter);
    }

    public interface IPlugIn : ISelect
    {
        string Name { get; }
        string Description { get; }
        MenuItem MenuItem { get; }
        List<KeyBinding> ShortCuts { get; }
    }
}