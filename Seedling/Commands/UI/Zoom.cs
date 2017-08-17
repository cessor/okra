using Seedling.Commands.Timer;

namespace Seedling.Commands.UI
{
    // TODO: Maybe also a gesture for the Mousewheel? 
    // TODO: 01.10.2013 Maybe also a gesture for the Mousewheel? 
    // TODO: 17.08.2017 Maybe also a gesture for the Mousewheel? 
    internal class Zoom : Plugin
    {
        public Zoom()
        {
            Description = "Zoom in or out.";
        }

        public override void Select()
        {
            Clock.FontSize += 1;
        }
    }
}