using Okra.Commands.Timer;

namespace Okra.Commands.Actions
{
    internal class ClearActions : Plugin
    {
        public ClearActions()
        {
            Name = "Do Nothing";
            Description = "Don't do anything after the timer has elapsed.";
        }

        public override void Select()
        {
            Clock.Done = () => { };
        }
    }
}