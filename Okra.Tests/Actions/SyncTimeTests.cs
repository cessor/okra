using System;
using DateApi;
using NUnit.Framework;
using Seedling.Commands.Synchronize;
using Should.Fluent;

namespace Seedling.Tests.Actions
{
    [TestFixture]
    public class SyncTimeTests
    {
        [Test]
        public void ShouldConvertAStringToATimeDtoWeasel()
        {
            // Arrange
            string json = @"{ 
                ""Duration"" : ""00:00:05"", 
                ""Start"" : ""19:20:00"", 
                ""Now"" : ""19:24:00"",
                ""Running"" : ""True"" 
            }";

            // System under Test
            var synctime = new SyncTime();

            // Act
            SyncTime s = synctime.FromJson(json);

            // Assert
            s.Duration.Should().Equal(5.Seconds());
            s.Start.Should().Equal(DateTime.Today.At(7.PM().And(20.Minutes())));
            s.Now.Should().Equal(DateTime.Today.At(7.PM().And(24.Minutes())));
            s.Running.Should().Equal(true);
        }

        [Test]
        public void Shouldjo()
        {
            // Arrange SUT
            var time = new SyncTime
                {
                    Duration = 25.Minutes(),
                    Start = DateTime.Today.At(7.PM().And(20.Minutes())),
                    Now = DateTime.Today.At(7.PM().And(24.Minutes()))
                };

            // Act
            TimeSpan timeLeft = time.TimeLeft;

            // Assert
            timeLeft.Should().Equal(21.Minutes());
        }
    }
}