using NSubstitute;
using NUnit.Framework;
using Okra.Commands;
using Okra.View.Clock;

namespace Okra.Tests.Actions
{
    [TestFixture]
    public class AdhsTests
    {
        [Test]
        public void ShouldQuicklySetStuff()
        {
            var t = Substitute.For<IClock>();
            var adhs = new Adhs(t);

            adhs.Execute(null);

            //t.Received(x => x.SetTo(10.Minutes()));
        }
    }

    public class Adhs : ViewCommand
    {
        internal Adhs(IClock clock) : base(clock)
        {
        }
    }
}