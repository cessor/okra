using System.ComponentModel;
using Seedling.Commands.Timer;

namespace Seedling.Commands.Synchronize
{
    [Description("Synchronize from Web")]
    public class SynchronizeFromWeb : Plugin
    {
        public override void Select()
        {
            var ask = new Ask(Clock.Color);
            string url = ask.AskForUrl();

            // TODO: blocklock the cock here (if null or localhorst) - 05.10.2012

            // TODO: Check for timeouts and 404s here - 05.10.2012
            SyncTime timeDto = new TimeLoader(new Web(), new SyncTime()).From(url);

            Clock.SetTo(timeDto.TimeLeft);

            if (timeDto.Running)
            {
                Clock.StartCounter();
            }
            else
            {
                Clock.StopCounter();
            }
        }
    }

    // TODO: Check for default and also make this shit obsolete by making the dialogs implement the interface directly - 05.10.2012
}