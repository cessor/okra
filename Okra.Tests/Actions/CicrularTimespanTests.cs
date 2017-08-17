using System;
using DateApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okra.Model;

namespace Okra.Tests.Actions
{
    [TestClass]
    public class CicrularTimespanTests
    {
        [TestMethod]
        public void ShouldDoASetOfOperations()
        {
            // Arange, Act, Assert
            TimeSpan time = new CircularTimeSpan().Add(1).Add(3).Add(0).ToTimeSpan();

            Assert.AreEqual(time, 1.Minute().And(30.Seconds()));
        }
    }
}