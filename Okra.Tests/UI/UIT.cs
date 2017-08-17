using System;
using System.Linq;
using NUnit.Framework;
using Should.Fluent;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WPFUIItems;
using TestStack.White.WindowsAPI;
using Application = TestStack.White.Application;

namespace Seedling.Tests.UI
{
    [TestFixture, Ignore("These Test are very brittle. They work, but not must be left alone to run")]
    public class UIT
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            var exe = @"F:\Users\Johannes\Desktop\Asse\Solutions\Okra\Build\Okra.exe";
            _application = TestStack.White.Application.Launch(exe);
        }

        private Application _application;

        // Further help> http://blogs.msdn.com/b/john_daddamio/archive/2008/04/04/testing-wpf-applications-with-the-white-ui-test-framework.aspx
        // https://github.com/TestStack/White
        [Test]
        public void HappyPath_ShouldFireUp_EnterAMessage_RunForASecond_DisplayTheMessage()
        {
            _application.Should().Not.Be.Null();
            _application.WaitWhileBusy();
            var window = _application.GetWindows().First();
            window.Should().Not.Be.Null();
            
            var label= window.Get<Label>(SearchCriteria.Indexed(0));

            label.Text.Should().Equal("00:00:01");
            label.RightClick();
            window.WaitWhileBusy();
            window.HasPopup().Should().Be.True();

            window.Popup.Get<Menu>(SearchCriteria.ByText("Display message")).Click();
            var messageWindow = _application.GetWindow("Enter a new Message!");
            messageWindow.Should().Not.Be.Null();

            var messageLabel = messageWindow.Get<Label>();
            messageLabel.Text.Should().Equal("Anything in particular?");
            var textbox =messageWindow.Get<TextBox>();
            
            textbox.Should().Not.Be.Null();
            textbox.Text = "Message";
            
            messageWindow.KeyIn(KeyboardInput.SpecialKeys.RETURN);

            label.Text.Should().Equal("00:00:01");
            window.KeyIn(KeyboardInput.SpecialKeys.SPACE);

            var messageBox = window.MessageBox("Tick!");
            messageBox.Get<Label>(SearchCriteria.Indexed(0)).Text.Should().Equal("Message");
            messageBox.Get<Button>(SearchCriteria.Indexed(0)).Click();

            window.WaitTill(() => messageBox.IsClosed, TimeSpan.FromSeconds(1));
        }

        [Test]
        public void ShouldTestSettingTheClock()
        {
            _application.Should().Not.Be.Null();
            _application.WaitWhileBusy();
            var window = _application.GetWindows().First();
            window.Should().Not.Be.Null();

            var label = window.Get<Label>(SearchCriteria.Indexed(0));
            label.Text.Should().Equal("00:00:01");
            label.Focus();
            window.Keyboard.Enter("100");

            label = window.Get<Label>(SearchCriteria.Indexed(0));
            label.Text.Should().Equal("00:01:00");

            // JS 02.03.2013 - Should be able to scroll to set the clock.
            // Scroll Magic Here. Unfortunately the TestStack.White mouse does not support scrolling.
            // I started looking into implementing this feature myself but I can't be bothered to finish it. Windows api and shit. Mouse Delta an so on. 


        }

        [Test]
        public void PressingTheHomeKeySetsTheTimeTo25Minutes()
        {
            _application.Should().Not.Be.Null();
            _application.WaitWhileBusy();
            var window = _application.GetWindows().First();
            window.Get<Label>(SearchCriteria.Indexed(0)).Text.Should().Equal("00:00:01");
            window.KeyIn(KeyboardInput.SpecialKeys.HOME);
            window.Get<Label>(SearchCriteria.Indexed(0)).Text.Should().Equal("00:25:00");
        }

        [Test, Ignore("Because.")]
        public void TestExit()
        {
            _application.Should().Not.Be.Null();
            _application.WaitWhileBusy();
            var window = _application.GetWindows().First();
            window.Mouse.RightClick();
            var exitButton = window.Popup.Get<Menu>(SearchCriteria.ByText("Exit"));
            exitButton.Click();            
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            if (!_application.HasExited)
            {
                _application.Close();
            }
            _application.Kill();
        }
    }
}