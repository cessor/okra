using System;
using System.Timers;

namespace Okra.Model.Time
{
    public class Countdown : IStartAndStop
    {
        private readonly Timer _timer = new Timer(250);

        public Countdown()
        {
            _timer.Elapsed += (s, e) => OnTick();
        }

        #region IStartAndStop Members

        public Action Tick { get; set; }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        #endregion

        public void OnTick()
        {
            Action handler = Tick;
            if (handler == null) return;
            handler();
        }
    }
}