using System;
using System.Windows.Controls;

namespace Okra.View.Keyboard
{
    public struct ShortCut
    {
        public Button Button { get; set; }
        public Button Modifier { get; set; }
        public String Description { get; set; }

        public string CompleteDescription()
        {
            return string.Format("{0} {1} : {2}", NameOf(Modifier), NameOf(Button), Description);
        }

        private static string NameOf(ContentControl button)
        {
            return (button.Tag ?? button.Content ?? button.Name).ToString();
        }
    }
}