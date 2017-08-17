using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;
using Okra.Commands.Timer;

namespace Okra.Commands.TimerActions
{
    internal class PlaySound : Plugin
    {
        public PlaySound()
        {
            Name = "Play a sound";
            Description = "Plays a sound to notify you that the timer has elapsed.";
        }

        public override void Select()
        {
            Clock.Done = Done;
        }

        public void Done()
        {
            try
            {
                Stream file = Assembly.GetExecutingAssembly().GetManifestResourceStream("Okra.Media.ting.wav");
                new SoundPlayer(file).Play();
            }
            catch (Exception)
            {
                MessageBox.Show("The timer has elapsed!");
            }
        }
    }
}