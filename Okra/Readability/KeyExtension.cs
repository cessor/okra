using System.Windows.Input;

namespace Okra.Readability
{
    internal static class KeyExtension
    {
        public static bool IsDigit(this Key key)
        {
            return (key >= Key.D0 && key <= Key.D9) // 34 <= x <= 43
                   || (key >= Key.NumPad0 && key <= Key.NumPad9); // 74 <= x <= 84
        }

        public static byte Digit(this Key key)
        {
            var digit = (byte) (key - 34);
            if (digit > 9)
                return (byte) (digit - 40);
            return digit;
        }
    }
}