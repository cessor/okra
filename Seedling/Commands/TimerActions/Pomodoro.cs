using Seedling.Readability;
using Seedling.Commands.Timer;

namespace Seedling.Commands.TimerActions
{
    internal class Pomodoro : Plugin
    {
        public Pomodoro()
        {
            Name = "Pomodoro";
            Description = "Flips between 25 minute work mode and 5 minute break mode.";
        }

        public override void Select()
        {
            Clock.Done = Break;
            Clock.StartCounter();
        }

        //Todo: Move this to a factory 22.03.2012
        //Todo: Move this to a factory 27.03.2012
        //Todo: Move this to a factory 29.06.2012
        //Todo: Move this to a factory 22.10.2012
        public void Break()
        {
            Clock.Color = 0x00DBFF.Rgb().Brush();
            Clock.SetTo(5.Minutes());
            Clock.Done = Work;
            Clock.StartCounter();
        }

        //Todo: Move this to a factory 22.03.2012
        //Todo: Move this to a factory 27.03.2012
        //Todo: Move this to a factory 29.06.2012
        //Todo: Move this to a factory 22.10.2012
        public void Work()
        {
            Clock.Color = 0x00DB00.Rgb().Brush();
            Clock.SetTo(25.Minutes());
            Clock.Done = Break;
            Clock.StartCounter();
        }
    }
}