using System;
using Okra.Commands.Timer;
using Okra.View.ColorPicker;
using Okra.View.Digits;
using Okra.View.Input;

namespace Okra.Commands.UI
{
    internal class PickColor : Plugin
    {
        private readonly Func<CurrentMousePosition> _mousePosition;
        private readonly IColorPicker _view;

        internal PickColor(IColorPicker view, Func<CurrentMousePosition> mousePosition, IClock clock)
        {
            Clock = clock;
            _view = view;
            _mousePosition = mousePosition;
        }

        public PickColor() : this(new ColorPicker(), () => new CurrentMousePosition(), null)
        {
            Name = "_Color";
            Description = "Choose a color!";
            AddShortCut("c");
        }

        public override void Select()
        {
            CurrentMousePosition currentMousePosition = _mousePosition();
            _view.ShowDialogAt(currentMousePosition);
            Clock.Color = _view.Color;
        }
    }
}