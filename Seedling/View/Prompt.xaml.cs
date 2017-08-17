using System.Windows.Input;

namespace Seedling.View
{
    public partial class Prompt
    {
        private string _message = string.Empty;

        public Prompt(string caption, string defaultMessage)
        {
            Caption = caption;
            DefaultMessage = defaultMessage;

            InitializeComponent();

            DataContext = this;
            MessageTextBox.Focus();
        }

        public string Caption { get; private set; }
        public string DefaultMessage { get; private set; }

        public string Message
        {
            get
            {
                return
                    string.IsNullOrWhiteSpace(_message)
                        ? DefaultMessage
                        : _message;
            }

            private set { _message = value; }
        }

        private new void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                DialogResult = false;
                return;
            }

            if (e.Key != Key.Enter && e.Key != Key.Return) return;
            Message = MessageTextBox.Text;
            DialogResult = true;
        }
    }
}