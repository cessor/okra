using System.Windows.Media;
using Okra.View;

namespace Okra.Commands.Synchronize
{
    public class Ask : IAskForAUrl
    {
        private readonly Brush _color;

        public Ask(Brush color)
        {
            _color = color;
        }

        public string AskForUrl()
        {
            var askForUrl = new AskForAUrl {Foreground = _color};
            if (askForUrl.ShowDialog() ?? false)
            {
                return askForUrl.Message;
            }
            return string.Empty;
        }
    }
}