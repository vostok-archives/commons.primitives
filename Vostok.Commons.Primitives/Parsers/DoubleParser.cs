using System;
using System.Globalization;

namespace Vostok.Commons.Primitives.Parsers
{
    public static class DoubleParser
    {
        public static bool TryParse(string input, out double res)
        {
            input = StringMethods.PrepareForFloatNumbers(input);
            return double.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out res);
        }

        public static double Parse(string input)
        {
            if (TryParse(input, out var res))
                return res;
            throw new FormatException($"{nameof(DoubleParser)}. Error in parsing string {input} to Double.");
        }
    }
}