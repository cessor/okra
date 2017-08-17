using NUnit.Framework;
using Seedling.Commands.Synchronize;
using Should.Fluent;

namespace Seedling.Tests.IntegrationTests
{
    [TestFixture]
    public class WebIntegrationTests
    {
        // TODO: Replace this with a local webserver call (when you have built the webserver) - 05.10.2012
        // TODO: Replace this with a local webserver call (when you have built the webserver) - 20.10.2012, DNOS
        // TODO: Replace this with a local webserver call (when you have built the webserver) - JH, 23.12.2012
        // TODO: Replace this with a local webserver call (when you have built the webserver) - JH, 18.08.2017
        [Test, Ignore("Because.")] // This goes to the web
        public void ShouldDownloadATest()
        {
            // Arrange
            string url = "http://cessor.de/test.txt";

            // System under Test
            var web = new Web();

            // Act
            string result = web.Get(url);

            // Assert
            result.Should().Equal("test");
        }
    }
}