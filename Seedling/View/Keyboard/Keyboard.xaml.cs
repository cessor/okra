using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Seedling.Commands.App;
using Seedling.Commands.Timer;
using Seedling.Commands.TimerActions;
using Seedling.Commands.UI;

namespace Seedling.View.Keyboard
{
    public partial class Keyboard
    {
        public Keyboard(Brush brush)
        {
            InitializeComponent();

            ButtonDesign color = ButtonDesign.FromColor(((SolidColorBrush) brush).Color);
            Highlight(AllShortcuts(), color);
            Escape.Click += (s, e) => Close();
        }

        public void Highlight(List<ShortCut> allShortcuts, ButtonDesign color)
        {
            IEnumerable<IGrouping<Button, ShortCut>> button = allShortcuts.GroupBy(sc => sc.Button);
            foreach (var shortcuts in button)
            {
                string completeDescription = DescribeAll(shortcuts);
                foreach (ShortCut shortcut in shortcuts)
                {
                    color.ApplyTo(shortcut.Button);
                    color.ApplyTo(shortcut.Modifier);
                    MakeShortcutDisplayItsPurpose(shortcut.Button, completeDescription);
                }
            }
        }

        private static string DescribeAll(IEnumerable<ShortCut> shortcuts)
        {
            return string.Join(" | ", shortcuts.Select(s => s.CompleteDescription()));
        }

        private void MakeShortcutDisplayItsPurpose(IInputElement button, string description)
        {
            button.MouseEnter += (s, e) => Message.Text = description;
        }

        private List<ShortCut> AllShortcuts()
        {
            // JH, 16.12.2012 - I Should generate this from the descriptions of the types
            return new KeyMap()
                .Key(Escape, typeof (ExitApplication))
                .Key(LeftAlt, F4, typeof (ExitApplication))
                .Key(LeftControl, X, typeof (ExitApplication))
                .Key(C, typeof (PickColor))
                .Key(T, typeof (PresetTime))
                .Key(K, typeof (ShowKeymap))
                .Key(M, typeof (DisplayMessage))
                .Key(F11, typeof (FullScreen))
                .Key(Space, typeof (Toggle))
                .Key(Return, typeof (Toggle))
                .Key(Return2, typeof (Toggle))
                .Key(Enter, typeof (Toggle))
                .Key(LeftControl, OemPlus, "Zoom in.")
                .Key(LeftControl, OemMinus, "Zoom out.")
                .Key(LeftControl, Add, "Zoom in.")
                .Key(LeftControl, Subtract, "Zoom out.")
                .Key(Home, "Set the timer to 25 Minutes.")
                .Key(End, "Set the timer to 0 Minutes.")
                .Key(LeftMouseButton, "Double click starts the timer. You can also drag it around.")
                .Key(RightMouseButton, "Opens the context menu.")
                .Key(MouseWheelWheel, "Scroll the wheel to set the time.")
                .Key(LeftControl, MouseWheelWheel, "Zoom in.")
                .Key(RightArrow, "Add 1 second.")
                .Key(LeftArrow, "Subtract 1 second.")
                .Key(LeftControl, RightArrow, "Add 10 seconds.")
                .Key(LeftControl, LeftArrow, "Subtract 10 seconds.")
                .Key(UpArrow, "Add 1 minute.")
                .Key(DownArrow, "Subtract 1 minute.")
                .Key(LeftControl, UpArrow, "Add 10 minutes.")
                .Key(LeftControl, DownArrow, "Subtract 10 minutes.")
                .Key(PageUp, "Add 1 hour.")
                .Key(PageDown, "Subtract 1 hour.")
                .Key(LeftControl, PageUp, "Add 10 hours.")
                .Key(LeftControl, PageDown, "Subtract 10 hours.")
                .Key(Oem0, "Type numbers to write out a specific duration, e.g. 1,2,0,0 for 12 minutes.")
                .Key(Oem1, "Type numbers to write out a specific duration, e.g. 1,2,0,0 for 12 minutes.")
                .Key(Oem2, "Type numbers to write out a specific duration, e.g. 1,2,0,0 for 12 minutes.")
                .Key(Oem3, "Type numbers to write out a specific duration, e.g. 1,2,0,0 for 12 minutes.")
                .Key(Oem4, "Type numbers to write out a specific duration, e.g. 1,2,0,0 for 12 minutes.")
                .Key(Oem5, "Type numbers to write out a specific duration, e.g. 1,2,0,0 for 12 minutes.")
                .Key(Oem6, "Type numbers to write out a specific duration, e.g. 1,2,0,0 for 12 minutes.")
                .Key(Oem7, "Type numbers to write out a specific duration, e.g. 1,2,0,0 for 12 minutes.")
                .Key(Oem8, "Type numbers to write out a specific duration, e.g. 1,2,0,0 for 12 minutes.")
                .Key(Oem9, "Type numbers to write out a specific duration, e.g. 1,2,0,0 for 12 minutes.")
                .Shortcuts;
        }
    }
}