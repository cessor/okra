using System;
using Okra.Commands.Timer;
using Okra.View.Digits;
using Okra.View.Input;
using Okra.View.TimePicker;

namespace Okra.Commands.UI
{
    internal class PresetTime : Plugin
    {
        private readonly Func<CurrentMousePosition> _mousePosition;
        private readonly ITimePicker _view;

        public PresetTime(ITimePicker view, Func<CurrentMousePosition> mousePosition, IClock clock)
        {
            Clock = clock;
            _view = view;
            _mousePosition = mousePosition;
        }

        public PresetTime() : this(new TimePicker(), () => new CurrentMousePosition(), null)
        {
            Name = "Preset Time";
            Description = "Set the time.";
            AddShortCut("m");
        }

        public override void Select()
        {
            CurrentMousePosition currentMousePosition = _mousePosition();
            _view.SetColor(Clock.Color);
            _view.ShowDialogAt(currentMousePosition);
            Clock.SetTo(_view.Time);
        }
    }
}