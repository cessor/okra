using System;
using System.Threading;
using System.Windows.Media;
using NSubstitute;
using NUnit.Framework;
using Okra.Commands.UI;
using Okra.Readability;
using Okra.View.ColorPicker;
using Okra.View.Digits;
using Okra.View.Input;
using Okra.View.TimePicker;
using Should.Fluent;

namespace Okra.Tests.Commands
{
    [TestFixture, Apartment(ApartmentState.STA)]
    public class PresetTimeTests
    {
        [Test]
        public void ShouldPresetTheTime()
        {
            var command = new PresetTime();
            command.Name.Should().Not.Be.NullOrEmpty();
            command.Description.Should().Not.Be.NullOrEmpty();
            command.ShortCuts.Should().Not.Be.Empty();
        }

        [Test]
        public void CommandShouldSetTheClockAfterPickingAValue()
        {
            // Dependent-On Components
            var view = Substitute.For<ITimePicker>();

            // Indirect Inputs
            var time = TimeSpan.FromSeconds(60);
            var cursor = new CurrentMousePosition(0, 0);
            view.Time.Returns(time);

            // Indirect Outputs
            var clock = Substitute.For<IClock>();

            // System under Test
            var command = new PresetTime(view, ()=>cursor, clock);

            // Act
            command.Select();

            // Assert
            view.Received().ShowDialogAt(cursor);
            clock.Received().SetTo(time);
        }

        [Test]
        public void TheTimePickerShouldHaveTheColorOfTheViewmodel()
        {
            Func<CurrentMousePosition> mousePosition = () => new CurrentMousePosition();
            var viewmodel = Substitute.For<IClock>();
            var color = Brushes.Lime;
            viewmodel.Color = color;

            var view = Substitute.For<ITimePicker>();
            
            // System under Test
            var command = new PresetTime(view, mousePosition, viewmodel);
            
            // Act
            command.Select();
            view.Received().SetColor(color);
        }
    }
}