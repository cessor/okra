using System.Threading;
using System.Windows.Media;
using NSubstitute;
using NUnit.Framework;
using Seedling.Readability;
using Seedling.Commands.UI;
using Seedling.View.ColorPicker;
using Seedling.View.Digits;
using Seedling.View.Input;
using Should.Fluent;
using Should.Fluent.Model;

namespace Seedling.Tests.Commands
{
    [TestFixture, Apartment(ApartmentState.STA)]
    public class PickColorTests
    {
        [Test]
        public void ShouldPickAColor()
        {
            var command = new PickColor();
            command.Name.Should().Not.Be.NullOrEmpty();
            command.Description.Should().Not.Be.NullOrEmpty();
            command.ShortCuts.Should().Not.Be.Empty();
        }

        [Test]
        public void SelectingThePickColorCommandMakesTheColorPickerAppear()
        {
            var cursor = new CurrentMousePosition(0,0);
            var picker = Substitute.For<IColorPicker>();
            var viewmodel = Substitute.For<IClock>();           
            var command = new PickColor(picker, () => cursor, viewmodel);
            command.Select();
            picker.Received().ShowDialogAt(cursor);
        }

        [Test]
        public void SelectingAColorPaintsTheColorOfTheViewModel()
        {
            var cursor = new CurrentMousePosition(0, 0);
            var picker = Substitute.For<IColorPicker>();
            var viewmodel = Substitute.For<IClock>();
            var command = new PickColor(picker, () => cursor, viewmodel);
            picker.Color.Returns(Brushes.Magenta);
            command.Select();
            viewmodel.Color.Should().Equal(Brushes.Magenta);
        }
    }
}