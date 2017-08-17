using NUnit.Framework;
using Okra.Commands.App;
using Should.Fluent;

namespace Okra.Tests.Commands
{
    [TestFixture]
    public class ExitApplicationTests
    {
        [Test]
        public void WorksAsAPlugin()
        {
            var exit = new ExitApplication();
            exit.Description.Should().Not.Be.NullOrEmpty();
            exit.Name.Should().Not.Be.NullOrEmpty();
            exit.ShortCuts.Should().Not.Be.Empty();
        }
    }
}