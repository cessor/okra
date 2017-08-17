using System;
using DateApi;
using NUnit.Framework;
using Okra.Commands.Synchronize;
using Okra.Model.Time;
using Okra.View.Digits;
using Should.Fluent;

namespace Okra.Tests.IntegrationTests
{
    [TestFixture]
    [Ignore("Requires Internet Connection.")]
    public class SynchronizationIntegrationTests
    {
        [Test]
        public void ShouldKrasserIntegrationsTest()
        {
            // sut
            IClock model = new Clock(new Countdown(), new Wristwatch(), TimeSpan.FromSeconds(0));
            IGetSyncTimeFromAUrl getstuff = new TimeLoader(new Web(), new SyncTime());
            IAskForAUrl urlProvider = new UrlProvider();
            var x = new SynchronizeFromWeb();
            x.Select();
            model.TimeLeft.Should().Equal(10.Minutes());
            model.IsRunning.Should().Be.True();
        }
    }
}