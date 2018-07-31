using System.Globalization;

namespace Vostok.Commons.Primitives.Parsers
{
    public static class StringMethods
    {
        public static string PrepareForFloatNumbers(string input)
        {
            var sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            return input.Replace(',', sep).Replace('.', sep).Replace('\'', sep).Replace(" ", "");
        }

        public static string PrepareForTimeSpan(string input) =>
            input.ToLower().Replace(',', '.');
    }
}