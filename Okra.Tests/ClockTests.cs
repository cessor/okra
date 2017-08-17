using System;
using DateApi;
using NSubstitute;
using NUnit.Framework;
using Seedling.Commands.Timer;
using Seedling.Model.Time;
using Seedling.View.Digits;
using Should.Fluent;

namespace Seedling.Tests
{
    [TestFixture]
    public class ClockTests
    {
        [Test]
        public void ShouldBehavior()
        {
            var start = Substitute.For<IStartAndStop>();
            var stop = Substitute.For<IHaveGotTheTime>();
            var weasel = new Clock(start, stop, 0.Seconds());

            bool iWasCalled = false;
            weasel.PropertyChanged += (sender, args) => iWasCalled = args.PropertyName == "FontSize";

            weasel.FontSize = 100f;
            iWasCalled.Should().Be.True();
        }

        [Test]
        public void ShouldSetTheTime()
        {
            // Arrange
            var startAndStop = Substitute.For<IStartAndStop>();
            var watch = Substitute.For<IHaveGotTheTime>();
            TimeSpan timeSpan = 0.Seconds();

            // System under Test
            var clock = new Clock(startAndStop, watch, timeSpan);

            clock.TimeLeft.Should().Equal(0.Seconds());

            // Act
            clock.SetTo(5.Seconds());

            // Assert
            clock.TimeLeft.Should().Equal(5.Seconds());
        }

        public class TestableClock : Clock
        {
            public TestableClock(IStartAndStop iStartAndStop, IHaveGotTheTime wristwatch, TimeSpan time) : base(iStartAndStop, wristwatch, time)
            {}

            public new bool IsRunning {
                get { return base.IsRunning; }
                set { base.IsRunning = value; }
            }
        }

        [Test]
        public void ShouldStartTheClock()
        {
            var startAndStop = Substitute.For<IStartAndStop>();
            var time = Substitute.For<IHaveGotTheTime>();
            var initialValue = 0.Seconds();
            var clock = new Clock(startAndStop, time, initialValue);

            clock.StartCounter();

            startAndStop.Received().Start();
            clock.IsRunning.Should().Be.True();
        }

        [Test]
        public void ShouldStopTheClock()
        {
            var startAndStop = Substitute.For<IStartAndStop>();
            var time = Substitute.For<IHaveGotTheTime>();
            var initialValue = 0.Seconds();
            var clock = new Clock(startAndStop, time, initialValue);

            clock.StopCounter();

            startAndStop.Received().Stop();
            clock.IsRunning.Should().Be.False();
        }



        [Test]
        public void ShouldUpdateTheDurationWhenTheTimeIsSetWhileRunning()
        {
            var startAndStop = Substitute.For<IStartAndStop>();
            var time = Substitute.For<IHaveGotTheTime>();
            var initialValue = 0.Seconds();
            var clock = new TestableClock(startAndStop, time, initialValue);
            
            clock.IsRunning = true;
            
            clock.SetTo(10.Minutes());

            startAndStop.Received().Stop();
            clock.Duration.Should().Equal(10.Minutes());
            clock.TimeLeft.Should().Equal(10.Minutes());
            startAndStop.Received().Start();
        }
    }
}