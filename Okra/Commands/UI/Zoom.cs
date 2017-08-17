using Okra.Commands.Timer;

namespace Okra.Commands.UI
{
    // TODO: Maybe also a gesture for the Mousewheel? 
    // TODO: 01.10.2013 Maybe also a gesture for the Mousewheel? 
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