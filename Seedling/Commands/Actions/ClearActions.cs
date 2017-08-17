using Seedling.Commands.Timer;

namespace Seedling.Commands.Actions
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