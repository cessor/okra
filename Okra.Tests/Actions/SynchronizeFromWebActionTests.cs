using System;
using DateApi;
using NSubstitute;
using NUnit.Framework;
using Okra.Commands.Synchronize;
using Okra.View.Digits;

namespace Okra.Tests.Actions
{
    [TestFixture, Ignore("I never built this")]
    public class SynchronizeFromWebActionTests
    {
        [Test]
        public void ShouldSynchronizeAndStartTheCounter()
        {
            // Arrange
            var timeDto = new SyncTime {Running = true, Duration = 10.Seconds()};

            var urlProvider = Substitute.For<IAskForAUrl>();
            var viewmodel = Substitute.For<IClock>();
            var load = Substitute.For<IGetSyncTimeFromAUrl>();

            load.From(Arg.Any<string>()).Returns(timeDto);

            // System under Test
            var sync = new SynchronizeFromWeb();

            // Act
            sync.Select();

            // Assert
            viewmodel.Received().StartCounter();
            viewmodel.DidNotReceive().StopCounter();
            viewmodel.Received().SetTo(10.Seconds());
        }

        [Test]
        public void ShouldSynchronizeAndStopTheCounter()
        {
            // Arrange
            var timeDto = new SyncTime {Running = false, Duration = 5.Seconds()};

            var urlProvider = Substitute.For<IAskForAUrl>();
            var viewmodel = Substitute.For<IClock>();
            var load = Substitute.For<IGetSyncTimeFromAUrl>();

            load.From(Arg.Any<string>()).Returns(timeDto);

            // System under Test
            var sync = new SynchronizeFromWeb();

            // Act
            sync.Select();

            // Assert
            viewmodel.Received().StopCounter();
            viewmodel.DidNotReceive().StartCounter();
            viewmodel.Received().SetTo(5.Seconds());
        }

        [Test]
        public void machmawasanners()
        {
            // Arrange
            var timeDto = new SyncTime
                {
                    Running = false,
                    Duration = 10.Minutes(),
                    Start = DateTime.Today.At(11.Hours()),
                    Now = DateTime.Today.At(11.Hours().And(5.Minutes())),
                };

            var urlProvider = Substitute.For<IAskForAUrl>();
            var viewmodel = Substitute.For<IClock>();
            var load = Substitute.For<IGetSyncTimeFromAUrl>();

            load.From(Arg.Any<string>()).Returns(timeDto);

            // System under Test
            var sync = new SynchronizeFromWeb();

            // Act
            sync.Select();

            // Assert
            viewmodel.Received().StopCounter();
            viewmodel.DidNotReceive().StartCounter();
            viewmodel.Received().SetTo(5.Minutes());
        }
    }
}