using NUnit.Framework;
using Okra.Model;
using Should.Fluent;

namespace Okra.Tests
{
    [TestFixture]
    public class ViewModelBaseTest
    {
        private class SpecificViewModel : ViewModel
        {
            private string _property;

            public string Property
            {
                get { return _property; }
                set { Set(() => Property, ref _property, value); }
            }
        }

        [Test]
        public void ShouldNotNotifyWhenITryToUpdateWithSameValue()
        {
            bool fired = false;

            // System under Test
            var model = new SpecificViewModel {Property = "InitialValue"};

            model.PropertyChanged += (s, e) => fired = (e.PropertyName == "Property");

            // Act
            model.Property = "InitialValue";

            // Assert
            fired.Should().Be.False();
        }

        [Test]
        public void ShouldNotifyThatTheValueHasChanged()
        {
            // Arrange
            bool fired = false;

            // System under Test
            var model = new SpecificViewModel();
            model.PropertyChanged += (s, e) => fired = (e.PropertyName == "Property");

            // Act
            model.Property = "UpdatedValue";

            // Assert
            model.Property.Should().Equal("UpdatedValue");
            fired.Should().Be.True();
        }
    }
}