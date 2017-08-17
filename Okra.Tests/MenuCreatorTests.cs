using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using NUnit.Framework;
using Okra.IoC;
using Separator = Okra.IoC.Separator;

namespace Okra.Tests
{
    [TestFixture]
    public class MenuCreatorTests
    {
     

        [Test]
        public void ShouldTestSomeThing()
        {
            var sections = new List<Tuple<string, List<Item>>>();
            var items = new List<Item>
                {
                    new Command {Name = "Start", Class = "Start", Description = "Start"},
                    new Separator(),
                    new Command {Name = "Stop", Class = "Stop", Description = "Stop"}
                };
            sections.Add(new Tuple<string, List<Item>>("Menu", items));

            //new MenuCreator().Create(sections);

            // Test the shit here.
        }
    }
}