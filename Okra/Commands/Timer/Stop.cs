namespace Okra.Commands.Timer
{
    internal class Stop : Plugin
    {
        public Stop()
        {
            Name = "Stop";
            Description = "Stops the timer.";
        }

        public override void Select()
        {
            Clock.StopCounter();
        }
    }
}