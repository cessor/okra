using System.ComponentModel;
using Seedling.Commands.Timer;

namespace Seedling.Commands.TimerActions
{
    [Description("Resets the timer to its original state after it is done.")]
    internal class RestartTimer : Plugin
    {
        public override void Select()
        {
            Clock.SetTo(Clock.Duration);
            Clock.StartCounter();
        }
    }
}