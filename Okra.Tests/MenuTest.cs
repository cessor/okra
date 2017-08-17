using System.Linq;
using NUnit.Framework;
using Should.Fluent;

namespace Okra.Tests
{
    [TestFixture]
    public class MenuTest
    {
        private readonly MenuDslParser _menuDslParser = new MenuDslParser();

   
        [Test]
        public void ShouldParseTwoSections()
        {
            var dsl = @"[Menu]
Start, Start, Starts the Timer.
[Other]
Stop, Stop, Stops the Timer.";

            var sections = _menuDslParser.Parse(dsl);

            sections.Count.Should().Equal(2);
            sections.First().Item1.Should().Equal("Menu");
            sections.First().Item2.Count.Should().Equal(1);
            sections.Last().Item1.Should().Equal("Other");
            sections.Last().Item2.Count.Should().Equal(1);
        }

        [Test]
        public void ShouldParseASeparator()
        {
            var dsl = @"[Menu]
Start, Start, Starts the Timer.
-
Stop, Stop, Stops the Timer.
# Comment";

            var sections = _menuDslParser.Parse(dsl);

            sections.Count.Should().Equal(1);
            sections.First().Item1.Should().Equal("Menu");
            sections.First().Item2.Count.Should().Equal(3);
        }
    }
}