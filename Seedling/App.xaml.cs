using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Seedling.Commands.Timer;
using Seedling.Model;
using Seedling.View.Digits;
using Menu = Seedling.View.Digits.Menu;

namespace Seedling
{
    public partial class App
    {
        [Export(typeof (IClock))] private IClock _clock;

        [ImportMany] // ReSharper disable once FieldCanBeMadeReadOnly.Local - Don't make this readonly or MEF will implode.
        private IEnumerable<IPlugIn> _plugin = new List<IPlugIn>();

        public App()
        {
            _clock = GiveMeAClock.ForTheCurrentConfig();
            
            LoadPlugins();
            
            IEnumerable<MenuItem> items = _plugin.Select(p => p.MenuItem);
            var mainMenu = new View.Digits.Menu();
            foreach (MenuItem menuItem in items)
            {
                mainMenu.Items.Add(menuItem);
            }

            IEnumerable<KeyBinding> shortcuts = _plugin.SelectMany(p => p.ShortCuts);

            // Display 00:00:00 Clock
            var display = new Display(_clock, shortcuts);
            display.Time.ContextMenu = mainMenu;
            display.Show();
        }

        private void LoadPlugins()
        {
            var catalog = new AggregateCatalog();
            var assemblyCatalog = new AssemblyCatalog(GetType().Assembly);

            catalog.Catalogs.Add(assemblyCatalog);

            //// Loads Plugins from file System
            // catalog.Catalogs.Add(new DirectoryCatalog(Environment.CurrentDirectory));
            new CompositionContainer(catalog).ComposeParts(this);
        }
    }
}