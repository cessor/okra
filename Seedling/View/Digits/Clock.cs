using System;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using Seedling.Readability;
using Seedling.Model;
using Seedling.Model.Time;
using Application = System.Windows.Application;

namespace Seedling.View.Digits
{
    public class Clock : ViewModel, IClock
    {
        private readonly IStartAndStop _counter;
        private readonly IHaveGotTheTime _wristwatch;
        private Brush _color;
        private DateTime _end;
        private double _fontSize;

        private bool _isRunning;
        private DateTime _start;
        private TimeSpan _timeLeft;

        public Clock(IStartAndStop iStartAndStop, IHaveGotTheTime wristwatch, TimeSpan time)
        {
            _counter = iStartAndStop;
            _wristwatch = wristwatch;
            _counter.Tick = Tick;
            TimeLeft = time;
        }

        #region IClock Members

        public TimeSpan Duration { get; private set; }

        public TimeSpan TimeLeft
        {
            get { return _timeLeft; }
            private set { Set(() => TimeLeft, ref _timeLeft, value); }
        }

        public double FontSize
        {
            get { return _fontSize; }
            set { Set(() => FontSize, ref _fontSize, value); }
        }

        public Brush Color
        {
            get { return _color; }
            set { Set(() => Color, ref _color, value); }
        }

        public bool IsRunning
        {
            get { return _isRunning; }
            protected set { Set(() => IsRunning, ref _isRunning, value); }
        }

        public Action Done { get; set; }

        public void StartCounter()
        {
            _start = _wristwatch.Now;
            Duration = TimeLeft;
            _end = _start.Add(Duration);

            _counter.Start();
            IsRunning = true;
        }

        public void StopCounter()
        {
            _counter.Stop();
            IsRunning = false;
        }

        public void SetTo(TimeSpan time)
        {
            if (IsRunning)
            {
                ContinueAt(time);
                return;
            }

            TimeLeft = time;
        }

        #endregion

        private void Tick()
        {
            DecreaseTime();
        }

        // TODO: Move this into its own strategy
        // TODO: Never. 22.05.2012
        // [ ... 10 ... ]
        // TODO: Never. 15.12.2013
        // TODO: Never. 02.03.2014
        // TODO: Never. 17.08.2017
        private void DecreaseTime()
        {
            TimeLeft = CalculateTimeleft();
            if (TimeLeft.Ticks < TimeSpan.TicksPerSecond)
            {
                LastTick();
            }
        }

        private void LastTick()
        {
            StopCounter();
            OnDone();
        }

        // TODO: This should be its own datatype so that it can be reused.  - 05.10.2012
        // TODO: This should be its own datatype so that it can be reused.  - 15.12.2012
        // TODO: This should be its own datatype so that it can be reused.  - 23.12.2012
        // TODO: Something something  - 02.03.2014 - FUCK. I'm getting old.
        // TODO: Something something  - 17.08.2017 - Yap, still getting old.
        private TimeSpan CalculateTimeleft()
        {
            return (_end - _wristwatch.Now).ToTheSecond();
        }

        private void OnDone()
        {
            Action handler = Done;
            if (handler == null) return;
            var methodInvoker = new MethodInvoker(handler);
            Application.Current.Dispatcher.Invoke(methodInvoker, DispatcherPriority.Normal);
        }

        private void ContinueAt(TimeSpan time)
        {
            StopCounter();
            TimeLeft = time;
            StartCounter();
        }
    }
}