using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Okra.Readability;
using Should.Fluent;

namespace Okra.Tests
{
    [TestFixture]
    public class DictionaryExtensionTests
    {
        [Test]
        public void IsDictionaryConcatWorkingOnMutableState()
        {
            // Arrange
            var source = new Dictionary<int, string> {{1, "A"}, {2, "B"}};
            var appendix = new Dictionary<int, string> {{3, "C"}, {4, "D"}};

            // Act 
            Dictionary<int, string> result = source.Combine(appendix);

            // Assert
            result.Keys.Count().Should().Equal(4);
        }
    }
}