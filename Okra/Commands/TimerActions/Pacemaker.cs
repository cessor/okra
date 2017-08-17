using System.ComponentModel;
using Okra.Commands.Timer;
using Okra.Readability;

namespace Okra.Commands.TimerActions
{
    public class Pacemaker : Plugin
    {
        public Pacemaker()
        {
            Name = "Pacemaker";
            Description = "A quick timer that synchronizes actions (do something every so and so seconds).";
        }

        public override void Select()
        {
            // TODO: 29.05.2012 - Make this a DSL! A fluent interface should be enough but a DSL parser might be even more awesome! (Because I can)
            // TODO: 03.06.2012 - Make this a DSL! A fluent interface should be enough but a DSL parser might be even more awesome! (Because I can)
            new PlaySound().Done();
            Clock.Color = 0x00FF00.Rgb().Brush();
            Clock.Done = Select;
            Clock.SetTo(30.Seconds());
            Clock.StartCounter();
        }
    }
}