namespace Okra.Commands.Timer
{
    public class Start : Plugin
    {
        public Start()
        {
            Name = "Start";
            Description = "Starts the time";
        }

        public override void Select()
        {
            Clock.StartCounter();
        }
    }
}