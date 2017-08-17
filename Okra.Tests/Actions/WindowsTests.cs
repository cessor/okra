using NSubstitute;
using NUnit.Framework;
using Okra.Commands.Power;
using Okra.Commands.Power.Win32Api;

namespace Okra.Tests.Actions
{
    [TestFixture]
    public class WindowsTests
    {
        private IWindowsFunctions _functions;

        [TestFixtureSetUp]
        public void BeforeEachTest()
        {
            _functions = Substitute.For<IWindowsFunctions>();
        }

        [Test]
        public void ShouldHibernate()
        {
            new Hibernate(_functions).Execute(null);

            _functions
                .Received()
                .Suspend(Arg.Is(true), Arg.Is(false), Arg.Any<bool>());
        }


        [Test]
        public void ShouldLockWorkStation()
        {
            
            new Lock(_functions).Execute(null);

            _functions.Received().LockComputer();
        }


        [Test]
        public void ShouldLogOff()
        {
            new LogOff(_functions).Execute(null);

            const uint flags = (uint) (ExitWindowsFlags.LogOff | ExitWindowsFlags.Force);
            _functions.Received().ExitWindows(Arg.Is(flags), Arg.Any<uint>());
        }


        [Test]
        public void ShouldRestart()
        {
            new Restart(_functions).Execute(null);

            const uint flags = (uint) (ExitWindowsFlags.Reboot | ExitWindowsFlags.Force);
            _functions.Received().ExitWindows(Arg.Is(flags), Arg.Any<uint>());
        }

        [Test]
        public void ShouldShutdown()
        {
            new Shutdown(_functions).Execute(null);

            const uint flags = (uint) (ExitWindowsFlags.ShutDown | ExitWindowsFlags.Force);
            _functions.Received().ExitWindows(Arg.Is(flags), Arg.Any<uint>());
        }

        [Test]
        public void ShouldSleep()
        {
            new Sleep(_functions).Execute(null);

            _functions.Received().Suspend(Arg.Is(false), Arg.Is(false), Arg.Any<bool>());
        }
    }
}