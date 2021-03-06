﻿using System;
using NUnit.Framework;
using Okra.Model.Time;
using Should.Fluent;

namespace Okra.Tests
{
    [TestFixture]
    public class WristwatchTests
    {
        [Test]
        public void ShouldGiveMeTime()
        {
            var watch = new Wristwatch();
            // Don't run this test at 12 O'Clock at night. ;) - JH. 02.03.2014
            watch.Now.Day.Should().Equal(DateTime.Now.Day);
        }
    }
}