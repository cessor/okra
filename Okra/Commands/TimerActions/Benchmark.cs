using System;
using System.Windows.Forms;
using Okra.Commands.Timer;
using Okra.Readability;

namespace Okra.Commands.TimerActions
{
    internal class Benchmark : Plugin
    {
        private TimeSpan _expectedDuration;
        private DateTime _start;

        public Benchmark()
        {
            Name = "Benchmark";
            Description = "Runs a benchmark to see whether your timer is running on time.";
        }

        public override void Select()
        {
            MessageBox.Show("Starting Benchmark!");
            _start = DateTime.Now;
            _expectedDuration = Clock.TimeLeft;
            Clock.Done = Done;
            Clock.StartCounter();
        }

        public void Done()
        {
            DateTime end = DateTime.Now;
            TimeSpan actualDuration = end - _start;
            TimeSpan difference = _expectedDuration - actualDuration;

            MessageBoxIcon icon = (difference.Duration() < 1.Second())
                ? MessageBoxIcon.Information
                : MessageBoxIcon.Error;

            string message =
                string.Format(
                    "The calculated time that passed is {0}.\nThe timer was running for {1}.\nTherefore the timer is off by {2}.\n\nStarted:\t{3}\nEnded:\t{4}",
                    actualDuration, _expectedDuration, difference, _start, end);
            MessageBox.Show(message, "Benchmark finished", MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
        }
    }
}