using DateApi;
using NSubstitute;
using NUnit.Framework;
using Okra.Commands.Synchronize;
using Should.Fluent;

namespace Okra.Tests.Actions
{
    [TestFixture]
    public class TestWhatACertainTypeShouldDoawd
    {
        // TODO: Is this test obsolte? 05.10.2012
        [Test]
        public void AlterSoHarteGangsterIntegrationsTestsAlter()
        {
            // Arrange
            const string url = "http://localhost:1000";
            const string json = "";

            var timeDto = new SyncTime {Running = true, Duration = 0.Seconds()};

            var web = Substitute.For<IGet>();
            web.Get(url).Returns(json);

            var convert = Substitute.For<IConvertToSyncTime>();
            convert.FromJson(json).Returns(timeDto);

            // System under Test
            var load = new TimeLoader(web, convert);

            // Act
            SyncTime mrm = load.From(url);

            // Assert
            mrm.Should().Not.Be.Null();

            mrm.Should().Be.OfType<SyncTime>();
            mrm.Duration.Should().Equal(0.Seconds());
            mrm.Running.Should().Equal(true);
        }
    }
}