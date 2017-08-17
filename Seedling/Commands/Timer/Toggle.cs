namespace Seedling.Commands.Timer
{
    internal class Toggle : Plugin
    {
        public Toggle()
        {
            Name = "Toggle";
            Description = "Starts or stops the timer.";
            AddShortCut("Space");
            AddShortCut("Enter");
            AddShortCut("Return");
        }

        public override void Select()
        {
            if (Clock.IsRunning) Clock.StopCounter();
            else Clock.StartCounter();
        }
    }
}