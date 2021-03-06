﻿using System;
using System.Globalization;
using Okra.Commands.Timer;
using Okra.Readability;

namespace Okra.Commands.UI
{
    internal class SetTime : Plugin
    {
        public SetTime()
        {
            Name = "SetTime";
            Description = "For how long should the timer be running?";
            AddShortCut("Home", 25.Minutes());
            AddShortCut("End", 0.Seconds());
        }

        public override void Select(object parameter)
        {
            TimeSpan time = TimeSpan.Parse(parameter.ToString(), CultureInfo.InvariantCulture);
            Clock.SetTo(time);
        }
    }
}